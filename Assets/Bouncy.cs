using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float force;
    public bool onFloor;
    public Transform point;

    private void Update()
    {
        Vector3 player = new Vector3(transform.position.x, 0.5f, transform.position.z);
        Vector3 pointPos = new Vector3(point.position.x, 0.5f, point.position.z);

        if (Vector3.Distance(player, pointPos) > 0.1f)
        {
            if(Vector3.Distance(player, pointPos) < 0.2f)
            {
                //transform.position = new Vector3(point.position.x, 1f, point.position.z);
                rigidBody.useGravity = false;
                rigidBody.constraints = RigidbodyConstraints.FreezeAll;
            }
            if (onFloor)
            {
                rigidBody.AddForce(Vector3.up * force, ForceMode.Force);
            }
            transform.position = Vector3.MoveTowards(transform.position, point.position, Time.deltaTime * 0.5f);
            Debug.Log("If");
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
