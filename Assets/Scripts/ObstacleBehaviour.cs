using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                    // GAME OVER
           other.gameObject.SetActive(false);
           GameObject gameOverMenu = GameObject.FindGameObjectWithTag("GameOvermenu");
           gameOverMenu.gameObject.SetActive(true);
        }
    }
}