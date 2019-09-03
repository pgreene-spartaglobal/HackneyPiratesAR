using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGoal : MonoBehaviour 
{
    [SerializeField] MazeController mc;
    public bool isCorrect = false;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") && (isCorrect))
        {
            // Player wins
            mc.Correct();
        }
        else if ((other.tag == "Player") && (!isCorrect))
        {
            // Incorrect
            mc.Incorrect();
        }
    }     
}
