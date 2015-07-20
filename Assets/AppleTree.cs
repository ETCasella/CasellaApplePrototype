using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	//a prefab for instantiating Apples
	public GameObject applePrefab;
	//speed at which the AppleTree moves in m/s
	public float speed = 1f;
	//distance where the AppleTree turns around
	public float leftAndRightEdge = 10f;
	//chance the AppleTree will change directions randomly 
	public float chanceToChangeDirections = 0.1f;
	//rate at which Apples will be created
	public float secondsBetweenAppleDrops = 1f;

	// Use this for initialization
	void Start () {
		//Dropping Apples every second
		//InvokeRepeating calls another function by name (first parameter)
		//on a repeating basis. The second argument - 2f - tells it to wait 
		//2seconds before it calls DropApple the first time. The third argument
		//tells it how often to repeat after that.
		InvokeRepeating ("DropApple", 2f, secondsBetweenAppleDrops);
	}

	void DropApple(){
		//instantiate (create) a version of the applePRefab
		//and store in as a ganme object
		GameObject apple = Instantiate (applePrefab) as GameObject;
		//set the apple's position to be the same as the tree's position
		apple.transform.position = transform.position;
	
	
	}
	
	// Update is called once per frame
	void Update () {
		//Basic Movement
		//store the object's position in a vector
		Vector3 pos = transform.position;
		//to the x component of this vector, add the speed
		//multiplied by the time between frames (so as we 
		//add up all the frames in a second, we get exactly 1 m/s
		pos.x += speed * Time.deltaTime;
		//now set the position of the object to be this vector
		//this will get modified every frame
		transform.position = pos;
		//CHANGING DIRECTION
		if (pos.x < -leftAndRightEdge) {// if the position hits the left edge
			speed = Mathf.Abs (speed); //MOVE RIGHT
		} else if (pos.x > leftAndRightEdge) {//if the position hits the right edge
			speed = -Mathf.Abs (speed);//MOVE LEFT
		}
	}
	
	 void FixedUpdate(){
			//FixedUpdate runs at 50Hz, so it dosent depend on the 
			//speed of the user's computer.Placing the random direction
			//change in Update would make it computer-dependent.We
			//dont want that .
			//RAndom Direction Change
			if (Random.value < chanceToChangeDirections) {
				speed *= -1;//Change Direction
			}
		}
}