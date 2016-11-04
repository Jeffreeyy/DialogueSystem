using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //Movement speed
    [SerializeField]private float _movementSpeed;
    //Vector2 with the move direction
    private Vector2 _moveDir;
    //Animator to controll the animations
    private Animator _animator;
    //SpriteRenderer to flip the sprite when walking in the other direction
    private SpriteRenderer _renderer;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    //Move up
    public void MoveUp()
    {
        _moveDir += Vector2.up;
    }
    //Move down
    public void MoveDown()
    {
        _moveDir += Vector2.down;
    }
    //Move left
    public void MoveLeft()
    {
        _moveDir += Vector2.left;
        SetLookDir(true);
    }
    //Move right
    public void MoveRight()
    {
        _moveDir += Vector2.right;
        SetLookDir(false);
    }
    //Stop with moving up
    public void StopMoveUp()
    {
        _moveDir -= Vector2.up;
    }
    //Stop with moving down
    public void StopMoveDown()
    {
        _moveDir -= Vector2.down;
    }
    //Stop with moving left
    public void StopMoveLeft()
    {
        _moveDir -= Vector2.left;
    }
    //Stop with moving right
    public void StopMoveRight()
    {
        _moveDir -= Vector2.right;
    }
    //Set the look direction of the sprite
    private void SetLookDir(bool flipX)
    {
        _renderer.flipX = flipX;
    }
    //Set the animation state
    private void SetAnimState(string name,bool walking)
    {
        _animator.SetBool(name, walking);
    }

    void Update()
    {
        //If not moving, set animation to idle, else set animation to walking
        if (_moveDir == Vector2.zero)
            SetAnimState("isWalking", false);
        else
            SetAnimState("isWalking", true);

        //Move the character to the move direction
        transform.Translate(_moveDir * _movementSpeed * Time.deltaTime);
    }
}
