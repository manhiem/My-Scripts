using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Player;

    int MoveSpeed = 5;
    public int MaxDist;
    public int MinDist;

    void Start()
    {
        Player = GameObject.Find("ARCore Device").gameObject.transform;
    }

    void Update()
    {
        //transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;


            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //enter something
            }

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit!");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit!");
            //other.gameObject.GetComponent<Health>().TakeDamage(30);
        }
    }
}

