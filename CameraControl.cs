using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : Bolt.EntityBehaviour<IArState>
{
    public GameObject entityCamera;
    void Start()
    {

    }

    void Update()
    {
        if(entity.IsOwner && entityCamera.gameObject.activeInHierarchy == false)
        {
            entityCamera.gameObject.SetActive(true);
        }
    }
}
