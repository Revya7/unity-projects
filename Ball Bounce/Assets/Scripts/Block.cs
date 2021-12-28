using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // config
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject breakVFX;
    [SerializeField] Sprite[] blockSpritesArray;

    // cached
    Level level;
    GameSession gameStatus;

    // state var
    // [SerializeField] int maxHits = 3;
    [SerializeField] int timesHit = 0; // seriazlized for debug

    private void OnCollisionEnter2D(Collision2D collision) {
        BlockHit();
    }

    private void BlockHit() {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position); // clip, 3d position, the source in 2d is the camera so just put the camera position
        if (tag == "Breakable") {
            timesHit++;
            int maxHits = blockSpritesArray.Length + 1;
            if (timesHit >= maxHits) {
                DestroyTheBlock();
            } else {
                Sprite spriteNeeded = blockSpritesArray[timesHit - 1];
                if (spriteNeeded) {
                    GetComponent<SpriteRenderer>().sprite = spriteNeeded;
                } else {
                    Debug.LogError("Missing Sprite on " + gameObject.name);
                }
            }
        }
    }

    private void DestroyTheBlock() {
        Destroy(gameObject, 0.0f);
        level.BlockDestroyed();
        PlaySparkleVFX();
        gameStatus.AddPointToScore();
    }

    private void PlaySparkleVFX() {
        GameObject sparkle = Instantiate(breakVFX, transform.position, transform.rotation);
        Destroy(sparkle, 1.0f);
    }

    void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        if (tag == "Breakable") {
            level.CountBlocks();
        }
    }

    void Update()
    {
        
    }
}
