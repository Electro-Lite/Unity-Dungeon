﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareAxe : MonoBehaviour
{
  // Start is called before the first frame update
  public void MainAction(){
    if (BarbarianScript.BarbarianActionReady==true) {
      GameObject.Find("Canvas/Dices/Button").SendMessage("DiceRoller");
      GameObject.Find("Canvas/Dices/Button").SendMessage("DiceRoller");
      GameObject.Find("Canvas/Dices/Button").SendMessage("DiceRoller");
      this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","2");
      BarbarianScript.BarbarianActionReady = false;
    }
  }
  public void SecondaryAction(){
    if (BarbarianScript.BarbarianActionReady==true) {
      GameObject.Find("Canvas/Dices/Button").SendMessage("DiceRoller");
      GameObject.Find("Canvas/Dices/Button").SendMessage("DiceRoller");
      GameObject.Find("Canvas/Dices/Button").SendMessage("PowerUpdate",4);
      this.transform.parent.parent.parent.gameObject.BroadcastMessage("PlayAttackAnim","2");
      BarbarianScript.BarbarianActionReady = false;
    }
  }

}
