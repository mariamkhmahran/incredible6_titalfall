using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public static GlobalVars Instance;
    public int primaryweapon;
    public int heavyweapon;
    public int titan;

    void Awake ()   
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        int prevweapon = primaryweapon;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            primaryweapon = (primaryweapon +1) == 4? 1 : primaryweapon + 1;
            // call amethod that changes the weapon in the weapon's script
        }
    }

    public void setPrimaryWeapon(int w) {
        primaryweapon = w;
    }

    public void setHeavyWeapon(int w) {
        heavyweapon = w;
    }

    public void setTitan(int w) {
        titan = w;
    }
}
