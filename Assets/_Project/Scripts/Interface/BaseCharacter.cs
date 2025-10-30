using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 5;

    protected int Damage = 1;
    protected int CurrentHealth;

    private void Start()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= CurrentHealth && damage >= 0)
        {
            CurrentHealth -= damage;
        }

        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
    }
}
