using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] Transform instanciador1;
    [SerializeField] Transform instanciador2;
    [SerializeField] Transform instanciador3;
    [SerializeField] Transform instanciador4;
    [SerializeField] Transform instanciador5;
    [SerializeField] GameObject pinchoSuelo;
    [SerializeField] GameObject pinchoPlat;

    // Update is called once per frame
    void Start()
    {
        Vector3 instPos1 = instanciador1.TransformPoint(Vector3.zero);
        Vector3 instPos2 = instanciador2.TransformPoint(Vector3.zero);
        Vector3 instPos3 = instanciador3.TransformPoint(Vector3.zero);
        Vector3 instPos4 = instanciador4.TransformPoint(Vector3.zero);
        Vector3 instPos5 = instanciador5.TransformPoint(Vector3.zero);
        StartCoroutine("pinchosInstan");
    }

    IEnumerator pinchosInstan()
    {
        while (true)
        {
            int numA = Random.Range(0, 4);
            if (numA == 0)
            {
                Instantiate(pinchoSuelo, instanciador1.TransformPoint(Vector3.zero), Quaternion.identity);
            }  
            if (numA == 1)
            {
                Instantiate(pinchoPlat, instanciador2.TransformPoint(Vector3.zero), Quaternion.identity);
            }  
            if (numA == 2)
            {
                Instantiate(pinchoPlat, instanciador3.TransformPoint(Vector3.zero), Quaternion.identity);
            }  
            if (numA == 3)
            {
                Instantiate(pinchoPlat, instanciador4.TransformPoint(Vector3.zero), Quaternion.identity);
            }  
            if (numA == 4)
            {
                Instantiate(pinchoPlat, instanciador5.TransformPoint(Vector3.zero), Quaternion.identity);
            }
           
            yield return new WaitForSeconds(1);
        }

       
    }

}
