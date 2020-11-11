using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightShot : IState
{
    private GameObject disc;
    private GameObject ownerGameObject;
    private float shotSpeed;

    public StraightShot(GameObject disc, GameObject ownerGameObject, float shotSpeed)
    {
        this.disc = disc;
        this.ownerGameObject = ownerGameObject;
        this.shotSpeed = shotSpeed;
    }

    public void Enter()
    {
        var shot = GameObject.Instantiate(disc, ownerGameObject.transform.position, ownerGameObject.transform.rotation);
        Vector2 shotDir = ownerGameObject.transform.rotation * Vector2.up;
        shot.GetComponent<Rigidbody2D>().velocity = shotDir * shotSpeed * Time.fixedDeltaTime;

    }

    public void Execute()
    {
    }

    public void Exit()
    {
    }
}
