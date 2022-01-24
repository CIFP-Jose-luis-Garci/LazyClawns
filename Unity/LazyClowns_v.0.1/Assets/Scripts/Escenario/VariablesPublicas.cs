using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesPublicas : MonoBehaviour
{
    public int saludMax;
    public static int saludCurrent;
    public static bool alive;
    public int vidas ;


    // Start is called before the first frame update
    void Start()
    {
        saludMax = 100;
        vidas = 3;
        saludCurrent = saludMax;
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        Morir();
        print(vidas);
    }
    void Morir()
    {
        if (saludCurrent <= 0)
        {
            Invoke("Reinicio", 1.5f);
            
        }
        if(vidas <= 0)
        {
            alive = false;
            print("Has Muerto");
        }
    }
    void Reinicio()
    {
        saludCurrent = saludMax;
        vidas--;
    }

}
