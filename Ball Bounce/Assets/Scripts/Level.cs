using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int totalNumOfBlocks; // serialized for debug purps

    // cached
    SceneLoader sceneLoader;

    public void CountBlocks() {
        totalNumOfBlocks++;
    }


    public void BlockDestroyed() {
        totalNumOfBlocks--;
        if(totalNumOfBlocks <= 0) {
            sceneLoader.LoadNextScene();
        } 
    }

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    void Update()
    {
        
    }
}
