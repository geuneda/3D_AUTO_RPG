using UnityEngine;
using UnityEngine.AI;

public class PlayerAutoMoveController : MonoBehaviour
{
    // 목표지점
    public Transform targetPoint;
    // 이동 할 agent
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (targetPoint)
        {
            agent.SetDestination(targetPoint.position);
        }
    }

    void Update()
    {
        // 타겟으로 이동
        if (targetPoint)
        {
            agent.SetDestination(targetPoint.position);
        }
    }
}
