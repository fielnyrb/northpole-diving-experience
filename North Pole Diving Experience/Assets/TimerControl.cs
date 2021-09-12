using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    public float gameDurationInSeconds = 120;
    public Text canvasText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameDurationInSeconds > 0)
        {
            gameDurationInSeconds -= Time.deltaTime;
            canvasText.text = "" + DisplayTime(gameDurationInSeconds);
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    //https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/

    string DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
