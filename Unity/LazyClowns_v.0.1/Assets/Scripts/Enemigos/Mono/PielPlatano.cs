using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PielPlatano : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Invoke("Destruir", 3f);
    }

    void Destruir()
    {
        Destroy(gameObject);
    }
}
