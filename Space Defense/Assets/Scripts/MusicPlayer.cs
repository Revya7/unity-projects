using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        int numberOfTypes = FindObjectsOfType<MusicPlayer>().Length;
        if(numberOfTypes > 1) {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
