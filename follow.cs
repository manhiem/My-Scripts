using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class follow : Bolt.EntityBehaviour<IArState>
{

    public override void Attached()
    {
        state.SetTransforms(state.PlayerTransform, this.gameObject.transform);
    }
    void Start()
    {

    }
 
    void Update()
    {

    }
 
}
 