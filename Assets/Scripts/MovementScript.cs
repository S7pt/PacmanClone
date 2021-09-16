using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private Animator _movement;
    [SerializeField] private float _moveSpeed;
    private Vector3 _movementVector;
    private Vector3 _inputVector;
    void Update()
    {
        _inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (_inputVector.x != 0)
        {
            _movementVector = new Vector2(_inputVector.x, 0);
            _movement.SetFloat("MoveX", _inputVector.x);
            _movement.SetFloat("MoveY", 0);
        }
        else if(_inputVector.y != 0)
        {
            _movementVector = new Vector2(0, _inputVector.y);
            _movement.SetFloat("MoveY", _inputVector.y);
            _movement.SetFloat("MoveX", 0);
        }
        gameObject.transform.position += _movementVector * _moveSpeed * Time.deltaTime;
    }
}
