using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; 

namespace Platformer.Mechanics
{

public class glideprompt : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] private Image UI_anim;
    public GameObject orb; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (orb == null && other.CompareTag("Player"))
        {
            UI_anim.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            UI_anim.enabled = false;
        }
    }   
}
}
