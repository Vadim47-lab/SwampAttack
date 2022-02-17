using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Button _fire;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private AudioClip _buttonPress;

    private Weapon _currentWeapon;
    private Animator _animator;
    private int _currentHealth;

    public int Money { get; private set; }
    public bool PlayerDied { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    private void Start()
    {
        PlayerDied = false;
        _currentWeapon = _weapons[0];
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            PlayerDied = true;
            _gameOver.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void Fire()
    {
        GetComponent<AudioSource>().PlayOneShot(_buttonPress);
        _currentWeapon.Shoot(_shootPoint);
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        _weapons.Add(weapon);
    }
}