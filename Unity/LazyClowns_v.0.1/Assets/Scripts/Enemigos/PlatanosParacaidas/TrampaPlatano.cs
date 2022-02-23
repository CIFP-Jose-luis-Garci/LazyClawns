using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaPlatano : MonoBehaviour
{
    [SerializeField] GameObject instanciador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            instanciador.SendMessage("ActivarTrampa");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            instanciador.SendMessage("DesactivarTrampa");
        }
    }

}
