using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogOfWarScript : MonoBehaviour
{
    public GameObject FogOfWarToggle;
    public GameObject FogOfWarCanvas;
    // Start is called before the first frame update
    void Awake(){
      Debug.Log("Start FogOfWarToggle");
      if(PlayerPrefs.GetString("IsOn")=="true"){
        FogOfWarToggle.GetComponent<Toggle>().isOn=true;
        FogOfWarCanvas.SetActive(true);
      }else{
        FogOfWarToggle.GetComponent<Toggle>().isOn=false;
        FogOfWarCanvas.SetActive(false);
      }
    }
    public void Toggle()
    {
      if(FogOfWarToggle.GetComponent<Toggle>().isOn==false){
        FogOfWarCanvas.SetActive(false);
        PlayerPrefs.SetString("IsOn","false");
      }else{
        FogOfWarCanvas.SetActive(true);
        PlayerPrefs.SetString("IsOn","true");
      }
    }

}
