using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
  private string SceneName;
  private string SavePath;
  public GameObject Inventory;
    // Start is called before the first frame update
    public void Start(){
      MemoryUnit.SceneName=SceneManager.GetActiveScene().name;
      if (MemoryUnit.SceneName =="Level Map") {
        SavePath="Canvas/PlayerCanvas";
        LightLoad();
      }else{
        SavePath="Dont";
        LightLoad();
      }
    }

    public void SaveGame(){
      if(SavePath!="Dont"){GameObject.Find(SavePath).BroadcastMessage("SaveGame","Save");}
      GameObject.Find("Fighters").BroadcastMessage("SaveGame","Save");
    }

    public void LoadGame(){
      if(SavePath!="Dont"){GameObject.Find(SavePath).BroadcastMessage("LoadGame","Save");}
      GameObject.Find("Fighters").BroadcastMessage("LoadGame","Save");
    }


    public void LightSave(){
      if (MemoryUnit.SceneName=="Level Map") {
        Inventory.SetActive(true);
        GameObject.Find(SavePath).BroadcastMessage("SaveGame","LightSave");
        GameObject.Find("MemoryUnit").SendMessage("PreFightSave");
      }
      GameObject.Find("Fighters").BroadcastMessage("SaveGame","LightSave");
      if (MemoryUnit.SceneName=="Level Map") {
        Inventory.SetActive(false);
      }
    }

    public void LightLoad(){
      if(SavePath!="Dont"){GameObject.Find(SavePath).BroadcastMessage("LoadGame","LightSave");}
      GameObject.Find("Fighters").BroadcastMessage("LoadGame","LightSave");
    }
}
