using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cura : MonoBehaviour
{
    private PlayerMove playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerMove>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.CurarVida();
            
        }
       
    }
}
