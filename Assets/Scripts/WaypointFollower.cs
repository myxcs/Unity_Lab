using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{

      //tạo waypoint
     [SerializeField] private GameObject[] waypoints;
     private int currentWaypointIndex = 0;

     [SerializeField] private float speed = 2.0f;

     private void Update()
    {
        //xác định khoảng cách từ waypoint đến moving platform
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                    currentWaypointIndex = 0;
            }
        }
     // Move towards the current waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
