using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform player;
    public float detectRange = 5f;

    private NavMeshAgent agent;
    private IMonsterBehavior currentBehavior;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetBehavior(new MonsterChaseBehavior()); // 초기 행동을 추적으로 설정
    }

    void Update()
    {
        currentBehavior.Execute(this);

        // 플레이어가 일정 범위 내로 들어왔는지 확인
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer <= detectRange && !(currentBehavior is MonsterAttackBehavior))
        {
            SetBehavior(new MonsterAttackBehavior());
        }
        else if (distanceToPlayer > detectRange && !(currentBehavior is MonsterChaseBehavior))
        {
            SetBehavior(new MonsterChaseBehavior());
        }
    }

    public void SetBehavior(IMonsterBehavior newBehavior)
    {
        currentBehavior = newBehavior;
    }

    public void ChasePlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }

    public void StopMovement()
    {
        agent.isStopped = true;
    }
}