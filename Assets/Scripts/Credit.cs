using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
