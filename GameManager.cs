using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    DungeonGenerator dungeonGenerator;
    public PlayerMovement player;

    public bool isPlayerTurn;

    void Start()
    {
        dungeonGenerator = GameObject.Find("DungeonGenerator").GetComponent<DungeonGenerator>();

        dungeonGenerator.InitializeDungeon();
        dungeonGenerator.GenerateDungeon();

        FoV.Initialize();

        player.Initialize();

        AStar.Initialize(dungeonGenerator);

        FirstTurn();
    }

    public void FirstTurn()
    {

        FoV.GetPlayerFoV(player.position);
        UpdateVisibility();

        isPlayerTurn = true;
    }

    public void FinishPlayersTurn()
    {
        isPlayerTurn = false;

        FoV.GetPlayerFoV(player.position);
        UpdateVisibility();

        EnemyTurn();
    }

    void EnemyTurn()
    {
        // TODO: Enemy turn;
        foreach (Enemy enemy in MapManager.enemies)
        {
            if (!enemy.isDead)
            {
                enemy.brain.DoTurn();
            }
        }

        isPlayerTurn = true;
    }

    void UpdateVisibility()
    {
        for (int y = 0; y < dungeonGenerator.mapHeight; y++)
        {
            for (int x = 0; x < dungeonGenerator.mapWidth; x++)
            {
                if (MapManager.map[x, y] != null)
                {
                    FoV.VisibilityCheck(new Vector2Int(x, y));

                    if (MapManager.map[x, y].hasEnemy)
                    {
                        MapManager.map[x, y].enemyObject.GetComponent<EnemyVisibility>().VisibilityCheck(new Vector2Int(x, y));
                    }
                }
            }
        }
    }
}
