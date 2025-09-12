using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;
    private bool canTakeDamage = true;

    private Animator anim;

    // ��ҧ�ԧ UI
    public HealthBar healthBar;     // �ҡ HealthBar ŧ Inspector
    public GameOverUI gameOverUI;   // �ҡ GameOverUI ŧ Inspector

    void Start()
    {
        anim = GetComponentInParent<Animator>();
        health = maxHealth;

        // ��駤��ᶺ���ʹ�������
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(health);
        }
    }

    public void TakeDamage(float damage)
    {
        if (!canTakeDamage) return;

        health -= damage;
        if (health < 0) health = 0;

        anim.SetBool("Damage", true);

        // �ѻവ UI
        if (healthBar != null)
        {
            healthBar.SetHealth(health);
        }

        if (health <= 0)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponentInParent<GatherInput>().DisableControls();
            Debug.Log("Player is dead");

            if (gameOverUI != null)
            {
                gameOverUI.ShowGameOver(); // �ʴ� Game Over Panel
            }
        }

        StartCoroutine(DamagePrevention());
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        if (health > 0)
        {
            canTakeDamage = true;
            anim.SetBool("Damage", false);
        }
        else
        {
            anim.SetBool("Death", true);
        }
    }
}
