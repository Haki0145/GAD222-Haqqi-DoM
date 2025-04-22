using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    public Image leftCharacterImage;
    public Image rightCharacterImage;
    public CharacterData[] characterDatas;

    public void ShowCharacter(string speakerName, string expression = "default")
    {
        Debug.Log($" Character Name: {speakerName}");
        Debug.Log($" Expresion Name: {expression}");
        leftCharacterImage.gameObject.SetActive(false);
        rightCharacterImage.gameObject.SetActive(false);

        foreach (CharacterData data in characterDatas)
        {
            if (data.characterName == speakerName)
            {
                Sprite expressionSprite = GetExpressionSprite(data, expression);
                if (data.appearsOnLeft)
                {
                    leftCharacterImage.sprite = expressionSprite;
                    leftCharacterImage.gameObject.SetActive(true);
                }
                else
                {
                    rightCharacterImage.sprite = expressionSprite;
                    rightCharacterImage.gameObject.SetActive(true);
                }
                return;
            }
        }
    }

    private Sprite GetExpressionSprite(CharacterData data, string expressionName)
    {
        foreach (CharacterData.Expression exp in data.expressions)
        {
            if (exp.name.ToLower() == expressionName.ToLower())
            {
                return exp.sprite;
            }
        }
        return data.expressions.Length > 0 ? data.expressions[0].sprite : null;
    }
}
