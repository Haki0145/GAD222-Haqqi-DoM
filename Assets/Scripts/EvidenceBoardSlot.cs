using UnityEngine;

public class EvidenceBoardSlot : MonoBehaviour
{
    public int slotID;
    public EvidenceBoardController boardController;
    public int currentEvidenceID = -1;

    void OnTriggerEnter2D(Collider2D other)
    {
        DraggableEvidence evidence = other.GetComponent<DraggableEvidence>();
        if (evidence != null)
        {
            currentEvidenceID = evidence.evidenceID;
            boardController.CheckEvidence(slotID, currentEvidenceID);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        DraggableEvidence evidence = other.GetComponent<DraggableEvidence>();
        if (evidence != null && evidence.evidenceID == currentEvidenceID)
        {
            currentEvidenceID = -1;
        }
    }
}
