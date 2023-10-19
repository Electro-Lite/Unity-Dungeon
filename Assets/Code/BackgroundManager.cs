using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject BackroundForest;
    public GameObject BackroundKats;
    public GameObject BackroundLava;
    private string Location;

    void Start()
    {
      Location=PlayerPrefs.GetString("FightLocation");
      if (Location=="Forest") {BackroundForest.SetActive(true);}
      if (Location=="Kats") {BackroundKats.SetActive(true);}
      if (Location=="Lava") {BackroundLava.SetActive(true);}

    }


}
