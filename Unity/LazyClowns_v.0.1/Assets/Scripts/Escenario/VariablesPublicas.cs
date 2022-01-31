using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesPublicas : MonoBehaviour
{
    public int saludMax;
    public static int saludCurrent;
    public static bool alive;
    public int vidas ;
    public static int meleeDamage;
    public static int distanceDamage;


    // Start is called before the first frame update
    void Start()
    {
        saludMax = 100;
        vidas = 1;
        saludCurrent = saludMax;
        alive = true;
        meleeDamage = 30;
        distanceDamage = 15;
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
            alive = false;
            print("Has Muerto");

        }
        
    }
  

}
