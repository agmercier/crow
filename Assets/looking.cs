using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using Cinemachine;

namespace Platformer.Gameplay
{

    public class looking : MonoBehaviour

    {
        //public GameObject player;
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            var player = model.player;
            if(player.health.IsAlive){
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
    }
}