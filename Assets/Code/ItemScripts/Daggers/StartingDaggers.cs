using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDaggers : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainAction(){
      if (ThiefScript.ThiefActionReady==true) {
        GameObject.Find("Canvas/Dices/Button").SendMessage("DiceRoller");
        this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","0");
        ThiefScript.ThiefActionReady=false;
      }
    }

}
