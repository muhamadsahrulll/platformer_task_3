using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f; // Kecepatan gerakan musuh
    public float moveDistance = 10f; // Jarak maksimal musuh akan bergerak

    private Rigidbody2D rb;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingToEnd = true;
    private SpriteRenderer spriteRenderer;
    public float knockbackForce = 5f;
    public PlayerHealth player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        endPos = startPos + new Vector3(moveDistance, 0, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    

    void FixedUpdate()
    {
        // Pergerakan musuh
        if (movingToEnd)
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime));
            if (Vector3.Distance(transform.position, endPos) < 0.1f)
            {
                movingToEnd = false;
                FlipSprite();
            }
        }
        else
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime));
            if (Vector3.Distance(transform.position, startPos) < 0.1f)
            {
                movingToEnd = true;
                FlipSprite();
            }
        }
    }

    void FlipSprite()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
