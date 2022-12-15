using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; 

namespace Platformer.Mechanics
{

public class interact_with_kiwi_prompt : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] private Image UI_kiwianim;
    public GameObject kiwi_orb; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (kiwi_orb != null && other.CompareTag("Player"))
        {
            UI_kiwianim.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            UI_kiwianim.enabled = false;
        }
    }   
}
}
