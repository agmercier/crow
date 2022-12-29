using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

    public class looking : MonoBehaviour

    {
        public GameObject player;
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            var vcam = GetComponent<CinemachineVirtualCamera>();
            if(Input.GetAxis("Vertical") < -0.5){
                vcam.Follow = player.transform.GetChild(0);
            }
            else if(Input.GetAxis("Vertical") > 0.5){
                vcam.Follow = player.transform.GetChild(1);
            }
            else{
                vcam.Follow = player.transform;
            }
        }
    }