using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Animator _pacmanAnimator;
    [SerializeField]
    private Transform _movePoint;
    [SerializeField]
    private Tilemap _maze;
    [SerializeField]
    private float _speed;

    private Vector3 _movementVector;
    private Vector2 _inputVector;
    private float movementSmoothing;
    
    void Start()
    {
        _movePoint.parent = null;
        movementSmoothing = _speed * Time.deltaTime;
    }

    void Update()
    {
        _inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Vector3.Distance(transform.position, _movePoint.position) <= 0.15f)
        {
            if (_inputVector.x != 0f && !ColliderCheck.CheckForWall(_movePoint.position, new Vector3(_inputVector.x,0,0), _maze))
            {
                _movementVector = new Vector3(_inputVector.x, 0, 0);
                _pacmanAnimator.SetFloat("MoveY", 0);
                _pacmanAnimator.SetFloat("MoveX", _inputVector.x);
            }
            else if (_inputVector.y != 0f && !ColliderCheck.CheckForWall(_movePoint.position, new Vector3(0, _inputVector.y, 0), _maze))
            {
                _movementVector = new Vector3(0, _inputVector.y, 0);
                _pacmanAnimator.SetFloat("MoveX", 0);
                _pacmanAnimator.SetFloat("MoveY", _inputVector.y);
            }
            Move(_movementVector);
        }
        transform.position = Vector3.MoveTowards(transform.position, _movePoint.position, movementSmoothing);
    }

    private void Move(Vector3 direction)
    {
        if (!ColliderCheck.CheckForWall(_movePoint.position, direction, _maze)){
            _movePoint.position = _movePoint.position + direction;
        }
    }
}
    

