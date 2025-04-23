using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipSystem : MonoBehaviour
{
    public Button skipButton;
    public GameObject summaryPanel;
    public TextMeshProUGUI summaryText;
    public Button confirmSkipButton;

    public string[] summaries;
    public string[] skipScenes;

    private int currentSection = 0;

    void Start()
    {
        
    }

    public void ShowSummary()
    {
        summaryPanel.SetActive(true);
        summaryText.text = summaries[currentSection];
    }

    public void SkipToNextScene()
    {
        summaryPanel.SetActive(false);

        if (currentSection < skipScenes.Length && !string.IsNullOrEmpty(skipScenes[currentSection]))
        {
            PlayerPrefs.SetInt("SkipDialogue", 1);
            SceneManager.LoadScene(skipScenes[currentSection]);
        }
        else
        {
            Debug.LogWarning("No scene to skip to!");
        }
    }

    public void AdvanceSection()
    {
        currentSection++;
    }
}
