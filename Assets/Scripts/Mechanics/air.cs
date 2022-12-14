using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class air : MonoBehaviour
    {
        public float verticalVelocity;

        public GameObject parent;

        public AudioClip bounce;

        void OnTriggerStay2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                var rb = other.attachedRigidbody;
                if (rb == null) return;
                var player = rb.GetComponent<PlayerController>();
                if (player == null) return;
                // AudioSource.PlayClipAtPoint(bounce, this.transform.position, 20f);
                AddVelocity(player);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
            AudioSource.PlayClipAtPoint(bounce,this.transform.position,20f);
            }
        }

        void AddVelocity(PlayerController player)
        {
            player.velocity.y = verticalVelocity;
            //player.velocity.x = /*parent.transform.forward **/ verticalVelocity;
            //player.Bounce(parent.transform.forward * verticalVelocity);
        }
    }
}