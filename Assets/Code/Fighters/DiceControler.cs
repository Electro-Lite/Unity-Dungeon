using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Animations;

public class DiceControler : MonoBehaviour
{
    // Start is called before the first frame update
    private int DiceValue;
    public static int HeroPower=0;
    public static int OpponentPower=0;
    public static int OpponentDefence=0;
    public int PowerChangeBy=0;
    private int DiceID;
    private int DiceIDToGive;
    public string a; //just ignore this fella ;)
    private int RepetitionCounter=0;
    public GameObject OriginalDice;
    public Transform OriginalDiceTransform;
    public GameObject[] DiceByID;
    public int[] DiceValueHolder;
    public static Color32 DiceColor=new Color32(255,255,255,255);
    private byte TrollDiceColor=147;
    private AudioManager AudioManager;
    public bool TutorialOn=false;

    private bool CommonBowAction=false;
    private bool CommonAxeAction=false;
    private bool CommonDaggersAction=false;
    private int  CRDaggersDiceID;
    private bool CRDaggersActionSupportBool=false;
    public int OriginalConformity=0;
    public int Conformity=0;
    private bool RareBowAction=false;
    private bool RareStaffAction=false;
    private bool RareStaffActionSupportBool=false;
    private bool RareDaggersAction=false;
    private bool EpicDaggersAction=false;
    private bool EpicDaggersActionSupportBool=false;
    private int  EpicDaggersDiceID;
    private int  EpicDaggersFrostLevel=0;
    private bool TrollAction=false;
    private int TrollMight=0;
    private int LavaCounter=0;
    private int DragonCounter=0;
    private bool GhoulWin=true;






    public Image Dice1;
    public int DiceVal1 = 0;
    public Image Dice2;
    public int DiceVal2 = 0;
    public Image Dice3;
    public int DiceVal3 = 0;
    public Image Dice4;
    public int DiceVal4 = 0;
    public Image Dice5;
    public int DiceVal5 = 0;
    public Image Dice6;
    public int DiceVal6 = 0;
    public Image Dice7;
    public int DiceVal7 = 0;
    public Image Dice8;
    public int DiceVal8 = 0;
    public Image Dice9;
    public int DiceVal9 = 0;
    public Image Dice10;
    public int DiceVal10 = 0;






    public void DiceRoller()
    {

      Text HeroPowerText = GameObject.Find("HeroPowerText").GetComponent<Text>();
      HeroPowerText.text =  HeroPower.ToString();

      if (TutorialOn==true) {
        Debug.Log("diceroll noticed tutorialon");
        GameObject.Find("Tutorial").SendMessage("DiceRolled");
        TutorialOn=false;
      }

      if (CommonBowAction==false & CommonAxeAction==false){//not ItemPower component
        DiceID = Random.Range(1,11);
        DiceValue = Random.Range(1,7);
      }

      if (TrollAction==true) {
        if (DiceValue>3) {
          TrollMight+=1;
        }
      }
      if (RareBowAction==true) {
        if (TurnController.PlayerTurn==false) {
          PowerUpdate(-2);
        }
      }

      if (RareStaffAction==true) {
        if (TurnController.PlayerTurn==true & RareStaffActionSupportBool==true){
          RareStaffActionSupportBool=false;
          RareStaffAction=false;
        } else if (TurnController.PlayerTurn==false) {
          PowerUpdate(-1);
          RareStaffActionSupportBool=true;
        }
      }

      if (CommonDaggersAction==true | RareDaggersAction==true) {
        if (CRDaggersActionSupportBool==true) {
          CRDaggersDiceID=RepetitionCounter;CRDaggersActionSupportBool=false;
          //Debug.Log(DiceValueHolder[RepetitionCounter].ToString());
        }
      }

      if (EpicDaggersAction==true) {
          if (EpicDaggersActionSupportBool==true) {
            EpicDaggersDiceID=RepetitionCounter;
            EpicDaggersActionSupportBool=false;
          }else{
            if (TurnController.PlayerTurn==false & EpicDaggersFrostLevel>0) {
              DiceValue=1;
              DiceValueHolder[RepetitionCounter]=DiceValue;
              EpicDaggersFrostLevel-=1;
            }else if (TurnController.PlayerTurn==false & EpicDaggersFrostLevel<=0) {
              EpicDaggersAction=false;
            }
          }
      }



      //Debug.Log("RepetitionCounter: "+RepetitionCounter+" ID: "+ DiceID + "Value:"+DiceValue ) ;
      DiceValueHolder[RepetitionCounter]=DiceValue;
      RepetitionCounter+=1;
      if (TurnController.PlayerTurn==false) {
        GameObject.Find("Dice0").GetComponent<Image>().color = DiceColor;
      }
      DiceByID[RepetitionCounter]=Instantiate(OriginalDice,OriginalDiceTransform.position,OriginalDiceTransform.rotation,OriginalDiceTransform.parent);
      DiceByID[RepetitionCounter].name="Dice"+RepetitionCounter.ToString();
      DiceByID[RepetitionCounter].SendMessage("DiceImage", DiceValue);


      var DiceAnim = DiceByID[RepetitionCounter].GetComponent<Animator>();
      DiceAnim.Play("DiceFly" + RepetitionCounter.ToString());
      StartCoroutine(DiceAnimatorDisabler(RepetitionCounter));
      PowerUpdate(DiceValue);
    }  //konec


