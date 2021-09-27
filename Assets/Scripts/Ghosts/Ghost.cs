using System.Collections.Generic;
using UnityEngine;

public abstract class Ghost : MonoBehaviour
{
    public GhostState _currentState;
    public float _aliveSpeed=0.7f;
    public float _deadSpeed=3;
    public Transform _movePoint;
    public Transform _scatterTarget;
    public Transform _pacmanPosition;

    public void SetState(GhostState state)
    {
        _currentState = state;
    }

    public void GetCurrentTarget()
    {
        _currentState.GetCurrentTarget();
    }
}

