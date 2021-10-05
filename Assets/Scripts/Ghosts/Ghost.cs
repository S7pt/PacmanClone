using System.Collections.Generic;
using UnityEngine;

public abstract class Ghost : MonoBehaviour
{
    [SerializeField]
    protected GhostState _currentState;
    [SerializeField]
    protected float _aliveSpeed=0.7f;
    [SerializeField]
    protected float _deadSpeed=3;
    [SerializeField]
    protected Transform _movePoint;
    [SerializeField]
    protected Transform _scatterTarget;
    [SerializeField]
    protected Transform _pacmanPosition;
    [SerializeField]
    protected Animator _movementAnimator;

    protected Vector3 _currentMovement;

    public Vector3 CurrentMovement
    {
        get
        {
            return _currentMovement;
        }
    }
    public Vector3 GetCurrentTarget()
    {
       return _currentState.GetCurrentTarget();
    }
    protected void SetState(GhostState state)
    {
        _currentState = state;
    }

    private void Start()
    {
        _movePoint.parent = null;
        SetChaseState();
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, _movePoint.position) <= 0.1f)
        {
            _currentMovement = PathFinding.FindTheShortestPath(this);
            Movement.Move(_currentMovement, _movePoint);
        }
        _movementAnimator.SetFloat("MoveX", _currentMovement.x);
        _movementAnimator.SetFloat("MoveY", _currentMovement.y);

        transform.position = Vector3.MoveTowards(transform.position, _movePoint.position, 3 * Time.deltaTime);
    }

    public abstract void SetChaseState();
    public abstract void SetScatterState();
    public abstract void SetFrightenedState();
    public abstract void SetDeadState();
}

