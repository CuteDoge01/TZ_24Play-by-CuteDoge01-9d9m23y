using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;

    private bool isGameOver = false;
    private void Start()
    {
        Time.timeScale = 0f;
        Application.targetFrameRate = 60;
    }
    public void OnScreenTouch()
    {
        Time.timeScale = 1.0f;
    }

    public void OnScreenLetGo()
    {
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        isGameOver = true;
        canvas.transform.Find("PlayButton").gameObject.SetActive(false);
        canvas.transform.Find("GameOverScreen").gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    private void FixedUpdate() //If the game is lost, prevent the OnScreenLetGo from unpausing the game
    {
        if (isGameOver)
        {
            Time.timeScale = 0f;
        }
    }
}
