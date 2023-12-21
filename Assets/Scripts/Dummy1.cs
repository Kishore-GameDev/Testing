using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Dummy1 : MonoBehaviour
{
    public GameObject plane, cube, blue;
    public int checkpoint;
    public int currentSphere;
    public List<GameObject> sphereList;
    public List<Vector3> spawnLocations;
    public List<GameObject> destroyableObjectList = new List<GameObject>();
    [SerializeField] private Animator animator;
    public int i = 0;
    public int Checkpoint = 0, spawnCount;
    public bool UP;
    public float waitTime;
    public AnimationCurve animationCurve;
    public Parent child;

    float time = 0.0f;
    [SerializeField] private float radius = 10.0f, objectSpawnRadius = 15f;         // Radius of the circle
    [SerializeField] private float angularSpeed = 45.0f;
    bool attacked, timeReached, lookingAtObject, rotating;

    public float upValue, downValue, upTime = 0f, downTime = 0f, CurrentTime = 0f, delta, rotateSpeed, moveSpeed;
    public GameObject currentObject;

    private void Awake()
    {
        Debug.Log("Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        checkpoint = 0;
        attacked = false;

        upValue = transform.position.y + 2;
        downTime = transform.position.y - 5;

        /*for(int j = 0; j < spawnLocations.Count; j++)
        {
            GameObject go = Instantiate(cube, spawnLocations[j], Quaternion.identity);
            destroyableObjectList.Add(go);
        }*/
        //SpawnObjects();
        //StartCoroutine(PatrolAndAttack());

        /*Vector3 pos = transform.position + Vector3.up * 10f + Vector3.back * 10f;
        GameObject go = Instantiate(cube, pos, Quaternion.identity, transform);

        transform.position += go.transform.localPosition;
        go.transform.localPosition = Vector3.zero;*/

        //Instantiate(child);

        //StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        currentObject = Instantiate(cube, transform.position, Quaternion.identity);

        yield return new WaitUntil(() => !currentObject);
        Debug.Log("Current Object is NULL");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        /*switch (checkpoint)
        {
            *//*case 0:
                Patrol();
                break;*//*

            case 1:
                transform.position = Vector3.Slerp(transform.position, sphereList[currentSphere].transform.localPosition + Vector3.back * 5f, Time.deltaTime * 2f);
                break;
        }*/

        /*if(Input.GetKey(KeyCode.Space) && checkpoint != 1)
        {
            checkpoint++;
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += transform.forward * -1f;
        }
    }

    private void Update()
    {
        /*delta = 1 - Mathf.Pow(Vector3.Distance(transform.position, curPlatform.transform.position) / startDistance, 5.0f / 9.0f);

        //rotate to platform's rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, curPlatform.transform.rotation, (delta / startDistance) * rotateSpeed);

        if (Mathf.Approximately(delta, 1))
        {
            isMoving = false;
        }
        //move to platform
        transform.position = Vector3.MoveTowards(transform.position, curPlatform.transform.position, moveSpeed * Time.deltaTime);*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //gameObject.SetActive(false);
            //gameObject.active = false;
            Destroy(currentObject);
        }
    }

    IEnumerator PatrolAndAttack()
    {
        float currentTime = 0;
        //waitTime = Random.Range(2, 6);

        while (Checkpoint == 0)
        {
            currentTime += Time.deltaTime;

                PatrolUpAndDown();
            /*if (currentTime <= waitTime)
            {
            }
            else
            {
                PatrolTowardDown();
            }*/
            /*if (!timeReached)
            {
                Patrol();
            }
            else if(timeReached && !lookingAtObject)
            {
                Rotate(i);
                lookingAtObject = true;
                Vector3 dir = Vector3.Normalize(destroyableObjectList[i].transform.position - transform.localPosition);
                float dot = Vector3.Dot(transform.forward, dir);
                Debug.Log(dot);
                if (dot > 1f)
                {
                    lookingAtObject = true;
                    //rotating = true;
                }
            }
            else if (timeReached)
            {
                if (!lookingAtObject)
                {
                    
                    lookingAtObject = true;
                }
                Attack(i);
                yield return new WaitForSeconds(3);
                yield return new WaitUntil(() => attacked == true);
                i++;
                if (i == destroyableObjectList.Count)
                {
                    i = 0;
                }

                currentTime = 0;
                timeReached = false;
                attacked = false;
                lookingAtObject = false;
            }*/

            /*if (timeReached == false)
            {
                currentTime += Time.deltaTime;
            }

            if (currentTime >= waitTime)
            {
                timeReached = true;
                //Debug.Log("Time Reached");
            }*/

            yield return new WaitForFixedUpdate();
        }

        yield return new WaitUntil(() => Checkpoint == 1);
    }

    private void PatrolUpAndDown()
    {
        time += Time.deltaTime;

        float angleInRadians = time * angularSpeed * Mathf.Deg2Rad;

        float x = radius * Mathf.Cos(angleInRadians);
        float z = radius * Mathf.Sin(angleInRadians);
        //float y = animationCurve.Evaluate((Time.time % animationCurve.length) * Time.deltaTime);
        float y = Mathf.Sin(Time.time * 0.8f) * 0.05f + blue.transform.localPosition.y;
        //float y = 0f;
        /*
        if(transform.position.y < upValue && UP)
        {
            y = transform.position.y + 0.3f * time;
        }
        else if(transform.position.y > downValue && !UP)
        {
            y = transform.position.y - 0.1f * time;
        }*/

        /*CurrentTime += Time.deltaTime;
        if (CurrentTime <= upTime && UP)
        {
            y = transform.position.y + upValue * Time.deltaTime;
            if(CurrentTime >= upTime)
            {
                UP = false;
                CurrentTime = 0f;
            }
        }
        if (CurrentTime <= downTime && !UP)
        {
            y = transform.position.y - downValue * Time.deltaTime;
            if(CurrentTime >= downTime)
            {
                UP = true;
                CurrentTime = 0f;
            }
        }*/


        Vector3 targetPos = new Vector3(x, y, z);
        Instantiate(cube, targetPos, Quaternion.identity);
        blue.transform.LookAt(targetPos);
        blue.transform.localPosition = targetPos;
    }

    private void PatrolTowardDown()
    {
        time += Time.deltaTime;

        float angleInRadians = time * angularSpeed * Mathf.Deg2Rad;

        radius -= 2f * Time.deltaTime;
        radius = radius <= 0 ? 0 : radius;

        float x = radius * Mathf.Cos(angleInRadians);
        float y = transform.position.y - 1f * Time.deltaTime;
        float z = radius * Mathf.Sin(angleInRadians);

        Vector3 targetPos = new Vector3(x, y, z);
        transform.LookAt(targetPos);
        transform.position = targetPos;
    }

    private void Patrol()
    {
        time += Time.deltaTime;

        float angleInRadians = time * angularSpeed * Mathf.Deg2Rad;

        float x = radius * Mathf.Cos(angleInRadians);
        float z = radius * Mathf.Sin(angleInRadians);

        Vector3 targetPos = new Vector3(x, transform.position.y, z);
        transform.LookAt(targetPos);
        transform.position = targetPos;
    }

    private void Rotate(int i)
    {
        Vector3 targetPos = new Vector3(destroyableObjectList[i].transform.position.x, transform.position.y, destroyableObjectList[i].transform.position.z);
        transform.LookAt(targetPos);
        //transform.rotation = Quaternion.Slerp(transform.localRotation, destroyableObjectList[i].transform.rotation, Time.deltaTime * 2f);
        //rotating = true;

        //Vector3 targetRot = destroyableObjectsList[i].transform.position - transform.position;
        //transform.Rotate(Vector3.up * Time.deltaTime * 50f);
    }

    private void Attack(int i)
    {
        waitTime = Random.Range(2, 6);
        //Vector3 targetPos = new Vector3(0, destroyableObjectsList[i].transform.position.y, 0);
        //transform.LookAt(targetPos);

        animator.SetTrigger("Attack");


    }

    public void Shoot()
    {
        Debug.Log("Shoot");
        attacked = true;
    }

    private void SpawnObjects()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            float angleInRadians = angularSpeed * Mathf.Deg2Rad;

            float x = radius * Mathf.Cos(angleInRadians);
            float z = radius * Mathf.Sin(angleInRadians);

            Vector3 targetPos = new Vector3(x, 10f, z);

            GameObject go = Instantiate(cube, targetPos, Quaternion.identity);
            destroyableObjectList.Add(go);
        }
    }
}
