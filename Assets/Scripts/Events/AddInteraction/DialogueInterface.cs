using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueInterface : MonoBehaviour
{
    public GameObject mobileControls;
    public GameObject inventory;
    public GameObject optionsButton;
    public GameObject dialoguePanel;
    public GameObject dialogueButton;
    public GameObject showDialogueButton;
    public static Dialogue dialogue;

    public void ShowDialogueInterface()
    {
        mobileControls.transform.localPosition = new Vector2(1000, 1000);
        inventory.SetActive(false);
        optionsButton.SetActive(false);
        dialoguePanel.SetActive(true);
        dialogueButton.SetActive(true);
    }

    public void StartDialogue()
    {
        if (dialogue != null)
        {
            ShowDialogueInterface();
            ContinueDialogue();
            showDialogueButton.SetActive(false);
        }
    }

    public void ContinueDialogue()
    {
        dialogue.enableDialogue = true;
    }

    public void HideDialogueInterface()
    {
        mobileControls.transform.localPosition = new Vector2(0, 0);
        inventory.SetActive(true);
        optionsButton.SetActive(true);
        dialoguePanel.SetActive(false);
        dialogueButton.SetActive(false);
    }
}
