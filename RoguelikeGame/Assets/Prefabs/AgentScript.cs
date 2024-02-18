using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class AgentScript : Agent
{

    [SerializeField] private Transform target;
    [SerializeField] private Transform start;

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continious = actionsOut.ContinuousActions;

        continious[0] = Input.GetAxisRaw("Horizontal") * 5;
        continious[1] = Input.GetAxisRaw("Vertical") * 5;

    }

    public override void OnEpisodeBegin()
    {
        transform.position = start.position;

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(target.position);

    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float xmove = actions.ContinuousActions[0];
        float zmove = actions.ContinuousActions[1];

        float speed = 5.0f;

        transform.localPosition += new Vector3(xmove, 0, zmove) * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "target")
        {
            AddReward(10);
            EndEpisode();
        }
        else if (collision.transform.tag == "wall")
        {
            AddReward(-0.001f);
        }
    }
}
