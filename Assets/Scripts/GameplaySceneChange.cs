using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplaySceneChange : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && playerController.dead)
        {
            SceneManager.LoadScene("GamePlay");
        }
        if (Input.GetKey(KeyCode.I) && playerController.dead)
        {
            SceneManager.LoadScene("Instructions");
        }

    }
}
