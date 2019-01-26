using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public Rigidbody rBody;
    public float speed; //4

    void Awake () {
		
	}
	
	void Start () {
        //Debug.Log ("<color=blue>Test</color>");
    }

    void Update () {
        CharacterMovement ();
	}

    void CharacterMovement () {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3 (horizontal, 0, vertical);
        rBody.AddForce (movement * speed);
    }



    //END
}
