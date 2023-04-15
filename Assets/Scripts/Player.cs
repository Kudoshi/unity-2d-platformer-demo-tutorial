using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI CoinLabel;

    private int m_Coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            //m_Coins = m_Coins + 1;
            m_Coins++;
            CoinLabel.text = m_Coins.ToString();
            Debug.Log(m_Coins);
            Destroy(collision.gameObject);
        }
    }
}
