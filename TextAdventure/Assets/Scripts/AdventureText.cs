using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // access on Text

public class AdventureText : MonoBehaviour {
    // after declaring the text, go in Unity and orboto with a text field, in the GAME OBJECT

    [SerializeField] Text textoComponento;
    [SerializeField] State stateName;

    State currentState;

    // Use this for initialization
    void Start () {
        currentState = stateName;
        textoComponento.text = currentState.GetStateStory();
	}
	
	// Update is called once per frame
	void Update () {
        ManageState();
	}

    private void ManageState() {

        var optionStateChosen = currentState.getOptionsState();

        for(int i=0; i < optionStateChosen.Length; i++) {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)) {
                currentState = optionStateChosen[i];
            }
        }

        textoComponento.text = currentState.GetStateStory();
    }
}
