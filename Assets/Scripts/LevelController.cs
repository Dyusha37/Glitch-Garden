using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }
    public void AttckerSpawned()
    {
        numberOfAttackers++;
    }
    public void AttckerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0&&levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }
    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().NextSceneLoad();
    }
    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        SpotSpawners();
    }

    private void SpotSpawners()
    {
        AtackerSpawner[] spawnerArray = FindObjectsOfType<AtackerSpawner>();
        foreach(AtackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
