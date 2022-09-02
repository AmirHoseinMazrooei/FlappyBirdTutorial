using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject m_Player;
    [SerializeField] private float m_ForceMultiplier;
    [SerializeField] private float m_Velocity;
    [SerializeField] private GameObject m_GameOverUI;
    private bool m_IsGameOver = false;
    private Rigidbody2D m_PlayerRigidBody2D;
    private void Start()
    {
        m_PlayerRigidBody2D=m_Player.GetComponent<Rigidbody2D>();
        m_PlayerRigidBody2D.velocity = Vector2.right * m_Velocity;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !m_IsGameOver)
        {
            print("Jump");
            m_PlayerRigidBody2D.velocity=new Vector2(m_PlayerRigidBody2D.velocity.x,m_ForceMultiplier);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Hazard"))
        {
            m_IsGameOver = true;
            print("Player is Dead!");
            m_GameOverUI.SetActive(true);
        }
    }
}
