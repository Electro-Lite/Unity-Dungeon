using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class OpponentInstantiator : MonoBehaviour
{
    void Start()
    {
      string CurrentOpponent=PlayerPrefs.GetString("CurrentOpponent");

      if (CurrentOpponent.IndexOf("Vlkodlak")>=0) {CurrentOpponent="Vlkodlak";}
      else if (CurrentOpponent.IndexOf("Vlk")>=0) {CurrentOpponent="Vlk";}
      else if (CurrentOpponent.IndexOf("Spider")>=0) {CurrentOpponent="Spider";}
      else if (CurrentOpponent.IndexOf("Troll")>=0) {CurrentOpponent="Troll";}
      else if (CurrentOpponent.IndexOf("SkeleSword")>=0) {CurrentOpponent="SkeleSword";}
      else if (CurrentOpponent.IndexOf("SkeleSpear")>=0) {CurrentOpponent="SkeleSpear";}
      else if (CurrentOpponent.IndexOf("Ghost")>=0) {CurrentOpponent="Ghost";}
      else if (CurrentOpponent.IndexOf("Minotaur")>=0) {CurrentOpponent="Minotaur";}
      else if (CurrentOpponent.IndexOf("Lava")>=0) {CurrentOpponent="Lava";}
      else if (CurrentOpponent.IndexOf("Drak")>=0) {CurrentOpponent="Drak";}
      else if (CurrentOpponent.IndexOf("Chapadl")>=0) {CurrentOpponent="Chapadla";}

      Debug.Log(CurrentOpponent+" =CurrentOpponent");
      UnityEngine.Object prefab = Resources.Load("Loot/OpponentsPrefab/"+CurrentOpponent, typeof(GameObject));
      if (prefab!=null) {
        GameObject player = Instantiate(prefab,this.transform) as GameObject;
        player.transform.SetParent(this.transform);
        player.name=CurrentOpponent;
      }
    }


}
