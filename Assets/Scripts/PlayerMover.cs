using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour 
{	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newPosition = transform.position;
		if (Input.GetKey ("w") && (Mathf.Abs(newPosition.x) + Mathf.Abs(newPosition.y) + Mathf.Abs((float)(newPosition.z + 5)) <= 4.50 || newPosition.y < 0)) 
			newPosition.y += 0.1f;
		if (Input.GetKey ("s") && (Mathf.Abs(newPosition.x) + Mathf.Abs(newPosition.y) + Mathf.Abs((float)(newPosition.z + 5)) <= 4.50 || newPosition.y > 0))
			newPosition.y -= 0.1f;
		if (Input.GetKey ("a") && (Mathf.Abs(newPosition.x) + Mathf.Abs(newPosition.y) + Mathf.Abs((float)(newPosition.z + 5)) <= 4.50 || newPosition.x > 0))
			newPosition.x -= 0.1f;
		if (Input.GetKey ("d") && (Mathf.Abs(newPosition.x) + Mathf.Abs(newPosition.y) + Mathf.Abs((float)(newPosition.z + 5)) <= 4.50 || newPosition.x < 0))
			newPosition.x += 0.1f;
		float x = newPosition.x;
		float y = newPosition.y;
		//Debug.Log (-(Mathf.Pow (x, 2)) - (Mathf.Pow (y, 2)) + 56.25);
		newPosition.z = -1 * (Mathf.Sqrt((-(Mathf.Pow (x, 2)) - (Mathf.Pow (y, 2)) + 20.25f)) + 2.75f);
		transform.position = newPosition;
		transform.rotation = Quaternion.Euler(new Vector3(360 - Mathf.Rad2Deg * Mathf.Atan (transform.position.y / transform.position.z), Mathf.Rad2Deg * Mathf.Atan(transform.position.x / transform.position.z), 0));
	}
}
