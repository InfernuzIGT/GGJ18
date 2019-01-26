using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public Rigidbody rBody;
    public float speed; //4
    // isHome muestra si el pj esta dentro de la cueva.
    public bool isHome;
    // Basicamente determina la velocidad en la que cambia la subida o bajada de la variable de luz, si esta en casa sube rapido, sino baja normalmente. 
    public int lightChangeFactor;

    void Awake () {
		
	}
	
	void Start () {
        //Debug.Log ("<color=blue>Test</color>");
        Initialize();
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

    public void Initialize(){

        lightChangeFactor = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "House")
        {
            Debug.Log("entered");
            isHome = true;
            lightChangeFactor = -4;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "House")
        {
            Debug.Log("exit");
            isHome = false;
            lightChangeFactor = 1;
        }

    }


    //END
}
