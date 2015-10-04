using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour 
{
	public Vector3 rotate;
	// Use this for initialization
	void Start() 
	{
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		
	}

	void FixedUpdate()
	{
		transform.Rotate (rotate);
	}
}
