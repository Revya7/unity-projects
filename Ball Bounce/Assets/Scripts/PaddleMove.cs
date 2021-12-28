using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f; // screen is 4:3 , x:y, in camera we set size to 6 so y to 6, therefor it's now 6:8 regle de troi, so full height width is 12 16
    [SerializeField] float minX = 1f; // Screen width - object width/2
    [SerializeField] float maxX = 15f;

    // cached
    GameSession myGameSession;
    Ball myBalls;

    void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        myBalls = FindObjectOfType<Ball>();
    }

    
    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(ChangePaddlePos(), minX, maxX);
        transform.position = paddlePos;
        // will refere to this, like in js, anything that has this component

        // If u dont have a limit u go directly transform.position = paddlePos;   (x or y or both) = Vector2( value, value ); u put the value inside the vector not the Mathf.clamp
    }

    private float ChangePaddlePos() {
        if(myGameSession.IsAutoPlayActive()) {
            return myBalls.transform.position.x;
        } else {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
