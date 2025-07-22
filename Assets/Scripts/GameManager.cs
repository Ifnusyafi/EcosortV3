using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int totalTrash = 0;
    private int trashCollected = 0;

    [Header("UI Level Selesai")]
    public GameObject levelCompletePanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterTrash()
    {
        totalTrash++;
    }

    public void CollectTrash()
    {
        trashCollected++;

        if (trashCollected >= totalTrash)
        {
            Debug.Log("✅ Semua sampah telah dikumpulkan!");
            if (levelCompletePanel != null)
                levelCompletePanel.SetActive(true);
        }
    }

    public void ResetTrashCounter()
    {
        totalTrash = 0;
        trashCollected = 0;

        if (levelCompletePanel != null)
            levelCompletePanel.SetActive(false);
    }

    // Fungsi tombol
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevelList()
    {
        SceneManager.LoadScene("LevelList");
    }
}
