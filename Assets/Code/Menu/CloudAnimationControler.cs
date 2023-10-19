using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CloudAnimationControler : MonoBehaviour
{
    public Animator CloudAnim;
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(DelayAnim());
    }
    IEnumerator DelayAnim(){
      yield return new WaitForSeconds(Random.Range(0, 12));
      CloudAnim.Play(Random.Range(0,2).ToString());
    }

}