      IEnumerator DiceAnimatorDisabler(int RepetitionCounterFix){
        AudioManager.Play("Dice"+Random.Range(0, 4).ToString());
        yield return new WaitForSeconds(1);
        DiceByID[RepetitionCounterFix].GetComponent<Animator>().enabled = false;
      }




      public void Update(){
        if (EpicDaggersAction==true & TurnController.PlayerTurn==true) {
          if(DiceValueHolder[EpicDaggersDiceID]==6){EpicDaggersFrostLevel=2;}
          else{EpicDaggersFrostLevel=1;}
        }

          if (CommonDaggersAction==true | RareDaggersAction==true){
            if(TurnController.PlayerTurn==false){CommonDaggersAction=false;RareDaggersAction=false;}
            for (int i = 0; i<=RepetitionCounter ; i++) {
              if (DiceValueHolder[i]==DiceValueHolder[CRDaggersDiceID] & CRDaggersDiceID !=i ) {
                Conformity+=1;
              }
            }
          }
          Conformity-=OriginalConformity;
          if (RareDaggersAction==true) {
            PowerUpdate(-Conformity*4);
          }
          if (CommonDaggersAction==true) {
            if(Conformity!=0){Debug.Log(Conformity.ToString()+"   "+OriginalConformity.ToString());}
            PowerUpdate(Conformity);
          }
          OriginalConformity+=Conformity;
          Conformity=0;
      }


    public void DiceValueGiver(int DiceIDToGive){
      Text HeroPowerText = GameObject.Find("HeroPowerText").GetComponent<Text>();

      a=(DiceValueHolder[DiceIDToGive-1].ToString());
      //int ValueFound = (int)this.GetType().GetField(a).GetValue(this);

      int ValueFound = 0;
      ValueFound = System.Convert.ToInt32(a);



      //Debug.Log("ValueFound: " + a);

      if      (ValueFound==1) {DiceValue=6;PowerUpdate(5);}
      else if (ValueFound==2) {DiceValue=5;PowerUpdate(3);}
      else if (ValueFound==3) {DiceValue=4;PowerUpdate(1);}
      else if (ValueFound==4) {DiceValue=3;PowerUpdate(-1);}
      else if (ValueFound==5) {DiceValue=2;PowerUpdate(-3);}
      else if (ValueFound==6) {DiceValue=1;PowerUpdate(-5);}
      DiceID=DiceIDToGive-1;
      DiceValueHolder[DiceID]=DiceValue;
      DiceByID[DiceIDToGive].SendMessage("DiceImage", DiceValue);
      HeroPowerText.text =  HeroPower.ToString();
    }


