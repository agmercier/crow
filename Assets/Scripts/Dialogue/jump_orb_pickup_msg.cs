using System.Collections;
using System.Collections.Generic;
// using TMPro;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class jump_orb_pickup_msg : MonoBehaviour
    {
        // private float time = 0;

        [Header("Ink JSON")]
        [SerializeField]
        private TextAsset inkJSON_jump;

        public GameObject player;

        // Update is called once per frame
        void Update()
        {
            if (player.GetComponent<PlayerController>().jumpUnlocked == true && !DialogueManager.GetInstance().dialogueIsPlaying)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON_jump);
            }
        }
    }
}
