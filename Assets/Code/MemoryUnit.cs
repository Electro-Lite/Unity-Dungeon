using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryUnit : MonoBehaviour
{
    public GameObject[] Opponents;
    private GameObject Player;
    public GameObject PlayerCanvas;
    private Dictionary<string, bool> OpponentsNames = new Dictionary<string, bool>();
    public static string SceneName;
    public static int StartGame;

    private void Start(){
    if (SceneName=="Level Map") {
      GameObject OpponetHolder=GameObject.Find("Opponents");
      Opponents=new GameObject[OpponetHolder.transform.childCount];
      for (int i=0;i<OpponetHolder.transform.childCount; i++) {
        Opponents[i]=OpponetHolder.transform.GetChild(i).gameObject;
        OpponentsNames.Add(Opponents[i].name+"Alive",Opponents[i].activeSelf);
      }
      if (GetBool("Battled")==true) {
        AfterFightLoad();
        SetBool("Battled",false);
      }
      if (StartGame==1) {
        LoadGame();
        StartGame=-1;
      }else if (StartGame==0) {
        PlayerCanvas.BroadcastMessage("StartingEquipmentLoad");
        ResetMemoryUnit();
        StartGame=-1;
      }
    }
    }


    public void SaveGame(){
      for (int i=0; i<Opponents.Length; i++) {
        SetBool(Opponents[i].name+"Alive",Opponents[i].activeSelf);
      }
      PlayerPrefs.SetInt("GameSaved",1);
      PlayerPrefs.SetFloat("PlayerPositionX",Player.transform.position.x);
      PlayerPrefs.SetFloat("PlayerPositionY",Player.transform.position.y);
      PlayerPrefs.SetFloat("PlayerPositionZ",Player.transform.position.z);
    }

    public void LoadGame(){
      for (int i=0; i<Opponents.Length; i++) {
        Opponents[i].SetActive(GetBool (Opponents[i].name+"Alive") );
        //Debug.Log(Opponents[i].name+"Alive"+"   "+Opponents[i].activeSelf.ToString());
      }
      /*
      Vlk1.SetActive(GetBool("Vlk1Alive"));
      Spider1.SetActive(GetBool("Spider1Alive"));
      Troll1.SetActive(GetBool("Troll11Alive"));*/
      float X =PlayerPrefs.GetFloat("PlayerPositionX",0);
      float Y =PlayerPrefs.GetFloat("PlayerPositionY",0);
      float Z =PlayerPrefs.GetFloat("PlayerPositionZ",0);
      Player.transform.position=new Vector3(X,Y,Z);
    }

    public void PreFightSave(){
      for (int i=0; i<Opponents.Length; i++) {
        SetBool("Pre"+Opponents[i].name+"Alive",Opponents[i].activeSelf);
        //Debug.Log("Pre"+Opponents[i].name+"Alive");
      }
      PlayerPrefs.SetFloat("PrePlayerPositionX",Player.transform.position.x);
      PlayerPrefs.SetFloat("PrePlayerPositionY",Player.transform.position.y);
      PlayerPrefs.SetFloat("PrePlayerPositionZ",Player.transform.position.z);
    }

    public void AfterFightLoad(){
      Debug.Log("AfterFightLoad");
      for (int i=0; i<Opponents.Length; i++) {
        Opponents[i].SetActive(GetBool ("Pre"+Opponents[i].name+"Alive") );
        //Debug.Log(Opponents[i].name+"Alive"+"   "+GetBool ("Pre"+Opponents[i].name+"Alive").ToString());
      }
      float X =PlayerPrefs.GetFloat("PrePlayerPositionX",0);
      float Y =PlayerPrefs.GetFloat("PrePlayerPositionY",0);
      float Z =PlayerPrefs.GetFloat("PrePlayerPositionZ",0);
      Player.transform.position=new Vector3(X,Y,Z);
      /*
      PlayerPrefs.DeleteKey("PrePlayerPositionX");
      PlayerPrefs.DeleteKey("PrePlayerPositionY");
      PlayerPrefs.DeleteKey("PrePlayerPositionZ");*/


    }
    public void KillOpponent(string OpponentName){
      Debug.Log("Kill "+ "Pre"+OpponentName+"Alive");
      SetBool("Pre"+OpponentName+"Alive",false);
      SetBool("Battled",true);
    }


    public bool GetBool(string KeyWord){
      int value = PlayerPrefs.GetInt(KeyWord);

      if (value == 1){
         return true;
      }else{
         return false;
      }
    }

    public void SetBool(string key, bool state){
       PlayerPrefs.SetInt(key, state ? 1 : 0);
    }
    void Awake(){
      SceneName=SceneManager.GetActiveScene().name;
      if (SceneName=="Level Map") {
        Player=GameObject.Find("Fighters");
      }
    }

    public void ResetMemoryUnit(){PlayerPrefs.DeleteAll();}
}
