using UnityEngine;

public class PlayerMovingState : IPlayerState
{
    public void EnterState(PlayerStateController player)
    {
        player.agent.isStopped = false;
        player.agent.SetDestination(player.targetPoint.position);
    }

    public void UpdateState(PlayerStateController player)
    {
        // 몬스터가 공격 범위 내에 있는지 확인
        Collider[] hitColliders = Physics.OverlapSphere(player.transform.position, player.attackRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Monster"))
            {
                player.SetState(new PlayerAttackingState()); // 전투 상태로 전환
                return;
            }
        }

        // 목적지에 도달했는지 확인
        if (!player.agent.pathPending && player.agent.remainingDistance <= player.agent.stoppingDistance)
        {
            player.agent.isStopped = true; // 이동 중지
        }
    }

    public void ExitState(PlayerStateController player)
    {
        // 이동 상태에서 빠져나올 때 로직이 필요하다면 여기에 추가
    }
}