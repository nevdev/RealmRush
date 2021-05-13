using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)]float travelSpeed = 1f;
    //[SerializeField] float waitTime = 1f;

    void Start()
    {
        
        StartCoroutine(FollowPath());
        
        //InvokeRepeating("PrintWaypointName", 0, 1f);
    }

    
    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            //Debug.Log(waypoint.name);
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * travelSpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }            
            //transform.position = waypoint.transform.position;
            //yield return new WaitForSeconds(waitTime);            
        }
    }
}
