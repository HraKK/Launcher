using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ZombieController : MonoBehaviour {

	public class Zombie
	{
		public Transform zombie;
		public float runningSpeed;
	}

	private List<Zombie> zombies;
	private System.Random rnd;
	private Transform me;
	private bool init;

	void Start () 
	{
		me = transform;
		var count = me.childCount;
		zombies = new List<Zombie>();
		rnd = new System.Random();

		for(var i = 0; i < count; i++)
		{
			zombies.Add(new Zombie() { zombie = me.GetChild(i), runningSpeed = rnd.Next(1, 5) });
		}
	}

	void Update()
	{
		// HACK
		if(Input.GetKeyDown(KeyCode.Space))
		{
			init = true;
		}

		if(!init)
		{
			return;
		}

		for(var i = 0; i < zombies.Count; i++)
		{
			if(zombies[i].zombie != null)
			{
				zombies[i].zombie.Translate(Vector3.right * zombies[i].runningSpeed * Time.deltaTime);
			}
		}
	}
}
