using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointPerBlock = 50;
    [SerializeField] int currentScore = 0; // for debug
    [SerializeField] Text scoreText; // for debug
    [SerializeField] bool autoPlayBool = false;

    public void AddPointToScore() {
        currentScore += pointPerBlock;
        scoreText.text = currentScore.ToString(); // didnt need to call this on Update, guess it will automatically keep track of it
    }

    private void Awake() {
        int countThem = FindObjectsOfType<GameSession>().Length; // with s
        if(countThem > 1) {
            DestroyImmediate(gameObject); // Use Immediate else bugs gonna happen
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGame() {
        DestroyImmediate(gameObject);
    }

    public bool IsAutoPlayActive() {
        return autoPlayBool;
    }

    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }
}
