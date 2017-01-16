using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateScoreUI : MonoBehaviour {

	private ScoreManager scoreManager;
	private Text scoreText;
	// Use this for initialization
	void Start()
	{
		scoreManager = GameObject.FindObjectOfType<ScoreManager>();
		Debug.Assert(scoreManager != null);
		scoreText = GetComponent<Text>();
		Debug.Assert(scoreText != null);
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = scoreManager.GetScore().ToString();
	}
}
