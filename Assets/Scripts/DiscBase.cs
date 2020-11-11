using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscBase : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float discSpeed;

    [SerializeField] float bounces, bouncesMax;

    [SerializeField] SpriteRenderer spr;

    [SerializeField] TrailRenderer trl;

    [SerializeField] PlayerController playerController;

    [SerializeField] GameObject player;

    [SerializeField] AudioSource bounceSound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerController.dead)
        {
            rb.velocity = rb.velocity.normalized * discSpeed * Time.fixedDeltaTime;
        }
        else if (playerController.dead)
        {
            rb.velocity = rb.velocity.normalized * discSpeed * Time.fixedDeltaTime * 0;

        }
    }

    private void Update()
    {
        if (gameObject.tag == "Player Disc")
        {
            spr.color = Color.white;
        }

        if (gameObject.tag == "Enemy Disc")
        {
            spr.color = Color.black;
        }

        trl.startColor = spr.color;
        trl.startWidth = transform.localScale.x;
        trl.endWidth = trl.startWidth / 2;
        trl.time = transform.localScale.x/3;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Boundary"))
        {
            bounces++;
            Instantiate(bounceSound);
            if (bounces >= bouncesMax)
            {
                Destroy(gameObject);
            }

            if (gameObject.tag == "Player Disc")
            {
                gameObject.tag = "Enemy Disc";

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Disc Changer"))
        {
            if (gameObject.tag == "Player Disc")
            {
                gameObject.tag = "Enemy Disc";

            }
            else if (gameObject.tag == "Enemy Disc")
            {
                gameObject.tag = "Player Disc";

            }
        }
    }
}
