using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReloader : MonoBehaviour
{
    private Vector3 initialPosition;
    private GameObject player;
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            DataManager.dataManager.ReloadLevel();
    
        }
    }
}
