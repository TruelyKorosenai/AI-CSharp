using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node {

    public bool Pathable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public int gScore;
    public int Hscore;
    public Node parent;

    public Node(bool m_walkable, Vector3 m_worldPos, int m_gridX, int m_gridY)
    {
        Pathable = m_walkable;
        worldPosition = m_worldPos;
        gridX = m_gridX;
        gridY = m_gridY;
    }

    public int fScore
    {
        get{return gScore + Hscore;}
    }

}
