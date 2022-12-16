using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class LogZone : MonoBehaviour
    {
        public GameObject tilemapLogs;
        public GameObject player;
        public GameObject logs;
        public AudioClip collectAudio;
        public Transform target;
        public float speed;

        private bool inZone;





        void Update()
        {
            if (Input.GetButtonDown("Water") && player.GetComponent<PlayerController>().waterUnlocked && inZone)
            {


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
                Debug.Log("Pressed X");
                AudioSource.PlayClipAtPoint(collectAudio, this.transform.position);

                player.GetComponent<PlayerController>().controlEnabled = false;

                logs.GetComponent<MoveTile>().move = true;


                yield return new WaitForSeconds(2);

                tilemapLogs.SetActive(true);
                player.GetComponent<PlayerController>().controlEnabled = true;

        }
        /* void OnTriggerStay2D(Collider2D other)
         {
             //if player object exists (prevents nullpointer errors)
             if (player != null && other.CompareTag("Player") == true)
             {

                 //water activate
                 if (Input.GetButtonDown("Water") && player.GetComponent<PlayerController>().waterUnlocked)
                 {
                   *//*  Debug.Log("Pressed X");
                     //tilemapLogs.SetActive(true);
                     AudioSource.PlayClipAtPoint(collectAudio, this.transform.position);

                     player.GetComponent<PlayerController>().controlEnabled = false;

                     logs.GetComponent<MoveTile>().move = true;
 *//*

                     StartCoroutine(ExampleCoroutine());
                 *//*    tilemapLogs.SetActive(true);
                     player.GetComponent<PlayerController>().controlEnabled = true;*//*
                 }
             }
         }*/
      

        
    }
}
