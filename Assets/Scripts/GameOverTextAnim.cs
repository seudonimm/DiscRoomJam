using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTextAnim : MonoBehaviour
{
    [SerializeField] float t;
    [SerializeField] Text thisText;
    [SerializeField] PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        thisText.color = new Color(thisText.color.r, thisText.color.g, thisText.color.b, 0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerController.dead)
        {
            t += Time.fixedDeltaTime;
            Mathf.Clamp01(t);

            Anim();
        }
    }

    void Anim()
    {
        thisText.color = new Color(thisText.color.r, thisText.color.g, thisText.color.b, Mathf.Lerp(0, 1, t));
        thisText.transform.position = new Vector3(thisText.transform.position.x, Mathf.Lerp(thisText.transform.position.y + 3, thisText.transform.position.y, t), thisText.transform.position.z);

    }
}
