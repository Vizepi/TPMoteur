using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	[SerializeField]
	private string [] triggeringTags;

	private int triggering = 0;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		bool ofTag = triggeringTags.Length == 0;
		foreach(string s in triggeringTags)
		{
			ofTag |= collision.gameObject.tag == s;
			if(ofTag)
			{
				break;
			}
		}
		if (ofTag)
		{
			triggering++;
		}
	}
	void OnTriggerExit2D(Collider2D collision)
	{
		bool ofTag = triggeringTags.Length == 0;
		foreach (string s in triggeringTags)
		{
			ofTag |= collision.gameObject.tag == s;
			if (ofTag)
			{
				break;
			}
		}
		if(ofTag)
		{
			triggering = Mathf.Max(0, triggering - 1);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	public bool Triggering()
	{
		return triggering != 0;
	}
}
