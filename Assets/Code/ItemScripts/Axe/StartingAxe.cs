using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingAxe : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainAction(){
      if (BarbarianScript.BarbarianActionReady==true) {
        GameObject.Find("Canvas/Dices/Button").SendMessage("DiceRoller");
        GameObject.Find("Canvas/Dices/Button").SendMessage("DiceRoller");
        this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","0");
        BarbarianScript.BarbarianActionReady = false;
      }
    }
}
