using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    public int level=10;
    public int health=3;
    public float[] position;

    public PlayerData(){
      level=10;
      health=3;
    }
}
