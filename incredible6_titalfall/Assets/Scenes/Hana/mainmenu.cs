using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class mainmenu : MonoBehaviour
{
   
    
    public Button playbutton;
    public Button quitbutton;
    public Button howtobutton;
    public Button creditsbutton;

    // Start is called before the first frame update
    void Start()
    {

        quitbutton.onClick.AddListener(Quit);
        playbutton.onClick.AddListener(Play);
        howtobutton.onClick.AddListener(howto);
        creditsbutton.onClick.AddListener(credits);

    }

    // Update is called once per frame
    void Update()
    {

    }
   
    public void Play()
    {
      
        SceneManager.LoadScene("start");
        Time.timeScale = 1f;
       


    }
    public void howto()
    {
        SceneManager.LoadScene("howto");
        Time.timeScale = 1f;
     

    }

    public void credits()
    {
        SceneManager.LoadScene("credits");
        Time.timeScale = 1f;


    }
    public void Quit()
    {
        Application.Quit();

    }

}


