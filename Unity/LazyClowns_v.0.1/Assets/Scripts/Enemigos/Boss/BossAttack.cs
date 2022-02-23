using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] GameObject instanciador1;
    [SerializeField] GameObject instanciador2;
    [SerializeField] GameObject instanciador3;
    [SerializeField] GameObject instanciador4;
    [SerializeField] GameObject instanciador5;
    [SerializeField] GameObject pinchoSuelo;
    [SerializeField] GameObject pinchoPlat;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine("pinchosInstan");
    }

    IEnumerator pinchosInstan()
    {
        while (true)
        {
            int numA = Random.Range(0, 4);
            if (numA == 0)
            {
                Instantiate(pinchoSuelo, instanciador1.transform);
            }  
            if (numA == 1)
            {
                Instantiate(pinchoPlat, instanciador1.transform);
            }  
            if (numA == 2)
            {
                Instantiate(pinchoPlat, instanciador1.transform);
            }  
            if (numA == 3)
            {
                Instantiate(pinchoPlat, instanciador1.transform);
            }  
            if (numA == 4)
            {
                Instantiate(pinchoPlat, instanciador1.transform);
            }
           
            yield return new WaitForSeconds(1);
        }

       
    }

}
