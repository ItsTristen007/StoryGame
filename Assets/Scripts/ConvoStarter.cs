using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class ConvoStarter : MonoBehaviour
{
    [SerializeField] NPCConversation RoboConvo;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ConversationManager.Instance.StartConversation(RoboConvo);
            }
        }
    }
}
