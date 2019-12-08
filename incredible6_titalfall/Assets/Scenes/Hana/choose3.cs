using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class choose3 : MonoBehaviour
{
    public Button w1tbutton;
    public Button w2tbutton;
    public static string ResultText;
    //public static Text ResultText;
    public static int Titan;
   
    // Update is called once per frame
    void Start()
    {

      
      
        if (w1tbutton)
           
            w1tbutton.onClick.AddListener(w1);
          
        if (w2tbutton)
          
             w2tbutton.onClick.AddListener(w2);
      
    }

    void Update()
    {
       
    }

    public void w1()
    {

        Titan = 0;
        
        Time.timeScale = 1f; ;
        SceneManager.LoadScene("play");
        Debug.Log(Titan);
        ResultText = "You won!";
    }
    public void w2()
    {
        ResultText = "You lost!";
        Titan = 1;
        Time.timeScale = 1f;
        play.x = 1;
        SceneManager.LoadScene("play");
        Debug.Log(Titan);
    }
   

}