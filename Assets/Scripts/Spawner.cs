using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private GameObject[] validTiles;
    public GameObject pickup_prefab;


    public int numOfPickups = 2;        // max num of active pickups
    private GameObject[] list_pickups;

	// Use this for initialization
	void Start () {
        validTiles = GameObject.FindGameObjectsWithTag("ValidTile");
        list_pickups = new GameObject[numOfPickups];
        for (int i = 0; i < numOfPickups; ++i)
        {
            int tileNum = Random.Range(0, validTiles.Length);
            Vector3 position = validTiles[tileNum].transform.position;
            list_pickups[i] = Instantiate(pickup_prefab, new Vector3(position.x, 0.5f, position.z), Quaternion.identity);
        }

	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < numOfPickups; ++i)
        {
            if (!list_pickups[i].activeInHierarchy)
            {
                int tileNum = Random.Range(0, validTiles.Length);
                Vector3 position = validTiles[tileNum].transform.position;
                list_pickups[i].transform.position = new Vector3(position.x, 0.5f, position.z);
                list_pickups[i].SetActive(true);
            }
        }
    }
}
