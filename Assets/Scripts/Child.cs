using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : Parent
{
    public GameObject target;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target.transform);
        transform.position += transform.forward * -5f;

    }

    // Update is called once per frame
    void Update()
    {
        LayerMask layerMask = LayerMask.GetMask("Default");
        Debug.DrawRay(transform.position, Vector3.forward * 10f, Color.blue, 60f);
        Debug.DrawRay(transform.position, Vector3.back * 10f, Color.black, 60f);
        Debug.DrawRay(transform.position, Vector3.right * 10f, Color.green, 60f);
        Debug.DrawRay(transform.position, Vector3.left * 10f, Color.red, 60f);

        /*time += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.D))
        {
            Destroy(gameObject);
        }

        Vector3 camFwd = new Vector3(target.transform.forward.x, 0, target.transform.forward.z).normalized;
        Vector3 currentLook = (transform.position - target.transform.position).normalized + transform.forward * -4f;
        const float posLerp = 0.99f;
        Vector3 targetLook = Vector3.Slerp(camFwd, currentLook, posLerp);
        
        Quaternion targetRotation = Quaternion.LookRotation(-targetLook, Vector3.up);

        transform.position = target.transform.position + targetLook;
        transform.rotation = targetRotation;

        //transform.LookAt(target.transform);
        //transform.position += transform.forward * -5f;*/
    }

    /*protected override void OnDisable()
    {
        base.OnDisable();
        Debug.Log("Child");
    }*/
}
