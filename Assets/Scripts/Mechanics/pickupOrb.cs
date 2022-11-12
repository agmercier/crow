using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * This is setup for the jump unlock!
 * 
 * Setup needed in unity scene:
 * 1/ Make sure the ability you want to unlock is unchecked on the player.
 *          -> Ex: Jump Unlocked (can be found in the 'Player Controller' component of the 'player' object).
 * 2/ Add the script to the orb you want the player to collide with to unlock the ability.
 * 3/ Once you have added the script you will notice two missing items. Drag the player object from the heiarchy tab to the receptical in the script titled 'Player'.
 *    Drag the sound you wish to be played in pickup to the receptical titled 'collectAudio'.
 *    
 * If it doesn't work ask: Arthur
 */


//Have to be in correct namespace to be able to call 'PlayerController', otherwise it wont be able to find it. Took me 2 hours to realise the problem
namespace Platformer.Mechanics
{


public class pickupOrb : MonoBehaviour
{
    //audio sound to be played when orb collected
    public AudioClip collectAudio;
    //the player object in the scene
    public GameObject player;
    internal bool collected = false;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if player object exists (prevents nullpointer errors)
        if (player != null)
        {
            //stops object collection from occuring more than once
            if (collected) return;
            collected = true;
            //removes orb once collected
            Destroy(this.gameObject);

            //fetches Player Controller component from the player and sets 'jumpUnlock' to true
            player.GetComponent<PlayerController>().jumpUnlocked = true;
        }
    }
}
}