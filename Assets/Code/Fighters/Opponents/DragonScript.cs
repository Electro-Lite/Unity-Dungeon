using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void DragonsBreath(){
          GameObject.Find("Canvas/Dices/Button").SendMessage("DragonPower");
    }

    public void OpponentTurnIniciator(){
      DragonsBreath();
      StartCoroutine(EndTurn());
    }
    IEnumerator EndTurn(){
      yield return new WaitForSeconds(5);
      GameObject.Find("EndTurnButton").SendMessage("EndTurn",true);
    }

    void Start(){
      TurnController.OpponentHealth=5;
      DiceControler.DiceColor=new Color32(255,104,0,255);
      GameObject.Find("EndTurnButton").SendMessage("OpponentNameReciever","Drak");//give oponent name to TurnController to memory unit
    }
}
