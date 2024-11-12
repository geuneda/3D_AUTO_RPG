using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public float attackRange = 3f;
    public int attackDamage = 10;
    public float attackInterval = 1.5f;

    private float lastAttackTime;

    void Update()
    {
        if (Time.time > lastAttackTime + attackInterval)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Monster"))
                {
                    // 몬스터에게 데미지 주기
                    MonsterHealth monsterHealth = hitCollider.GetComponent<MonsterHealth>();
                    if (monsterHealth)
                    {
                        monsterHealth.TakeDamage(attackDamage);
                        lastAttackTime = Time.time;
                        break; // 한 번 공격 후 종료
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}