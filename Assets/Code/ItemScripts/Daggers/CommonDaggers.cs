using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonDaggers : MonoBehaviour
{

      // Start is called before the first frame update
      public void MainAction(){
        if (ThiefScript.ThiefActionReady==true) {
          GameObject.Find("Canvas/Dices/Button").SendMessage("CommonDaggersPoisonPower");
          this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","1");
          ThiefScript.ThiefActionReady=false;
        }

      }

      public void SecondaryAction(){
        if (ThiefScript.ThiefActionReady==true) {
          GameObject.Find("Canvas/Dices/Button").SendMessage("CommonDaggersPower");
          ThiefScript.ThiefActionReady=false;
        }
      }
}
