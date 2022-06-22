using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public int id;
    public Vector2Int position;

    EnemyVisibility visibility;

    public void Initialize(int newID, Vector2Int newPosition)
    {
        id = newID;
        position = newPosition;

        visibility = GetComponent<EnemyVisibility>();
        visibility.Initialize();
    }

    public void DoTurn()
    {
        Vector2Int player;

        if (EnemyPerception.IsPlayerVisible(position, out player))
        {
            Debug.Log("Player is visible, moving");
            List<Vector2Int> path = AStar.CalculatePath(position, player);
            Debug.Log("path length: " + path.Count);
            EnemyMovement.Move(path[0], this);
        }
    }
}
