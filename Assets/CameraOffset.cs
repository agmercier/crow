using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics{

    public class CameraOffset : MonoBehaviour
    {
        public GameObject CameraPos;
        public GameObject Player;
        // Start is called before the first frame update
        private Vector3 tempvec;

        void Start()
        {
            tempvec = CameraPos.GetComponent<Transform>().position;
        }

        // Update is called once per frame
        void OnTriggerEnter2D(Collider2D other)
        {
            // CameraPos.GetComponent<Transform>().position.y -= 0.5f;
            tempvec.y -= 0.5f;
            CameraPos.GetComponent<Transform>().position = tempvec;
        }
        
        void OnTriggerExit2D(Collider2D other)
        {  
            // CameraPos.GetComponent<Transform>().position.y += 0.5f;
            tempvec.y += 0.5f;
            CameraPos.GetComponent<Transform>().position = tempvec;
        }
    }
}