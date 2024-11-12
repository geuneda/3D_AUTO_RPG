using UnityEngine;
using UnityEngine.AI;

public class PlayerStateController : MonoBehaviour
{
    private IPlayerState currentState;

    public NavMeshAgent agent;
    public Transform targetPoint;
    public float attackRange = 3f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetState(new PlayerMovingState()); // 초기상태 이동상태
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SetState(IPlayerState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}