using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Args {
	public string text;
	public float time;

	public Args(string str, float t) {
		text = str;
		time = t;
	}
}

public class Display : MonoBehaviour {
	public Text displayText;

	//Displays 'text' for 'time' long
	public void DisplayText(Args args) {
		StartCoroutine(args.text, args.time);
	}

	IEnumerator Show(string text, float time) {
		displayText.text = text;
		yield return new WaitForSeconds(time);
		displayText.text = "";
	}
}
