using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool InventoryEnabled;
    public GameObject Inventory;
    public bool[] IsFull;
    private GameObject[] Slot;
    private int AllSlots=20;
    public GameObject SlotHolder;
    public int PressedButton;
    public static GameObject Description;


    private void Update(){
      if ( Input.GetKeyDown(KeyCode.I) ){
        InventoryEnabled=!InventoryEnabled;
      }
      if (InventoryEnabled==true){
        Inventory.SetActive(true);
      }else if (InventoryEnabled==false) {
        Inventory.SetActive(false);
      }
    }


    void Awake(){
      Description=GameObject.Find("Description");
      AllSlots=20;
      Slot=new GameObject[AllSlots];
      for (int i = 0; i<AllSlots;i++) {
        Slot[i]=SlotHolder.transform.GetChild(i).gameObject;
        if(Slot[i].transform.childCount > 0){
          IsFull[i]=true;
        }else{ IsFull[i]=false;}
      }
    }


    private void InventotySlotPermissionFinder(string name){
      for (int i = 0; i < AllSlots; i++) {
        if (IsFull[i]==false) {
          IsFull[i]=true;
          GameObject.Find(name).SendMessage("SendItemToInventoryNow",i);
          break;
        }
      }
    }


    public void OpenCloseInventory(){
      InventoryEnabled=!InventoryEnabled;
    }


    public void CheckInventorySlot(string ID){
      int a=int.Parse(ID);
      if (Slot[a].transform.childCount == 0) {
        if (MemoryUnit.SceneName=="Level Map") {
          GameObject.Find("Canvas/PlayerCanvas/PlayerInventory/InventorySlotHolder/InventorySlot ("+ID+")").SendMessage("PermissionReciever");
          }else{
            GameObject.Find("Canvas/PlayerInventory/InventorySlotHolder/InventorySlot ("+ID+")").SendMessage("PermissionReciever");
          }
        IsFull[a]=true;
      }else{IsFull[a]=false; ;}
    }


    public void IsFullSwitch(int ID){
      if (IsFull[ID]==false) {
        IsFull[ID]=true;
      }else{
        IsFull[ID]=false;
      }
    }









    //Save Inventory
    public void SaveGame(string KeyCode){
      Debug.Log("Saing Inventory");
      for (int i =0;i!=AllSlots;i++) {
        //Debug.Log(i.ToString()+Slot[i].name);
          if (Slot[i].transform.childCount>0){
            PlayerPrefs.SetString(Slot[i].name+KeyCode,Slot[i].transform.GetChild(0).gameObject.name);
            //Debug.Log(Slot[i].name+Slot[i].transform.GetChild(0).gameObject.name);
          }else{PlayerPrefs.DeleteKey(Slot[i].name+KeyCode);}
      }
    }

    public void LoadGame(string KeyCode){
      for (int i =0;i!=AllSlots;i++) {
        if (Slot[i].transform.childCount==0) {
          UnityEngine.Object prefab = Resources.Load("Loot/"+PlayerPrefs.GetString(Slot[i].name+KeyCode), typeof(GameObject));
          if (prefab!=null) {
            GameObject player = Instantiate(prefab,Slot[i].transform) as GameObject;
            player.transform.SetParent(Slot[i].transform);
            player.name=PlayerPrefs.GetString(Slot[i].name+KeyCode);
          }
        }
      }
    }
}
