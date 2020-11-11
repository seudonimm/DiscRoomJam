using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    //[SerializeField] GameObject target;
    //[SerializeField] string targetTag;
    [SerializeField] float adjustment; //the amount of degrees tobe added for the correct side to point to target

    [SerializeField] Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag(targetTag);
    }

    // Update is called once per frame
    void Update()
    {
        MousePosition();
        var dir = direction/* - (Vector2)transform.position*/;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + adjustment;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Debug.Log("Rotate pls");

    }

    void MousePosition()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();

        
    }

}
