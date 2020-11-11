using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] float adjustment;
    [SerializeField] GameObject player;
    [SerializeField] PlayerController playerController;

    [SerializeField] float timer, timerDefault;
    [SerializeField] GameObject disc, discSpawn;
    [SerializeField] float shotSpeed;

    [SerializeField] float size, t, min, max, sizeChangeSpeed;
    [SerializeField] bool pulseAnim;
    public bool isDestroyed;
    //[SerializeField] bool shoot;

    [SerializeField] ParticleSystem pS;

    [SerializeField] AudioSource shootSound;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerDefault;
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        RotateTowardsPlayer();

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            pulseAnim = true;
            if (playerController.timer < 30)
            {
                
            }
            if (playerController.timer > 30 && playerController.timer < 60)
            {
                timerDefault = 2.5f;
            }
            if (playerController.timer > 60 && playerController.timer < 120)
            {
                timerDefault = 2f;

            }
            if (playerController.timer > 120 && playerController.timer < 160)
            {
                timerDefault = 1.5f;

            }
            if (playerController.timer > 160)
            {
                timerDefault = 1f;

            }


            ShootDisc();
            timer = timerDefault;
        }

        Pulse();
    }

    void RotateTowardsPlayer()
    {
        //direction = (Vector2)target.transform.position - (Vector2)transform.position;
        direction = player.transform.position;
        var dir = direction - (Vector2)transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + adjustment;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    void ShootDisc()
    {
        Instantiate(shootSound);
        var shot = Instantiate(disc, discSpawn.transform.position, discSpawn.transform.rotation);
        Vector2 shotDir = transform.rotation * Vector2.up;
        shot.GetComponent<Rigidbody2D>().velocity = shotDir * shotSpeed * Time.fixedDeltaTime;
        //shoot = false;
    }
    void Pulse()
    {
        if (pulseAnim)
        {
            t = 1;
        }
        else
        {
            t -= Time.deltaTime * sizeChangeSpeed;
        }
        t = Mathf.Clamp01(t);
        size = Mathf.Lerp(min, max, t);
        //t = Mathf.PingPong(Time.time, 1);
        discSpawn.transform.localScale = new Vector3(size, size, transform.localScale.z);
        pulseAnim = false;

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player Disc"))
        {
            Instantiate(pS, transform.position, transform.rotation);
            isDestroyed = true;
            gameObject.SetActive(false);

            playerController.enemyScore++;
        }
    }
}
