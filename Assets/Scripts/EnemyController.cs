using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody myRigidbody;
    public PlayerController player;
    public int damageToGive;
    public float timeBetweenAttacks;
    private float attackCounter;
    private bool touchingPlayer;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        attackCounter = 0f;
        touchingPlayer = false;
    }

    
    void Update()
    {
        attackCounter -= Time.deltaTime;
        if (touchingPlayer)
        {
            AttackPlayer();
        }
    }

    void FixedUpdate()
    {
        transform.LookAt(player.gameObject.transform.position);
        myRigidbody.velocity = transform.forward * moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            touchingPlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            touchingPlayer = false;
        }
    }

    private void AttackPlayer()
    {
        if (attackCounter <= 0f)
        {
            player.gameObject.GetComponent<HealthManager>().Damage(damageToGive);
            attackCounter = timeBetweenAttacks;
        }
    }
}
