using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    //Variables necesarias para la opci�n de suavizado
    [SerializeField] float smoothVelocity = 0.3F;
    [SerializeField] Vector3 camaraVelocity = Vector3.zero;

    float offsetY = 1f;
    void FixedUpdate()
    {
        //Con este c�digo, conseguimos que siga al objeto pero con suavidad
        //La velocidad de suavizado, cuanto menor sea m�s brusco ser� el movimiento
        Vector3 targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y + offsetY, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);
        //Opcional: que la c�mara mire al objeto (la c�mara no puede ser ortogr�fica)
        //transform.LookAt(playerPosition);
    }
}
    
