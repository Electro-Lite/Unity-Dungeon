using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class EnterFightScript : MonoBehaviour
{
  private bool PressedEnter=false;

  private void Update(){
    if (Input.GetKey("enter") & PressedEnter==false){
      PressedEnter=true;
      EnterFight(true);
    }
  }

  public void EnterFight(bool Enter){
    if (Enter==true) {
      //load fight
      GameObject.Find("Canvas").SendMessage("LightSave");
      Movement.MovementEnabled=true;
      GameObject.Find("Fighters").SendMessage("FightEnterSwitch", false);
      StartCoroutine(Wait(2));
    }else{
      GameObject.Find("Fighters").SendMessage("FightEnterSwitch", false);
      Movement.MovementEnabled=true;
      PlayerPrefs.DeleteKey("CurrentOpponent");
    }
  }
  IEnumerator Wait(int a){
    Debug.Log("load");
    var Transition = GameObject.Find("TransitionImage").GetComponent<Animator>();
    Transition.Play("TransitionAnimMap");
    yield return new WaitForSeconds(a);
    GameObject.Find("Menu").SendMessage("RoomCount");
    yield return new WaitForSeconds(0.5F);
    SceneManager.LoadScene("scena");
  }
}
