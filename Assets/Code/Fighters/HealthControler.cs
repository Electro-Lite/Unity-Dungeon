using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthControler : MonoBehaviour
{
    public int health;
    public int MaxHealth;
    public Image[] Bars;
    public Sprite FullBars;


    private void Update()
    {   //ne víc než max health
        if (health> MaxHealth)
            {
            health = MaxHealth;
            }

        for(int i=0 ; i < Bars.Length ; i++)
        {



            if (i < health)
            {
                Bars[i].enabled = true;

            }
            else
            {
                Bars[i].enabled = false;
            }
        }
    }
    private void HealthSync(){
      string RelativeFigheter = this.name;
      if (RelativeFigheter=="Barbarian") {TurnController.BarbarianHealth=health;}
      else if (RelativeFigheter=="Druid") {TurnController.DruidHealth=health;}
      else if (RelativeFigheter=="Huntress") {TurnController.HuntressHealth=health;}
      else if (RelativeFigheter=="Thief") {TurnController.ThiefHealth=health;}
    }
    private void HealthChange(int HealthChange)
    {
        health += HealthChange;
        HealthSync();
        Update();
        GameObject.Find("EndTurnButton").SendMessage("PlayerDeathCheck");
    }
          void Awake(){HealthSync();}

}
