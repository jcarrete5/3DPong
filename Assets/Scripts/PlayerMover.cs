using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour 
{	
	public float centerZ;
	public float radius;
	// Update is called once per frame
	void Update () 
	{
		Vector3 newPosition = transform.position;
		if (Input.GetKey ("w") && (Mathf.Abs(newPosition.x) + Mathf.Abs(newPosition.y) <= radius || newPosition.y < 0)) 
			newPosition.y += 0.15f;
		if (Input.GetKey ("s") && (Mathf.Abs(newPosition.x) + Mathf.Abs(newPosition.y) <= radius || newPosition.y > 0))
			newPosition.y -= 0.15f;
		if (Input.GetKey ("a") && (Mathf.Abs(newPosition.x) + Mathf.Abs(newPosition.y) <= radius || newPosition.x > 0))
			newPosition.x -= 0.15f;
		if (Input.GetKey ("d") && (Mathf.Abs(newPosition.x) + Mathf.Abs(newPosition.y) <= radius || newPosition.x < 0))
			newPosition.x += 0.15f;
		float x = newPosition.x;
		float y = newPosition.y;
		newPosition.z = -1 * (Mathf.Sqrt(-(Mathf.Pow (x, 2)) - (Mathf.Pow (y, 2)) + Mathf.Pow (radius, 2)) - centerZ);
		transform.position = newPosition;
		transform.rotation = Quaternion.Euler(new Vector3(360 - Mathf.Rad2Deg * Mathf.Atan (transform.position.y / transform.position.z), Mathf.Rad2Deg * Mathf.Atan(transform.position.x / transform.position.z), 0));
	}
}
