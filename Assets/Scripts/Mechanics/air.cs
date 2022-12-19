using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class air : MonoBehaviour
    {
        public float verticalVelocity;

        public AudioClip bounce;

        void OnTriggerStay2D(Collider2D other)
        {
            var rb = other.attachedRigidbody;
            if (rb == null) return;
            var player = rb.GetComponent<PlayerController>();
            if (player == null) return;
            AudioSource.PlayClipAtPoint(bounce, this.transform.position, 20f);
            AddVelocity(player);
        }

        void AddVelocity(PlayerController player)
        {
            player.velocity.y = verticalVelocity;
        }
    }
}
