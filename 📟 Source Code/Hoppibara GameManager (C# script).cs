using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Singleton 

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;

    }
    #endregion

    public float currentScore = 0f;
    public bool isPlaying = false;
    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();

    public Data data;


    private void Start()
    {
        //if we have loaded data 
        //else create new data
        data = new Data();
    }

    private void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
        }
    }

    public void StartGame()
    {
        onPlay.Invoke();
        isPlaying = true;
        currentScore = 0;

    }

    public void GameOver()
    {
        onGameOver.Invoke();
        isPlaying = false;
        if (data.highscore < currentScore)
        {
            data.highscore = currentScore;
        }
    }

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }
}
