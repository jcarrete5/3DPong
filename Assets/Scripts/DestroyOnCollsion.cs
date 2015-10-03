using UnityEngine;

public class DestroyOnCollsion : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Collision occured");
		Destroy(collision.gameObject);
	}
}
