using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public List<Waypoint> Path = new();

    [SerializeField] private Waypoint _startPoint;
    [SerializeField] private Waypoint _finishPoint;
    private Waypoint _exploredPoint;
    private bool _isFinishFound = false;

    Dictionary<Vector2Int, Waypoint> grid = new();
    Queue<Waypoint> queue = new();
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        SetStartFinishColor();
        FindPath();
        CreatePath();

        return Path;
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
        _startPoint.SetTopColor(Color.green);
        _finishPoint.SetTopColor(Color.red);
    }

    private void FindPath()
    {
        queue.Enqueue(_startPoint);
        while (queue.Count > 0 && !_isFinishFound)
        {
            _exploredPoint = queue.Dequeue();
            _exploredPoint.isExplored = true;
            //CheckFinishPoint(_exploredPoint);
            ExploreNearestPoins();
        }
    }

    private void ExploreNearestPoins()
    {
        if (_isFinishFound) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int nearestPointCoordinates = direction + _exploredPoint.GetGridPos();
            try
            {
                Waypoint nearestPoint = grid[nearestPointCoordinates];
                if (!nearestPoint.isExplored && !queue.Contains(nearestPoint))
                {
                    //nearestPoint.SetTopColor(Color.blue);
                    queue.Enqueue(nearestPoint);
                    nearestPoint.previousPoint = _exploredPoint;

                }
                CheckFinishPoint(nearestPoint);
            }
            catch
            {

            }


        }
    }

    private void CheckFinishPoint(Waypoint point)
    {
        if (point == _finishPoint)
        {
            Debug.Log("Finish point was found:  " + point);
            point.SetTopColor(Color.red);
            _isFinishFound = true;
        }

    }

    private void CreatePath()
    {
        Path.Add(_finishPoint);
        Waypoint pathPoint = _finishPoint.previousPoint;
        while(pathPoint != _startPoint)
        {
            Path.Add(pathPoint);
            pathPoint.SetTopColor(Color.black);
            pathPoint = pathPoint.previousPoint;
        }
        Path.Add(_startPoint);
        Path.Reverse();
    }

}
