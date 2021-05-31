﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;

    public int hp = 100;
    public HPBar hpbar;

    private float spawnRate = 0.2f; //플레이어는 0.2초마다 총알발사
    private float timerAfterSpawn;
    public GameObject playerbulletPrefab;

    void Start()
    {
        playerRigidbody = GetComponent <Rigidbody>();
        
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        playerRigidbody.velocity = newVelocity;

        timerAfterSpawn += Time.deltaTime;

        if(Input.GetButton("Fire1")&&timerAfterSpawn >= spawnRate)
        {
            timerAfterSpawn = 0;
            GameObject bullet = Instantiate(playerbulletPrefab, transform.position, transform.rotation);
        }

    }
    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
        hpbar.SetHP(hp);
        Debug.Log(hp);
        if(hp<=0)
        {
            Die();
        }
    }

    public void GetHeal(int heal)
    {
        hp += heal;
        if(hp>100)
        {
            hp = 100;
        }
        hpbar.SetHP(hp);
    }
}
