using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFigheterManager : MonoBehaviour
{
  public string ActiveFigheter;
  RectTransform HunterssEquipmentPosition;
  RectTransform BarbarianEquipmentPosition;
  RectTransform DruidEquipmentPosition;
  RectTransform ThiefEquipmentPosition;
  public GameObject BarbarianEquipment;
  public GameObject DruidEquipment;
  public GameObject HuntressEquipment;
  public GameObject ThiefEquipment;
  public GameObject BarbarianAbilities;
  public GameObject DruidAbilities;
  public GameObject HuntressAbilities;
  public GameObject ThiefAbilities;

    // Start is called before the first frame update

    public void Start(){
      BarbarianAbilities=GameObject.Find("Canvas/Fighters/Barbarian/Abilities");
      DruidAbilities=GameObject.Find("Canvas/Fighters/Druid/Abilities");
      HuntressAbilities=GameObject.Find("Canvas/Fighters/Huntress/Abilities");
      ThiefAbilities=GameObject.Find("Canvas/Fighters/Thief/Abilities");
      BarbarianEquipment=GameObject.Find("Canvas/Fighters/Barbarian/Equipment");
      DruidEquipment=GameObject.Find("Canvas/Fighters/Druid/Equipment");
      HuntressEquipment=GameObject.Find("Canvas/Fighters/Huntress/Equipment");
      ThiefEquipment=GameObject.Find("Canvas/Fighters/Thief/Equipment");
    }

    public void Switch (string ActiveFigheter){
      if (ActiveFigheter=="Barbarian") {
        BarbarianAbilities.SetActive(true);
        DruidAbilities.SetActive(false);
        HuntressAbilities.SetActive(false);
        ThiefAbilities.SetActive(false);
        BarbarianEquipment.SetActive(true);
        DruidEquipment.SetActive(false);
        HuntressEquipment.SetActive(false);
        ThiefEquipment.SetActive(false);

      }else if (ActiveFigheter=="Druid") {
        DruidAbilities.SetActive(true);
        BarbarianAbilities.SetActive(false);
        HuntressAbilities.SetActive(false);
        ThiefAbilities.SetActive(false);
        DruidEquipment.SetActive(true);
        BarbarianEquipment.SetActive(false);
        HuntressEquipment.SetActive(false);
        ThiefEquipment.SetActive(false);

      }else if (ActiveFigheter=="Huntress") {
        HuntressAbilities.SetActive(true);
        DruidAbilities.SetActive(false);
        BarbarianAbilities.SetActive(false);
        ThiefAbilities.SetActive(false);
        HuntressEquipment.SetActive(true);
        DruidEquipment.SetActive(false);
        BarbarianEquipment.SetActive(false);
        ThiefEquipment.SetActive(false);

      }else if (ActiveFigheter=="Thief") {
        ThiefAbilities.SetActive(true);
        HuntressAbilities.SetActive(false);
        DruidAbilities.SetActive(false);
        BarbarianAbilities.SetActive(false);
        ThiefEquipment.SetActive(true);
        HuntressEquipment.SetActive(false);
        DruidEquipment.SetActive(false);
        BarbarianEquipment.SetActive(false);

      }else{//no one
        ThiefAbilities.SetActive(false);
        HuntressAbilities.SetActive(false);
        DruidAbilities.SetActive(false);
        BarbarianAbilities.SetActive(false);
        ThiefEquipment.SetActive(false);
        HuntressEquipment.SetActive(false);
        DruidEquipment.SetActive(false);
        BarbarianEquipment.SetActive(false);
      }
    }
    public void SaveEquipment(){
      ThiefEquipment.SetActive(true);
      HuntressEquipment.SetActive(true);
      DruidEquipment.SetActive(true);
      BarbarianEquipment.SetActive(true);
      GameObject.Find("Daggers").SendMessage("SaveEquipment");
      GameObject.Find("Bow").SendMessage("SaveEquipment");
      GameObject.Find("Staff").SendMessage("SaveEquipment");
      GameObject.Find("Axe").SendMessage("SaveEquipment");


    }
}
