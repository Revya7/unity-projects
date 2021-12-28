using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThisEnemy : MonoBehaviour
{

    [SerializeField] float rotateSpeed = 360f;
    void Update()
    {
        transform.Rotate(new Vector3(0f,0f, rotateSpeed * Time.deltaTime));
    }
}
