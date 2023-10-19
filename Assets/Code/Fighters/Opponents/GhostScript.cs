using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class GhostScript : MonoBehaviour
{
    private int Defence=25;
    // Start is called before the first frame update
    public void FlyThrough(){
          int x =Random.Range(1, 4);
          if     (x==1 & TurnController.BarbarianHealth>0)   {GameObject.Find("Barbarian").SendMessage ("HealthChange", -1);}
          else if(x==2 & TurnController.DruidHealth>0)       {GameObject.Find("Druid").SendMessage     ("HealthChange", -1);}
          else if(x==3 & TurnController.ThiefHealth>0)       {GameObject.Find("Thief").SendMessage     ("HealthChange", -1);}
          else if(x==4 & TurnController.HuntressHealth>0)    {GameObject.Find("Huntress").SendMessage  ("HealthChange", -1);}
          else FlyThrough();

    }

    public void OpponentTurnIniciator(){
      FlyThrough();
      GameObject.Find("EndTurnButton").SendMessage("EndTurn",true);
    }

    void Start(){
      GameObject.Find("Shield").GetComponent<Animator>().Play("DefenceUIAnim");
      Text DefenceText = GameObject.Find("OpponentDefenceText").GetComponent<Text>();
      DefenceText.text =  Defence.ToString();
      DiceControler.OpponentDefence=Defence;
      DiceControler.DiceColor=new Color32(155,155,255,80);
      TurnController.OpponentHealth=2;
      GameObject.Find("EndTurnButton").SendMessage("OpponentNameReciever","Ghost");//give oponent name to TurnController to memory unit
    }
}
