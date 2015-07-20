using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GUIText scoreGT;

	void Start(){
		GameObject scoreGO = GameObject.Find ("ScoreCounter");
		scoreGT = scoreGO.GetComponent<GUIText> ();
		scoreGT.text = "0";
	}

	// Update is called once per frame
	void Update () {
		//get the current screen postion of the mouse from Input
		//Input.mousPosition gets assigned to a new Vector3 mousPos2D every frame
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	
	}
void OnCollisionEnter(Collision Coll){
		//grab the thing we collided with
		GameObject collidedWith = Coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
		}

		int score = int.Parse (scoreGT.text);
		score += 100;
		scoreGT.text = score.ToString ();
		if (score > HighScore.score) {
			HighScore.score = score;
		}
	}
}