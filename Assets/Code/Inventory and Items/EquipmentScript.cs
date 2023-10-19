using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEngine.Animations;

public class EquipmentScript : MonoBehaviour,IDropHandler
{
  Transform  OriginalPosition;
  public string SlotType;
  public string ParentName;
  public bool IsFull;
  public GameObject SlotImage;
  public GameObject StartingWeapon;


  //WeaponSlot
  //Rings
  //Special
  //Consumable




    private void Awake(){
      SlotImage=GameObject.Find(SlotType+"Image");
      IsFull=false;
      CheckIfFull();
    }
    public void OnDrop(PointerEventData data){
      Debug.Log(SlotType+" "+data.pointerDrag.tag);
      if (SlotType==data.pointerDrag.tag){
        if (IsFull==false) {
          if (data.pointerDrag != null) {

            GameObject DraggedItem= data.pointerDrag;
            //DraggedItem.transform.GetChild(0).gameObject.GetComponent<EventTrigger>.SetActive(false);
            DraggedItem.transform.SetParent(this.transform, false);
            IsFull=true;
            Debug.Log(this.transform.parent.parent.name);
            this.transform.parent.parent.gameObject.SendMessage("ActionSwitch");
          }
        }
      }
      ImageManager();
    }


  public void ItemPower(string action){
    if (action=="MainAction" | action=="SecondaryAction" ) {
      this.transform.GetChild(0).gameObject.SendMessage(action);

    }
  }


  public void IsFullManager(bool SetTo){
    IsFull=SetTo;
    ImageManager();
  }


  private void ImageManager(){
    SlotImage.SetActive(false);
    if (IsFull==false) {
      SlotImage.SetActive(true);
    }
  }

  public void CheckIfFull(){
    IsFull=false;
    ParentName=this.transform.parent.name;
    Transform[] ts = GetComponentsInChildren<Transform>();
    foreach(Transform t in ts){
      if (this.name!=t.name) {
        //Debug.Log("didit");
        IsFull=true;
        break;
      }
    }
    ImageManager();
  }





  //Save Equipment
  public void SaveGame(string KeyCode){
    Debug.Log("Saving Equipment "+KeyCode);
    if (this.transform.childCount>0) {
      IsFull=true;
      //Debug.Log(this.name+this.transform.GetChild(0).gameObject.name);
      PlayerPrefs.SetString(this.name+KeyCode,this.transform.GetChild(0).gameObject.name);
    }else{PlayerPrefs.DeleteKey(this.name+KeyCode);}
  }

  public void LoadGame(string KeyCode){
    Debug.Log("EquipmentLoad");
      if (this.transform.childCount<=0) {
        UnityEngine.Object prefab = Resources.Load("Loot/"+PlayerPrefs.GetString(this.name+KeyCode), typeof(GameObject));
        if (prefab!=null) {
          //Debug.Log("actually gonna try Loading Equipment");
          GameObject player = Instantiate(prefab,this.transform) as GameObject;
          player.transform.SetParent(this.transform);
          player.name=PlayerPrefs.GetString(this.name+KeyCode);
        }
      }
      CheckIfFull();
    }
  public void StartingEquipmentLoad(){
    StartingWeapon = Instantiate(StartingWeapon,this.transform) as GameObject;
    StartingWeapon.transform.SetParent(this.transform);
    StartingWeapon.name="Starting" + this.name;
    CheckIfFull();
  }
}
