using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    GameSession gameSession; // still get it dynamically not in start

    [SerializeField] float timeUntilGameOverScreen = 2f;

    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
        gameSession = FindObjectOfType<GameSession>();
        if(gameSession) {
            gameSession.ResetGame();
        }
    }

    public void LoadGame() {
        SceneManager.LoadScene(1);
        gameSession = FindObjectOfType<GameSession>();
        if(gameSession) {
            gameSession.ResetGame();
        }
    }

    public void LoadGameOver() {
        StartCoroutine(LoadGameOverWithDelay());
    }

    IEnumerator LoadGameOverWithDelay() {
        yield return new WaitForSeconds(timeUntilGameOverScreen);
        SceneManager.LoadScene("Game Over");
    }


    public void QuitApp() {
        Application.Quit();
    }

}
