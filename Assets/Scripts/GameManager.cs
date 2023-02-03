using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject SpawnManager;
    public GameObject Background;
    public GameObject Player;

    private PointSystem _pointSystem;

    void Awake()
    {
        SpawnManager.SetActive(false);
        Background.GetComponent<MoveLeft>().enabled = false;
        Player.GetComponent<PlayerController>().enabled = false;
        _pointSystem = GetComponent<PointSystem>();
        _pointSystem.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RestartGame();
    }

    public void StartGame()
    {
        SpawnManager.SetActive(true);
        Player.GetComponent<PlayerController>().enabled = true;
        Background.GetComponent<MoveLeft>().enabled = true;
        _pointSystem.enabled = true;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
