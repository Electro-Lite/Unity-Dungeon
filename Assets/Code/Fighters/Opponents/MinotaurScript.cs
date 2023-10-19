using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurScript : MonoBehaviour
{
  // Start is called before the first frame update
  //GhoulPower is used temporarily and should be replaced as soon as Ghould design is made
  public void Axe(){
    GameObject.Find("Canvas/Dices/Button").SendMessage("GhoulPower");
  }

  public void OpponentTurnIniciator(){
    Axe();
  }

  void Start(){
    TurnController.OpponentHealth=3;
    GameObject.Find("EndTurnButton").SendMessage("OpponentNameReciever","Minotaur");//give oponent name to TurnController to memory unit
  }
}
