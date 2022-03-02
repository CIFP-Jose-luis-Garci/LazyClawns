using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    [SerializeField] GameObject colliderPincho;
    [SerializeField] Transform puntoDeSpawn;
    GameObject clone;
    

    void InctanciadorPinchos()
    {

        Vector3 instPos = puntoDeSpawn.TransformPoint(Vector3.zero);
       clone = Instantiate(colliderPincho, puntoDeSpawn.TransformPoint(Vector3.zero), Quaternion.identity);
       
    }
    void DestruirPinchos()
    {

        Destroy(clone);
    }
}
