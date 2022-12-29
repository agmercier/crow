using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * General NPC unlock, based on Arthur's npc unlock (but generalized)
 */


//Have to be in correct namespace to be able to call 'PlayerController', otherwise it wont be able to find it. Took me 2 hours to realise the problem
namespace Platformer.Mechanics
{


public class NPC_interaction_unlock : MonoBehaviour
{
    //audio sound to be played when orb collected
    public AudioClip collectAudio;
    //the player object in the scene
    public GameObject npc;
    public GameObject npcTrigger;
    public GameObject npcVisualCue;
    internal bool collected = false;

    public GameObject later_npc;
    public GameObject later_npcTrigger;
    public GameObject mushroom;

    public Sprite newSprite;

    void Start()
    {
     }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if npc object exists (prevents nullpointer errors)
        if (npc != null)
        {
            //stops object collection from occuring more than once
            if (collected) return;
            collected = true;

            //play the collection sound
            AudioSource.PlayClipAtPoint(collectAudio, this.transform.position,20f);

            //removes orb once collected
            Destroy(this.gameObject);

            //changes from mute to speakable icon
            npcVisualCue.GetComponent<SpriteRenderer>().sprite = newSprite;

            //makes speakable
            npcTrigger.GetComponent<DialogueTrigger>().hasSound = true;

            mushroom.SetActive(true);

            if(later_npc != null)
            {
                later_npc.SetActive(true);
                later_npcTrigger.GetComponent<DialogueTrigger>().hasSound = true;
            }

            }
    }
}
}