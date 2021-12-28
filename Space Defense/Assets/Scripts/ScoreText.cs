using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    [SerializeField] GameSession gameSession;

    Text scoreText;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        scoreText = GetComponent<Text>();
    }


    public void UpdateScore() {
        scoreText.text = gameSession.ReturnScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameSession.ReturnScore().ToString();
    }
}
