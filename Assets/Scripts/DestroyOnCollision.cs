using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log(collision.gameObject.name + " collided with " + gameObject.name);
		Destroy(collision.gameObject);
	}
}
