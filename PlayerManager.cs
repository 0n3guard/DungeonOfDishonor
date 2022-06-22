using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerStats stats;

    public int baseAC = 12;
    public int baseAttackBonus = 0;
    public int baseDicesDamage = 1;
    public int baseSidesDamage = 2;
    public int baseBonusDamage = 0;

    public void Initialize()
    {
        stats = new PlayerStats()
        {
            ac = baseAC,
            attackBonus = baseAttackBonus,
            dicesDamage = baseDicesDamage,
            sidesDamage = baseSidesDamage,
            bonusDamage = baseBonusDamage
        };
    }
}

public class PlayerStats
{
    public int ac;
    public int attackBonus;
    public int dicesDamage;
    public int sidesDamage;
    public int bonusDamage;
}