    private void Start(){
        AudioManager=FindObjectOfType<AudioManager>();
        Text HeroPowerText = GameObject.Find("HeroPowerText").GetComponent<Text>();
        HeroPowerText.text = HeroPower.ToString();
    }

    public void PowerUpdate(int PowerChangeBy){

              Text HeroPowerText = GameObject.Find("HeroPowerText").GetComponent<Text>();
              Text OpponentPowerText = GameObject.Find("Canvas/Fighters/Opponent/OpponentPowerText").GetComponent<Text>();
              if (TurnController.PlayerTurn==true) {
                HeroPower+=PowerChangeBy;
                HeroPowerText.text =  HeroPower.ToString();
              }else if (TurnController.PlayerTurn==false) {
                OpponentPower+=PowerChangeBy;
                OpponentPowerText.text=OpponentPower.ToString();
              }

    }
    public void ResetDice(){
      while (RepetitionCounter!=0) {
      Destroy(DiceByID[RepetitionCounter]);
      RepetitionCounter+=-1;
      }
      HeroPower=0;PowerUpdate(0);
      OpponentPower=0;TurnController.PlayerTurn=false;PowerUpdate(0);TurnController.PlayerTurn=true;
    }


    public void CommonBowPower(){
      CommonBowAction=true;
      DiceValue = 5;
      DiceRoller();
      CommonBowAction=false;
    }
    public void CommonStaffPower(){
      DiceRoller();
      if (DiceValue<3) {
        PowerUpdate(-DiceValue);
        Destroy(DiceByID[RepetitionCounter]);
        RepetitionCounter+=-1;
      }else if (DiceValue==6) {
        PowerUpdate(3);
      }
    }
    public void CommonAxePower(){
      CommonAxeAction=true;
      DiceValue = Random.Range(1,7);
      if (DiceValue<3){DiceValue=3;}
      DiceRoller();
      CommonAxeAction=false;
    }
    public void CommonDaggersPower(){
      CommonDaggersAction=true;
      CRDaggersActionSupportBool=true;
      DiceRoller();
      //Debug.Log("CommonDaggersPower");
      CRDaggersActionSupportBool=false;
    }
    public void CommonDaggersPoisonPower(){
      DiceRoller();
      GameObject.Find("EndTurnButton").SendMessage("CommonDaggersPoisonPower");
    }
    public void RareBowPower(){
      DiceRoller();
      if (DiceValue==6) {
        RareBowAction=true;
      }
      CommonBowAction=false;
    }
    public void RareStaffPower(){
      RareStaffAction=true;
    }
    public void RareDaggersPower(){
      RareDaggersAction=true;
      CRDaggersActionSupportBool=true;
      DiceRoller();
      CRDaggersActionSupportBool=false;
      PowerUpdate(10);
    }
    public void EpicDaggersPower(){
      EpicDaggersAction=true;
      EpicDaggersActionSupportBool=true;
      DiceRoller();
      EpicDaggersActionSupportBool=false;

    }
    public void SpiderPower(){
      PowerUpdate(12);
      DiceRoller();
    }
    public void GhoulPower(){
      StartCoroutine(GhoulDelay());
    }
    IEnumerator GhoulDelay(){
      GhoulWin=true;
      PowerUpdate(10);
      int x=RepetitionCounter;
      for (int i=0; i<x; i++) {
        if (DiceValueHolder[i]==6) {
          GhoulWin=false;
          DiceByID[i+1].GetComponent<Image>().color=new Color32(255,100,255,200);
          x=i+1;
          Debug.Log("got 6");
          break;
        }
      }
      if (GhoulWin==true) {
          PowerUpdate(20);
      }else{
        yield return new WaitForSeconds(1);
          DiceByID[x].GetComponent<Image>().color=new Color32(255,255,255,255);
      }
      yield return new WaitForSeconds(1);
      DiceRoller();
      DiceRoller();
      DiceRoller();
      GameObject.Find("EndTurnButton").SendMessage("EndTurn",true);
    }
    public void TrollPower(){
      TrollAction=true;
      TrollMight=0;
      DiceRoller();
      DiceRoller();
      DiceRoller();
      StartCoroutine(TrollRepeat());
    }
    IEnumerator TrollRepeat(){
      yield return new WaitForSeconds(1);
      TrollDiceColor-=30;
      DiceColor=new Color32(44,TrollDiceColor,39,255);
      int TmpA=TrollMight;
      while(TrollMight>0){
        TrollMight-=1;
        TmpA-=1;
        DiceRoller();
        if (TmpA==0) {
          yield return new WaitForSeconds(1);
        }

      }
      if (TrollMight!=0) {
        TrollRepeat();
      }
      GameObject.Find("EndTurnButton").SendMessage("EndTurn",true);
    }
    public void LavaPower(){
      LavaCounter=RepetitionCounter;
      DiceColor=new Color32(255,104,0,255);
      DiceRoller();
      DiceRoller();
      //Debug.Log(DiceValueHolder[LavaCounter+1].ToString() +" "+ DiceValueHolder[LavaCounter].ToString());
      for (int i=0; i!=LavaCounter; i++) {
        Debug.Log("checking "+DiceValueHolder[i].ToString()+" against "+DiceValueHolder[LavaCounter+1].ToString());
        if (DiceValueHolder[LavaCounter+1]==DiceValueHolder[i]) {
          Debug.Log("its a match !");
          StartCoroutine(LavaStrike(i));
        }
        Debug.Log("checking "+DiceValueHolder[i].ToString()+" against "+DiceValueHolder[LavaCounter].ToString());
        if (DiceValueHolder[LavaCounter]==DiceValueHolder[i]) {
          Debug.Log("its a match !");
          StartCoroutine(LavaStrike(i));
        }
      }
      DiceColor=new Color32(77,77,77,255);
      DiceRoller();
      DiceRoller();
      DiceRoller();
      DiceRoller();
    }
    IEnumerator LavaStrike(int i){
      Debug.Log("going to change "+DiceValueHolder[i].ToString()+" to 1");
      i+=1;
      Text HeroPowerText = GameObject.Find("HeroPowerText").GetComponent<Text>();
      yield return new WaitForSeconds(2);
      DiceByID[i].GetComponent<Image>().color =new Color32(255,104,0,255);
      HeroPower-=DiceValueHolder[i-1]-1;
      yield return new WaitForSeconds(1);
      DiceByID[i].SendMessage("DiceImage", 1);
      yield return new WaitForSeconds(2);
      DiceByID[i].GetComponent<Image>().color =new Color32(255,255,255,255);
      HeroPowerText.text =  HeroPower.ToString();
    }



