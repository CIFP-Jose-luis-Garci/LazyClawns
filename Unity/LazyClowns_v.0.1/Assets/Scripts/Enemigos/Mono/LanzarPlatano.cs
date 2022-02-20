using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarPlatano : MonoBehaviour
{

    [SerializeField] GameObject piel;
    [SerializeField] GameObject banana;

    [SerializeField] Transform transPiel;
    [SerializeField] Transform transBanana;


    void Instanciar()
    {
        Instantiate(piel, transPiel);
        Instantiate(banana, transBanana);
    }


}
