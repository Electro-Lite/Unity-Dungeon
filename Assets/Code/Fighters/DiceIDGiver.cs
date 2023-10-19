using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceIDGiver : MonoBehaviour
{
    string DiceName;
    private int DiceID;

    public void DiceIDGiverFunction(){
      DiceName=this.name;
      Debug.Log(DiceName[4]+"  "+DiceName.Length);
      if (DiceName.Length==6) {
        int.TryParse(DiceName[4].ToString()+DiceName[5].ToString(), out DiceID);
      }else{
        int.TryParse(DiceName[4].ToString(), out DiceID);
      }

      if (DruidScript.DruidActionReady==true) {
        GameObject.Find("Canvas/Fighters/Druid").SendMessage("WillONatureButton",DiceID);
      }

    }
}
