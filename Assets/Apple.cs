using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	public static float bottomY = -20f;

	// Update is called once per frame
	void Update () {
		//if this apples y coordinate is less than bottomY
		if (transform.position.y < bottomY) {
			//destroy this particular apple
			//this will kill every apple after it has dropped for some time.
			Destroy (this.gameObject);

			ApplePicker apScript = Camera.main.GetComponent<ApplePicker> ();
			apScript.AppleDestroyed ();
		}
	
	}
}
