using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
  public GameObject FightEnter;
    private void Start(){FightEnter.SetActive(false);}

    public void FightEnterSwitch(bool SetTo){
      if (SetTo==true) {
        FightEnter.SetActive(true);
      }else{
        FightEnter.SetActive(false);
      }
    }

    void OnCollisionEnter2D(Collision2D CollisionInfo){
      string TargetTag=CollisionInfo.collider.tag;
      PlayerPrefs.SetString("FightLocation",CollisionInfo.collider.tag);
      Debug.Log(PlayerPrefs.GetString("FightLocation",CollisionInfo.collider.tag));
      if (CollisionInfo.collider.tag=="Forest") {EnterFightSet(CollisionInfo.collider.name);}
      if (CollisionInfo.collider.tag=="Kats")   {EnterFightSet(CollisionInfo.collider.name);}
      if (CollisionInfo.collider.tag=="Lava")   {EnterFightSet(CollisionInfo.collider.name);}
      //Interaktivní elementy
      if (CollisionInfo.collider.tag=="Interactive"){
        if (CollisionInfo.collider.name.IndexOf("Chest")>=0) {
          CollisionInfo.collider.transform.gameObject.SendMessage("Initiate");
          Debug.Log("Chest");
        }
      }

    }
    private void EnterFightSet(string OpponentName){
      PlayerPrefs.SetString("CurrentOpponent",OpponentName);
      FightEnter.SetActive(true);
      Movement.MovementEnabled=false;
    }
}
