using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

	[SerializeField]
	private Trigger leftTrigger;
	[SerializeField]
	private Trigger rightTrigger;
	[SerializeField]
	private float speed;
	[SerializeField]
	private Transform art;
	[SerializeField]
	private bool startLeft = true;
	[SerializeField]
	private Rigidbody2D rb;

	private bool left = true;

	void Start()
	{
		Debug.Assert(leftTrigger != null);
		Debug.Assert(rightTrigger != null);
		Debug.Assert(art != null);
		Debug.Assert(rb != null);
		speed = -Mathf.Abs(speed);
	}

	// Update is called once per frame
	void Update()
	{
		if (left)
		{
			if (!leftTrigger.Triggering())
			{
				left = false;
				art.localScale = new Vector3(startLeft ? -1 : 1, 1, 1);
				speed = Mathf.Abs(speed) * (startLeft ? 1 : -1);
			}
		}
		else
		{
			if (!rightTrigger.Triggering())
			{
				left = true;
				art.localScale = new Vector3(startLeft ? 1 : -1, 1, 1);
				speed = Mathf.Abs(speed) * (startLeft ? -1 : 1);
			}
		}
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2(speed, rb.velocity.y);
	}
}
