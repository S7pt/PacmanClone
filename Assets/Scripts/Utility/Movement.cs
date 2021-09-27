using UnityEngine;

class Movement
{
    public static void Move(Vector3 direction,Transform movePoint)
    {
        if (!ColliderCheck.CheckForWall(movePoint.position, direction, Global.Maze))
        {
            movePoint.position = movePoint.position + direction;
        }
    }
}

