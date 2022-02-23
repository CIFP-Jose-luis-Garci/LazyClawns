using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageDistancia;
    public bool lookingRight;
    void Start()
    {
        //transform.parent = null;
        damageDistancia = VariablesPublicas.distanceDamage;
        lookingRight = GameObject.Find("Player").GetComponent<PlayerMove>().facingRight;
    }

    // Update is called once per frame
    void Update()
    {
        if (lookingRight)
        {
            transform.Translate(Vector2.right * 9f * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * 9f * Time.deltaTime);
            gameObject.transform.rotation = new Quaternion (0f, 180f, 0f,0f);
            
        }
        Invoke("Eliminar", 10F);
       
    }
    void Eliminar()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.name =="EnemyPatrol")
        {
            print("DADO");
            enemy.GetComponent<EnemyController>().TakeDamage(damageDistancia);
            Destroy(gameObject);
        }
        else if(enemy.name == "Monkey")
        {
            enemy.GetComponent<Controller>().TakeDamage(damageDistancia);
            Destroy(gameObject);
            print("DADO MONO");
        }

    }

  
}
