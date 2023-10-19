using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class DiceRoll : MonoBehaviour
{
    public Sprite dice1;
    public Sprite dice2;
    public Sprite dice3;
    public Sprite dice4;
    public Sprite dice5;
    public Sprite dice6;
    public Image Dice;
    public Animation DiceFly;


    public void DiceImage(int DiceValue)
    {
        
        if (DiceValue == 1)
        {
            Dice.sprite = dice1;
        }
        else if (DiceValue == 2)
        {
            Dice.sprite = dice2;
        }
        else if (DiceValue == 3)
        {
            Dice.sprite = dice3;
        }
        else if (DiceValue == 4)
        {
            Dice.sprite = dice4;
        }
        else if (DiceValue == 5)
        {
            Dice.sprite = dice5;
        }
        else if (DiceValue == 6)
        {
            Dice.sprite = dice6;
        }
    }
 

}
