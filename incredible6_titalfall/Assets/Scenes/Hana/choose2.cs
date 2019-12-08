using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class choose2 : MonoBehaviour
{
    public Button w1tbutton;
    public Button w2tbutton;
    int start;
    static public int heavyweapon;
    // Update is called once per frame
    void Start()
    {
        w1tbutton.onClick.AddListener(w1);
        w2tbutton.onClick.AddListener(w2);
      
    }
    void Update()
    {
        
        int prevweapon = heavyweapon;
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (heavyweapon >= transform.childCount - 1)
                heavyweapon = 0;
            else if (heavyweapon <= 0)
                heavyweapon = transform.childCount-1;
            else
                heavyweapon++;
        }
        if (prevweapon != heavyweapon)
        {
            switchWeapons();
        }
        if (start == heavyweapon)
        {
            switchWeapons();
        }
    }

    void switchWeapons()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == heavyweapon)

                weapon.gameObject.SetActive(true);

            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }


    public void w1()
    {

        SceneManager.LoadScene("start 3");
        Time.timeScale = 1f; ;
        heavyweapon = 1;
        start = heavyweapon;
        Debug.Log(heavyweapon);
    }
    public void w2()
    {
       
      SceneManager.LoadScene("start 3");
        Time.timeScale = 1f;
        heavyweapon = 2;
        start = heavyweapon;
        Debug.Log(heavyweapon);
       
    }
 

}