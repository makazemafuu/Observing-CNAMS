using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{

    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behavior;

    [Range(10, 500)]
    public int startingCount = 250;
    const float AgentDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareAvoidanceRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        // Initialize & instantiate our flock
        for (int i = 0; i < startingCount; i++)
        {
            Vector3 spawnArea = Random.insideUnitSphere;
            FlockAgent newAgent = Instantiate(
            agentPrefab, transform.position + new Vector3(spawnArea.x, 0, spawnArea.y) * startingCount * AgentDensity,
            Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
            transform
            );
            newAgent.name = "Agent" + i;
            agents.Add(newAgent); // Keeping track of those and iterate through them
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
