using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue System/Dialogue")]
public class Dialogue : ScriptableObject
{
    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;
        [TextArea(3, 10)]
        public string sentence;
        public string expression; // Add this field
    }

    public DialogueLine[] dialogueLines;
}