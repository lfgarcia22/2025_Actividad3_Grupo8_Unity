using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueComponent : MonoBehaviour
{
    [Header("Dialogue configurations")]
    [SerializeField, TextArea(1, 5)] private string[] dialogues;
    [SerializeField] private float timeBetweenLetters = 0.3f;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Image dialogueImage;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Sprite actorIcon;

    private bool isTalking = false;
    private int indexDialogue = -1;

    // Start speech of the actor with Dialogue Component
    public void Speech(GameObject instigator)
    {
        if (instigator.TryGetComponent(out PlayerController playerController))
        {
            // playerController.Interacting = true;
        }

        dialoguePanel.SetActive(true);
        dialogueImage.sprite = actorIcon;

        if (isTalking)
        {
            CompleteDialogue();
        }
        else
        {
            NextDialogue(instigator);
        }
    }

    // Next dialogue
    private void NextDialogue(GameObject instigator)
    {
        indexDialogue++;
        if (indexDialogue >= dialogues.Length)
        {
            FinishDialogue(instigator);
            return;
        }

        StartCoroutine(ShowDialogue());
    }

    // Close dialogue panel
    private void FinishDialogue(GameObject instigator)
    {
        isTalking = false;
        indexDialogue = -1;
        dialogueImage.sprite = null;
        dialogueText.text = "";
        dialoguePanel.SetActive(false);

        if (instigator.TryGetComponent(out PlayerController playerController))
        {
            // playerController.Interacting = false;
        }
    }

    // Show dialogue with a wait between letters
    private IEnumerator ShowDialogue()
    {
        isTalking = true;
        dialogueText.text = "";
        char[] dialogueChars = dialogues[indexDialogue].ToCharArray();
        foreach (char character in dialogueChars)
        {
            dialogueText.text += character;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
        isTalking = false;
    }

    // Complete the dialogue without the wait
    private void CompleteDialogue()
    {
        StopCoroutine(ShowDialogue());
        dialogueText.text = dialogues[indexDialogue];
        isTalking = false;
    }
}
