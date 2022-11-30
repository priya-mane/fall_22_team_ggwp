using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ref : https://github.com/nickbota/Unity-Platformer-Episode-6

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    
	[SerializeField] private float speed;
	private float currentPosX;
	private Vector3 velocity = Vector3.zero;
	[SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;

    public GameObject door;
    //Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Start()
    {
	    
    }
    
    private void Update()
    {
        //Room camera
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

		//Follow player
		if (player.position.x + lookAhead>=0 && player.position.x + lookAhead<Mathf.Abs(nextRoom.position.x))
		{
			transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
		}
		else
		{
			if (player.position.x <= 2 * Mathf.Abs(previousRoom.position.x))
			{
				transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0,
					transform.position.y, transform.position.z), ref velocity, speed);
			}
			else
			{
				transform.position = Vector3.SmoothDamp(transform.position, new Vector3(nextRoom.position.x, transform.position.y,transform.position.z), ref velocity, speed);

			}
		}
		lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
		
		/*
		if (player.position.x <= 2*Mathf.Abs(previousRoom.position.x))
		{
			// in room 1 
			//transform.position = new Vector3(Mathf.Max(transform.position.x, player.position.x + lookAhead),
			//	transform.position.y, transform.position.z);
			Debug.Log("In room 1");
			
			transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Mathf.Max(transform.position.x, player.position.x + lookAhead),
				transform.position.y, transform.position.z), ref velocity, speed);
		}
		else
		{ 
			if ( player.position.x + lookAhead < 3.95+Mathf.Abs(nextRoom.position.x) )
			{
				Debug.Log("player in range for second room");
				//transform.position = new Vector3(nextRoom.position.x, transform.position.y, transform.position.z);
				transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Mathf.Min(nextRoom.position.x, transform.position.x), transform.position.y, transform.position.z), ref velocity, speed);
				
			}
			else
			{
				//transform.position = new Vector3(player.position.x, transform.position.y,transform.position.z);
				transform.position = Vector3.SmoothDamp(transform.position, new Vector3(nextRoom.position.x, transform.position.y,transform.position.z), ref velocity, speed);
			}
			
		}
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        */
        
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x+3.95f;
        // currentPosX = door.transform.position.x;
    } 
}
