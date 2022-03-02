using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleIntanciador : MonoBehaviour
{

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = VariablesPublicas.meleeDamage;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Eliminar", 0.5f);
    }
    void Eliminar()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().TakeDamage(damage);

        }if (collision.gameObject.tag == "Monkey")
        {
            collision.GetComponent<Controller>().TakeDamage(damage);

        }
        Destroy(gameObject);


    }
    

}