    public void DragonPower(){
      DragonCounter=RepetitionCounter;
      DiceColor=new Color32(255,104,0,255);
      DiceRoller();
      DiceRoller();
      for (int i=0; i<DragonCounter; i++) {
        if (DiceValueHolder[DragonCounter+1]==DiceValueHolder[i]) {
          StartCoroutine(DragonStrike(i));
        }
        if (DiceValueHolder[DragonCounter]==DiceValueHolder[i]) {
          StartCoroutine(DragonStrike(i));
        }
      }
      DiceColor=new Color32(77,77,77,255);
      DiceRoller();
      DiceRoller();
      DiceRoller();
      DiceRoller();
    }
    IEnumerator DragonStrike(int i){
      Debug.Log("dragon coroutine for" + i.ToString() + " which is Dice" + DiceByID[i+1].name + " with value "+ DiceValueHolder[i].ToString());
      yield return new WaitForSeconds(2);
      DiceByID[i+1].GetComponent<Image>().color=new Color32(255,104,0,255);
      yield return new WaitForSeconds(2);
      Text HeroPowerText = GameObject.Find("HeroPowerText").GetComponent<Text>();
      HeroPower-=DiceValueHolder[i];
      HeroPowerText.text =  HeroPower.ToString();
      DiceByID[i+1].GetComponent<Image>().color=new Color32(255,104,0,100);
    }
    public void TutorialSet(){
      Debug.Log("TutorialSet");
      TutorialOn=true;
    }

}
