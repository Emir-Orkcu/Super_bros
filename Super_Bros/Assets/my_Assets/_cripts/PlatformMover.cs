using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour {

	public GameObject platform; 

	public GameObject[] myWaypoints; 

	[Range(0.0f, 10.0f)] 
	public float moveSpeed = 5f; 
	public float waitAtWaypointTime = 1f; 

	public bool loop = true; 

	

	Transform _transform;
	int _myWaypointIndex = 0;		
	float _moveTime;
	bool _moving = true;

	
	void Start () {
		_transform = platform.transform;
		_moveTime = 0f;
		_moving = true;
	}
	
	
	void Update () {
		
		if (Time.time >= _moveTime) {
			Movement();
		}
	}

	void Movement() {
		
		if ((myWaypoints.Length != 0) && (_moving)) {

			
			_transform.position = Vector3.MoveTowards(_transform.position, myWaypoints[_myWaypointIndex].transform.position, moveSpeed * Time.deltaTime);

			
			if(Vector3.Distance(myWaypoints[_myWaypointIndex].transform.position, _transform.position) <= 0) {
				_myWaypointIndex++;
				_moveTime = Time.time + waitAtWaypointTime;
			}
			
			
			if(_myWaypointIndex >= myWaypoints.Length) {
				if (loop)
					_myWaypointIndex = 0;
				else
					_moving = false;
			}
		}
	}
}
