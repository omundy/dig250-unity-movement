using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 *  Example showing
 *  1. Editor "tooling" using OnValidate to prepopulate references
 *  2. Scene building helpers with gizmos
 *  3. Structure of a reusable prefab
 *  4. Basic moving platform
 */

public class Platform : MonoBehaviour
{

    public Transform platform;
    public Transform start;
    public Transform end;

    public float speed = 3.0f;
    public bool toStart = false;

    // These two functions are only performed in the Editor
    // https://docs.unity3d.com/Manual/ExecutionOrder.html
    void OnValidate()
    {
        start = transform.parent.Find("Start").transform;
        end = transform.parent.Find("End").transform;
        platform = transform;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(start.position, .2f);
        Gizmos.DrawSphere(end.position, .2f);
        Gizmos.DrawLine(start.position, end.position);
    }

    // account for player (controlled by gravity) 
    void FixedUpdate()
    {
        if (!toStart)
        {
            platform.position = Vector3.MoveTowards(platform.position, start.position, speed * Time.deltaTime);
        }
        else
        {
            platform.position = Vector3.MoveTowards(platform.position, end.position, speed * Time.deltaTime);
        }

        if (platform.position == start.position) toStart = true;
        else if (platform.position == end.position) toStart = false;

    }





}
