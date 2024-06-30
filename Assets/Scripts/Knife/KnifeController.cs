using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    private KnifeManager _knifeManager;
    
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;

    private bool canShoot = false;

    private void Start()
    {
        GetComponentValues();
    }

    private void Update()
    {
        HandleShotInput();
    }

    private void FixedUpdate()
    {
        Shoot();
    }

    private void  HandleShotInput(){
        if (Input.GetMouseButtonDown(0))
        {
            canShoot = true;
        }
    }

    private void Shoot()
    {
        if (canShoot)
        {
           rb.AddForce(Vector2.up* moveSpeed * Time.fixedDeltaTime); 
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Circle"))
        {
            _knifeManager.SetKnifeActive();
            canShoot = false;
            rb.isKinematic = true;
            transform.SetParent(other.gameObject.transform);
        }
    }

    private void GetComponentValues()
    {
        rb = GetComponent<Rigidbody2D>();
        _knifeManager = GameObject.FindObjectOfType<KnifeManager>();
    }
}
