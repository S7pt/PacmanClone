using UnityEngine;

public class Blinky : Ghost
{
    private void Start()
    {
        _movePoint.parent = null;
        SetState(new BlinkyChaseState(this));
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, _movePoint.position) <= 0.15f)
        {
            Movement.Move(PathFinding.FindTheShortestPath(this), _movePoint);
        }
        transform.position = Vector3.MoveTowards(transform.position, _movePoint.position, 3*Time.deltaTime);
    }
}

