using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAI
{
    public static void MakeDecision(EnemyBrain brain)
    {
        Vector2Int playerPosition;

        if (EnemyPerception.IsPlayerVisible(brain.position, out playerPosition))
        {
            Chase(brain, playerPosition);
        }
        else
        {
            Patrol(brain);
        }
    }

    static void Patrol(EnemyBrain brain)
    {
        List<Vector2Int> potentialPositions = new List<Vector2Int>();

        foreach (Vector2Int pos in GetNeighboringPositions(brain.position))
        {
            if (MapManager.map[pos.x, pos.y].isWalkable && !MapManager.map[pos.x, pos.y].hasEnemy)
            {
                potentialPositions.Add(pos);
            }
        }

        if (potentialPositions.Count > 0)
        {
            int roll = Random.Range(0, potentialPositions.Count - 1);
            Vector2Int target = potentialPositions[roll];

            EnemyMovement.Move(target, brain);
        }
    }

    static List<Vector2Int> GetNeighboringPositions(Vector2Int position)
    {
        List<Vector2Int> positions = new List<Vector2Int>();

        positions.Add(new Vector2Int(position.x + 1, position.y - 1));
        positions.Add(new Vector2Int(position.x + 1, position.y + 1));
        positions.Add(new Vector2Int(position.x + 1, position.y));
        positions.Add(new Vector2Int(position.x - 1, position.y + 1));
        positions.Add(new Vector2Int(position.x - 1, position.y));
        positions.Add(new Vector2Int(position.x - 1, position.y - 1));
        positions.Add(new Vector2Int(position.x, position.y - 1));
        positions.Add(new Vector2Int(position.x, position.y + 1));

        return positions;
    }

    static void Chase(EnemyBrain brain, Vector2Int playerPosition)
    {
        List<Vector2Int> path = AStar.CalculatePath(brain.position, playerPosition);

        EnemyMovement.Move(path[0], brain);
    }
}