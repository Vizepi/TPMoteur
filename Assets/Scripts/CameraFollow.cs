using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	[SerializeField]
	private Transform player;
	[SerializeField]
	private Rect boundingBox;
	[SerializeField]
	private Camera cam;

	private float halfWidth, halfHeight;

	// Use this for initialization
	void Start () {
		Debug.Assert(player != null);
		Debug.Assert(cam != null);
		halfHeight = cam.orthographicSize;
		halfWidth = halfHeight * Screen.width / Screen.height;
		Debug.Assert(halfHeight <= boundingBox.height);
		Debug.Assert(halfWidth <= boundingBox.width);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 camPos = new Vector3(player.position.x, player.position.y, cam.transform.position.z);
		if(camPos.x - halfWidth < boundingBox.xMin)
		{
			camPos.x = halfWidth + boundingBox.xMin;
		}
		if (camPos.y - halfHeight < boundingBox.yMin)
		{
			camPos.y = halfHeight + boundingBox.yMin;
		}
		if (camPos.x + halfWidth > boundingBox.xMax)
		{
			camPos.x = boundingBox.xMax  - halfWidth;
		}
		if (camPos.y + halfHeight > boundingBox.yMax)
		{
			camPos.y = boundingBox.yMax - halfHeight;
		}
		cam.transform.position = camPos;
	}
}
