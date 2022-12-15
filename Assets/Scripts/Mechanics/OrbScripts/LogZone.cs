using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class LogZone : MonoBehaviour
    {
        public GameObject tilemapLogs;
        public GameObject player;
        public AudioClip collectAudio;


        void OnTriggerStay2D(Collider2D other)
        {
            //if player object exists (prevents nullpointer errors)
            if (player != null)
            {

                //water activate
                if (Input.GetButtonDown("Water") && player.GetComponent<PlayerController>().waterUnlocked)
                {
                    tilemapLogs.SetActive(true);
                    AudioSource.PlayClipAtPoint(collectAudio, this.transform.position);
                }
            }
        }
    }
}
