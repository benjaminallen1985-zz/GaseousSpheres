using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	void Start () {
		Text myText = GetComponent<Text>();
		myText.text = ScoreKeeper.score.ToString();
		ScoreKeeper.Reset();
	}
	
	void Update () {
	
	}
}
