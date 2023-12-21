using Obi;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rope_Controller : MonoBehaviour
{
    public ObiRope Rope;
    public ObiPathSmoother pathSmoother;
    public Transform start, end;
    public MeshRenderer mesh;

    public List<Vector3> frames;
    public List<ObiPathFrame> smoothChunks;
    public int path = 0, oldPath = 0;
    public float speed;
    public GameObject sphere;
    public bool reached, move, stabble;
    public Vector3 middlePathPos, curentPathPos, startPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetTarget(Transform startT, Transform endT)
    {
        /*start = transform.AddComponent<ObiParticleAttachment>();
        end = transform.AddComponent<ObiParticleAttachment>();

        start.target = startT;
        start.particleGroup = Rope.blueprint.groups[0];

        end.target = endT;
        end.particleGroup = Rope.blueprint.groups[2];*/
        sphere.transform.position = endT.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start.position = new Vector3(Random.Range(-2, 2), start.position.y, Random.Range(-2, 2));
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            sphere.transform.position = start.position;
            path = 0;
        }

        if (move)
        {
        }

        Move();

    }

    private void FixedUpdate()
    {
        frames.Clear();
        for (int i = 0; i < Rope.elements.Count; i++)
        {
            if(i == Rope.elements.Count - 1)
            {
                frames.Add(Rope.solver.positions[Rope.elements[i].particle2]);
            }

            frames.Add(Rope.solver.positions[Rope.elements[i].particle1]);
        }

        /*foreach (ObiPathFrame frame in pathSmoother.rawChunks[0])
        {
            frames.Add(frame);
        }*/
        
        smoothChunks.Clear();

        foreach(ObiPathFrame frame in pathSmoother.smoothChunks[0])
        {
            smoothChunks.Add(frame);
        }
    }

    /*public void Move()
    {
        if (sphere.transform.position == end.position) (path >= frames.Count)
            return;
        //sphere.transform.position += Time.deltaTime * (sphere.transform.position - frames[path].position).normalized;
        if (frames[frames.Count/2].position != middlePathPos && startPos != start.position)
        {
            stabble = false;
            sphere.transform.position = curentPathPos;
            //curentPathPos = frames[path].position;
            middlePathPos = frames[frames.Count / 2].position;
            Debug.Log("If");
            return;
        }
        else
        {
            //path = oldPath;
            stabble = true;
            Debug.Log("else");
        }

        oldPath = path;
        startPos = start.position;
        
        if(path == frames.Count-1)
        {
            curentPathPos = frames[frames.Count-1].position;
        }
        else
        {
            curentPathPos = frames[path].position + (frames[path].position - frames[path + 1].position) / 2;
        }

        middlePathPos = frames[frames.Count/2].position;
        sphere.transform.position = Vector3.MoveTowards(sphere.transform.position, frames[path].position, Time.deltaTime * speed);

        if (oldPath == path && path < frames.Count && frames[frames.Count / 2].position == middlePathPos && startPos == start.position && sphere.transform.position == frames[path].position && !reached)
        {
            reached = true;
            path++;
            Debug.Log(path);
            reached = false;
        }
    }*/

    public void Move()
    {
        if /*(sphere.transform.position == end.position)*/ (path >= frames.Count)
            return;
        //sphere.transform.position += Time.deltaTime * (sphere.transform.position - frames[path].position).normalized;
        if (frames[frames.Count / 2] != middlePathPos && startPos != start.position)
        {
            stabble = false;
            sphere.transform.position = curentPathPos;
            //curentPathPos = frames[path].position;
            middlePathPos = frames[frames.Count / 2];
            Debug.Log("If");
            return;
        }
        else
        {
            //path = oldPath;
            stabble = true;
            Debug.Log("else");
        }

        oldPath = path;
        startPos = start.position;

        if (path == frames.Count - 1)
        {
            curentPathPos = frames[frames.Count - 1];
        }
        else
        {
            curentPathPos = frames[path] + (frames[path] - frames[path + 1]) / 2;
        }

        middlePathPos = frames[frames.Count / 2];
        sphere.transform.position = Vector3.MoveTowards(sphere.transform.position, frames[path], Time.deltaTime * speed);

        if (oldPath == path && path < frames.Count && frames[frames.Count / 2] == middlePathPos && startPos == start.position && sphere.transform.position == frames[path] && !reached)
        {
            reached = true;
            path++;
            Debug.Log(path);
            reached = false;
        }
    }
}
