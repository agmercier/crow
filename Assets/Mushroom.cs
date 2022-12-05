using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class Mushroom : MonoBehaviour
    {
        private float bounce = 5f;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerController>().jumpState =  PlayerController.JumpState.PrepareToJump;
                //collision.gameObject.GetComponent<PlayerController>().jump = true;
                //collision.gameObject.GetComponent<PlayerController>().stopJump = false;
            }
        }
    }
}