using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public TextMeshProUGUI darahTxt;
    public GameObject player;

    //public float knockbackForce = 10f;

    private Rigidbody2D rb;

    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateHealthText();

        if (currentHealth == 0)
        {
            Destroy(player.gameObject);
            Debug.Log("mati");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
            if (collision.contacts[0].normal.y > 0.5f) // Player hits enemy from top
            {
                Destroy(collision.gameObject); // Enemy dies
            }
        }
    }
    private void UpdateHealthText()
    {
        if (darahTxt != null)
        {
            darahTxt.text = "Darah :" + currentHealth.ToString();
        }
    }



    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        // Tambahkan logika lain yang mungkin Anda inginkan, misalnya menampilkan efek visual, memeriksa jika health <= 0, dll.
    }

    public void ApplyKnockback(Vector2 direction, float force)
    {
        rb.velocity = Vector2.zero; // Hentikan kecepatan sebelumnya
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }
}
