using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioBarraVida : MonoBehaviour
{
    [SerializeField] Texture[] barraVida;
    [SerializeField] RawImage imagen;
    private PlayerMove spriteRender;
    int numSkin;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GameObject.Find("Player").GetComponent<PlayerMove>();
        numSkin = spriteRender.skinSelected;
    }

    // Update is called once per frame
    void Update()
    {
        CambioSkin();
        numSkin = spriteRender.skinSelected;
    }

    void CambioSkin()
    {
        if(numSkin == 0)
        {
            imagen.texture = barraVida[0];
        }
        if(numSkin == 1)
        {
            imagen.texture = barraVida[1];
        }
        if(numSkin == 2)
        {
            imagen.texture = barraVida[2];
        }
        if(numSkin == 3)
        {
            imagen.texture = barraVida[3];
        }
    }
}
