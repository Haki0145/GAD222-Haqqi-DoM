using UnityEngine;
using UnityEngine.EventSystems;

public class EvidenceSlot : MonoBehaviour, IDropHandler
{
    public int slotID;
    public EvidenceBoardManager boardManager;

    public void OnDrop(PointerEventData eventData)
    {
        EvidenceItem droppedEvidence = eventData.pointerDrag.GetComponent<EvidenceItem>();
        if (droppedEvidence != null)
        {
            boardManager.EvidenceDropped(droppedEvidence.evidenceID, slotID);
        }
    }
}
