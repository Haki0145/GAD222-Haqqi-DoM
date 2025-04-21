using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character Data")]
public class CharacterData : ScriptableObject
{
    [System.Serializable]
    public class Expression
    {
        public string name;
        public Sprite sprite;
    }

    public string characterName;
    public Expression[] expressions;
    public bool appearsOnLeft;
}