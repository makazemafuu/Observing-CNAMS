using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FlockBehavior
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // If not neighbors, maintain current alignment
        if (context.Count == 0)
            return agent.transform.up;

        // Add all points together and average
        Vector3 alignmentMove = Vector3.zero;
        foreach (Transform item in context)
        {
            alignmentMove += (Vector3)item.transform.up;
        }
        alignmentMove /= context.Count;

        return alignmentMove;
    }
}
