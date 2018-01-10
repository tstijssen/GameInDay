using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MusicPlayerSingleton : MonoBehaviour {

    private AudioSource backgroundMusic;

    private static MusicPlayerSingleton instance = null;
    public static MusicPlayerSingleton Instance
    {
        get { return instance; }
    }

	// Use this for initialization
	void Start () {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        // audio settings
        backgroundMusic = GetComponent<AudioSource>();
        backgroundMusic.Play();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
