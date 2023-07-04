using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private string _name;

    public void LoadLevel()
    {
        SceneManager.LoadScene(_name);
    }
}
