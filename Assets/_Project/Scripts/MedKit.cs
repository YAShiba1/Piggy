using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int HealthPoints = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.AddHealth(HealthPoints);
            Destroy(gameObject);
        }
    }
}
