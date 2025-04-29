using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth;

    protected float currentHealth;
    
    protected event Action<float> OnTakeDamage;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
}