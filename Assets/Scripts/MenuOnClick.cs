using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOnClick : MonoBehaviour {

    // sound variables
    public AudioClip btnpress_sound;
    private float throwSpeed = 2000f;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void GoToMenu()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(btnpress_sound, vol);
        SceneManager.LoadScene("MainMenu");
    }
}
