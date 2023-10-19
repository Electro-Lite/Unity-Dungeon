using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
  public GameObject FogOfWarPlane;
  public Transform Player;
  public LayerMask FogOfWarLayer;
  public float ViewRadius=5f;
  public float ViewRadiusSqr{get {return ViewRadius*ViewRadius;}}

  private Mesh FogMesh;
  private Vector3[] m_vertices;
  private Color[] FogColor;

    // Start is called before the first frame update
    void Start(){
      Initialize();
    }

    // Update is called once per frame
    void Update(){
      Ray r=new Ray(transform.position, Player.position-transform.position);
      RaycastHit hit;
      if (Physics.Raycast(r, out hit,1000,FogOfWarLayer,QueryTriggerInteraction.Collide)){
        for (int i=0; i<m_vertices.Length;i++) {
          Vector3 v=FogOfWarPlane.transform.TransformPoint(m_vertices[i]);
          float dist=Vector3.SqrMagnitude(v-hit.point);
          if(dist < ViewRadiusSqr){
            float alpha = Mathf.Min(FogColor[i].a,dist/ViewRadiusSqr);
            FogColor[i].a=alpha;
          }
        }
      }
    }
    void Initialize(){
      FogMesh =FogOfWarPlane.GetComponent<MeshFilter>().mesh;
      m_vertices=FogMesh.vertices;
      FogColor= new Color[m_vertices.Length];
      for (int i=0;i<FogColor.Length;i++) {
        FogColor[i]=Color.black;
      }
      UpdateColor();
    }
    void UpdateColor(){
      FogMesh.colors=FogColor;
    }
}
