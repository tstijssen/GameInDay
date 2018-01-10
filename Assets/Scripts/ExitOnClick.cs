using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOnClick : MonoBehaviour {
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
    public void ExitGame()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(btnpress_sound, vol);
        Application.Quit();
    }
}
