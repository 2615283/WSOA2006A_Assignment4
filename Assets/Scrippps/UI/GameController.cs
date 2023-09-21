using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject playerScreen;
    [SerializeField]
    GameObject winScreen;
    [SerializeField]
    GameObject loading;

    public void Quit()
    {
        Application.Quit();    
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        playerScreen.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        playerScreen.SetActive(true);
        Time.timeScale = 1;
    }

    public void Reset()
    {
        //stop the movement of all the things that need to stop moving
        Invoke(nameof(ReloadLevel), 2f);
        loading.SetActive(true);
        //reset all stats, including artifacts collected, enemies killed and player health
        //if a reset function for the player's death exists in another script. we will use it here.
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void playAgain()
    {
        winScreen.SetActive(false);
        ReloadLevel();
        //Reset all necessary stats.
    }
}
