using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        FadeSystem.Instance.FadeToScene(sceneName);
    }
}
