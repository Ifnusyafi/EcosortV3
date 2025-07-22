using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] myObjects;
    public Transform spawnAreaParent;
    private Collider[] spawnAreas;

    public int numberOfObjectsToSpawn = 10;

    void Start()
    {
        spawnAreas = spawnAreaParent.GetComponentsInChildren<Collider>();

        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "Level1_Normal":
                numberOfObjectsToSpawn = 1;
                break;
            case "Level1_Hard":
                numberOfObjectsToSpawn = 15;
                break;
            case "Level2_Normal":
                numberOfObjectsToSpawn = 20;
                break;
            case "Level2_Hard":
                numberOfObjectsToSpawn = 25;
                break;
            default:
                numberOfObjectsToSpawn = 10;
                break;
        }

        // Spawn objek
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            SpawnRandomObject();
        }
    }

    void SpawnRandomObject()
    {
        if (myObjects.Length == 0 || spawnAreas.Length == 0)
        {
            Debug.LogWarning("Tidak ada objek atau area untuk spawn.");
            return;
        }

        int randomIndex = Random.Range(0, myObjects.Length);
        Collider randomArea = spawnAreas[Random.Range(0, spawnAreas.Length)];

        Vector3 randomPos = new Vector3(
            Random.Range(randomArea.bounds.min.x, randomArea.bounds.max.x),
            randomArea.bounds.max.y,
            Random.Range(randomArea.bounds.min.z, randomArea.bounds.max.z)
        );

        GameObject obj = Instantiate(myObjects[randomIndex], randomPos, Quaternion.identity);
        GameManager.Instance.RegisterTrash();
    }
}
