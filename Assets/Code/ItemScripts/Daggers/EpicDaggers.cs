using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicDaggers : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainAction(){
      if (ThiefScript.ThiefActionReady==true) {
        GameObject.Find("Canvas/Dices/Button").SendMessage("EpicDaggersPower");
        this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","3");
        ThiefScript.ThiefActionReady=false;
      }
    }

}
