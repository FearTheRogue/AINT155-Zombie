using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

    // Creates a delegate and event for sending the score
    public delegate void SendScore(int theScore);
    public static event SendScore OnSendScore;

    // sets the score 
    public int score = 10;
    // Creates a bool if has sent
    private bool scoreSent = false;

    public void OnAddScore()
    { 
        if (OnSendScore != null)
        {
            if (!scoreSent)
            {   
                // Sends the score to the GameUI script
                scoreSent = true;
                OnSendScore(score);
            }
        }
    }

} // AddScore
