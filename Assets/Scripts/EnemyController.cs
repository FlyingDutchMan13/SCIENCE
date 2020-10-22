using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody myRigidbody;
    public PlayerController player;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        
    }

    
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.LookAt(player.gameObject.transform.position);
        myRigidbody.velocity = transform.forward * moveSpeed;

    }
}
