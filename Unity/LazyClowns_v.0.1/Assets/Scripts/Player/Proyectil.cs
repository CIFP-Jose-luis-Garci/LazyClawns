using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 30;
    void Start()
    {
        //transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 1f * Time.deltaTime);
        //Invoke("Eliminar", 3f);
    }
    void Eliminar()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().TakeDamage(damage);

        }
        Destroy(gameObject);

    }
    
}
