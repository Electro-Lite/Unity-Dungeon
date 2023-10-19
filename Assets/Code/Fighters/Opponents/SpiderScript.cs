using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    // Start is called before the first frame update

  public void SpiderBite(){
        GameObject.Find("Canvas/Dices/Button").SendMessage("SpiderPower");
    }

    public void OpponentTurnIniciator(){
      SpiderBite();
      GameObject.Find("EndTurnButton").SendMessage("EndTurn",true);
    }

    void Start(){
      TurnController.OpponentHealth=2;
      GameObject.Find("EndTurnButton").SendMessage("OpponentNameReciever","Spider");//give oponent name to TurnController to memory unit
    }


    // Update is called once per frame

}
