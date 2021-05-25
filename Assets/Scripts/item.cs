using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    int healAmount = 20;

    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(0f, 15f * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController PlayerController = other.GetComponent<PlayerController>();
        if(PlayerController != null)
        {
            PlayerController.GetHeal(healAmount);
        }
        Destroy(gameObject);
    }
}
