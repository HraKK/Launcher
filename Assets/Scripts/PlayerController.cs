using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private BoxCollider2D playerCollider;
	private Animator animator;
	private float mainForce;
	private Vector2 direction;

	private bool isFalling;
	private bool startLaunch;
	private bool isHit;
	private bool addForce;

	void Start () 
	{
		playerCollider = GetComponent<BoxCollider2D>();

		animator = GetComponent<Animator>();
		mainForce = 500.0f;

		isFalling = false;
		startLaunch = false;
	}

	void DetermineStates()
	{
		isFalling = (rigidbody2D.velocity.y < 0 && mainForce > 100);
	}

	void UpdateAnimator()
	{
		animator.SetBool("StartJump", startLaunch);
		animator.SetBool("FallDown", isFalling);
		animator.SetBool("OnHit", isHit);

		animator.SetFloat("MainForce", mainForce);

		if(isHit)
		{
			isHit = false;
		}
	}

	void Update () 
	{
		// TODO: Change key
		if(Input.touchCount > 0)
		{
			if(rigidbody2D.isKinematic)
			{
				rigidbody2D.isKinematic = false;
				direction = new Vector2(1, 1);
				startLaunch = true;
				addForce = true;
				
				playerCollider.isTrigger = true;
				playerCollider.isTrigger = false;
			}else
			{

			}
		}

		DetermineStates();
		UpdateAnimator();
	}

	void OnCollision2DEnter(Collision2D coll)
	{
		mainForce -= 70.0f;
		direction -= new Vector2(0.3f, 0.0f);
		addForce = true;
	}

	void FixedUpdate()
	{
		if(addForce)
		{
			rigidbody2D.AddForce(direction * mainForce);
			addForce = false;
		}
	}

	void OnTrigger2DEnter(Collider2D col)
	{
		Debug.Log (col.name);

		isHit = true;

		if(col.name == "Trigger")
		{
			Destroy(col.transform.parent.gameObject);
		}
	}	
}
