using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoAgua : MonoBehaviour
{
    private PlayerMove playerHealth;
    private int damage;
    private void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerMove>();
        damage = 100;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }

    }
}
