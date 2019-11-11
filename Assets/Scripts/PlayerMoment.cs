using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoment : MonoBehaviour
{
    float forceMahnitude = 43f;
    //private float score;
    
    private Rigidbody playerRigidbody;
    float leftRight;
    float upDown;
    bool onGraund;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
   
    }


    private void FixedUpdate()
    {

        if (onGraund)
        {
            Vector3 leftRightVector = Vector3.right * leftRight * forceMahnitude;
            playerRigidbody.AddForce(leftRightVector);

            Vector3 upDownVector = Vector3.up * upDown * forceMahnitude;
            playerRigidbody.AddForce(upDownVector);
        }

    }

    // Update is called once per frame
    void Update()
    {

        leftRight = Input.GetAxis("Horizontal");
        upDown = Input.GetAxis("Vertical");



    }
    private void OnCollisionEnter(Collision collision)
    {
        onGraund = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        onGraund = false;
    }
    public void SetScore(float anIncrement)
    {
        DataManager.dataManager.score += anIncrement;
        //score += anIncrement;
        UIController.uiController.SetScoreText(DataManager.dataManager.score.ToString());
    }
}
