using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDiscChanger : MonoBehaviour
{
    [SerializeField] GameObject discChanger;
    public int changers;
    [SerializeField] int changersMax;
    [SerializeField] Collider2D player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)){
            if (changers < changersMax)
            {
                Instantiate(discChanger, transform.position, transform.rotation);
                changers++;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Disc Changer"))
        {
            Destroy(col.gameObject);
            changers--;
        }
    }
}
