using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerHealth : MonoBehaviour
{
    public float health = 10f;
    public Slider healthBar;
    public float damageAmount = 1f;
    private bool canTakeDamage = true;
    public float damageCooldown = 1.5f; 

    void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet") && canTakeDamage)
        {
            TakeDamage(damageAmount);
            Destroy(other.gameObject);  
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;

        if (health <= 0)
            Destroy(gameObject);  
        else
            StartCoroutine(DamageCooldown()); 
    }

    private IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }
}
