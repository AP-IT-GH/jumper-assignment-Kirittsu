using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;


public class Jumper : Agent
{
    public float jumpForce = 10f;
    public float gravityScale = 2f; // Adjust this value to control the speed of falling
    public LayerMask whatIsGround;

    private bool onGround;
    private Rigidbody rb;
    private const float penaltyForJumping = -0.5f;
    private const float rewardWaiting = 0.02f;

    // Define possible actions
    private enum Action { Jump, Wait }

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        rb.constraints |= RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        rb.useGravity = false; // Disable gravity until jumping
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(onGround);
        base.CollectObservations(sensor);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        onGround = Physics.Raycast(transform.position, Vector3.down, transform.lossyScale.y * 0.5f + 0.2f, whatIsGround);

        // Convert discrete action to enum
        Action action = (Action)actionBuffers.DiscreteActions[0];

        // Execute the action
        switch (action)
        {
            case Action.Jump:
                if (onGround)
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                    // Apply penalty for jumping
                    AddReward(penaltyForJumping);
                }
                break;
            case Action.Wait:
                // Apply reward for not jumping
                if (onGround)
                {
                    AddReward(rewardWaiting);
                }
                break;
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // Default to no action
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = (int)Action.Wait;

        // If 'space' is pressed, take jump action
        if (Input.GetKey(KeyCode.Space))
        {
            discreteActionsOut[0] = (int)Action.Jump;
        }
    }

    private void FixedUpdate()
    {
        // Apply custom gravity
        rb.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);
    }

    public void Hit()
    {
        AddReward(-2.0f);
        EndEpisode();
    }

    public void Reward()
    {
        AddReward(1.0f);
        EndEpisode();
    }
}