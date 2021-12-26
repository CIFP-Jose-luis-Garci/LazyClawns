using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb2D;


    bool alive = true;
    float desplX;
    float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        speed = 1;
        maxSpeed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        desplX = Input.GetAxis("Horizontal");
        
    }
    private void FixedUpdate()
    {
        if (alive)
        {
            Andar();
        }
        
    }


    void Andar()//Descomentar Animator cuando esten los spirtes
    {
        rb2D.velocity = new Vector2(desplX * maxSpeed, rb2D.velocity.y);   //Mantener velocidad en el aire y moverse sin que afecte(Movimiento en el aire)
        speed = rb2D.velocity.x;
        speed = Mathf.Abs(speed);
        //animator.SetFloat("Andar", speed);
    }
}
