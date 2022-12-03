using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueLoader : MonoBehaviour
{
    public DialogueLib _lib;
    public DialogueLib.LevelName _name;
    int i;

    public void StartDialogue(Text DialogueText, int index)
    {
        i = 0;
        DialogueText.text = _lib.dialogue[i];
    }

    public void ChangeDialogue(Text DialogueText, int index)
    {
        i += index;
        if (i >= 0 && i <= 2)
        {
            DialogueText.text = _lib.dialogue[i];
        }
        if(i < 0)
        {
            i = 2;
            DialogueText.text = _lib.dialogue[i];
        }
        if (i > 2)
        {
            i = 0;
            DialogueText.text = _lib.dialogue[i];
        }
    }
}
