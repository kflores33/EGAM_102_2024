using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingWall : MonoBehaviour
{
    //public Transform locationHandle;
    public Transform moveHandles;
    public Transform patrolTarget;

    public Transform patrolHandleA;
    public Transform patrolHandleB;

    public float moveSpeed;
    public float minimumDistance;

    public Timer timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (timer.hasWon == false)
        {
            // Move towards this position
            Vector3 targetPosition = patrolTarget.position;

            //to find the direction from A to B = B - A
            Vector3 delta = targetPosition - moveHandles.position;
            Vector3 moveDirection = delta.normalized;

            moveHandles.position += moveDirection * moveSpeed * Time.deltaTime;

            // If we're reall close, change our target
            if (delta.magnitude < minimumDistance)
            {
                if (patrolTarget == patrolHandleA)
                {
                    patrolTarget = patrolHandleB;
                }
                else if (patrolTarget == patrolHandleB)
                {
                    patrolTarget = patrolHandleA;
                }
            }
        }
    }
}
