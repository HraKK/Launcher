using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	private Transform me;
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;

	void Start()
	{
		me = transform;
		var sky = GameObject.Find("Sky");

		if(sky != null)
		{
			sky.transform.parent = me;
		}
	}

	void Update () 
	{
		if (target)
		{
			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			me.position = Vector3.SmoothDamp(me.position, destination, ref velocity, dampTime);
		}
	}
}
