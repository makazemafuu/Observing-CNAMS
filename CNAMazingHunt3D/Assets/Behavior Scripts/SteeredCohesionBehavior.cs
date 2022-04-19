using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Script inherites from the FlockBehavior class instead of MonoBehavior
// Because it's a scriptable object we'll need to create an attribute of a menu for it

[CreateAssetMenu(menuName = "Flock/Behavior/Steered Cohesion")]
public class SteeredCohesionBehavior : FlockBehavior
{

    Vector3 currentVelocity;
    public float agentSmoothTime = 0.5f;


    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // If not neighbors, return no adjustment
        if (context.Count == 0)
            return Vector3.zero;

        // Add all points together and average
        Vector3 cohesionMove = Vector3.zero;
        foreach (Transform item in context)
        {
            cohesionMove += (Vector3)item.position;
        }
        cohesionMove /= context.Count;

        // Create offset from agent position
        cohesionMove -= (Vector3)agent.transform.position;
        cohesionMove = Vector3.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);
        return cohesionMove;
    }
}
