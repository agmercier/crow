using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class RockZone : MonoBehaviour
    {
        public GameObject tilemapRock;
        public GameObject tilemapRockSplit;
        public GameObject player;
        public GameObject stoneLeft;
        public GameObject stoneRight;
        public GameObject air;
        public AudioClip collectAudio;

        public bool inZone;





        void Update()
        {
            if (Input.GetButtonDown("Water") && player.GetComponent<PlayerController>().waterUnlocked && inZone)
            {

                Debug.Log("Pressed X");
                StartCoroutine(ExampleCoroutine());

            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                inZone = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player") == true)
            {
                inZone = false;
            }
        }
        IEnumerator ExampleCoroutine()
        {

            AudioSource.PlayClipAtPoint(collectAudio, this.transform.position);

            player.GetComponent<PlayerController>().controlEnabled = false;

            stoneLeft.SetActive(true);
            stoneRight.SetActive(true);
            air.SetActive(true);
            tilemapRock.SetActive(false);

            yield return new WaitForSeconds(0.2f);

            stoneLeft.GetComponent<MoveTile>().move = true;
            stoneRight.GetComponent<MoveTile>().move = true;
            air.GetComponent<MoveTile>().move = true;


            yield return new WaitForSeconds(2);

            tilemapRockSplit.SetActive(true);
            player.GetComponent<PlayerController>().controlEnabled = true;

        }
    }
}
