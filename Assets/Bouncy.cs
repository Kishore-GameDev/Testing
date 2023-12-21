using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bouncy : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float force, stopDistance;
    public bool onFloor, reached;
    public Transform point;
    public Vector3 velocity;
    public NavMeshAgent agent;
    public GameObject bouncy;

    private void Update()
    {
        velocity = rigidBody.velocity;
        Vector3 player = new Vector3(transform.position.x, 0.5f, transform.position.z);
        Vector3 pointPos = new Vector3(point.position.x, 0.5f, point.position.z);

        if (Vector3.Distance(player, pointPos) > 0.1f && !reached)
        {
            if(Vector3.Distance(player, pointPos) < stopDistance)
            {
                //transform.position = new Vector3(point.position.x, 1f, point.position.z);
                //rigidBody.useGravity = false;
                //rigidBody.constraints = RigidbodyConstraints.FreezeAll;
                reached = true;
            }
            else
            {
                //rigidBody.useGravity = true;
                //rigidBody.constraints = RigidbodyConstraints.None;
            }
            if (onFloor)
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.AddForce(Vector3.up * force, ForceMode.Force);
            }
            //transform.position = Vector3.MoveTowards(transform.position, point.position, Time.deltaTime * 0.5f);
            agent.SetDestination(pointPos);
            Debug.Log("If");
        }
        else if(Vector3.Distance(player, pointPos) > stopDistance)
        {
            reached = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = false;
        }
    }
}
