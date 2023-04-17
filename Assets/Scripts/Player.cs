using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI CoinLabel;
    public TextMeshProUGUI UI_CoinCountLabel;
    public GameObject Winning_UI;

    private int m_Coins;
    private Vector3 m_RespawnPoint;
    private Rigidbody2D m_Rb;
    private PlayerMovement m_playerMovement;

    private void Start()
    {
        m_RespawnPoint = transform.position;
        m_Rb = GetComponent<Rigidbody2D>();
        m_playerMovement = GetComponent<PlayerMovement>();
    }

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

        if (collision.CompareTag("DeathCollider"))
        {
            transform.position = m_RespawnPoint;
            m_Rb.velocity = Vector3.zero;
            Debug.Log("Respawned!");
        }

        if (collision.CompareTag("WinningFlag"))
        {
            UI_CoinCountLabel.text = m_Coins.ToString();
            Winning_UI.SetActive(true);
            m_Rb.velocity = Vector3.zero;
            m_playerMovement.enabled = false;

            Debug.Log("WIN!");
        }
    }
}
