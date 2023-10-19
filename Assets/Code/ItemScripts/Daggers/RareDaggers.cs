using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareDaggers : MonoBehaviour
{
  // Start is called before the first frame update

  public void MainAction(){
    if (ThiefScript.ThiefActionReady==true) {
      GameObject.Find("Canvas/Dices/Button").SendMessage("RareDaggersPower");
      this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","2");
      ThiefScript.ThiefActionReady=false;
    }
  }
}
