using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIMovement : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    public GameObject target;
    public Transform[] points;
    int pointIndex = 0;
    bool chase = false;




    void GoToNext()
    {





        agent.destination = points[pointIndex].position;
        pointIndex = (pointIndex + 1) % points.Length;

    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(points.Length>0)
            GoToNext();
    }

    // Update is called once per frame
    void Update()
    {
        if (chase)
        {
            agent.destination = target.transform.position;
        }
        else
        {
            //agent.destination = target.GetComponent<Transform>().position;
            if (agent.remainingDistance < 0.5f)
            {
                if (points.Length > 0)
                    GoToNext();
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hobba");
        chase = true;
    }
}
