using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.05f;
    public Dialogue testDialogue;
    public string nextSceneName;

    public GameObject choicePanel;
    public Button choice1Button;
    public Button choice2Button;

    public Dialogue choice1Dialogue;
    public Dialogue choice2Dialogue;
    public string choice1Scene;
    public string choice2Scene;

    private Queue<Dialogue.DialogueLine> dialogueLines;

    void Start()
    {
        dialogueLines = new Queue<Dialogue.DialogueLine>();
        StartDialogue(testDialogue);

        choicePanel.SetActive(false);

        choice1Button.onClick.AddListener(() => OnChoiceSelected(choice1Dialogue, choice1Scene));
        choice2Button.onClick.AddListener(() => OnChoiceSelected(choice2Dialogue, choice2Scene));
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueLines.Clear();

        foreach (Dialogue.DialogueLine line in dialogue.dialogueLines)
        {
            dialogueLines.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue.DialogueLine line = dialogueLines.Dequeue();
        nameText.text = line.speakerName;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(line.sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of dialogue.");
        ShowChoices();
    }

    void ShowChoices()
    {
        choicePanel.SetActive(true);
    }

    void OnChoiceSelected(Dialogue selectedDialogue, string selectedScene)
    {
        choicePanel.SetActive(false);

        if (selectedDialogue != null)
        {
            StartDialogue(selectedDialogue);
        }
        else if (!string.IsNullOrEmpty(selectedScene))
        {
            SceneManager.LoadScene(selectedScene);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextLine();
        }
    }
}
