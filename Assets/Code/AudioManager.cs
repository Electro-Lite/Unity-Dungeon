using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
  public Sound[] Sounds;
  public static AudioManager Instance;
    void Awake(){
      if (Instance==null){
        Instance=this;
      }else{
        Destroy(gameObject);
        return;
      }
      DontDestroyOnLoad(gameObject);
      foreach(Sound s in Sounds){
        s.source=gameObject.AddComponent<AudioSource>();
        s.source.clip=s.clip;
        s.source.volume=s.volume;
        s.source.pitch=s.pitch;
        s.source.loop=s.loop;
      }
      Play("BackgroundOrchestra");
    }
  public void Play(string name){
    Sound s=Array.Find(Sounds, Sound => Sound.name==name);
    if (s == null) {
      Debug.LogWarning("Sound" +name+ "not found!");
      return;
    }
    s.source.Play();
  }
  public void Stop(string name){
    Sound s=Array.Find(Sounds, Sound => Sound.name==name);
    if (s == null) {
      Debug.LogWarning("Sound" +name+ "not found!");
      return;
    }
    s.source.Stop();
  }
}
