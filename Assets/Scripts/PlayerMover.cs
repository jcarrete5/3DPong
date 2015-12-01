using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {
	public float moveSpeed;
	public float inset;
	public Transform bounds;

	void Update() {
		Vector3 translation = new Vector3();
		translation.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
		translation.y = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
		transform.Translate(translation);

		float clampedX = Mathf.Clamp(transform.position.x, bounds.Find("-XWall").position.x + inset, bounds.Find("+XWall").position.x - inset);
		float clampedY = Mathf.Clamp(transform.position.y, bounds.Find("-YWall").position.y + inset, bounds.Find("+YWall").position.y - inset);
		transform.position = new Vector3(clampedX, clampedY, transform.position.z);
	}
}
