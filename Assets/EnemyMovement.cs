using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    PathFinder pathFinder;

    // Start is called before the first frame update
    void Start()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(MoveEnemy(path));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MoveEnemy(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        
    }
}
