using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ChickenWander : MonoBehaviour
{
    Chicken chicken;

    public float wanderRadius;
    public float wanderTimer;
    private NavMeshAgent agent;


    private float timer;
    // Use this for initialization
    void OnEnable()
    {
        chicken = GetComponent<Chicken>();
        chicken.OnChickenInstanceKilled += StopWander;

        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }
    private void Update()
    {
        Wander();
    }

    public void Wander()
    {

        if (!chicken.isDead)
        {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
            

    } 

    void StopWander()
    {   
        agent.isStopped = true;
        agent.Warp(agent.transform.position);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
