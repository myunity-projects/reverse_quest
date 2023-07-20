using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        levelManager.LoadScene("MainMenu");
    }
}
