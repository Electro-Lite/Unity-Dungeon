using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class DruidScript : MonoBehaviour
{

    public static bool DruidActionReady=true;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private int DiceID;
    private bool Primed;
    private string DiceName;



    public void ActionSwitch(){DruidActionReady=false;}
    public void WillONature()
    {
      if (DruidActionReady == true)
      {
      Primed=true;
      Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);

      }

    }

  private void Start()
  {
    if (this.name=="Druid") {
      UnityEngine.Object prefab = Resources.Load("Loot/FightersImagePrefabs/"+"DruidImage"+PlayerPrefs.GetString("FightLocation"), typeof(GameObject));
      if (prefab!=null) {
        GameObject player = Instantiate(prefab,this.transform) as GameObject;
        player.transform.SetParent(this.transform);
        player.name="DruidImage";
      }
    }

    Text HeroPowerText = GameObject.Find("HeroPowerText").GetComponent<Text>();
  }

  public void WillONatureButton(int DiceID)
  {
    if (Primed==true){

      if (DiceID!=0) {
        DruidActionReady=false;
        Debug.Log("WillONatureButton"+DiceID.ToString());
        GameObject.Find("Canvas/Dices/Button").SendMessage("DiceValueGiver",DiceID);
        Primed=false;
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
      }
    }



  }

}
