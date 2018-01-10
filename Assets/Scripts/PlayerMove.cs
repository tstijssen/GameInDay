using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public List<Transform> BodyParts = new List<Transform>();

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public float player_speed;
    public float rotation_speed;
    public float spawn_timer = 2;

    public float min_distance;
    public GameObject BodyPart; // prefab for extending snake body

    private Transform currentPart;
    private Transform previousPart;

    // Update is called once per frame
    void Update () {

        if (spawn_timer > 0)
        {
            spawn_timer -= Time.deltaTime;
        }
        else
        {
            BodyParts[0].Translate((BodyParts[0].forward * player_speed) * Time.smoothDeltaTime);

            if (Input.GetAxis("Horizontal") != 0)
            {
                BodyParts[0].Rotate(((Vector3.up * rotation_speed) * Time.deltaTime) * Input.GetAxis("Horizontal"));
            }

            for (int i = 1; i < BodyParts.Count; ++i)
            {
                currentPart = BodyParts[i];
                previousPart = BodyParts[i - 1];

                float distance = Vector3.Distance(previousPart.position, currentPart.position);

                Vector3 newpos = previousPart.position;
                newpos.y = BodyParts[0].position.y;

                float t = Time.deltaTime * distance / min_distance * player_speed;

                if (t > 0.5f)
                {
                    t = 0.5f;
                }

                currentPart.position = Vector3.Slerp(currentPart.position, newpos, t);
                currentPart.rotation = Quaternion.Slerp(currentPart.rotation, previousPart.rotation, t);
            }
        }
    }

    public void ExtendBody()
    {
        Transform newPart = (Instantiate(BodyPart, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;
        newPart.SetParent(transform);
        BodyParts.Add(newPart);
        Debug.Log(BodyParts.Count);
    }
}
