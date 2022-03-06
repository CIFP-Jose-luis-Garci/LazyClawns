using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioSkinEscenas : MonoBehaviour
{

    PlayerMove player;
    int skinSelected;

    [SerializeField] Sprite [] deadSkin;
    [SerializeField] Image Jugador;

    // Start is called before the first frame update
    void Start()
    {
        skinSelected = PlayerMove.skinSelected;
        SeleccionSkin();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SeleccionSkin()
    {
        if(skinSelected == 0)
        {
            Jugador.sprite = deadSkin[0];
        }
        else if (skinSelected == 1)
        {
            Jugador.sprite = deadSkin[1];
        }
        else if (skinSelected == 2)
        {
            Jugador.sprite = deadSkin[2];
        }
        else if (skinSelected == 3)
        {
            Jugador.sprite = deadSkin[3];
        }
    }






}
