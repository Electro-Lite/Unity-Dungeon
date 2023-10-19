using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonAxe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
      this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","Common");
    }
    public void MainAction(){
      if (BarbarianScript.BarbarianActionReady==true) {
        GameObject.Find("Canvas/Dices/Button").SendMessage("DiceRoller");
        GameObject.Find("Canvas/Dices/Button").SendMessage("PowerUpdate",1);
        this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","1");
        BarbarianScript.BarbarianActionReady = false;
      }
    }
    public void SecondaryAction(){
      if (BarbarianScript.BarbarianActionReady==true) {
        GameObject.Find("Canvas/Dices/Button").SendMessage("CommonAxePower");
        GameObject.Find("Canvas/Dices/Button").SendMessage("CommonAxePower");
        this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","1");
        BarbarianScript.BarbarianActionReady = false;
      }
    }


}
