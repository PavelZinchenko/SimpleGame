using UnityEngine;
using Zenject;

public class LevelLoader : MonoBehaviour
{
    [Inject] ZenjectSceneLoader _sceneLoader;

    [SerializeField] private string[] _names = { };

    public void LoadLevel()
    {
        _sceneLoader.LoadScene(_names[0], UnityEngine.SceneManagement.LoadSceneMode.Single);

        for (var i = 1; i < _names.Length; ++i)
            _sceneLoader.LoadScene(_names[i], UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
}
