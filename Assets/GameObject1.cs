using UnityEngine;

public class GameObject1 : MonoBehaviour
{
    public GameObject object1, object2, object3;
    public float dot;
    public Vector3 Object1, Object2;
    public bool rotate, inside;

    public Vector3 position;
    [Range(0f, 20f)] public float radius;

    private void Start()
    {
        
    }

    private void Update()
    {
        Object1 = transform.position;
        Object2 = object1.transform.position;

        Object1.y = 0;
        Object2.y = 0;

        Vector3 dir = Vector3.Normalize(Object2 - Object1);
        dot = Vector3.Dot(transform.forward, dir);

        if (rotate /*&& dot != 1f*/)
        {
            Vector3 look = object1.transform.position;
            look.y = transform.position.y;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(look - transform.position), Time.deltaTime * 2f);
        }

        if(Vector3.Distance(object1.transform.position, object3.transform.position) < radius)
        {
            inside = true;
        }
        else
        {
            inside = false;
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            transform.position = object2.transform.position + (object3.transform.position - object2.transform.position) / 2;
        }
    }
}
