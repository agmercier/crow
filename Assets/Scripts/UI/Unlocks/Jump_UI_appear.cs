using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; 

namespace Platformer.Mechanics
{

public class Jump_UI_appear : MonoBehaviour
{
    //[Header("Image")]
    [SerializeField] private Image jumpImage;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && player.GetComponent<PlayerController>().jumpUnlocked == true)
        {
            jumpImage.enabled = true;
        }
    }
     void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jumpImage.enabled = false;
        }
    }   
}
}