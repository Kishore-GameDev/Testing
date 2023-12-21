using Obi;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Obi_Controller : MonoBehaviour
{
    public Rope_Controller ropePrefab;
    public ObiSolver solver;

    public Rope_Controller rope1, rope2;
    public Transform startT, endT1, endT2;

    public List<ObiStructuralElement> bend;
    public ObiPathFrame raw, smooth;

    public bool nothing;

    void Start()
    {
        rope1 = Instantiate(ropePrefab, solver.transform);
        //rope1.SetTarget(startT, endT1);

        //rope2 = Instantiate(ropePrefab, solver.transform);
        //rope2.SetTarget(startT, endT2);
        Async();
    }

    private void Update()
    {
        raw = rope1.pathSmoother.rawChunks[0][0];
        //smooth = rope1.pathSmoother.smoothChunks;

        if(Input.GetKeyDown(KeyCode.T))
        {
            //rope1.Rope.tearingEnabled = true;
            StartCoroutine(DissolveRope());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //rope1.Rope.tearingEnabled = false;
            //rope1.Rope.ResetParticles();
            //rope1.gameObject.SetActive(true);
            StartCoroutine(RessolveRope());
        }
    }

    async void Async()
    {
        while (!nothing)
        {
            await Task.Delay(1);

            Debug.Log("Loop Loop");
        }

        Debug.Log("Loop End");
    }

    IEnumerator DissolveRope()
    {
        float value = 0;

        rope1.mesh.material.SetFloat("_Dissolve", 0.4f);
        while (value <= 1)
        {
            value += Time.deltaTime * 2f;
            rope1.mesh.material.SetFloat("_Dissolve", value);

            yield return null;
        }

        rope1.mesh.material.SetFloat("_Dissolve", 1f);
    }

    IEnumerator RessolveRope()
    {
        float value = 1;
        while (value >= 0)
        {
            value -= Time.deltaTime * 2f;
            rope1.mesh.material.SetFloat("_Dissolve", value);

            yield return null;
        }

        rope1.mesh.material.SetFloat("_Dissolve", 0f);
    }
}
