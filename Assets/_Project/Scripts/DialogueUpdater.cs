using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUpdater : MonoBehaviour
{
    public DialogueData dialogue;
    public GameObject textbox;
    public string currentString;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            {
                textbox.SetActive(!textbox.activeSelf);
            }
    }

    public void ReadInput(string s)
    {
        dialogue.conversationBlock[0] = GPTDialogue.getGPT(s);
    }
}
