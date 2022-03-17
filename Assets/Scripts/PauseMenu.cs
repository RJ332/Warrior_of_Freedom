using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool GP = false;
    public GameObject pausemenuUI;
    //public GameObject StartGamemenuUI;
    public GameObject defmenuUI;
    public GameObject powerupUI;
    public int GP2 = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GP) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        GP = false;
    }

    public void Pause ()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GP = true;
    }

    public void LoadMenu()
    {
        pausemenuUI.SetActive(false);
        //StartGamemenuUI.SetActive(false);
        defmenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void ExitDef()
    {
        defmenuUI.SetActive(false);
        pausemenuUI.SetActive(true);
        //StartGamemenuUI.SetActive(true);
    } 

    public void ExitPM()
    {
        //pausemenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 0);
        Time.timeScale = 1f;
    }

    public void PowerupGame()
    {
        powerupUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
