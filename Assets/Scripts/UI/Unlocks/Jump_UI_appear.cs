using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; 

namespace Platformer.Mechanics
{

public class Jump_UI_appear : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] private SpriteRenderer jumpImage;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true && player.GetComponent<PlayerController>().jumpUnlocked == true)
        {
            jumpImage.enabled = true;
        }
    }
     void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            jumpImage.enabled = false;
        }
    }   
}
}