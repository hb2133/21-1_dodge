using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 0.5f;

    private Transform target; //발사할 대상
    private float spawnRate; //생성주기
    private float timeAfterSpawn; //최근 생성 시점에서 지난 시간.

    public int hp = 100;
    public HPBar hpbar;
    public GameObject level;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn>=spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
        hpbar.SetHP(hp);
        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
