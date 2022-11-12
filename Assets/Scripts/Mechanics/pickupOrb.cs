using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{


public class pickupOrb : MonoBehaviour
{

    public AudioClip tokenCollectAudio;
    public GameObject player;
    internal bool collected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //only exectue OnPlayerEnter if the player collides with this token.
        if (player != null)
        {
            if (collected) return;
            collected = true;
            Destroy(this.gameObject);
            player.GetComponent<PlayerController>().jumpUnlocked = true;

        }
    }
}
}