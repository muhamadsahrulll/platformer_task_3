using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    public int damageAmount = 100;
    public float knockbackForce = 5f;
    //public PlayerHealth player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                // Kurangi darah player
                player.TakeDamage(damageAmount);
                //Debug.Log("mati");

                // Terapkan knockback
                Vector2 knockbackDirection = (player.transform.position - transform.position).normalized;
                player.ApplyKnockback(knockbackDirection, knockbackForce);
            }
        }
    }
}
