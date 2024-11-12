using Monster;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform player;
    public float detectRange = 5f;

    private NavMeshAgent agent;
    private IMonsterBehavior currentBehavior;

    private IMonsterBehavior chaseBehavior = new MonsterChaseBehavior();
    private IMonsterBehavior attackBehavior = new MonsterAttackBehavior();
    
    void Start()
    {
        player = GameManager.Instance.CurrentPlayer.transform;
        agent = GetComponent<NavMeshAgent>();
        SetBehavior(new MonsterChaseBehavior()); // 초기 행동을 추적으로 설정
    }

    void Update()
    {
        currentBehavior.Execute(this);

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        // 플레이어와의 거리 기준으로 행동을 전환
        if (distanceToPlayer <= detectRange && !(currentBehavior is MonsterAttackBehavior))
        {
            SetBehavior(attackBehavior); // 기존 인스턴스를 사용
        }
        else if (distanceToPlayer > detectRange && !(currentBehavior is MonsterChaseBehavior))
        {
            SetBehavior(chaseBehavior); // 기존 인스턴스를 사용
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