using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestriptionScript : MonoBehaviour
{
  public RectTransform MovingObject;
  public Vector3 Offset;
  public RectTransform Basis;
  public Camera Cam;

    // Update is called once per frame
    void Update()
    {
      MoveObject();
    }

    public void MoveObject(){
      Vector3 pos = Input.mousePosition + Offset;
      MovingObject.position=pos;
    }

}
