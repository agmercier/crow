using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class CheckPoint : MonoBehaviour
    {
        public GameObject checkPoint;
        public AudioClip collectAudio;
        public GameObject spawnPoint;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void OnTriggerEnter2D(Collider2D other)
        {
            if (checkPoint != null)
            {
                //play the collection sound
                AudioSource.PlayClipAtPoint(collectAudio, this.transform.position, 20f);

                spawnPoint.transform.position = this.transform.position;
            }
        }
    }
}
