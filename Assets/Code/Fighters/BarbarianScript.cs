using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class BarbarianScript : MonoBehaviour
{
    public static bool BarbarianActionReady=true;
    void Awake(){
        UnityEngine.Object prefab = Resources.Load("Loot/FightersImagePrefabs/"+"BarbarianImage"+PlayerPrefs.GetString("FightLocation"), typeof(GameObject));
        if (prefab!=null) {
          GameObject player = Instantiate(prefab,this.transform) as GameObject;
          player.transform.SetParent(this.transform);
          player.name="BarbarianImage";
        }
      }

    public void ActionSwitch(){BarbarianActionReady=false; GameObject.Find("Fighters").SendMessage("Switch","Thief");}
    
    public void Rage(){
        if (TurnController.PlayerTurn==true) {
          GameObject.Find("Barbarian").SendMessage("HealthChange", -1);
          GameObject.Find("Canvas/Dices/Button").SendMessage("DiceRoller");
        }
    }



}
