using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPerception
{
    public static bool IsPlayerVisible(Vector2Int position, out Vector2Int player)
    {
        bool isVisible = false;
        player = new Vector2Int();

        foreach (Vector2Int pos in FoV.GetEnemyFoV(position))
        {
            if (MapManager.map[pos.x, pos.y].hasPlayer)
            {
                isVisible = true;
                player = pos;
                break;
            }
        }

        return isVisible;
    }
}
