using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public FadeSystem _fadeSystem;
    

    public void LoadScene(string sceneName)
    {
        _fadeSystem.FadeToScene(sceneName);
    }
}
