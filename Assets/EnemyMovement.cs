using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Waypoint> waypoints;
    // Start is called before the first frame update
    void Start()
    {
        DisplayWaypointName();
        StartCoroutine(DisplayWaypointName());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DisplayWaypointName()
    {
        foreach (Waypoint waypoint in waypoints)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        
    }
}
