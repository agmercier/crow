using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        //List of unlockable mechanics here:
        public bool jumpUnlocked = false;
        public bool moveUnlocked = true;
        public bool waterUnlocked = false;
        public bool glideUnlocked = false;

        public float floatingReset = 0f;

        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        private float permaGravity;
        public float floatingGravityModifier = 0.1f;
        public bool gliding = false;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/ public Collider2D collider2d;
        /*internal new*/ public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            permaGravity = this.gravityModifier;
        }

        protected override void Update()
        {
            if (controlEnabled && !DialogueManager.GetInstance().dialogueIsPlaying)
            {
                //can only move if movement is unlocked(moveUnlocked == true)
                if (moveUnlocked)
                {
                    move.x = Input.GetAxisRaw("Horizontal");
                }
                
                //jump mechanic only works if jump unlocked (jumpUnlocked == true)
                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump") && jumpUnlocked)
                {
                    jumpState = JumpState.PrepareToJump;
                    //this.GetComponent<PlayerController>().gravityModifier = floatingGravityModifier;
                    if(glideUnlocked)
                    {
                        gliding = true;
                    }
                }
                else if (Input.GetButtonUp("Jump") && jumpUnlocked)
                {
                    stopJump = true;
                    Schedule<PlayerStopJump>().player = this;
                    //this.GetComponent<PlayerController>().gravityModifier = permaGravity;
                    if(glideUnlocked)
                    {
                        gliding = false;
                    }
                }


                if (Input.GetButtonDown("Jump") && glideUnlocked)
                {
                    this.GetComponent<PlayerController>().velocity.y = floatingReset;
                    this.GetComponent<PlayerController>().gravityModifier = floatingGravityModifier;
                    gliding = true;

                }
                else if (Input.GetButtonUp("Jump") && glideUnlocked)
                {
                    this.GetComponent<PlayerController>().gravityModifier = permaGravity;
                    gliding = false;
                }

            }
            else
            {
                move.x = 0;
            }
            UpdateJumpState();
            base.Update();
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
            animator.SetBool("InFlight",gliding);

            targetVelocity = move * maxSpeed;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}