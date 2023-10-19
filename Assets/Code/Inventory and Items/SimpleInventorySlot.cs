using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleInventorySlot : MonoBehaviour,IDropHandler
{
  Transform  OriginalPosition;
  public string SlotType;
  public string ParentName;
  public bool IsFull;
  //WeaponSlot
  //Rings
  //Special
  //Consumable
  public void OnDrop(PointerEventData data){
    Debug.Log("drop");
    if (IsFull==false) {
      Debug.Log("SlotReady");
      if (data.pointerDrag != null) {
        Debug.Log("smething ?");

        GameObject DraggedItem= data.pointerDrag;
        //DraggedItem.transform.GetChild(0).gameObject.GetComponent<EventTrigger>.SetActive(false);
        DraggedItem.transform.SetParent(this.transform, false);
        IsFull=true;
      }
    }
  }

  private void Awake(){
    IsFull=false;
    ParentName=this.transform.parent.name;
    Transform[] ts = GetComponentsInChildren<Transform>();
         foreach(Transform t in ts){
           if (this.name!=t.name) {
             Debug.Log("didit");
             IsFull=true;
             break;
           }
         }
  }

  public void IsFullManager(bool SetTo){
    IsFull=SetTo;
    Debug.Log(this.name);
  }
}
