using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static int playerSelect;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        playerSelect = 0;
        SpawnManager.score = 0;
        SpawnManager.isGameOver = 0;
        SceneManager.LoadScene("MainScene");
    }

    public void SelectFirstSoju()
    {
        playerSelect = 0;
        SceneManager.LoadScene("GameScene");
    }

    public void SelectTruthSoju()
    {
        playerSelect = 1;
        SceneManager.LoadScene("GameScene");
    }   
}