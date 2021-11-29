using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }


    void Movimiento()
    {
        float desphX = Input.GetAxis("Horizontal");
        float desphV = Input.GetAxis("Vertical");
        rb.AddForce(Vector3.left * desphX * speed);
        rb.AddForce(Vector3.back * desphV * speed);

    }
}
