using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActivacionBarraBoss : MonoBehaviour
{
    private PlayerMove playerHealth;
     BossCtr boss;
    [SerializeField] GameObject vidaBoss;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerMove>();
        boss = GameObject.Find("EnemyBoss").GetComponent<BossCtr>();
        vidaBoss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.currentHealth <= 0)
            vidaBoss.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.CurarVida();
            print("BarraBoss");
            vidaBoss.SetActive(true);
            
        }
    }
}
