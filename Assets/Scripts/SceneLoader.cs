using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private FadeSystem _fadeSystem;
    private void Awake()
    {
        _fadeSystem = FindAnyObjectByType<FadeSystem>().GetComponent<FadeSystem>();
    }

    public void LoadScene(string sceneName)
    {
        _fadeSystem.FadeToScene(sceneName);
    }
}
