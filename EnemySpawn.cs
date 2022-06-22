using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject prefab;
    public GameObject parent;

    public void SpawnEnemy(Vector2Int position, float tileScaling)
    {
        GameObject enemyObject = Instantiate(prefab, new Vector3(position.x * tileScaling, position.y * tileScaling, -0.5f), Quaternion.identity);
        enemyObject.transform.parent = parent.transform;

        int dataID;
        Enemy enemy = new Enemy() { position = position, name = CallEnemy(out dataID) };
        enemy.hp = GetComponent<EnemiesData>().enemyTypes[dataID].maxHP;
        enemy.ac = GetComponent<EnemiesData>().enemyTypes[dataID].ac;
        enemy.baseAttack = GetComponent<EnemiesData>().enemyTypes[dataID].baseAttack;
        enemy.baseDamage = GetComponent<EnemiesData>().enemyTypes[dataID].baseDamage;
        enemy.bonusDamage = GetComponent<EnemiesData>().enemyTypes[dataID].bonusDamage;

        enemyObject.name = enemy.name;

        enemyObject.GetComponent<SpriteRenderer>().sprite = GetComponent<EnemiesData>().enemyTypes[dataID].sprite;
        MapManager.enemies.Add(enemy);

        int id = MapManager.enemies.IndexOf(enemy);

        MapManager.map[position.x, position.y].hasEnemy = true;
        MapManager.map[position.x, position.y].enemyObject = enemyObject;
        MapManager.map[position.x, position.y].enemyID = id;

        enemyObject.GetComponent<EnemyBrain>().Initialize(id, position);
        enemy.brain = enemyObject.GetComponent<EnemyBrain>();
    }

    string CallEnemy(out int id)
    {
        string name = "";

        id = -1;
        int chance = Random.Range(1, 100);

        EnemiesData data = GetComponent<EnemiesData>();

        for (int i = data.enemyTypes.Length - 1; i >= 0; i--)
        {
            if (chance <= data.enemyTypes[i].spawnChance)
            {
                name = data.enemyTypes[i].name;
                id = i;
                break;
            }
        }

        return name;
    }
}
