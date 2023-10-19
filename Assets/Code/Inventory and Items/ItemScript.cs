using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class ItemScript : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
  private GameObject Canvas;
  private Canvas CanvasRT;
  private CanvasGroup canvasGroup;
  private RectTransform TransformThis;
  private Vector2 OriginalPosition;
  private bool WasDropped=false;
  public GameObject Description;
  private TextMeshProUGUI DescriptionText;
  private EventTrigger trigger;
  public Vector3 Offset;
  private Transform OriginalParent;

    //Draging and Droping
    private void Start(){
      Canvas= GameObject.Find("Canvas");
      CanvasRT=Canvas.GetComponent<Canvas>();
      TransformThis=GetComponent<RectTransform>();
      trigger = GetComponent<EventTrigger>( );
      EventTrigger.Entry Entry1 = new EventTrigger.Entry( );
      Entry1.eventID = EventTriggerType.PointerEnter;
      Entry1.callback.AddListener( ( data ) => { OnPointerEnterDelegate( ( PointerEventData ) data ); } );
      trigger.triggers.Add( Entry1 );
      EventTrigger.Entry Entry2 = new EventTrigger.Entry( );
      Entry2.eventID = EventTriggerType.PointerExit;
      Entry2.callback.AddListener( ( data ) => { OnPointerExitDelegate( ( PointerEventData ) data ); } );
      trigger.triggers.Add( Entry2 );
      canvasGroup=GetComponent<CanvasGroup>();
      OriginalPosition=TransformThis.anchoredPosition;
      Description=GameObject.Find("Description");//must be enabled at the start of game
      Description=InventoryManager.Description;
      DescriptionText=Description.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnterDelegate( PointerEventData data ){
      DescriptionText.SetText(this.name);
      Description.SetActive(true);
    }
    public void OnPointerExitDelegate( PointerEventData data ){
      Description.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData){
      for (int i=1; i<=5; i++) {
        string ParentName=  this.transform.parent.name;
        string ComparisonParentName="Slot"+ i.ToString();
        if (ParentName==ComparisonParentName) {
          //GameObject.Find(ParentName).SendMessage("RequestInventorySlotPermission");
        }
      }
    }
    public void OnBeginDrag(PointerEventData eventData){
      OriginalParent=this.transform.parent;
      canvasGroup.blocksRaycasts=false;
      if (MemoryUnit.SceneName=="Level Map") {
        this.transform.SetParent(GameObject.Find("tmpItemHolder").transform);
      }
    }
    public void OnEndDrag(PointerEventData eventData){
      canvasGroup.blocksRaycasts=true;
      if (this.transform.parent.name=="tmpItemHolder") {
        this.transform.SetParent(OriginalParent);
      }
      TransformThis.anchoredPosition=OriginalPosition;
      GameObject.Find("Canvas/PlayerCanvas").BroadcastMessage("CheckIfFull");

    }
    public void OnDrag(PointerEventData eventData){
      TransformThis.anchoredPosition+=eventData.delta / CanvasRT.scaleFactor;
      //Debug.Log(Screen.width.ToString()+"  "+Screen.height.ToString());


    }/*
    public void SendOriginalPositionToRecipiant(string RecipiantName){
      Debug.Log("Sent Org Position to: "+RecipiantName);
      GameObject.Find(RecipiantName).SendMessage("OriginalPositionReciever",OriginalPosition);
    }*/
}
