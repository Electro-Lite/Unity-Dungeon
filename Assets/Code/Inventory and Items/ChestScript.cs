﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
  public GameObject[] Slots;
  public GameObject LootHolder;
  private string Dungeon;
  private string ItemLevel;
  private string[] ItemType={"Axe","Bow","Staff","Daggers"};
  private string ChestType;
  private int SlotOrder=0;
  private bool ValidLoot=false;
  int x;
  bool Used = false;

  public void Initiate(){
    if (Used==false) {
    ResetChest();
    PlaceLoot();
    Used=true;
    Debug.Log("chest Initialization succesfull");
    }
    LootHolder.SetActive(true);
  }

  public void PlaceLoot(){
    while(ValidLoot==false){
      ChestType=this.name;
      if (ChestType.IndexOf("Forest")>0) {ItemLevel="Common";}
      else if (ChestType.IndexOf("Kat")>0) {ItemLevel="Rare";}
      else if (ChestType.IndexOf("Lava")>0){ItemLevel="Epic";}
      else{Debug.Log("loot manager failed at determining ChestType");}

      x=  Random.Range(1, 10);
      if (x==9) {
        if (ItemLevel=="Common") {ItemLevel="Rare";}
        if (ItemLevel=="Rare") {ItemLevel="Epic";}
      } else if (x==8) {
        if (ItemLevel=="Common") {ItemLevel="Starting";}
        if (ItemLevel=="Rare") {ItemLevel="Common";}
        if (ItemLevel=="Epic") {ItemLevel="Rare";}
    }
    x= Random.Range(0, 4);
    if (ItemLevel=="Epic" & x==1) {ValidLoot=false;}
    else if (ItemLevel=="Epic" & x==2) {ValidLoot=false;}
    else if (ItemLevel=="Epic" & x==0) {ValidLoot=false;}
    else{ValidLoot=true;Debug.Log(ItemLevel+ItemType[x]+" is valid loot");}
  }
    Debug.Log(ItemLevel+ItemType[x]+" is to be set as loot");
    UnityEngine.Object prefab = Resources.Load("Loot/"+ItemLevel+ItemType[x], typeof(GameObject));
    if (prefab!=null) {
      Debug.Log("actually gonna try Placing Loot");
      Slots[SlotOrder].SetActive(true);
      GameObject player = Instantiate(prefab,Slots[SlotOrder].transform) as GameObject;
      player.transform.SetParent(Slots[SlotOrder].transform);
      player.name=(ItemLevel+ItemType[x]);
      SlotOrder++;
      x=  Random.Range(1, 10);
      if (x==10) {PlaceLoot();}
    }
  }

  private void ResetChest(){
    Used=false;
    ValidLoot=false;
    SlotOrder=0;
    for (int i=0; i!=4; i++) {
      if (Slots[i].transform.childCount>=1) {
        Slots[i].SetActive(false);
        Destroy(Slots[i].transform.GetChild(0).gameObject);
      }
    }
  }

}
