using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {
	public float moveSpeed;
	public float centerZ;
	public float radius;

	void Update() {
		//update position of paddle
		Vector3 newPosition = transform.position;
		if (Mathf.Sqrt(Mathf.Pow(newPosition.x, 2) + Mathf.Pow(newPosition.y, 2)) <= Mathf.Pow(radius, 2) || newPosition.y < 0)
			newPosition.y += Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
		if (Mathf.Sqrt(Mathf.Pow(newPosition.x, 2) + Mathf.Pow(newPosition.y, 2)) <= Mathf.Pow(radius, 2) || newPosition.y < 0)
			newPosition.x += Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

		float x = newPosition.x;
		float y = newPosition.y;
		newPosition.z = -1 * (Mathf.Sqrt(-(Mathf.Pow(x, 2)) - (Mathf.Pow(y, 2)) + Mathf.Pow(radius, 2)) - centerZ);
		transform.position = newPosition;
		transform.rotation = Quaternion.Euler(new Vector3(360 - Mathf.Rad2Deg * Mathf.Atan (transform.position.y / transform.position.z), Mathf.Rad2Deg * Mathf.Atan(transform.position.x / transform.position.z), 0));
	}
}
