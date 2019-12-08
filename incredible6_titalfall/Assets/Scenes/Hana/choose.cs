using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class choose : MonoBehaviour
{
    public Button w1tbutton;
    public Button w2tbutton;
    public Button w3button;
    static  public int primaryweapon;
    private GameObject Global;

    // Update is called once per frame
    void Start()
    {
        w1tbutton.onClick.AddListener(w1);
        w2tbutton.onClick.AddListener(w2);
        w3button.onClick.AddListener(w3);
        Global = GameObject.Find("GlobalVars");
        //switchWeapons();
    }

    void Update()
    {
        int prevweapon = primaryweapon;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (primaryweapon >= transform.childCount - 1)
                primaryweapon = 0;
            else if (primaryweapon <= 0)
                primaryweapon = transform.childCount -2;
            else
                primaryweapon++;


        }
        if (prevweapon != primaryweapon)
        {
            switchWeapons();
        }

      
    }

    void switchWeapons()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == primaryweapon)

                weapon.gameObject.SetActive(true);

            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
    public void w1()
    {
       
        SceneManager.LoadScene("start 2");
        Time.timeScale = 1f; ;
        Global.GetComponent<GlobalVars>().setPrimaryWeapon(1);
        Debug.Log(primaryweapon);
    }
    public void w2()
    {
       
        SceneManager.LoadScene("start 2");
        Time.timeScale = 1f;
        Global.GetComponent<GlobalVars>().setPrimaryWeapon(2);
        Debug.Log(primaryweapon);
    }
    public void w3()
    {
        SceneManager.LoadScene("start 2");
        Time.timeScale = 1f;
        Global.GetComponent<GlobalVars>().setPrimaryWeapon(3);
        Debug.Log(primaryweapon);
    }

}