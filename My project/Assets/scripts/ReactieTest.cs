using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ReactieTest : MonoBehaviour
{
    enum State { idle, wait, play, stop };
    State myState = State.idle;

    [SerializeField] Button StartButton;
    [SerializeField] Button StopButton;
    [SerializeField] Button ContinueButton;
    [SerializeField] TextMeshProUGUI Stopwatch;
    float time = 0;
    float startTimeThreshold = 0;

    private void ClickStartButton()
    {
        myState = State.wait;
        time = 0;
        startTimeThreshold = Random.Range(4, 10);  // willekeurige tijd tussen 4–10 sec
        UpdateUI();
    }
    private void ClickStopButton()
    {
        myState = State.stop;
        UpdateUI();
    }

    private void ClickContinueButton()
    {
        myState = State.idle;
        time = 0;
        Stopwatch.text = "";
        UpdateUI();
    }

    private void UpdateUI()
    {
        StartButton.gameObject.SetActive(myState == State.idle);
        StopButton.gameObject.SetActive(myState == State.play);
        ContinueButton.gameObject.SetActive(myState == State.stop);
    }


    void Start()
    {
        StartButton.onClick.AddListener(ClickStartButton);
        StopButton.onClick.AddListener(ClickStopButton);
        ContinueButton.onClick.AddListener(ClickContinueButton);

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (myState == State.wait)
        {
            time += Time.deltaTime;
            if (time > startTimeThreshold)
            {
                time = 0;
                myState = State.play;
                UpdateUI();
            }
        }

        if (myState == State.play)
        {
            time += Time.deltaTime;
            Stopwatch.text = time.ToString("F3");
        }
    }
}
