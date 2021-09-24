using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int carrentScaneIndex;
    private void Start()
    {
        carrentScaneIndex = SceneManager.GetActiveScene().buildIndex;
            if (carrentScaneIndex == 0)
            {
                StartCoroutine(WaitForTime());
            }
    }
    IEnumerator WaitForTime(){
        yield return new WaitForSeconds(3f);
        NextSceneLoad();
    }
    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(carrentScaneIndex);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }
    public void NextSceneLoad()
    {
        SceneManager.LoadScene(carrentScaneIndex+1);
    }
    public void LoadLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Option Screen");
    }
}
