using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameSaveScript : MonoBehaviour
{
  public GameObject Player;
    /*
    // Start is called before the first frame update
    string f="joj";
    public void  SaveGame(){
      string path ="C:/Users/Electro/Desktop/SaveFile.txt";
      BinaryFormatter Formatter=new BinaryFormatter();
    //  FileStream FStream= new FileStream(path, FileMode.Create);
      //player info: health equip inventory
      //Player position
      //living enemies
      System.IO.File.WriteAllText(path+".txt","Joj to som sa lekol");
      //Formatter.Serialize(FStream,f);
      //FStream.Close();
    }
    public void  LoadGame(){
      string path ="C:/Users/Electro/Desktop/SaveFile";
      BinaryFormatter Formatter=new BinaryFormatter();
      FileStream FStream= new FileStream(path, FileMode.Open);
      //player info: health equip inventory
      //Player position
      //living enemies
      Debug.Log(Formatter.Deserialize(FStream));
      FStream.Close();
    }
    */

    public void SaveGame(){
      PlayerPrefs.SetFloat("PlayerPositionX",Player.transform.position.x);
      PlayerPrefs.SetFloat("PlayerPositionY",Player.transform.position.y);
      PlayerPrefs.SetFloat("PlayerPositionZ",Player.transform.position.z);
    }
    public void LoadGame(){
      float X =PlayerPrefs.GetFloat("PlayerPositionX",0);
      float Y =PlayerPrefs.GetFloat("PlayerPositionY",0);
      float Z =PlayerPrefs.GetFloat("PlayerPositionZ",0);
      Player.transform.position=new Vector3(X,Y,Z);

    }

}
