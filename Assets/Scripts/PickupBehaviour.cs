using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour {

    public float Pickup_SpinSpeed;
    public int Pickup_Score;
    private Interface ScoreInterface;

    // Use this for initialization
    void Start()
    {
        GameObject ManagerInfo;
        ManagerInfo = GameObject.Find("GameManager");
        ScoreInterface = ManagerInfo.GetComponent<Interface>();
    }
    // Update is called once per frame
    void Update () {
        transform.Rotate((transform.up * Pickup_SpinSpeed) * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponentInParent<PlayerMove>().ExtendBody();

            ScoreInterface.AddScore(Pickup_Score);
            gameObject.SetActive(false);
        }
    }
}
