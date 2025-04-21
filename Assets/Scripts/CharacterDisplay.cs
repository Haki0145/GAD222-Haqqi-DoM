using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    public Image leftCharacterImage;
    public Image rightCharacterImage;
    public CharacterData[] characterDatas;

    public void ShowCharacter(string speakerName)
    {
        leftCharacterImage.gameObject.SetActive(false);
        rightCharacterImage.gameObject.SetActive(false);

        foreach (CharacterData data in characterDatas)
        {
            if (data.characterName == speakerName)
            {
                if (data.appearsOnLeft)
                {
                    leftCharacterImage.sprite = data.characterSprite;
                    leftCharacterImage.gameObject.SetActive(true);
                }
                else
                {
                    rightCharacterImage.sprite = data.characterSprite;
                    rightCharacterImage.gameObject.SetActive(true);
                }
                return;
            }
        }
    }
}
