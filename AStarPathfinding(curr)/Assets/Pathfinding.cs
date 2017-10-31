using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour {

    public Transform seeker;
    public Transform target;

    Grid grid;
    void Awake()
    {
        grid = GetComponent<Grid>();
    }

    void Update()
    {
        FindPath(seeker.position, target.position);
    }

	void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        List<Node> openList = new List<Node>();
        HashSet<Node> closedList = new HashSet<Node>();
        openList.Add(startNode);

        while (openList.Count > 0)
        {
            Node currentNode = openList[0];
            for (int i =1; i <openList.Count; i++)
            {
                if (openList[i].fScore < currentNode.fScore || openList[i].fScore == currentNode.fScore && openList[i].Hscore < currentNode.Hscore)
                {
                    currentNode = openList[i];
                }
            }

        openList.Remove(currentNode);
        closedList.Add(currentNode);

            if (currentNode == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }
            
            foreach (Node neighbour in grid.GetNeighbours(currentNode))
            {
                if (!neighbour.Pathable || closedList.Contains(neighbour))
                { continue; }

                int newMovementScoreToNeighbour = currentNode.gScore + GetDistance(currentNode, neighbour);
                if(newMovementScoreToNeighbour < neighbour.gScore || !openList.Contains(neighbour))
                {
                    neighbour.gScore = newMovementScoreToNeighbour;
                    neighbour.Hscore = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if(!openList.Contains(neighbour))
                    {
                        openList.Add(neighbour);
                    }
                }
            }
        }
    }


    void RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        grid.path = path;
    }
    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }


}
