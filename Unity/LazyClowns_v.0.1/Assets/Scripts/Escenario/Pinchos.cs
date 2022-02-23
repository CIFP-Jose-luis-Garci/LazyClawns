using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    [SerializeField] GameObject colliderPincho;

    void InctanciadorPinchos()
    {
        Instantiate(colliderPincho, transform.position, Quaternion.identity);
    }
    void DestruirPinchos()
    {
        Destroy(colliderPincho);
    }
}
