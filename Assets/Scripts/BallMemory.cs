using UnityEngine;
using System.Collections;

public class BallMemory : MonoBehaviour
{
	public bool PlayerHitBallLast { get; set; }

	void OnCollisionEnter(Collision collision)
	{
		PlayerHitBallLast = collision.collider.CompareTag("Player");
	}
}
