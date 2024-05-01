using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coin;
    private int coins = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            coin.text = "Coin : " + coins;
        }
    }
}
