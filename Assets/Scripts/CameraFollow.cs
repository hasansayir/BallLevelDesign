using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        //transform.position = player.transform.position + offset;
    }
    private void LateUpdate()
    {

        transform.position = player.transform.position + offset;
      
    }
   
}
