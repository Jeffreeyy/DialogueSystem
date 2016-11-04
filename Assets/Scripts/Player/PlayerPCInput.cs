using UnityEngine;
using System.Collections;

public class PlayerPCInput : MonoBehaviour {

    private PlayerMovement _playerMovement;

    public delegate void InteractAction();
    public static InteractAction OnInteract;
    // Use this for initialization
    void Start ()
    {
        _playerMovement = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Key Down
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            _playerMovement.MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            _playerMovement.MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            _playerMovement.MoveLeft();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _playerMovement.MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(OnInteract != null)
                OnInteract();
        }
        //Key Up
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            _playerMovement.StopMoveUp();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            _playerMovement.StopMoveDown();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            _playerMovement.StopMoveLeft();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            _playerMovement.StopMoveRight();
        }
    }
}
