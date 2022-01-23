using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleIntanciador : MonoBehaviour
{

    public int damage = 30;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Eliminar", 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().TakeDamage(damage);

        }
        Destroy(gameObject);


    }
    void Eliminar()
    {
        Destroy(gameObject);
    }

}
