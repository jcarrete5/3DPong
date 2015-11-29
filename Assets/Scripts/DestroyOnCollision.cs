using UnityEngine;

//Destroys the collider colliding with this GameObject
public class DestroyOnCollision : MonoBehaviour {
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log(collision.gameObject.name + " collided with " + gameObject.name);
		Destroy(collision.gameObject);
	}
}
