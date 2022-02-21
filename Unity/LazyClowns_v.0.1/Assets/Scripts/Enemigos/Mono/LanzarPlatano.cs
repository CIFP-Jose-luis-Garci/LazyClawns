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
        Vector3 instPos = transBanana.TransformPoint(Vector3.zero);
        
        Instantiate(piel, transPiel.TransformPoint(Vector3.zero), Quaternion.identity);
        Instantiate(banana, transBanana.TransformPoint(Vector3.zero), Quaternion.identity);
    }


}
