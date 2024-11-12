using UnityEngine;

public class PlayerAttackingState : IPlayerState
{
    private float lastAttackTime;

    public void EnterState(PlayerStateController player)
    {
        player.agent.isStopped = true; // 공격 중이므로 이동 멈춤
    }

    public void UpdateState(PlayerStateController player)
    {
        // 공격방식 리팩토링 예정
        Collider[] hitColliders = Physics.OverlapSphere(player.transform.position, player.attackRange);
        bool monsterInRange = false;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Monster"))
            {
                MonsterHealth monsterHealth = hitCollider.GetComponent<MonsterHealth>();
                if (monsterHealth && Time.time > lastAttackTime + 1.5f) // 임시 공격 딜레이
                {
                    monsterHealth.TakeDamage(10); // 임시 데미지
                    lastAttackTime = Time.time;
                }
                monsterInRange = true;
            }
        }

        if (!monsterInRange)
        {
            player.SetState(new PlayerMovingState()); // 몬스터가 없으면 이동 상태로 전환
        }
    }

    public void ExitState(PlayerStateController player)
    {
        // 전투 상태에서 빠져나올 때 로직 추가 가능
    }
}