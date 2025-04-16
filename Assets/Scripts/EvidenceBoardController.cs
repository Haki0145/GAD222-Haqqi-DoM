using UnityEngine;
using UnityEngine.SceneManagement;

public class EvidenceBoardController : MonoBehaviour
{
    public int[] correctCombination;
    private int[] currentCombination;

    void Start()
    {
        currentCombination = new int[correctCombination.Length];
        for (int i = 0; i < currentCombination.Length; i++)
        {
            currentCombination[i] = -1;
        }
    }

    public void CheckEvidence(int slotID, int evidenceID)
    {
        if (slotID >= 0 && slotID < currentCombination.Length)
        {
            currentCombination[slotID] = evidenceID;
            CheckSolution();
        }
    }

    void CheckSolution()
    {
        for (int i = 0; i < correctCombination.Length; i++)
        {
            if (currentCombination[i] != correctCombination[i]) return;
        }
        Debug.Log("Correct combination! Proceed to next scene.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}