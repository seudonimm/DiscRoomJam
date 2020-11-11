using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoAngledShot : IState
{
    private GameObject disc;
    private GameObject ownerGameObject;
    private float shotSpeed;

    public TwoAngledShot(GameObject disc, GameObject ownerGameObject, float shotSpeed)
    {
        this.disc = disc;
        this.ownerGameObject = ownerGameObject;
        this.shotSpeed = shotSpeed;
    }

    public void Enter()
    {
        var shot1 = GameObject.Instantiate(disc, ownerGameObject.transform.position, ownerGameObject.transform.rotation);
        var shot2 = GameObject.Instantiate(disc, ownerGameObject.transform.position, ownerGameObject.transform.rotation);

        Vector2 shotDir1 = ownerGameObject.transform.rotation * new Vector2(-1 ,1);
        shot1.GetComponent<Rigidbody2D>().velocity = shotDir1 * shotSpeed * Time.fixedDeltaTime;

        Vector2 shotDir2 = ownerGameObject.transform.rotation * new Vector2(1, 1);
        shot2.GetComponent<Rigidbody2D>().velocity = shotDir2 * shotSpeed * Time.fixedDeltaTime;

    }

    public void Execute()
    {
    }

    public void Exit()
    {
    }
}
