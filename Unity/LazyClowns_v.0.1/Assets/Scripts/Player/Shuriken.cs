using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageDistancia = 30;
    void Start()
    {
        //transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 6f * Time.deltaTime);
       Invoke("Eliminar", 10F);
    }
    void Eliminar()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Enemy")
        {
            collision.GetComponent<EnemyController>().TakeDamage(damageDistancia);
            Destroy(gameObject);
        }
        
    }
}
