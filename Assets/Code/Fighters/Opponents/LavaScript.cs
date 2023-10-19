using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
  // Start is called before the first frame update
  public void LavaBite(){
        GameObject.Find("Canvas/Dices/Button").SendMessage("LavaPower");
  }

  public void OpponentTurnIniciator(){
    LavaBite();
    StartCoroutine(EndTurn());
  }
  IEnumerator EndTurn(){
    yield return new WaitForSeconds(5);
    GameObject.Find("EndTurnButton").SendMessage("EndTurn",true);
  }

  void Start(){
    TurnController.OpponentHealth=2;
    GameObject.Find("EndTurnButton").SendMessage("OpponentNameReciever","Lava");//give oponent name to TurnController to memory unit
  }
}
