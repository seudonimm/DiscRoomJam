using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<bool> positionsFilled;
    [SerializeField] List<GameObject> positions;
    [SerializeField] List<GameObject> enemyToPosition;

    [SerializeField] GameObject enemy;

    [SerializeField] float posNumber;
    [SerializeField] float timeUntilNextEnemy, timeUntilNextEnemyDefault;
    [SerializeField] GameObject player;
    [SerializeField] PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        //foreach(Transform child in this.gameObject.transform)
        //{
        //    positions.Add(child.gameObject);
        //}
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

        enemyToPosition = new List<GameObject>(new GameObject[positions.Capacity]);
        Debug.Log(positions.Capacity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerController.timer < 30)
        {
            SpawnEnemy();
        }
        if (playerController.timer > 30 && playerController.timer < 60)
        {
            SpawnEnemy();
            SpawnEnemy();
        }
        if (playerController.timer > 60 && playerController.timer < 120)
        {
            SpawnEnemy();
            SpawnEnemy();
            SpawnEnemy();

        }
        if (playerController.timer > 120)
        {
            SpawnEnemy();
            SpawnEnemy();
            SpawnEnemy();
            SpawnEnemy();

        }


    }

    void SpawnEnemy()
    {
        int pos;

        timeUntilNextEnemy -= Time.fixedDeltaTime;
        if (timeUntilNextEnemy <= 0 && posNumber < positionsFilled.Capacity)
        {

            posNumber++;
            //if (posNumber <= endlessShapes.positionFilled.Capacity)
            //{
            do
            {
                pos = RandomNumber(positions.Capacity);
            }
            while (positionsFilled[pos]);
            //target = endlessShapes.positions[pos].position;
            positionsFilled[pos] = true;

            enemyToPosition[pos] = Instantiate(enemy, positions[pos].transform.position, positions[pos].transform.rotation);

            timeUntilNextEnemy = timeUntilNextEnemyDefault;
        }
        CheckEnemies();

    }

    void CheckEnemies()
    {
        for (int i = 0; i < positions.Capacity; i++)
        {
            if (enemyToPosition[i] != null && enemyToPosition[i].GetComponent<EnemyController>().isDestroyed)
            {
                Destroy(enemyToPosition[i]);

                enemyToPosition[i] = null;
                Debug.Log("empty");
                positionsFilled[i] = false;
                posNumber--;


            }
        }
    }

    private void OnDisable()
    {
        //this array does not reset for some reason, this is to reset the values to false

        for (int i = 0; i < positionsFilled.Capacity; i++)
        {
            positionsFilled[i] = false;
        }
    }


    int RandomNumber(int num)
    {
        int rand = Random.Range(0, num);

        return rand;
    }
}
