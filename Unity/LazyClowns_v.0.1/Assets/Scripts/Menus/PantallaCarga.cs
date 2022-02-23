using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PantallaCarga : MonoBehaviour
{
    InputSystem inputCr;
    
    
    
    [SerializeField] Text cargarTexto;
    [SerializeField] Slider cargarSlider;

    bool cargar = false;

    private void Awake()
    {
        inputCr = new InputSystem();

        inputCr.Cargar.Pantalla.performed += ctx => { StartCoroutine(Cargar()); };
        //inputCr.Cargar.Pantalla.canceled += _ => { cargar = false; };
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cargar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Pantalla()
    {
        if (cargar)
        {
            StartCoroutine(Cargar());
        }

    }

    IEnumerator Cargar()
    {

        
        cargarSlider.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        AsyncOperation operationCargar = SceneManager.LoadSceneAsync(1);
        
        while (operationCargar.isDone == false)
        {
           
            float progreso = Mathf.Clamp01(operationCargar.progress / .00f);
            cargarSlider.value = progreso;
            cargarTexto.text = "" + progreso * 100 + "%";
            yield return null;
        }

        

    }
}
