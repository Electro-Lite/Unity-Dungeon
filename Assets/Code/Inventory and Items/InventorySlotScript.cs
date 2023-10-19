using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotScript : MonoBehaviour,IDropHandler
{
  Transform  OriginalPosition;
  private bool SlotReady=false;
  private string SlotID;

  public void OnDrop(PointerEventData data){
    GameObject.Find("Fighters").SendMessage("CheckInventorySlot",SlotID);
    if (SlotReady==true) {
      if (data.pointerDrag != null) {
        GameObject DraggedItem= data.pointerDrag;
        DraggedItem.SendMessage("SendOriginalPositionToRecipiant",this.name);//idk why i need this, worked without
        //DraggedItem.SendMessage("ItemDestriptionTransformControler");
        if (MemoryUnit.SceneName=="Level Map") {DraggedItem.transform.SetParent(GameObject.Find("Canvas/PlayerCanvas/PlayerInventory/InventorySlotHolder/InventorySlot ("+SlotID+")").transform, false);
        }
        else{DraggedItem.transform.SetParent(GameObject.Find("Canvas/PlayerInventory/InventorySlotHolder/InventorySlot ("+SlotID+")").transform, false);
        }

        //empty previous slot
        string ParentName=OriginalPosition.parent.gameObject.name;
        int InventorySlotToSwitch=0;
        if (ParentName.Length==17) {
          InventorySlotToSwitch=int.Parse(ParentName[15].ToString());
          GameObject.Find("Fighters").SendMessage("IsFullSwitch",InventorySlotToSwitch);
        }else if (ParentName.Length==18) {
          InventorySlotToSwitch=int.Parse(ParentName[15].ToString()+this.name[16].ToString());

          GameObject.Find("Fighters").SendMessage("IsFullSwitch",InventorySlotToSwitch);

        }


        SlotReady=false;
      }
    }


  }
  private void Awake(){
    if (this.name.Length<=17) {
      SlotID=this.name[15].ToString();
    }else{
      SlotID=this.name[15].ToString()+this.name[16].ToString();
    }


  }
  public void PermissionReciever(){//permision to transfer item to slot
    SlotReady=true;
  }
  public void OriginalPositionReciever(Transform TempTransform){
    OriginalPosition=TempTransform;
  }
  public void IsFullManager(bool SetTo){
  }




}
