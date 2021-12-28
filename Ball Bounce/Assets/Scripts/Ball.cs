using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // configs param
    [SerializeField] PaddleMove paddle1;
    [SerializeField] Vector2 LaunchVector;
    [SerializeField] AudioClip[] ClipsArray;
    [SerializeField] float velocityTwick = 0.2f;

    // states
    Vector2 paddleToBallVector;
    bool wasLaunched = false;
    

    // cached, get once
    AudioSource ballAudioSource;
    Rigidbody2D myRigidBody;

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        ballAudioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        StickAndLaunch();
    }

    private void StickAndLaunch() {
        if (!wasLaunched) {
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
            if(Input.GetMouseButton(0)) {
                GetComponent<Rigidbody2D>().velocity = LaunchVector;
                wasLaunched = true;
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(wasLaunched) {
            AudioClip clip = ClipsArray[UnityEngine.Random.Range(0, ClipsArray.Length)];
            ballAudioSource.PlayOneShot(clip);
            myRigidBody.velocity += new Vector2(UnityEngine.Random.Range(0f, velocityTwick), UnityEngine.Random.Range(0f, velocityTwick)); // some randomness,better than (0.2f,0.2f)
        }
        // Play vs PlayOneShot, play til the end dont interrupt
    }
}
