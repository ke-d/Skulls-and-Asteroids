﻿using UnityEngine;
using System.Collections;

public class DestroyOffscreen : MonoBehaviour {
	private GameObject screen;

	void Awake () {
		screen = GameObject.FindGameObjectWithTag ("Background");
	}
	void Update () {
		if (OutOfBounds ()) {
			StartCoroutine (Destroy (.5f));
		}
	}

	bool OutOfBounds() {
		return Mathf.Abs (transform.position.x) > screen.GetComponent<Renderer> ().bounds.size.x/1.4 || Mathf.Abs (transform.position.y) > screen.GetComponent<Renderer> ().bounds.size.y/1.4;
	}
	
	IEnumerator Destroy(float time) {
		yield return new WaitForSeconds (time);
		OnOutOfBounds ();
	}

	public void OnOutOfBounds(){
		Destroy (gameObject);
	}
}
