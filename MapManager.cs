using System.Collections;
using System; 
using System.Collections.Generic;
using UnityEngine;

public class MapManager
{
    public static Tile[,] map; 
    public static List<Enemy> enemies;
}

[Serializable] 
public class Tile
{ 
    public int xPosition;
    public int yPosition; 
    [NonSerialized]
    public GameObject baseObject; 
    public string type; 
    public bool hasPlayer = false;
    public bool isWalkable = false;
    public string baseChar;
    public string secondChar = "";
    public bool isOpaque = false;
    public bool isVisible = false;
    public bool isExplored = false;
    public string color = "black";
    public bool hasEnemy = false;
    public int enemyID = -1;

    [NonSerialized]
    public GameObject enemyObject;
}

[Serializable]
public class Wall
{ 
    public List<Vector2Int> positions;
    public string direction;
    public int length;
    public bool hasFeature = false;
    public Feature parent;
}

[Serializable]
public class Feature
{ 
    public List<Vector2Int> positions;
    public Wall[] walls;
    public string type;
    public int width;
    public int height;
    public int id;
    public bool hasPlayer = false;
}
