using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth = 5;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= _currentHealth && damage >= 0)
        {
            _currentHealth -= damage;
        }

        Die();
    }

    public void AddHealth(int healthPoints)
    {
        _currentHealth += healthPoints;
    }

    private void Die()
    {
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;

            Destroy(gameObject);
        }
    }
}
