using Monster;
using UnityEngine;

public class MonsterAttackBehavior : IMonsterBehavior
{
    private float lastAttackTime;

    public void Execute(MonsterAI monster)
    {
        monster.StopMovement(); // 공격 중이므로 이동 멈춤

        // 공격 로직 실행
        if (Time.time > lastAttackTime + 2f) // 공격 간격
        {
            PlayerHealth playerHealth = monster.player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(5); // 예시 데미지
                lastAttackTime = Time.time;
            }
        }
    }
}