using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class DialogueTrigger : MonoBehaviour
    {
        [Header("Visual Cue")]
        [SerializeField]
        private GameObject visualCue;

        [Header("Ink JSON")]
        [SerializeField]
        private TextAsset inkJSON;

        public bool hasSound;

        private bool playerInRange;

        [Header("Animator")]
        public Animator animator;

        [Header("Sound clip")]
        public AudioClip kiwisound;

        private void Awake()
        {
            playerInRange = false;
            visualCue.SetActive(false);
            // hasSound = false;
        }

        private void Update()
        {
            if (
                playerInRange &&
                !DialogueManager.GetInstance().dialogueIsPlaying
            )
            {
                visualCue.SetActive(true);
                if (Input.GetButtonDown("Interact") && hasSound)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                    animator.SetBool("isTalking",!DialogueManager.GetInstance().dialogueIsPlaying);
                    AudioSource.PlayClipAtPoint(kiwisound, this.transform.position,20f);
                }
            }
            else
            {
                visualCue.SetActive(false);
                animator.SetBool("isTalking",DialogueManager.GetInstance().dialogueIsPlaying);
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                playerInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                playerInRange = false;
            }
        }
    }
}
