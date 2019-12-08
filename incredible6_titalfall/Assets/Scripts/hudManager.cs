using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudManager : MonoBehaviour
{
    public Canvas titan_hud;
    public Canvas pilot_hud;
    bool titan_on;

    // pilot
    public Slider pilot_health_bar;
    public Slider pilot_titanfall_bar;

    public Text pilot_ammo_textfield;
    public Text pilot_weapon_name_textfield;

    // reference player health here
    int pilot_health;
    int pilot_titanfall;

    int pilot_remaining_ammo = 100;
    int pilot_maximum_ammo = 400;
    string pilot_weapon_name = "Revolver";


    // titan
    public Slider titan_health_bar;
    public Slider titan_cooldown_bar;
    public Slider titan_core_ability_bar;


    public Image titan_dash_1;
    public Image titan_dash_2;
    public Image titan_dash_3;

    int titan_health = 100;

    int titan_cooldown = 0;
    int titan_remaining_dashes = 2;
    int titan_core_ability = 0;

    private GameObject pilot;
    private GameObject titan;




      void Start ()
      {
        displayPilotPanel();
      }

      void Update ()
    {
      // pilot updated
      if(!titan_on) 
      {
        // pilot_health -= 1;
        // pilot_remaining_ammo -=1;
        // pilot_titanfall +=1;
        pilot_health_bar.value = pilot_health;
        pilot_titanfall_bar.value = pilot_titanfall;
        pilot_ammo_textfield.text = pilot_remaining_ammo.ToString() + " |" +pilot_maximum_ammo.ToString();
        pilot_weapon_name_textfield.text = pilot_weapon_name;
      }
      else
      {
        // titan_health -=1;
        // titan_cooldown +=1;
        // titan_core_ability +=1;

        titan_health_bar.value = titan_health;
        titan_cooldown_bar.value = titan_cooldown;
        titan_core_ability_bar.value = titan_core_ability;

        if(titan_remaining_dashes == 2) {
          titan_dash_3.enabled = false;
          titan_dash_2.enabled = true;
          titan_dash_1.enabled = true;

        } else if(titan_remaining_dashes == 1) {
          titan_dash_3.enabled = false;
          titan_dash_2.enabled = false;
          titan_dash_1.enabled = true;

        } else if(titan_remaining_dashes == 0) {
          titan_dash_1.enabled = false;
          titan_dash_2.enabled = false;
          titan_dash_3.enabled = false;

        } else if(titan_remaining_dashes == 3) {
          titan_dash_3.enabled = true;
          titan_dash_2.enabled = true;
          titan_dash_1.enabled = true;
        }
      }

    }
    public void displayTitanPanel ()
    {
      pilot_hud.enabled = false;
      titan_hud.enabled = true;
      titan_on = true;
    }
     public void displayPilotPanel ()
    {
      pilot_hud.enabled = true;
      titan_hud.enabled = false;
      pilot = GameObject.FindGameObjectsWithTag("Pilot")[0];
      pilot_health = pilot.GetComponent<Pilot>().health;
      Debug.Log("pilot_health");
      
      Debug.Log(pilot_health);
      pilot_titanfall =  pilot.GetComponent<Pilot>().titanfall;
      titan_on = false;
    }
}
