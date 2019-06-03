using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our Level Timer in SEC")]
    [SerializeField]
    float levelTime = 10f;

    private Slider timer;
    private bool timerFinished = false;
    private bool triggeredLevelFinished = false;

    private void Start()
    {
        timer = GetComponent<Slider>();
    }

    private void Update()
    {
        if (triggeredLevelFinished)
        {
            return;
        }
        timer.value = Time.timeSinceLevelLoad / levelTime;
        timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }

}
