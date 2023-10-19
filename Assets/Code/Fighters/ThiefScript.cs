using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ThiefScript : MonoBehaviour
{
  public static bool ThiefActionReady=true;

  void Awake(){
    UnityEngine.Object prefab = Resources.Load("Loot/FightersImagePrefabs/"+"ThiefImage"+PlayerPrefs.GetString("FightLocation"), typeof(GameObject));
    //Debug.Log(PlayerPrefs.GetString("FightLocation")+"  sup");
    if (prefab!=null) {
        //Debug.Log(this.name);
        GameObject player = Instantiate(prefab,this.transform) as GameObject;
        player.transform.SetParent(this.transform);
        player.name="ThiefImage";
        }
    }

  public void ActionSwitch(){ThiefActionReady=false;}
    public void UseDagger(){
      //check enemy count
    if (ThiefActionReady==true) {
        ThiefActionReady=false;
        GameObject.Find("Button").SendMessage("DiceRoller");
        GameObject.Find("Fighters").SendMessage("Switch","Huntress");
      }
    }
}
