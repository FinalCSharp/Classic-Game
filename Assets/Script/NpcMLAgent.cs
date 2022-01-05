using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class NpcMLAgent : Agent
{
    Transform p1, p2;
    public Transform npc2;
    Rigidbody2D rb;
    public void Start()
    {
        //    p1 = GameObject.Find("Player1(Clone)").transform;
        //  p2 = GameObject.Find("Player2(Clone)").transform;
        rb = transform.GetComponent<Rigidbody2D>();
    }
    public float moveSpeed = 20;
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(npc2.position);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.DiscreteActions[0] / 100;
        float moveY = actions.DiscreteActions[1] / 100;
        rb.MovePosition(transform.localPosition + new Vector3(moveX, moveY, 0));
    }
    public override void OnEpisodeBegin()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("fence"))
        {
            SetReward(-1f);
        }
    }
}
