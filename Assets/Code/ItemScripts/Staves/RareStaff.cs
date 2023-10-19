using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareStaff : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainAction(){
      if (DruidScript.DruidActionReady==true) {
        GameObject.Find("Canvas/Dices/Button").SendMessage("RareStaffPower");
        this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","2");
        DruidScript.DruidActionReady = false;
      }
    }
}
