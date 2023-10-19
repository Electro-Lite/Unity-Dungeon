using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VlkodlakScript : MonoBehaviour
{
  // Start is called before the first frame update

public void WarewolfClaw(){
      for (int i =0; i!=6; i++) {
        GameObject.Find("Canvas/Dices/Button").SendMessage("DiceRoller");
      }
  }

  public void OpponentTurnIniciator(){
    WarewolfClaw();
    GameObject.Find("EndTurnButton").SendMessage("EndTurn",true);
  }

  void Start(){
    TurnController.OpponentHealth=2;
    GameObject.Find("EndTurnButton").SendMessage("OpponentNameReciever","Vlkodlak");//give oponent name to TurnController to memory unit
  }


}
