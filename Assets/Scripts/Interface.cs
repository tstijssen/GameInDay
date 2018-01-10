using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour {
    public KeyCode backButton;
    public int targetScore;
    private int playerScore;
    private GameObject player;
    public Text textUI;
    public int numOfMaps;
    int MapNumber;

    // sound variables
    public AudioClip win_sound;
    public AudioClip pickup_sound;
    public AudioClip lose_sound;
    public AudioClip back_sound;

    private float throwSpeed = 2000f;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        playerScore = PlayerPrefs.GetInt("Score");
        MapNumber = PlayerPrefs.GetInt("Map");
    }

    private void OnGUI()
    {
        string scoreboardText = "SCORE: ";
        scoreboardText += playerScore;
        textUI.text = scoreboardText;
        //GUI.Label(new Rect(200, 0, 100, 30), scoreboardText);     // display the scoreboard to the screen
    }

    void Update()
    {
        if (Input.GetKeyDown(backButton))
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(back_sound, vol);
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void PlayerDeath()
    {
        StartCoroutine(PlayerLose());
    }

    void GameOver()
    {
        // show end game screen
        SceneManager.LoadScene("GameOver");
        PlayerPrefs.SetInt("Score", playerScore);
        PlayerPrefs.SetInt("Map", MapNumber);
    }

    public void AddScore(int score)
    {
        playerScore += 10;
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(pickup_sound, vol);
        Debug.Log(playerScore);

        if (playerScore >= targetScore * (MapNumber + 1))
        {
            // win, move to next map, if at end of map list, show game over screen
            MapNumber++;
            PlayerPrefs.SetInt("Map", MapNumber);
            PlayerPrefs.SetInt("Score", playerScore);
            Debug.Log(MapNumber);
            StartCoroutine(PlayerWin());
        }
    }

    IEnumerator PlayerWin()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(win_sound, vol);
        yield return new WaitWhile(() => source.isPlaying);

        if (PlayerPrefs.GetInt("Map") >= numOfMaps)
        {
            GameOver();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    IEnumerator PlayerLose()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(lose_sound, vol);
        yield return new WaitWhile(()=>source.isPlaying);
        GameOver();
    }

}
