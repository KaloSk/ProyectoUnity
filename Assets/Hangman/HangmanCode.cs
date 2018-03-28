using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HangmanCode : MonoBehaviour {

	public string palabra;
	string palabraEscondida;

	public Text outputText;
	public InputField inputField;
	public RawImage rawImg;

	public Scene scena;

	// Use this for initialization
	void Start () {
		foreach (char c in palabra) {
			palabraEscondida += "*";
		}

		outputText.text = palabraEscondida;
	}
	
	// Update is called once per frame
	void Update () {
		

		if (inputField.isFocused && Input.GetKeyDown (KeyCode.Return)) {
			Debug.Log (inputField.text);
			char letra = inputField.text [0];

			inputField.text = "";

			if (palabra.Contains (letra.ToString())) {
				string palabraTemporal = "";
				for (int i = 0; i < palabra.Length; i++) {
					if (palabra [i] == letra) {
						palabraTemporal += letra;
					} else {
						palabraTemporal += palabraEscondida [i];
					}
				}
				palabraEscondida = palabraTemporal;
				outputText.text = palabraEscondida;

				if(!palabraEscondida.Contains("*")){
					Debug.Log ("WIN");

				}
			}
		}

	}
}
