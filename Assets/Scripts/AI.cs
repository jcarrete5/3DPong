using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	private GameObject[] balls;
	public float centerZ;
	public float radius;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update() 
	{
		balls = GameObject.FindGameObjectsWithTag("Ball");
		if(balls.Length > 0)
		{
			Vector3 newPosition = transform.position;
			if(balls[0].transform.position.y < newPosition.y)
				newPosition.y -= 1.5f;
			if(balls[0].transform.position.y > newPosition.y)
				newPosition.y += 1.5f;
			if(balls[0].transform.position.x < newPosition.x)
				newPosition.x -= 1.5f;
			if(balls[0].transform.position.x > newPosition.x)
				newPosition.x += 1.5f;
			Debug.Log(balls[0].transform.position.x + "\t" + balls[0].transform.position.y);
			float x = newPosition.x;
			float y = newPosition.y;
			newPosition.z = (Mathf.Sqrt(-(Mathf.Pow (x, 2)) - (Mathf.Pow (y, 2)) + Mathf.Pow (radius, 2)) - centerZ);
			transform.position = newPosition;
			Debug.Log(transform.position.x + "\t" + transform.position.y + "\t" + transform.position.z);
			transform.rotation = Quaternion.Euler(new Vector3(180 + Mathf.Rad2Deg * Mathf.Atan (transform.position.y / transform.position.z),180 + Mathf.Rad2Deg * Mathf.Atan(transform.position.x / transform.position.z), 0));
		}
	}
}
