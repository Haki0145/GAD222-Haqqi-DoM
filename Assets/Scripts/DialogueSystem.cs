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
    private bool isChoicemade = false;
    private Coroutine typingCoroutine;
    private bool isTyping = false;
    private string currentSentence;

    void Start()
    {
        dialogueLines = new Queue<Dialogue.DialogueLine>();

        if (PlayerPrefs.GetInt("SkipDialogue", 0) == 1)
        {
            PlayerPrefs.SetInt("SkipDialogue", 0);
            SkipToNextChoice();
        }
        else
        {
            StartDialogue(testDialogue);
        }

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
        GetComponent<CharacterDisplay>().ShowCharacter(line.speakerName, line.expression);
        currentSentence = line.sentence;
        StopTyping();
        typingCoroutine = StartCoroutine(TypeSentence(currentSentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void StopTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            isTyping = false;
        }
    }

    void CompleteCurrentLine()
    {
        StopTyping();
        dialogueText.text = currentSentence;
        isTyping = false;
    }

    void EndDialogue()
    {
        if (!isChoicemade && (choice1Dialogue != null || choice2Dialogue != null))
        {
            ShowChoices();
        }
        else
        {
            LoadNextScene();
        }
    }

    void ShowChoices()
    {
        choicePanel.SetActive(true);
    }

    void OnChoiceSelected(Dialogue selectedDialogue, string selectedScene)
    {
        isChoicemade = true;
        nextSceneName = selectedScene;
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

    public void SkipToNextChoice()
    {
        dialogueLines.Clear();

        if (choice1Dialogue != null || choice2Dialogue != null)
        {
            ShowChoices();
        }
        else
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            FadeSystem.Instance.FadeToScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next scene name is not set!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                CompleteCurrentLine();
            }
            else
            {
                DisplayNextLine();
            }
        }
    }


}