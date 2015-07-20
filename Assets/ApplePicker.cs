using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplePicker : MonoBehaviour {

	//holder for the basket prefab
	public GameObject basketPrefab;
	//public holder for the number of baskets
	public int numBaskets =3;
	// public holder for the bottom oy corrdinate of the baskets
	public float basketBottomY = -14f;
	//public holder for the y spaci9ng between baskets
	public float basketSpacingY = 2f;
	//a list of baskets
	public List<GameObject> basketList;


	// Use this for initialization
	void Start () {
		basketList = new List<GameObject> ();
		//loop through the number of baskets
		for (int i=0; i<numBaskets; i++) {
			//institiate a basket game object
			GameObject tBasketGO = Instantiate (basketPrefab) as GameObject;
			// instantiate a zero vector (a palceholder for now)
			Vector3 pos = Vector3.zero;
			// set y corrdinate to be basketBottomY plus i * basketSpacingY
			pos.y = basketBottomY + (basketSpacingY * i);
			//set the basket to be at the specfied y postion
			tBasketGO.transform.position = pos;
			basketList.Add (tBasketGO);
		}
	
	}

	public void AppleDestroyed(){
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag ("Apple");
		foreach (GameObject tGO in tAppleArray) {
			Destroy (tGO);
		}
		int basketIndex = basketList.Count - 1;
		GameObject tBasketGO = basketList [basketIndex];
		basketList.RemoveAt (basketIndex);
		Destroy (tBasketGO);

		if (basketList.Count == 0) {
			Application.LoadLevel ("Scene_0");
		}
	
	}
}
