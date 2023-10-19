using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class HuntressScript : MonoBehaviour
{
  public static bool HuntressActionReady=true;

  void Awake(){
      UnityEngine.Object prefab = Resources.Load("Loot/FightersImagePrefabs/"+"HuntressImage"+PlayerPrefs.GetString("FightLocation"), typeof(GameObject));
      if (prefab!=null) {
        GameObject player = Instantiate(prefab,this.transform) as GameObject;
        player.transform.SetParent(this.transform);
        player.name="HuntressImage";
      }
  }
  public void ActionSwitch(){HuntressActionReady=false;}
  public void Fire(string action){
    //check enemy count
    if (HuntressActionReady==true) {
      this.transform.Find("Equipment").transform.Find("Bow").gameObject.SendMessage("ItemPower",action);
      GameObject.Find("Fighters").SendMessage("Switch","Druid");
    }
  }
}
