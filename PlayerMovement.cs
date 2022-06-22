using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Vector2Int position;

    GameManager manager;
    DungeonGenerator dungeon;

    bool initialized = false;

    public void Initialize()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        dungeon = GameObject.Find("DungeonGenerator").GetComponent<DungeonGenerator>();

        Move(InputToVector(0, 0));
        initialized = true;
    }

    private void Update()
    {
        if (initialized && manager.isPlayerTurn)
        {
            if (Input.GetKeyUp("up") || Input.GetKeyUp("w") || Input.GetKeyUp(KeyCode.Keypad8))
            {
                Move(InputToVector(0, 1));
            }
            if (Input.GetKeyUp("down") || Input.GetKeyUp("s") || Input.GetKeyUp(KeyCode.Keypad2))
            {
                Move(InputToVector(0, -1));
            }
            if (Input.GetKeyUp("left") || Input.GetKeyUp("a") || Input.GetKeyUp(KeyCode.Keypad4))
            {
                Move(InputToVector(-1, 0));
            }
            if (Input.GetKeyUp("right") || Input.GetKeyUp("d") || Input.GetKeyUp(KeyCode.Keypad6))
            {
                Move(InputToVector(1, 0));
            }
            if (Input.GetKeyUp(KeyCode.Keypad7) || Input.GetKeyUp("q"))
            {
                Move(InputToVector(-1, 1));
            }
            if (Input.GetKeyUp(KeyCode.Keypad9) || Input.GetKeyUp("e"))
            {
                Move(InputToVector(1, 1));
            }
            if (Input.GetKeyUp(KeyCode.Keypad1) || Input.GetKeyUp("z"))
            {
                Move(InputToVector(-1, -1));
            }
            if (Input.GetKeyUp(KeyCode.Keypad3) || Input.GetKeyUp("c"))
            {
                Move(InputToVector(1, -1));
            }
            if (Input.GetKeyUp(KeyCode.Escape))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                SceneManager.LoadScene(0);
            }
        }
    }

    Vector2Int InputToVector(int x, int y)
    {
        Vector2Int target = new Vector2Int(position.x + x, position.y + y);

        return target;
    }

    void Move(Vector2Int target)
    {
        if (MapManager.map[target.x, target.y].hasEnemy)
        {
            Attack(MapManager.map[target.x, target.y].enemyObject.GetComponent<EnemyBrain>());
        }
        else if (MapManager.map[target.x, target.y].isWalkable)
        {
            MapManager.map[position.x, position.y].hasPlayer = false;
            MapManager.map[position.x, position.y].secondChar = "";
            position = target;
            MapManager.map[position.x, position.y].hasPlayer = true;
            MapManager.map[position.x, position.y].secondChar = "@";

            transform.position = new Vector3(position.x * dungeon.tileScaling, position.y * dungeon.tileScaling, transform.position.z);
        }

        manager.FinishPlayersTurn();
    }

    void Attack(EnemyBrain enemy)
    {
        int roll = DiceRoller.RollDice(1, 20);

        Debug.Log("Rolled " + roll + ", enemy has AC " + MapManager.enemies[enemy.id].ac);

        if ((roll + PlayerManager.stats.attackBonus) > MapManager.enemies[enemy.id].ac)
        {
            int damage = DiceRoller.RollDice(PlayerManager.stats.dicesDamage, PlayerManager.stats.sidesDamage);
            damage += PlayerManager.stats.bonusDamage;

            Debug.Log("Dealt " + damage + " damage!");
            enemy.gameObject.GetComponent<EnemyHealth>().DealDamage(damage);
        }
        else
        {
            Debug.Log("Miss!");
        }
    }
}
