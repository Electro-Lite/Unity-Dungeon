using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LootManager : MonoBehaviour
{
    // Start is called before the first frame update
  public GameObject[] Slots;
  private string Dungeon;
  private string ItemLevel;
  private string[] ItemType={"Axe","Bow","Staff","Daggers"};
  private string Location;
  private int SlotOrder=0;
  private bool ValidLoot=false;
  int x;

  public void Start(){
    while(ValidLoot==false){
      Location=PlayerPrefs.GetString("FightLocation");
      if (Location=="Forest") {ItemLevel="Common";}
      else if (Location=="Kats") {ItemLevel="Rare";}
      else if (Location=="Lava"){ItemLevel="Epic";}
      else{Debug.Log("loot manager failed at checking background");}

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
      if (x==10) {Start();}
    }
  }
}
