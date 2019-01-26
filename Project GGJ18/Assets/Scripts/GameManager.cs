using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

/*
    private static GameManager _instance;
    public static GameManager instance {
        get {
            if (_instance == null) {
                _instance = new GameManager ();
            }
            return _instance;
        }
    }
*/

   public GameObject GOPlayer;
   public PlayerManager _PlayerManager;


    // light: valor de la cantidad de luz que tiene el personaje disponible, varia entre 0 y 30 y disminuye linealmente en una unidad por segundo.
    // flame: valor de la cantidad de tiempo que nos queda de llama en el hogar. varia entre 0 y 60 y disminuye afectado por un coeficiente
    //        que varia segund el tiempo de partida

    [Range(0f,60f)]
    public float light;
    [Range(0f,30f)]
    public float flame;
    // Tiempo de espera para actualizar los estados y valores del juego: Light, Flame, etc.
    [Range (0.1f, 0.5f)]
    public float waitTime;

    // orb: El contador de orbes.
    // time: contador del tiempo en segudos, va a ser el contador total de tiempo que te mantenes vivo.
    int orbs, time;

    public Text txtFlame,txtLight,txtOrbs,txtTime;

    void Awake () {
		
	}
	
	void Start () {
		
		Initialize();
		StartCoroutine("ChangeStates");
	}
	
	void Update () {
		
		TextUpdate();
	}

	void Initialize (){

		_PlayerManager = GameObject.FindObjectOfType<PlayerManager>();
		//_PlayerManager = GOPlayer.gameObject.GetComponent<PlayerManager>();


		// Establezco el valor inicial de las variables.
		light    = 30;
		flame    = 60;
		orbs     = 0;
		time     = 0;
		waitTime = 0.1f;
	}

	void TextUpdate(){

		// Para debugear
		txtTime.text  = "Time: "  + time.ToString();
		txtOrbs.text  = "Orbs: "  + orbs.ToString();
		txtLight.text = "Light: " + light.ToString();
		txtFlame.text = "Flame: " + flame.ToString();
	}

	IEnumerator ChangeStates(){

		while (true)
        {
            yield return new WaitForSeconds(waitTime);
            //time = (INT)Time.deltaTime;
            flame -= 1 * waitTime; 
            if(light >= 0 && light <= 30){

            	  light -= 1 * waitTime * _PlayerManager.lightChangeFactor;
            	  	if(light > 30)
            	  		light = 30;

            }
           
        }
	}

}
