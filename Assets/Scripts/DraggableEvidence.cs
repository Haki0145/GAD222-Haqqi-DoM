using UnityEngine;

public class DraggableEvidence : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging;
    public int evidenceID;

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, transform.position.z);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}
