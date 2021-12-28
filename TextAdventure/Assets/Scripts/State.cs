using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")] // gives us the option to create a state from this script FROM RIGHT CLICK

// The name of this class will be the type in other scripts
public class State : ScriptableObject {
   [TextArea(14,15)] [SerializeField] string storyText;         // (min, scroll after otherwise expand)
    [SerializeField] State[] nextStates;

    public string GetStateStory() {
        return storyText;
    }

    public State[] getOptionsState() {
        return nextStates;
    } 
}
