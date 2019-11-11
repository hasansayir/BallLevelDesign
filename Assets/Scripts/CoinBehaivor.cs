using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaivor : MonoBehaviour
{
    private float amount = 5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag==("Player"))
        {

            //other.GetComponent<PlayerMoment>().score += amount;
            other.GetComponent<PlayerMoment>().SetScore(amount);
            Destroy(gameObject);
        }
        
    }
}
