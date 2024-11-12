using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 10f;
    public Slider healthBar;
    public float damageAmount = 1f;
    private bool canTakeDamage = true;
    public float damageCooldown = 1.5f;
    public float fallDamageThreshold = 5f;  
    public float fallDamageMultiplier = 1f; 

    private bool isGrounded = true;
    private float lastYPosition;

    void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
        lastYPosition = transform.position.y;
    }

    void Update()
    //CHeck with player so fix this part up
    {
        if (!isGrounded && transform.position.y < lastYPosition)
            lastYPosition = transform.position.y;
    }

    //Take into consideration of gravity as well as the method of desotrying the game obkect for TakeDamage
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            float fallDistance = lastYPosition - transform.position.y;
            if (fallDistance >= fallDamageThreshold)
            {
                float fallDamage = fallDistance * fallDamageMultiplier;
                TakeDamage(fallDamage);
            }
            lastYPosition = transform.position.y;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet2") && canTakeDamage)
        {
            TakeDamage(damageAmount);
            Destroy(other.gameObject);  
        }
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {
            health -= damage;
            healthBar.value = health;
            if (health <= 0){
                Destroy(gameObject);  
            }
            else
                StartCoroutine(DamageCooldown()); 
        }
    }

    private IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }
}
