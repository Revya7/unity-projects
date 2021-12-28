using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScoller : MonoBehaviour
{

    [SerializeField] float BackgroundScollSpeed = 0.2f;
    Material myMaterial;

    Vector2 offset;

    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0f, BackgroundScollSpeed);
    }


    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
