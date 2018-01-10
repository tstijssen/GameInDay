using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameBehaviour : MonoBehaviour {
    public Text textUI;
    // Use this for initialization
    void Start () {
        textUI.text = "Final Score:" + PlayerPrefs.GetInt("Score");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
