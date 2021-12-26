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
    float jumpForce;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        speed = 1;
        maxSpeed = 4f;
        jumpForce = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        desplX = Input.GetAxis("Horizontal");
        if (alive)
        {
            Saltar();
            Correr();
        }
        print(rb2D.velocity.x);
    }
    private void FixedUpdate()
    {
        if (alive)
        {
            Andar();
            Giro(desplX);
        }
        
    }


    void Andar()//Descomentar Animator cuando esten los spirtes
    {
        rb2D.velocity = new Vector2(desplX * maxSpeed, rb2D.velocity.y);   //Mantener velocidad en el aire y moverse sin que afecte(Movimiento en el aire)
        speed = rb2D.velocity.x;
        speed = Mathf.Abs(speed);
        //animator.SetFloat("Andar", speed);
    }

    void Saltar()//Cuando esten las animaciones descomentar todo y comprobar si funciona
    {
        if (Input.GetKeyDown(KeyCode.Space) /*&& animator.GetBool("IsGrounded")*/)//Animacion de saltar//Cojer datos del animator
        {
            rb2D.AddForce(new Vector2(0f, 1f) * jumpForce, ForceMode2D.Impulse);//Aplicamos fuerza para que pueda saltar
            //animator.SetTrigger("Jump");//Cambio de animaciones
        }
        /*Debug.DrawRay(transform.position, Vector2.down * distanciaSuelo, Color.red); //Dibuja la linea de deteccion
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanciaSuelo);//Detecta si hay algo en su camino
        if (hit.collider != null)//Si el collider esta no hay nada //Animacion de cambio de caer a correr
        {
            animator.SetBool("IsGrounded", true);

        }
        else
        {
            animator.SetBool("IsGrounded", false);
        }*/
    }
    void Giro(float horizontal)//Scrip para que cambie de direccion dependiendo de a que direccion se mueva
    {
        if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    void Correr()//Cuando haya animaciones descomentar y comprobar
    {
        speed = rb2D.velocity.x;
        if (Input.GetKeyDown(KeyCode.LeftControl) && Mathf.Abs(speed) > 0)
        {
            //animator.SetBool("Run", true);
            maxSpeed = 6.5f;
            
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            //animator.SetBool("Run", false);
            maxSpeed = 4f;
        }
    }
}
