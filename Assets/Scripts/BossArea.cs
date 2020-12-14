using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArea : MonoBehaviour
{
	[SerializeField]
	private GameObject[] objectsToHide;

	[SerializeField]
	private float detectionDistance;

	private GameObject Player;

	Vector3 centerPosition;

	void Start()
	{
		Player = GameObject.FindWithTag("Player");

		centerPosition = gameObject.GetComponent<Collider>().bounds.center;
	}


	void Update()
	{
		bool IsPlayerNear = Vector3.Distance(Player.transform.position, centerPosition) < detectionDistance;

		if (Input.GetKeyDown(KeyCode.E) && IsPlayerNear == true)
		{
			for(int i = 0; i < objectsToHide.Length; i++)
			{
				objectsToHide[i].SetActive(false);
			}
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, detectionDistance);
	}

}
