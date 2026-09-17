using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
        OnChangeScene("Game");
    }

    private void OnChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

}
