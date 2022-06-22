using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyBrain brain;

    private void Start()
    {
        brain = GetComponent<EnemyBrain>();
    }

    public void DealDamage(int damage)
    {
        MapManager.enemies[brain.id].hp -= damage;

        if (MapManager.enemies[brain.id].hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        MapManager.enemies[brain.id].isDead = true;
        MapManager.map[brain.position.x, brain.position.y].hasEnemy = false;
        MapManager.map[brain.position.x, brain.position.y].enemyID = -1;
        MapManager.map[brain.position.x, brain.position.y].enemyObject = null;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
