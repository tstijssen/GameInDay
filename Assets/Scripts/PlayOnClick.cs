using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayOnClick : MonoBehaviour {
    // sound variables
    public AudioClip btnpress_sound;
    private float throwSpeed = 2000f;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    void Start()
    {
        source = GetComponentInParent<AudioSource>();
    }
    public void PlayGame()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(btnpress_sound, vol);
        SceneManager.LoadScene("Game");
        PlayerPrefs.SetInt("Map", 0);
        PlayerPrefs.SetInt("Score", 0);
   
    }
}
