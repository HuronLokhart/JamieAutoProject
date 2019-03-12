using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public Rigidbody thisRigidBody;
    public Vector2 inputAxis;
    public float tankVelocity;
    public float ForceMultiplier;
    public float torqueMultiplier;

    public float inputToTorque;
    
    // Start is called before the first frame update
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputAxis.y = Input.GetAxis("Vertical");
        inputAxis.x =Input.GetAxis("Horizontal");

        inputToTorque = inputAxis.x;
    }


    void FixedUpdate()
    {
        tankVelocity = thisRigidBody.velocity.magnitude;
        
        if (thisRigidBody.velocity.magnitude < 8f)
        {
            thisRigidBody.AddForce(transform.forward * inputAxis.y * ForceMultiplier, ForceMode.Impulse);
        }
            thisRigidBody.AddTorque(0, inputToTorque * torqueMultiplier, 0, ForceMode.VelocityChange);
    }
}
