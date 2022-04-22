using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomMovements : MonoBehaviour
{
	public Transform target;
	private Vector3 targetPos;

	private Vector3 randomTargetPos;
	public float randomTargetDistMin = 2;
	public float randomTargetDistMax = 10;
	[Tooltip("S'il n'y a pas de cible définie générer une destination aléatoire")]
	public bool useRandomTarget = false;
	[Tooltip("Afficher la ligne qui sépare la cible de la destination")]
	public bool drawLineTarget = true;
	[Tooltip("Matérialiser les sphères représentant les distances slow et stop")]
	public bool drawGizmoTarget = true;

	public float distStop = 1;
	public float distSlowDown = 2;
	public float vitesse = 0;
	public float vitesseMax = 1.0f;
	private float vitesseMin = 0.5f;
	public float acceleration = 1.0f;
	private static Vector3 itWillStay;

	private bool atDestination;
	void Start()
	{
		itWillStay = transform.position;
		SetRandomTargetPos();
	}

	void SetRandomTargetPos()
	{
		randomTargetPos = Random.onUnitSphere;
		randomTargetPos = randomTargetPos.normalized * Random.Range(randomTargetDistMin, randomTargetDistMax) + itWillStay;
		randomTargetPos.y = itWillStay.y;
	}

	// Update is called once per frame
	void Update()
	{
		//Mise a jour du comportement
		if (target == null)
			useRandomTarget = true;

		//Calcul du point de destination
		if (useRandomTarget || target == null)
			targetPos = randomTargetPos;
		else
			targetPos = target.position;

		//Debug (après le calcul de targetPos)
		if (drawLineTarget)
			Debug.DrawLine(transform.position, targetPos, GetComponent<Renderer>().material.color);

		//Distance au point
		Vector3 deplacement = targetPos - transform.position;
		float distance = deplacement.magnitude;
		float distanceRestante = distance - distStop;
		atDestination = distance <= 0.01f;

		//Deplacement
		if (!atDestination)
		{
			//On cherche à aller le plus vite vers la destination, mais à ralentir quand on arrive
			//On reste entre vitesse min et max
			float vitesseVoulue = vitesseMax;
			if (distanceRestante < (distSlowDown - distStop))
				vitesseVoulue = Mathf.Lerp(vitesseMax, vitesseMin, 1.0f - (distanceRestante / (distSlowDown - distStop)));

			//Prise en compte de l'accélération
			if (vitesseVoulue > vitesse)
				vitesse = Mathf.Min(vitesse + acceleration * Time.deltaTime, vitesseVoulue);
			else
				vitesse = vitesseVoulue; // On freine parfaitement
			deplacement = deplacement.normalized * Time.deltaTime * vitesse;
			transform.position += deplacement;
		}
		else 
			SetRandomTargetPos();
	}

	void OnDrawGizmosSelected()
	{
		if (drawGizmoTarget)
		{
			// Sphère rouge a la distance de stop
			Gizmos.color = new Color(1, 0, 0, 1.0f);
			Gizmos.DrawWireSphere(targetPos, distStop);
			// Sphère bleue a la distance de freinage
			Gizmos.color = new Color(0, 0, 1, 1.0f);
			Gizmos.DrawWireSphere(targetPos, distSlowDown);
		}
	}
}