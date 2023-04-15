using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int m_Coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            //m_Coins = m_Coins + 1;
            m_Coins++;
            Debug.Log(m_Coins);
            Destroy(collision.gameObject);
        }
    }
}
