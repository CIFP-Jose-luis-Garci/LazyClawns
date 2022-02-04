using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{

    [SerializeField] Text volumenText;
    public float volumen;
    [SerializeField] Slider mySlider;

    

    // Start is called before the first frame update
    void Start()
    {
        mySlider.value = PlayerPrefs.GetFloat("volumenAudio", 1f);
        AudioListener.volume = mySlider.value;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Volumen(float valor)
    {
        volumen = valor;
        PlayerPrefs.SetFloat("volumenAudio", volumen);
        AudioListener.volume = mySlider.value;
    }


    public void CargarEscena(int escena)
    {
        Time.timeScale = 1f;
        PauseManager.paused = false;
        SceneManager.LoadScene(escena);
    }

    public void SubirVolumen()
    {
        volumen = (mySlider.value);
        volumenText.text = "VOLUMEN:" + volumen;
    }

    
}
