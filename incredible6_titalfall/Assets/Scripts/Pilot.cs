using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pilot : MonoBehaviour
{
    [HideInInspector]
    public int health;
    [HideInInspector]
    public int primaryweapon;
    [HideInInspector]
    public int heavyweapon;
    [HideInInspector]
    public int titanfall;


    public bool canCallTitan = false;
    public bool calledTitan = false;
    public bool isTitan = false;
    public bool increaseHealth = false;

    public float timePassed = 0;
    public float prevTime = 0;

    private GameObject Global;


    void Start()
    {
        Global = GameObject.Find("GlobalVars");
        primaryweapon = Global.GetComponent<GlobalVars>().primaryweapon;
        heavyweapon = Global.GetComponent<GlobalVars>().heavyweapon;
        health = 50;
        titanfall = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        timePassed += Time.deltaTime;

        if(( (int) timePassed) >= 3) {
            increaseHealth = true;
            health += 5;
            prevTime = ((int) timePassed);
        }

        if(increaseHealth && (((int) timePassed) - prevTime) >= 1) {
            health += 5;
            prevTime = ((int) timePassed);
        }

        if(health >= 100) {
            health = 100;
        }

        if(health <= 0 ) {
            killed();
        }


        if( titanfall >= 100){
            titanfall = 100;
            canCallTitan = true;
        }

        if (!isTitan && canCallTitan && Input.GetKeyDown(KeyCode.Q)) {
            callTitan();
        }

        if (!isTitan && calledTitan  && Input.GetKeyDown(KeyCode.E)) {
            embarkTitan();
        }
        
    }

    void reload(){
        // call currWeapon.reload
    }

    public void killedPilot(){
        titanfall += 10;
    }

    public void killedTitan(){
        titanfall += 50;
    }

    public void callTitan(){
        titanfall = 0;
        canCallTitan= false;
        calledTitan = true;

        // Calls titan
    }
    public void embarkTitan(){
        isTitan = true;
        calledTitan = false;
        
    }
    public void damage(int damage){
        timePassed = 0;
        prevTime = 0;
        increaseHealth = false;
        health -= damage;

    }
    public void killed() {
        SceneManager.LoadScene("Game Over");
    }

}
