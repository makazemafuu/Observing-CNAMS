using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehavior : FlockBehavior
{
    public FlockBehavior[] behaviors;
    public float[] weights;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // Handle data mismatch
        if (weights.Length != behaviors.Length)
        {
            Debug.Log("Data mismatch in" + name, this);
            return Vector3.zero;
        }

        // Setup move
        Vector3 move = Vector3.zero;

        // We'll iterate through each behaviors rather than each objects, and then we'll simply pass in all the objects to those behaviors
        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector3 partialMove = behaviors[i].CalculateMove(agent, context, flock) * weights[i];
            // Confirm that the partialMove is being limited to the extent of the weight
            if (partialMove != Vector3.zero)
            {
                if (partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }

                move += partialMove;

            }
        }

        return move;

    }

}
