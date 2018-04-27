using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

    public BoxMovement player;
    Text debugText;
    public float spacing;
    Transform collection;
    public GameObject weaponPrefab;

	// Use this for initialization
	void Start () {
        debugText = transform.Find("DebugText").GetComponent<Text>();
        collection = transform.Find("WeaponCollection");

        for(int i = 0; i < player.colors.Count; i++)
        {
            Instantiate(weaponPrefab, collection).GetComponent<Image>().color = player.colors[i] ;
            collection.GetChild(i).localPosition = new Vector3(spacing*i, spacing,0);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
