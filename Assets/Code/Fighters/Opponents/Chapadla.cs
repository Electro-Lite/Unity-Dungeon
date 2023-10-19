using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapadla : MonoBehaviour
{
    // Start is called before the first frame update
  private int OpponentCount;

  public void ChapadloSmash()
    {
        GameObject.Find("Canvas/Dices/Button").SendMessage("DiceRoller");
    }

    public void OpponentTurnIniciator(){
      ChapadloSmash();
      GameObject.Find("EndTurnButton").SendMessage("EndTurn",true);
    }

    void Start(){
      DiceControler.DiceColor=new Color32(147,0,0,255);
      OpponentCount=Random.Range(1,4);
      Debug.Log("OpponentCount= "+OpponentCount);
      GameObject.Find("Opponent Pad").SetActive(false);
      for (int i=4;i>OpponentCount; i--) {
        Debug.Log(i.ToString());
        GameObject.Find("Vlk"+i.ToString()).SetActive(false);
      }

      TurnController.OpponentHealth=1;
      GameObject.Find("EndTurnButton").SendMessage("OpponentNameReciever","Chapadla");//give oponent name to TurnController to memory unit
      /*
      int x=0;
      for (int i=0; i!=OpponentCount+1; i++) {
        StartCoroutine(VlkGrowl(x));
        x+=1;
      }
    }
    IEnumerator VlkGrowl(int x){
      Debug.Log("Growl");
      yield return new WaitForSeconds(Random.Range(0,80)/100);
      while (x<6) {
        GameObject.Find("AudioManager").SendMessage("Play","Growl"+ x.ToString());
        yield return new WaitForSeconds((Random.Range(0,1000)/1000)+3);
      }
      */
    }


    // Update is called once per frame

}
