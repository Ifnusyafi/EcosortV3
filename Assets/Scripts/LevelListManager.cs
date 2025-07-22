using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelListManager : MonoBehaviour
{
    public GameObject confirmationPopup;
    private string selectedLevelName = "";

    public void SelectLevel(string levelName)
    {
        selectedLevelName = levelName;
        confirmationPopup.SetActive(true);
    }


    public void PlayLevel(string difficulty)
    {
        string sceneToLoad = selectedLevelName + "_" + difficulty;

        if (IsSceneInBuild(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("Scene tidak ditemukan di Build Settings: " + sceneToLoad);
        }
    }

    public void CancelSelection()
    {
        confirmationPopup.SetActive(false);
    }

    private bool IsSceneInBuild(string sceneName)
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < sceneCount; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            string name = Path.GetFileNameWithoutExtension(path);
            if (name == sceneName)
            {
                return true;
            }
        }
        return false;
    }
}
