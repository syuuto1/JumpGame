using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
    
    public void ResultScene()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }
}
