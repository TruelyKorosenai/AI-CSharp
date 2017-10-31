using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {


    public Vector3 GridSize;
    public float NodeRadius;

    List<Node> grid;

    void OnDrawGizmos() {

        Gizmos.DrawWireCube(transform.position, new Vector3 (GridSize.x, 1, GridSize.z));
    }


}