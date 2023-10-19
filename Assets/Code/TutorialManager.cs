using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool PlayTutorial;
    public GameObject AskForTutorial;
    public GameObject MenuSetTutorial;
    public GameObject ArrowToEnemy1;
    public GameObject ArrowToEnemy2;
    public GameObject ArrowOnBarbarian;
    public GameObject ArrowOnAttack;
    public GameObject ArrowOnPower;
    public GameObject ArrowOnFinish;
    void Start()
    {
      if (PlayerPrefs.GetString("Tutorial","yes")=="no") {
        Destroy(this.gameObject);
        MenuSetTutorial.GetComponent<Toggle>().isOn=false;
      }else{
        if (MemoryUnit.SceneName=="Level Map") {
          Movement.MovementEnabled=false;
          GameObject.Find("AudioManager").SendMessage("Play","t1");
          StartCoroutine(Wait1(13));
        }else{
          GameObject.Find("AudioManager").SendMessage("Stop","t2");
          GameObject.Find("AudioManager").SendMessage("Play","t3");
          GameObject.Find("Canvas/Dices/Button").SendMessage("TutorialSet");
          StartCoroutine(Wait2(4.5F));
        }
        MenuSetTutorial.GetComponent<Toggle>().isOn=true;
      }
      this.transform.parent.gameObject.SetActive(false);
    }
    public void TutorialSet(bool SetTo){
      Debug.Log("TutorialSet"+SetTo.ToString());
      if (SetTo==true) {
        PlayerPrefs.SetString("Tutorial","yes");
      }else{PlayerPrefs.SetString("Tutorial","no");}
    }

    // Update is called once per frame
    public void TMovement(bool play){
      Movement.MovementEnabled=true;
      PlayTutorial=play;
      if (PlayTutorial==true) {
        GameObject.Find("AudioManager").SendMessage("Play","t2");
        StartCoroutine(Wait0(4.5F));
      }else{PlayerPrefs.SetString("Tutorial","no");}
    }
    IEnumerator Wait0(float sec){
      yield return new WaitForSeconds(sec);
      ArrowToEnemy1.SetActive(true);
      yield return new WaitForSeconds(1);
      ArrowToEnemy2.SetActive(true);
    }
    IEnumerator Wait1(float sec){
      yield return new WaitForSeconds(sec);
      AskForTutorial.SetActive(true);
    }
    IEnumerator Wait2(float sec){
      yield return new WaitForSeconds(sec);
      ArrowOnBarbarian.SetActive(true);
      yield return new WaitForSeconds(3);
      ArrowOnBarbarian.SetActive(false);
      ArrowOnAttack.SetActive(true);
    }
    public void DiceRolled(){
      Debug.Log("play t4");
      ArrowOnAttack.SetActive(false);
      GameObject.Find("AudioManager").SendMessage("Stop","t3");
      GameObject.Find("AudioManager").SendMessage("Play","t4");
      StartCoroutine(Wait3(4));
    }
    IEnumerator Wait3(float sec){
      yield return new WaitForSeconds(sec);
      ArrowOnPower.SetActive(true);
      yield return new WaitForSeconds(sec+1);
      ArrowOnPower.SetActive(false);
      yield return new WaitForSeconds(2);
      yield return new WaitForSeconds(2);
      ArrowOnFinish.SetActive(true);
    }
    public void TurnFinished(){
      GameObject.Find("AudioManager").SendMessage("Stop","t4");
      GameObject.Find("AudioManager").SendMessage("Play","t5");
      ArrowOnFinish.SetActive(false);
    }
    public void VlkDown(){
      GameObject.Find("AudioManager").SendMessage("Stop","t5");
      GameObject.Find("AudioManager").SendMessage("Play","t6");
      PlayerPrefs.SetString("Tutorial","no");
    }
    public void KillTutorial(){
      if (MenuSetTutorial.GetComponent<Toggle>().isOn==false) {
        Debug.Log("KillTutorial");
        GameObject.Find("AudioManager").SendMessage("Stop","t1");
        GameObject.Find("AudioManager").SendMessage("Stop","t2");
        GameObject.Find("AudioManager").SendMessage("Stop","t3");
        GameObject.Find("AudioManager").SendMessage("Stop","t4");
        GameObject.Find("AudioManager").SendMessage("Stop","t5");
        GameObject.Find("AudioManager").SendMessage("Stop","t6");
        AskForTutorial.SetActive(false);
        ArrowToEnemy1.SetActive(false);
        ArrowToEnemy2.SetActive(false);
        ArrowOnBarbarian.SetActive(false);
        ArrowOnAttack.SetActive(false);
        ArrowOnPower.SetActive(false);
        ArrowOnFinish.SetActive(false);
        PlayTutorial=false;
        PlayerPrefs.SetString("Tutorial","no");
      }
    }
}
