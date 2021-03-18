using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int countDown = 1;

    public GameObject enemy;
    public Transform[] points;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countDown += (int)Time.deltaTime;

        if(countDown == 10)
        {
            Debug.Log("Equalled");
            
            foreach(Transform tr in points)
            {
                Instantiate(enemy, tr.position, Quaternion.identity);
            }

            countDown = 0;
        }
    }
}
