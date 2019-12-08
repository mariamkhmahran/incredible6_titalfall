using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class start : MonoBehaviour
{
   
    public Button w1tbutton;
    public Button w2tbutton;
    public Button w3button;

    // Start is called before the first frame update
    void Start()
    {

        w1tbutton.onClick.AddListener(w1);
        w2tbutton.onClick.AddListener(w2);
        w3button.onClick.AddListener(w3);
      //  if (menubutton)
        //    menubutton.onClick.AddListener(Menu);
    }

    // Update is called once per frame
    void Update()
    {

        //Save stuff
       


    }
   
    public void w1()
    {
        SceneManager.LoadScene("start 2");
        Time.timeScale = 1f; ;
    }
    public void w2()
    {
        SceneManager.LoadScene("start 2");
        Time.timeScale = 1f;
    }
    public void w3()
    {
        SceneManager.LoadScene("start 2");
        Time.timeScale = 1f;
    }


}


