using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float mouseSensitivityHorizontal;
    public float mouseSensitivityVertical;

    public float moveSpeed;
    public float strafeSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * strafeSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
        transform.Rotate(-Input.GetAxis("Mouse Y") * mouseSensitivityVertical, Input.GetAxis("Mouse X") * mouseSensitivityHorizontal, 0);
 	}
}
