using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class MapSetup : MonoBehaviour {

    public Transform player;
    public Transform floor_valid;
    public Transform floor_obstacle;

    public const string stile_valid = "0";
    public const string stile_wall = "1";
    public const string stile_start = "S";

    public TextAsset map_file;

    // Use this for initialization
    void Start () {

        string[][] map = readFile();

        for(int y = 0; y < map.Length; ++y)
        {
            for (int x = 0; x < map[0].Length; ++x)
            {
                switch (map[y][x])
                {
                    case stile_start:
                        Instantiate(floor_valid, new Vector3(x, 0, -y), Quaternion.identity);
                        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(x, 0.25f, -y);
                        break;
                    case stile_valid:
                        Instantiate(floor_valid, new Vector3(x, 0, -y), Quaternion.identity);
                        break;
                    case stile_wall:
                        Instantiate(floor_obstacle, new Vector3(x, 0, -y), Quaternion.identity);
                        break;
                    default:
                        break;
                }

            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    string[][] readFile()
    {
        string text = map_file.ToString();
        string[] lines = Regex.Split(text, "\r\n");
        int rows = lines.Length;

        string[][] levelBase = new string[rows][];
        for (int i = 0; i < rows; ++i)
        {
            string[] stringsOfLine = Regex.Split(lines[i], " ");
            levelBase[i] = stringsOfLine;
        }
        return levelBase;
    }

}
