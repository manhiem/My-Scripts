using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Bolt.EntityBehaviour<IMyState>
{
    public Camera fpsCamera;

    // Update is called once per frame
    void Update()
    {
        if(entity.IsOwner && fpsCamera.gameObject.activeInHierarchy == false)
        {
            fpsCamera.gameObject.SetActive(true);
        }
    }
}
