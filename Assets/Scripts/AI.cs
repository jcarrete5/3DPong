using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	private GameObject[] balls;
	public float centerZ;
	public float radius;
	private int framesTillSkip;
	// Use this for initialization
	void Start () 
	{
		framesTillSkip = 10;
	}
	
	// Update is called once per frame
	void Update() 
	{
		balls = GameObject.FindGameObjectsWithTag("Ball");
		if(balls.Length > 0 && framesTillSkip > 0)
		{
			framesTillSkip--;
			Vector3 newPosition = transform.position;
			if(Mathf.Abs(balls[0].transform.position.y - newPosition.y) <= 1.5)
				newPosition.y = balls[0].transform.position.y;
			if(Mathf.Abs(balls[0].transform.position.x - newPosition.x) <= 1.5)
			    newPosition.x = balls[0].transform.position.x;
			if(balls[0].transform.position.y - newPosition.y < -1.5)
				newPosition.y -= 1.5f;
			if(balls[0].transform.position.y - newPosition.y > 1.5)
				newPosition.y += 1.5f;
			if(balls[0].transform.position.x - newPosition.x < -1.5)
				newPosition.x -= 1.5f;
			if(balls[0].transform.position.x - newPosition.x > 1.5)
				newPosition.x += 1.5f;
			float x = newPosition.x;
			float y = newPosition.y;
			newPosition.z = (Mathf.Sqrt(-(Mathf.Pow (x, 2)) - (Mathf.Pow (y, 2)) + Mathf.Pow (radius, 2)) - centerZ);
			transform.position = newPosition;
			transform.rotation = Quaternion.Euler(new Vector3(180 + Mathf.Rad2Deg * Mathf.Atan (transform.position.y / transform.position.z),180 + Mathf.Rad2Deg * Mathf.Atan(transform.position.x / transform.position.z), 0));
		}
		if (framesTillSkip < 1)
			framesTillSkip = 10;
	}
}