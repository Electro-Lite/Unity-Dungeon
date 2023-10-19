using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AttackAnimScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayAttackAnim(string rarity){this.GetComponent<Animator>().Play(rarity);}


}
