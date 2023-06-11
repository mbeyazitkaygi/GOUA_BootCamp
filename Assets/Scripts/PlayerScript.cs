using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;
    [SerializeField] private GameObject _deathEffect, _hitEffect;
    private float _currentHealth;

    [SerializeField] private HealthBar _healthbar;


    void Start()
    {
        _currentHealth = _maxHealth;

        _healthbar.UpdateHealthBar(_maxHealth,_currentHealth);
    }

    void OnMouseDown() 
    {
        _currentHealth -= 0.9f;

        if(_currentHealth <= 0)
        {
            Instantiate(_deathEffect, transform.position, Quaternion.Euler(-90,0,0));
            Destroy(gameObject);
        }
        else
        {
            _healthbar.UpdateHealthBar(_maxHealth,_currentHealth);
            Instantiate(_hitEffect, transform.position, Quaternion.identity);
        }
    }
}
