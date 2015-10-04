using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{
	public GameObject ballPrefab;
	public Text messageText;

	void Start()
	{
		StartCoroutine(SpawnBall());
	}

	public IEnumerator SpawnBall()
	{
		for(int i = 3; i > 0; i--)
		{
			messageText.text = i.ToString();
			yield return new WaitForSeconds(1);
		}
		messageText.text = "";

		GameObject ball = Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		ball.GetComponent<Rigidbody>().AddForce(0, 0, -250); 
	}
}
