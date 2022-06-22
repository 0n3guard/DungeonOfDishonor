using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public static int RollDice(int dices, int faces)
    {
        int roll = 0;

        for (int i = 0; i < dices; i++)
        {
            roll += Random.Range(1, faces);
        }

        return roll;
    }
}
