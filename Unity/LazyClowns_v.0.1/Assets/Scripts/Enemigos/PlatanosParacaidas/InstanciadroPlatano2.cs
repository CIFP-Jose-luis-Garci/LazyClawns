using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadroPlatano2 : MonoBehaviour
{
    [SerializeField] GameObject PlatanoParacaidas;
    [SerializeField] Transform instantiatePosicion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivarTrampa()
    {
        StartCoroutine("Instanciador");
        print("trampa");
    }
    public void DesactivarTrampa()
    {
        StopCoroutine("Instanciador");
        print("salirTrampa");
    }


    IEnumerator Instanciador()
    {
        while (true)
        {
            float randomX;



            randomX = Random.Range(-273f, -300);



            Vector3 newPos = new Vector3(randomX, instantiatePosicion.position.y, instantiatePosicion.position.z);
            Instantiate(PlatanoParacaidas, newPos, Quaternion.identity);

            yield return new WaitForSeconds(3);
        }







    }

}
