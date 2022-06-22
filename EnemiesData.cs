using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesData : MonoBehaviour
{
    public EnemyType[] enemyTypes;
}

[System.Serializable]
public class EnemyType
{
    public string name;
    public Sprite sprite;
    public int spawnChance;
    public int hp;
    public int maxHP;
    public int baseAttack;
    public int ac;
    public int baseDamage;
    public int bonusDamage;
}

[System.Serializable]
public class Enemy
{
    public Vector2Int position;
    public string name;
    public EnemyBrain brain;
    public int hp;
    public int maxHP;
    public int baseAttack;
    public int ac;
    public int baseDamage;
    public int bonusDamage;
    public bool isDead;
}
