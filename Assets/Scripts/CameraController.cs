using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) { 
			transform.Rotate (new Vector3 (0f, -5f, 0f)); 
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (new Vector3 (0f, 5f, 0f));
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Rotate (new Vector3 (5f, 0f, 0f));
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Rotate (new Vector3 (-5f, 0f, 0f));
		}
	}
}
