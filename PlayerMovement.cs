using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMovement : Bolt.EntityBehaviour<IMyState>
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;

    public override void Attached()
    {
        state.SetTransforms(state.PlayerTransform, transform);
    }

    public override void SimulateOwner()
    {
        var speed = 4f;
        var movement = Vector3.zero;
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            movement.x -= 1f;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            movement.x += 1f;
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            movement.z += 1f;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            movement.z -= 1f;
        }

        if(movement != Vector3.zero)
        {
            transform.position = transform.position + movement.normalized * speed * BoltNetwork.FrameDeltaTime;
        }

        if(entity.IsOwner)
        {
            if (axes == RotationAxes.MouseXAndY)
            {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            else
            {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
        }
    }
}