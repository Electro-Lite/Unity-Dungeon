using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Animations;

public class TurnController : MonoBehaviour
{
    public static bool PlayerTurn=true;
    public bool SafetyBool=false;
    public static int OpponentHealth;
    public static int BarbarianHealth;
    public static int DruidHealth;
    public static int ThiefHealth;
    public static int HuntressHealth;
    private TextMeshProUGUI RoundResolutionText;
    private bool BarbarianAlive=true;private bool DruidAlive=true;
    private bool HuntressAlive=true;private bool ThiefAlive=true;
    private string OpponentName;
    private int CommonDaggersPoisonLevel=0;
    public GameObject ScreenLock;
    public GameObject Loot;
    private GameObject Inventory;
    public Animator EndTurnButtonAnimator;
    private bool EndTurnButtonOn=false;



    // Start is called before the first frame update
    void Start()
    {
      //primer
      EndTurnButtonAnimator.Play("0");
      BarbarianScript.BarbarianActionReady=true;
      DruidScript.DruidActionReady=true;
      HuntressScript.HuntressActionReady=true;
      ThiefScript.ThiefActionReady=true;

      Inventory=GameObject.Find("PlayerInventory");
      Loot=GameObject.Find("FoundLoot");
      Loot.SetActive(false);
    }
    void Update(){
      if (BarbarianScript.BarbarianActionReady==false | HuntressScript.HuntressActionReady==false | DruidScript.DruidActionReady==false|ThiefScript.ThiefActionReady==false) {
        if (PlayerTurn==true & EndTurnButtonOn==false) {
          EndTurnButtonAnimator.Play("1");
          EndTurnButtonOn=true;
        }
      }
    }

    public void EndTurn(bool SafetyBool){
      if (PlayerTurn==true){/*end of player turn*/
        PlayerActionReadySwitch();
        PlayerTurn=false;
        CommonDaggersPoisonPower();
        GameObject.Find(OpponentName).SendMessage("OpponentTurnIniciator");

      }else if (SafetyBool==true) {/*end of Opponent turn*/
        StartCoroutine(TurnResolver());
        PlayerActionReadySwitch();
        SafetyBool=false;
        PlayerTurn=true;

        }

      }

    private void PlayerActionReadySwitch(){
      if (PlayerTurn==true) {
        BarbarianScript.BarbarianActionReady=false;
        DruidScript.DruidActionReady=false;
        HuntressScript.HuntressActionReady=false;
        ThiefScript.ThiefActionReady=false;
      }else{
          BarbarianScript.BarbarianActionReady=true;
          DruidScript.DruidActionReady=true;
          HuntressScript.HuntressActionReady=true;
          ThiefScript.ThiefActionReady=true;

        }
      }
      private void PlayerDeathCheck(){

        if (BarbarianHealth <=0  &  DruidHealth <= 0  &  HuntressHealth <= 0  &  ThiefHealth <= 0  ) {
        GameObject.Find("Canvas/RoundResolutionUI/GameOverText").SetActive(true);
        StartCoroutine(PlayerDeathCheckCoroutine());
        }
        if(BarbarianAlive==true){ if (BarbarianHealth <= 0) {
          GameObject.Find("Barbarian").SetActive(false); BarbarianAlive=false;  }}

        if(DruidAlive==true){ if (DruidHealth <= 0) {
          GameObject.Find("Druid").SetActive(false); DruidAlive=false;    }}

        if(HuntressAlive==true){ if (HuntressHealth <= 0) {
          GameObject.Find("Huntress").SetActive(false); HuntressAlive=false;   }}

        if(ThiefAlive==true){ if (ThiefHealth <= 0) {
          GameObject.Find("Canvas/Fighters/Thief").SetActive(false); ThiefAlive=false;   }}
      }

      IEnumerator PlayerDeathCheckCoroutine(){
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Level Map");
      }

      IEnumerator TurnResolver(){
        EndTurnButtonAnimator.Play("0");
        RoundResolutionText=  GameObject.Find("RoundResolutionText").GetComponent<TextMeshProUGUI>();
        if (DiceControler.OpponentPower<DiceControler.HeroPower){/*player win*/
          if (DiceControler.HeroPower<DiceControler.OpponentDefence) {
            ScreenLock.SetActive(true);
            yield return new WaitForSeconds(2); RoundResolutionText.SetText("Opponent Defended");
            yield return new WaitForSeconds(4); RoundResolutionText.SetText("");
            GameObject.Find("Canvas/Dices/Button").SendMessage("ResetDice");
            ScreenLock.SetActive(false);
          }else{
            OpponentHealth += -1;
            ScreenLock.SetActive(true);
            yield return new WaitForSeconds(2); RoundResolutionText.SetText("Round Won");
            yield return new WaitForSeconds(4); RoundResolutionText.SetText("");
            GameObject.Find("Canvas/Dices/Button").SendMessage("ResetDice");
            ScreenLock.SetActive(false);
            OpponentDeathCheck();
          }
        }
        else{/*player lose*/
          ScreenLock.SetActive(true);
          yield return new WaitForSeconds(2); RoundResolutionText.SetText("Round Lost");
          yield return new WaitForSeconds(4); RoundResolutionText.SetText("");
          GameObject.Find("Canvas/Dices/Button").SendMessage("ResetDice");
          ScreenLock.SetActive(false);
          if(BarbarianAlive==true)  {GameObject.Find("Barbarian").SendMessage ("HealthChange", -1);}
          if(DruidAlive==true)      {GameObject.Find("Druid").SendMessage     ("HealthChange", -1);}
          if(ThiefAlive==true)      {GameObject.Find("Thief").SendMessage     ("HealthChange", -1);}
          if(HuntressAlive==true)   {GameObject.Find("Huntress").SendMessage  ("HealthChange", -1);}
        }
        EndTurnButtonOn=false;
      }

      public void OpponentDeathCheck(){
        if (OpponentHealth<=0) {
            //RoundResolutionText=  GameObject.Find("Canvas/RoundResolutionUI/GameVictoryText").GetComponent<TextMeshProUGUI>();
            GameObject.Find(OpponentName).SendMessage("StopSound");
            GameObject.Find("Canvas/RoundResolutionUI/GameVictoryText").SetActive(true);
            ScreenLock.SetActive(true);
            Loot.SetActive(true);
            GameObject.Find("MemoryUnit").SendMessage("KillOpponent",PlayerPrefs.GetString("CurrentOpponent"));
            Debug.Log("Kill  "+OpponentName);
            GameObject.Find("Tutorial").SendMessage("VlkDown");
            //Transition
        }
      }
        public void LeaveScene(){
          //Transition
          Inventory.SetActive(true);
          GameObject.Find("Canvas").SendMessage("LightSave");
          StartCoroutine(Wait(2));
        }
      public void CommonDaggersPoisonPower(){
        if (PlayerTurn==true) {
          CommonDaggersPoisonLevel+=1;
        }else{
          GameObject.Find("Canvas/Dices/Button").SendMessage("PowerUpdate",-CommonDaggersPoisonLevel);
        }
      }

      public void OpponentNameReciever(string name){Debug.Log("reciever");OpponentName=name;Debug.Log(name);}

      IEnumerator Wait(int a){
        var Transition = GameObject.Find("TransitionImage").GetComponent<Animator>();
        Transition.Play("TransitionAnimMap");
        yield return new WaitForSeconds(a);
        SceneManager.LoadScene("Level Map");
      }


}
