using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonStaff : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainAction(){
      if (DruidScript.DruidActionReady==true) {
        GameObject.Find("Canvas/Dices/Button").SendMessage("PowerUpdate",3);
        this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","1");
        DruidScript.DruidActionReady = false;
      }
    }
    public void SecondaryAction(){
      if (DruidScript.DruidActionReady==true) {
        GameObject.Find("Canvas/Dices/Button").SendMessage("CommonStaffPower");
        DruidScript.DruidActionReady = false;
      }
    }


}
