using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHeatlth = 3;
    int _currentHealth;

    [SerializeField] int _treasureCount = 0;

    [SerializeField] Text _treasureText;

    public bool _isInvincible = false;

    public int TreasureCount
    {
        get => _treasureCount;
        set => _treasureCount = value;
    }

    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        _currentHealth = _maxHeatlth;
    }

    public void IncreassHealth(int amount) 
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHeatlth);
        Debug.Log("Player's Health:" + _currentHealth);
    }

    public void DecreaseHealth(int amount) 
    {
        _currentHealth -= amount;
        Debug.Log("Player's Health: " + _currentHealth);
        if (_currentHealth <= 0) 
        {
            Kill();
        }
    }

    public void Kill() 
    {
        gameObject.SetActive(false);
        //play particles
        //play sounds
    }

    public void UpdateDisplay(Player player)
    {
        _treasureText.text = "Treasure Count: " + player.TreasureCount;
    }
}
