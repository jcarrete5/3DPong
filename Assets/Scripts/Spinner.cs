using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour {
	public Vector3 rotate;

	void Update() {
		transform.Rotate(rotate);
	}
}
