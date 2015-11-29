using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	public float moveSpeed;
	public float centerZ;
	public float radius;

	GameObject[] balls;
	float errorOffsetX, errorOffsetY;
	int framesTillSkip;

	void Start ()  {
		framesTillSkip = 30;
	}
	
	void Update() {
		balls = GameObject.FindGameObjectsWithTag("Ball");

		if(balls.Length > 0 && framesTillSkip > 0) {
			framesTillSkip--;
			Vector3 newPosition = transform.position;
			if(Mathf.Abs((balls[0].transform.position.y + errorOffsetY) - newPosition.y) <= 0.15)
				newPosition.y = balls[0].transform.position.y + errorOffsetY;
			if(Mathf.Abs((balls[0].transform.position.x + errorOffsetX) - newPosition.x) <= 0.15)
			    newPosition.x = balls[0].transform.position.x + errorOffsetX;
			if((balls[0].transform.position.y + errorOffsetY) - newPosition.y < -0.15)
				newPosition.y -= moveSpeed * Time.deltaTime;
			if((balls[0].transform.position.y + errorOffsetY) - newPosition.y > 0.15)
				newPosition.y += moveSpeed * Time.deltaTime;
			if((balls[0].transform.position.x + errorOffsetX) - newPosition.x < -0.15)
				newPosition.x -= moveSpeed * Time.deltaTime;
			if((balls[0].transform.position.y + errorOffsetX) - newPosition.x > 0.15)
				newPosition.x += moveSpeed * Time.deltaTime;
			float x = newPosition.x;
			float y = newPosition.y;
			newPosition.z = (Mathf.Sqrt(-(Mathf.Pow (x, 2)) - (Mathf.Pow (y, 2)) + Mathf.Pow (radius, 2)) - centerZ);
			transform.position = newPosition;
			transform.rotation = Quaternion.Euler(new Vector3(180 + Mathf.Rad2Deg * Mathf.Atan (transform.position.y / transform.position.z),180 + Mathf.Rad2Deg * Mathf.Atan(transform.position.x / transform.position.z), 0));
		}

		if (framesTillSkip < 1) {
			framesTillSkip = 10;
			errorOffsetX = Random.Range(-0.25f, 0.25f);
			errorOffsetY = Random.Range(-0.25f, 0.25f);
		}
	}
}