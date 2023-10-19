using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendItemToInventory : MonoBehaviour
{
  private void SendItemToInventoryNow(int TargetSlot){
    Transform child = this.transform.GetChild(0);
    Debug.Log("moving object: " + child.name);
    Debug.Log("Canvas/PlayerInventory/InventorySlotHolder/InventorySlot("+TargetSlot.ToString()+")");
    child.SetParent(GameObject.Find("Canvas/PlayerInventory/InventorySlotHolder/InventorySlot ("+TargetSlot.ToString()+")").transform, false);
  }
  
  public void RequestInventorySlotPermission(){
    if ( GameObject.Find("PlayerInventory").activeSelf ){
      bool PermissionGranted=false;
      Transform[] ts = GetComponentsInChildren<Transform>();
      foreach(Transform t in ts){
        if(ts.Length>1 & PermissionGranted==false){
          string name=this.name;
          GameObject.Find("Fighters").SendMessage("InventotySlotPermissionFinder",name);
          PermissionGranted=true;

          }
        }
      }
    }



}
