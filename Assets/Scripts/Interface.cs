using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour {
    private int playerScore = 0;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnGUI()
    {
        string scoreboardText = "SCORE: ";
        scoreboardText += playerScore;
        GUI.Label(new Rect(200, 0, 100, 30), scoreboardText);     // display the scoreboard to the screen

        if (!player.activeInHierarchy)
        {
            // show game over screen
        }

    }

    public void AddScore(int score)
    {
        playerScore += 10;
        Debug.Log(playerScore);
    }
}
