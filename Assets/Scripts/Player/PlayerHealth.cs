using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // 최대 체력
    private int currentHealth;

    void Start()
    {
        // 플레이어 체력을 초기화
        currentHealth = maxHealth;
    }

    // 플레이어가 데미지를 받을 때 호출될 함수
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 체력을 회복할 때 사용할 함수 (추후 필요할 경우)
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
    }

    // 플레이어가 사망했을 때 처리할 로직
    private void Die()
    {
        Debug.Log("Player died!");
        // TODO: 게임 오버 UI 표시, 플레이어 컨트롤러 비활성화 등
        gameObject.SetActive(false); // 간단히 플레이어를 비활성화 (추후 게임 오버 화면으로 연결 가능)
    }
}