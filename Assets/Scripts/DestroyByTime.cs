using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	public int timeAlive;
	
	void Start() {
		StartCoroutine(DestroyPowerUp());
	}

	IEnumerator DestroyPowerUp() {
		yield return new WaitForSeconds(timeAlive);
		Destroy (gameObject);
	}
}
