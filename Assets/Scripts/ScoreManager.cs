using UnityEngine;

public class ScoreManager : MonoBehaviour {

	private uint score = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddScore(uint sc)
	{
		score += sc;
	}

	public void SubScore(uint sc)
	{
		score = sc > score ? 0 : score - sc;
	}

	public uint GetScore()
	{
		return score;
	}
}
