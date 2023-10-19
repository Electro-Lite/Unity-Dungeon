using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;


public class MainMenu : MonoBehaviour
{
  public Button ContinueButton;
  private bool MenuOn=false;
  private bool AnimHelper=true;
  private float Volume;
  public AudioMixer AudioMix;
  public Dropdown DropdownMenu;
  public GameObject SettingsMenu;
  public GameObject RoomCountText;
    // Start is called before the first frame update
    void Start(){
      SettingsMenu.SetActive(true);
      if (PlayerPrefs.GetInt("GameSaved")!=1) {
        ContinueButton.interactable=false;
        Debug.Log("Disabled");
      }
      SettingsMenu.SetActive(false);
    }
    private void Update(){
      if (Input.GetKey("escape") & AnimHelper==true){
        AnimHelper=false;
        StartCoroutine( MenuAnim() );
      }
    }

    public void PlayGame (int ContinueGame){
      MemoryUnit.StartGame=ContinueGame;
      StartCoroutine( WaitAndLoad(2,"Level Map") );
    }
    IEnumerator WaitAndLoad(int a, string Scene){
      var Transition = GameObject.Find("TransitionImage").GetComponent<Animator>();
      Transition.Play("TransitionAnim");
      yield return new WaitForSeconds(a);
      SceneManager.LoadScene(Scene);
    }

    public void Quit(){Application.Quit();}
    public void CloseMenu(){
      StartCoroutine(MenuAnim());
    }

    IEnumerator MenuAnim(){
      if (MenuOn==false) {
        this.GetComponent<Animator>().Play("On");
      }
      else if (MenuOn==true) {
        this.GetComponent<Animator>().Play("Off");
      }
      MenuOn=!MenuOn;
      yield return new WaitForSeconds(1);
      AnimHelper=true;
    }
    public void MasterVolume(){
      Volume = GameObject.Find ("VolumeSlider").GetComponent <Slider> ().value;
      AudioMix.SetFloat("VolumeOfMaster",Volume);
      Debug.Log(Volume);
    }
    public void SetQuality(){
      QualitySettings.SetQualityLevel(DropdownMenu.value);
      Debug.Log(DropdownMenu.value);
    }
    public void RoomCount(){
      if (MemoryUnit.SceneName=="Level Map"){
        int RoomCount=PlayerPrefs.GetInt("RoomCount");
        if (RoomCount>0) {
          RoomCount++;
        }else{RoomCount=1;}
        PlayerPrefs.SetInt("RoomCount",RoomCount);
        RoomCountText.GetComponent<TextMeshProUGUI>().SetText("Entering room number #"+RoomCount.ToString());
        RoomCountText.SetActive(true);

      }
    }

}
