using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareBow : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainAction(){
      if (HuntressScript.HuntressActionReady==true) {
        GameObject.Find("Canvas/Dices/Button").SendMessage("RareBowPower");
        this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","2");
        HuntressScript.HuntressActionReady=false;
      }
    }
}
