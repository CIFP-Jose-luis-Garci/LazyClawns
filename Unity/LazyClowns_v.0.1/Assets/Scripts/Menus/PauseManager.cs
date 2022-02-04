using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    InputSystem action;

    public static bool paused = false;
    [SerializeField] GameObject pauseMenu;

    public static bool inventario = false;
    [SerializeField] GameObject inventory;

  
    private void Awake()
    {
        action = new InputSystem();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        paused = true;
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        paused = false;
        pauseMenu.SetActive(false);
    }
    public void PauseInventory()
    {
        Time.timeScale = 0f;
        inventario = true;
        inventory.SetActive(true);
    }
    public void ResumeInventory()
    {
        Time.timeScale = 1f;
        inventario = false;
        inventory.SetActive(false);
    }
    private void Start()
    {
        //pauseMenu = GameObject.Find("Pause");
        //inventory = GameObject.Find("Inventario");

        action.Pausa.Pause.started += ctx => DeterminedPause();
        action.Pausa.Inventario.performed += ctx => DeterminedInventory();

        pauseMenu.SetActive(false);
        inventory.SetActive(false);
    }

    private void Update()
    {
        
    }
    private void DeterminedPause()
    {
        if (!paused)
        {
            PauseGame();



        }
        else
        {
            ResumeGame();



        }

        pauseMenu.SetActive(paused);
    }

    private void DeterminedInventory()
    {
        if (!inventario)
        {
            PauseInventory();



        }
        else
        {
            ResumeInventory();



        }

        inventory.SetActive(inventario);
    }
    public void Continuar()
    {
        Time.timeScale = 1f;
        paused = false;
        pauseMenu.SetActive(false);
    }

    private void OnEnable()//Importantisimo para el funcionamiento del nuevo input system
    {
        action.Enable();
    }

    private void OnDisable()//Importantisimo para el funcionamiento del nuevo input system
    {
        action.Disable();
    }
}
