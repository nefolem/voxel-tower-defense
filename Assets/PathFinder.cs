using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private Waypoint startPoint, finishPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    } ;
    
    void Start()
    {
        LoadBlocks();
        SetStartFinishColor();
        ExploreNearestPoins();
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                Debug.LogWarning("Duplicate of " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
                
    }

    private void SetStartFinishColor()
    {
        startPoint.SetTopColor(Color.green);
        finishPoint.SetTopColor(Color.red);
    }

    private void ExploreNearestPoins()
    {
        foreach(Vector2Int direction in directions)
        {
            Debug.Log(direction+startPoint.GetGridPos());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
