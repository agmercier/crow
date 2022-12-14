using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{

public class FacePlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject visual;

    void OnTriggerEnter2D(Collider2D other)
    {
        visual.GetComponent<SpriteRenderer>().flipX = !visual.GetComponent<SpriteRenderer>().flipX;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        visual.GetComponent<SpriteRenderer>().flipX = !visual.GetComponent<SpriteRenderer>().flipX;
    }
}

}