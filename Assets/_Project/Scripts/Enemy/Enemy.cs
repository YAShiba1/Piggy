using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : BaseCharacter
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _audioSource.Play();
            player.TakeDamage(Damage);
        }
    }
}
