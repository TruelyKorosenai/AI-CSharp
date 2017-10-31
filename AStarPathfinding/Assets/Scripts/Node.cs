using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public bool Impassable = false;
    public Vector3 NodePos;


    public Node (bool obstacle, Vector3 Pos) {
        Impassable = obstacle;
        NodePos = Pos;
    }
	
}
