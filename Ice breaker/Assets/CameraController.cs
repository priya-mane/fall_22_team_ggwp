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

	//Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;


    private void Update()
    {
        //Room camera
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

		//Follow player
		if (player.position.x <= previousRoom.position.x)
		{
			// in room 1
			transform.position = new Vector3(Mathf.Max(transform.position.x, player.position.x+lookAhead), transform.position.y, transform.position.z);
		}
		else
		{
			transform.position = new Vector3(Mathf.Min(transform.position.x, player.position.x+lookAhead), transform.position.y, transform.position.z);
		}
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x+3.5f;
    } 
}
