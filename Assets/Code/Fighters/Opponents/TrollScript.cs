using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollScript : MonoBehaviour
{
    // Start is called before the first frame update

  public void Club(){
        GameObject.Find("Canvas/Dices/Button").SendMessage("TrollPower");
    }

    public void OpponentTurnIniciator(){
      Club();
    }

    void Start(){
      DiceControler.DiceColor=new Color32(0,147,0,255);
      TurnController.OpponentHealth=3;
      GameObject.Find("EndTurnButton").SendMessage("OpponentNameReciever","Troll");//give oponent name to TurnController to memory unit
    }


    // Update is called once per frame

}
