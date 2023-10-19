using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void SkeletonBone(){
          GameObject.Find("Canvas/Dices/Button").SendMessage("PowerUpdate",20);
    }
    public void OpponentTurnIniciator(){
      SkeletonBone();
      GameObject.Find("EndTurnButton").SendMessage("EndTurn",true);
    }

    void Start(){
      TurnController.OpponentHealth=2;
      GameObject.Find("EndTurnButton").SendMessage("OpponentNameReciever",this.name);//give oponent name to TurnController to memory unit
    }
}
