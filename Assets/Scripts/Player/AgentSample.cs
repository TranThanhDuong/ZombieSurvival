using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSample : MonoBehaviour
{
    public Transform target;
    public PolyNavAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
