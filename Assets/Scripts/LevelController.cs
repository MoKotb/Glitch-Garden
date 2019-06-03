using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    private LivesDisplay lives;
    private float numberOfLives;

    [SerializeField]
    GameObject winPanel;
    [SerializeField]
    GameObject losePanel;
    [SerializeField]
    float waitToLoad = 3f;

    private void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        lives = FindObjectOfType<LivesDisplay>();
    }

    void Update()
    {
        if (lives)
        {
            numberOfLives = lives.GetLives();
        }
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished && numberOfLives > 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winPanel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        losePanel.SetActive(true);
        GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            spawner.StopSpawning();
        }
    }
}
