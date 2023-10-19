using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBow : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainAction(){
      if (HuntressScript.HuntressActionReady==true) {
        GameObject.Find("Canvas/Dices/Button").SendMessage("DiceRoller");
        GameObject.Find("Canvas/Dices/Button").SendMessage("PowerUpdate",1);
        this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","1");
        HuntressScript.HuntressActionReady=false;
      }
    }
    public void SecondaryAction(){
      if (HuntressScript.HuntressActionReady==true) {
        GameObject.Find("Canvas/Dices/Button").SendMessage("DiceRoller");
        GameObject.Find("Canvas/Dices/Button").SendMessage("CommonBowPower");
        this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","1");
        HuntressScript.HuntressActionReady=false;
      }
    }

}
