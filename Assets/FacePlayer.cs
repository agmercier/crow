using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{

public class FacePlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject kiwi;

    void OnTriggerEnter2D(Collider2D other)
    {
        kiwi.GetComponent<SpriteRenderer>().flipX = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        kiwi.GetComponent<SpriteRenderer>().flipX = true;
    }
}

}