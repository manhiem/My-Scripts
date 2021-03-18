using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Bolt.EntityBehaviour<IArState>
{
    public Rigidbody bulletPrefab;
    public float bulletSpeed;
    public GameObject muzzle;

    public override void Attached()
    {
        state.OnShoot = Shoot;
        state.SetTransforms(state.PlayerTransform, this.gameObject.transform);
    }
    // Start is called before the first frame update
    private void Shoot()
    {
        Rigidbody bulletClone = Instantiate(bulletPrefab, muzzle.transform.position, this.transform.rotation);

        bulletClone.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && entity.IsOwner)
        {
            state.Shoot();
        }
    }
}
