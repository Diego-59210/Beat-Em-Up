using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    [SerializeField] private GameObject BotonPausa;
    [SerializeField] private GameObject MenuPausa;
    private bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                reanudar(); 
            }

            else
            {
                pausa();
            }
        }
         
                
    }
    public void pausa()
    {
        
        Time.timeScale = 0f;
        BotonPausa.SetActive(false);
        MenuPausa.SetActive(true);
    }
    public void reanudar()
    {
        Time.timeScale = 1f;
        BotonPausa.SetActive(true);
        MenuPausa.SetActive(false);
    }
    public void reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void cerrarJuego()
    {
        Debug.Log("Se ta cerrando el game xd");
        Application.Quit();
    }

}

