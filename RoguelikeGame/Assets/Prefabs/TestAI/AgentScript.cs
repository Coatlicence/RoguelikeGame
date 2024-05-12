using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class AgentScript : Agent
{

    [SerializeField] private GameObject Dests;
    [SerializeField] private GameObject Start;

    [SerializeField] private float Speed;

    private Transform CurrentDest;

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continious = actionsOut.ContinuousActions;

        continious[0] = Input.GetAxisRaw("Horizontal") * Speed;
        continious[1] = Input.GetAxisRaw("Vertical") * Speed;

        Debug.Log(Input.GetAxisRaw("Horizontal") * Speed);

    }

    public override void OnEpisodeBegin()
    {
        CurrentDest = Dests.transform.GetChild(Random.Range(0, Dests.transform.childCount));

        CurrentDest.gameObject.SetActive(true);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(Start.transform.position);

    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float xmove = actions.ContinuousActions[0];
        float zmove = actions.ContinuousActions[1];

        transform.localPosition += new Vector3(xmove, 0, zmove) * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == CurrentDest.gameObject)
        {
            AddReward(10);
            EndEpisode();
            CurrentDest.gameObject.SetActive(false);
        }
    }
}
