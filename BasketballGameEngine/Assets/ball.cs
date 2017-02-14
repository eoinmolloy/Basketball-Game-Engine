using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {
	Vector3 P, P0, V, V0;
	float g, time;
	float elasticity;
	bool animation;
	public int power;
	GameObject[] targets;
	int bounces;



	// Use this for initialization
	void Start () {
		//adding the array of targets
		targets = GameObject.FindGameObjectsWithTag("target");

		bounces = 0;
		power = 8;
		P0 = GameObject.Find ("Launcher").transform.position;
		g = 9.81f;
		V0 = GameObject.Find ("Launcher").transform.forward.normalized * power;
		elasticity = 0.8f;

		animation = true;
	}




	Vector3 calculateVelocity (float t)
	{
		float x, y, z;
		x = V0.x;
		z = V0.z;
		y = -g * t + V0.y;

		return (new Vector3 (x, y, z));
	}

	Vector3 calculatePosition (float t)
	{
		float x, y, z;
		x = V0.x * t + P0.x;
		z = V0.z * t + P0.z;
		y = V0.y * t + P0.y - .5f * g * t*t;

		return (new Vector3 (x, y, z));
	}


	// Update is called once per frame
	void Update () {

		if (animation) {
			time += Time.deltaTime;

			P = calculatePosition (time);
			V = calculateVelocity (time);
			transform.position = P;
			checkCollision ();
			checkTargetCollision ();
			if (V.magnitude < .1)
				animation = false;
		}

	}

	void checkCollision()
	{
		checkCollisionWithGround ();
		checkTargetCollision ();
	}
	void checkCollisionWithGround ()
	{
		if (P.y <= 0.25 && V.y <0) 
		{
			time = 0;
			P0 = P;
			V0 = V*elasticity;
			V0.y = - V0.y;
			//print ("Position after collision" + P0);
			bounces++;
		}
	}

	void checkTargetCollision(){
		int i = 0;
		bool hit = false;
		if (hit == false) {
			for (i = 0; i < targets.Length; i++) {
				print (i + ":" + targets [i].name);			
				float dist = Vector3.Distance (targets [i].transform.position, transform.position);
				//print (targets[i].name +" : " + dist);

				if (dist < 1.0f && bounces == 2) {
					print (targets [i].name + "HITTTTTTT");
					hit = true;		
					Destroy (targets[i]);
					Destroy (gameObject);
				}
			}
		}
	}

}
