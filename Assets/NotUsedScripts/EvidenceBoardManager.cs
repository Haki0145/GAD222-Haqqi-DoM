using UnityEngine;
using UnityEngine.SceneManagement;

public class EvidenceBoardManager : MonoBehaviour
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

    public void EvidenceDropped(int evidenceID, int slotID)
    {
        if (slotID >= 0 && slotID < currentCombination.Length)
        {
            currentCombination[slotID] = evidenceID;
            CheckSolution();
        }
    }

    private void CheckSolution()
    {
        for (int i = 0; i < correctCombination.Length; i++)
        {
            if (currentCombination[i] != correctCombination[i])
            {
                return;
            }
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
