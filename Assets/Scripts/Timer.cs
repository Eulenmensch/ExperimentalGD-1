using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 301f;
    private TextMeshProUGUI timerSeconds;
    float minutes;
    float seconds;

    // Start is called before the first frame update
    void Start()
    {
        timerSeconds = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        minutes = Mathf.FloorToInt(timer / 60f);
        seconds = Mathf.FloorToInt(timer - minutes * 60);
        timerSeconds.text = minutes.ToString("0") + ":" + seconds.ToString("00");
        if(timer <= 0)
        {
            FindObjectOfType<CanvasController>().OnGameLost();
        }
    }
}
