using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class pause : MonoBehaviour
{
    public static bool option = false;
    public static bool gameov = false;
    public GameObject pausemenu;
    public Button restartbutton;
    public Button resumetbutton;
    public Button menubutton;
  
    // Start is called before the first frame update
    void Start()
    {
      
        resumetbutton.onClick.AddListener(Resume);
        restartbutton.onClick.AddListener(Play);
        if (menubutton)
            menubutton.onClick.AddListener(Menu);
    }

    // Update is called once per frame
    void Update()
    {

        //Save stuff
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Resume();
            }
            else
            {
                Pause();

            }


        }


    }
    public void Pause()
    {
        //SceneManager.LoadScene("pause");
        // Time.timeScale = 1f;
        pausemenu.SetActive(true);
        Time.timeScale = 0;
        option = false;
   

    }
    public void Resume()
    {
        //SceneManager.LoadScene("play");
        pausemenu.SetActive(false);
        Time.timeScale = 1;
        option = false;

    
    }
    public void Play()
    {
        Debug.Log("hena");
        SceneManager.LoadScene("start");
        Time.timeScale = 1f;
        gameov = false;



    }
    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
        option = false;

    }
    public void Quit()
    {
        Application.Quit();

    }

}


