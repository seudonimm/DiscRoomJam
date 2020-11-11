using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscShooter : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] Vector3 shooterDirection;
    [SerializeField] GameObject disc, bigDisc, growShrinkDisc;

    [SerializeField] float shotSpeed;
    [SerializeField] bool shoot;

    [SerializeField] int num;
    [SerializeField] float size, t, min, max, sizeChangeSpeed;

    [SerializeField] Transform nextShotDisplay;
    [SerializeField] GameObject displayDisc;
    [SerializeField] GameObject twoDisc;
    [SerializeField] GameObject discForDisplay, bigDiscForDisplay, growShrinkDiscForDisplay;

    [SerializeField] AudioSource shootSound;

    private StateMachine stateMachine = new StateMachine();

    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        num = RandomNumber(4);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Pulse();

    }

    private void FixedUpdate()
    {
        if (shoot)
        {
            ShootDisc();
            ShowNextDisc();

        }
    }

    void Pulse()
    {
        if (shoot)
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
        transform.localScale = new Vector3(size, size, size);

    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot = true;
        }
    }

    void ShootDisc()
    {
        Instantiate(shootSound);
        if (num == 0)
        {
            stateMachine.ChangeState(new StraightShot(disc, gameObject, shotSpeed));
        }

        if(num == 1)
        {
            stateMachine.ChangeState(new TwoAngledShot(disc, gameObject, shotSpeed));
        }

        if(num == 2)
        {
            stateMachine.ChangeState(new StraightShot(bigDisc, gameObject, shotSpeed/2));

        }
        
        if(num == 3)
        {
            stateMachine.ChangeState(new StraightShot(growShrinkDisc, gameObject, shotSpeed / 2));

        }

        shoot = false;
        num = RandomNumber(4);

    }

    void ShowNextDisc()
    {
        if(displayDisc != null)
        {
            Destroy(displayDisc);
        }
        if (num == 0)
        {
            displayDisc = Instantiate(discForDisplay, nextShotDisplay.transform.position, nextShotDisplay.transform.rotation);
        }

        if (num == 1)
        {
            displayDisc = Instantiate(twoDisc, nextShotDisplay.transform.position, nextShotDisplay.transform.rotation);
        }

        if (num == 2)
        {
            displayDisc = Instantiate(bigDiscForDisplay, nextShotDisplay.transform.position, nextShotDisplay.transform.rotation);

        }

        if (num == 3)
        {
            displayDisc = Instantiate(growShrinkDiscForDisplay, nextShotDisplay.transform.position, nextShotDisplay.transform.rotation);

        }
    }

    int RandomNumber(int num)
    {
        int rand = Random.Range(0, num);

        return rand;
    }
}
