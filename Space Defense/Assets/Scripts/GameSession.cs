using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int currentScore = 0;
    void Awake()
    {
        int numberOfTypes = FindObjectsOfType<GameSession>().Length;
        if(numberOfTypes > 1) {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void IncreaseScore(int score) {
        currentScore += score;
    }

    public void ResetGame() {
        Destroy(gameObject);
    }

    public int ReturnScore() {
        return currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
