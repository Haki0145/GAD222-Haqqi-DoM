using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeSystem : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 1f;


    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOutIn(sceneName));
    }

    IEnumerator FadeOutIn(string sceneName)
    {
        float timer = 0f;
        Color panelColor = fadePanel.color;

        // Fade Out
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            panelColor.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadePanel.color = panelColor;
            yield return null;
        }

        // Load Scene
        SceneManager.LoadScene(sceneName);

        // Fade In
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            panelColor.a = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadePanel.color = panelColor;
            yield return null;
        }
        yield return null;

    }
}
