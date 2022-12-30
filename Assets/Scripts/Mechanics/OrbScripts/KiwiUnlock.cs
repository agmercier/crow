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
    public GameObject kiwiTrigger;
    public GameObject kiwiVisualCue;
    internal bool collected = false;

    public GameObject later_kiwi;
    public GameObject later_kiwiTrigger;
    public GameObject mushroom;

    public Sprite newSprite;

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
            AudioSource.PlayClipAtPoint(collectAudio, this.transform.position,20f);

            //removes orb once collected
            Destroy(this.gameObject);

            //changes from mute to speakable icon
            kiwiVisualCue.GetComponent<SpriteRenderer>().sprite = newSprite;

            //makes speakable
            kiwiTrigger.GetComponent<DialogueTrigger>().hasSound = true;

            mushroom.SetActive(true);

            if(later_kiwi != null)
            {
                later_kiwi.SetActive(true);
                later_kiwiTrigger.GetComponent<DialogueTrigger>().hasSound = true;
            }

            }
    }
}
}