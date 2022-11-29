using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Kiwi unlock
 */


//Have to be in correct namespace to be able to call 'PlayerController', otherwise it wont be able to find it. Took me 2 hours to realise the problem
namespace Platformer.Mechanics
{


public class KiwiUnlock : MonoBehaviour
{
    //audio sound to be played when orb collected
    public AudioClip collectAudio;
    //the player object in the scene
    public GameObject kiwi;
    internal bool collected = false;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if kiwi object exists (prevents nullpointer errors)
        if (kiwi != null)
        {
            //stops object collection from occuring more than once
            if (collected) return;
            collected = true;

            //play the collection sound
            AudioSource.PlayClipAtPoint(collectAudio, this.transform.position);

            //removes orb once collected
            Destroy(this.gameObject);

            //activates kiwi
            if (!kiwi.activeInHierarchy)
            {
                kiwi.SetActive(true);
            }
        }
    }
}
}