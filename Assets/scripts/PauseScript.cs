using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PausaFinalUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Continuar();

            }
            else
            {
                Pausa();
            }
        }
    }
    public void Continuar()
    {
        PausaFinalUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pausa()
    {
        PausaFinalUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}