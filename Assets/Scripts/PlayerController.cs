using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool moveUp, moveDown, moveLeft, moveRight;
    [SerializeField] float moveSpeed;

    [SerializeField] float lives;
    public float timer;
    public bool dead;

    public int enemyScore;

    [SerializeField] CreateDiscChanger cdc;

    [SerializeField] Text timerText, enemyScoreText, gameOverTimeText, gameOverEnemyScoreText, bestTimeText, bestScoreText, newBestTimeText, newBestScoreText;
    [SerializeField] AudioSource death;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        newBestScoreText.enabled = false;
        newBestTimeText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        timerText.text = timer.ToString();
        enemyScoreText.text = enemyScore.ToString();
        gameOverTimeText.text = timer.ToString();
        bestTimeText.text = UIValues.BestTime.ToString();
        bestScoreText.text = UIValues.BestEnemyScore.ToString();
    }

    private void FixedUpdate()
    {

        if (!dead)
        {
            Move();

            timer += Time.deltaTime;
        }

        if (dead)
        {
            rb.velocity = Vector2.zero;
        }
    }

    void Move()
    {
        if (moveLeft)
        {
            rb.AddForce(Vector2.left * moveSpeed * Time.fixedDeltaTime);

        }
        else if (moveRight)
        {
            rb.AddForce(Vector2.right * moveSpeed * Time.fixedDeltaTime);

        }

        if (moveUp)
        {
            rb.AddForce(Vector2.up * moveSpeed * Time.fixedDeltaTime);

        }
        else if (moveDown)
        {
            rb.AddForce(Vector2.down * moveSpeed * Time.fixedDeltaTime);

        }
        rb.velocity = Vector2.zero;
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveUp = true;
        }
        else
        {
            moveUp = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDown = true;
        }
        else
        {
            moveDown = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Enemy Disc"))
        {
            Instantiate(death);
            dead = true;
            lives--;

            if(timer > UIValues.BestTime)
            {
                UIValues.BestTime = timer;
                newBestTimeText.enabled = true;
            }
            gameOverEnemyScoreText.text = enemyScore.ToString();

            if (enemyScore > UIValues.BestEnemyScore)
            {
                UIValues.BestEnemyScore = enemyScore;
                newBestScoreText.enabled = true;
            }

        }

        if (col.gameObject.CompareTag("Disc Changer"))
        {
            Destroy(col.gameObject);
            cdc.changers--;
        }

    }
}
