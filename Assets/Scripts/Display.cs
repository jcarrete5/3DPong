using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Display : MonoBehaviour {
	public Text displayText;

	//Displays 'text' for 'time' long
	public void DisplayText(string text, float time) {
		StartCoroutine(text, time);
	}

	IEnumerator Show(string text, float time) {
		displayText.text = text;
		yield return new WaitForSeconds(time);
		displayText.text = "";
	}
}
