using System.Collections.Generic;
using UnityEngine;

static class PathFinding
{
    public static Vector3 FindTheShortestPath(Ghost ghost)
    {
        Queue<Vector3> possibleWays = new Queue<Vector3>(4);
        float lowestSquareMagnitude;
        float currentSquareMagnitude;
        Vector3 currentMinimalPath;
        possibleWays = CheckAllPossibleWays(ghost);
        if (possibleWays.Count < 2 && possibleWays.Peek() == ghost.CurrentMovement)
        {
            return ghost.CurrentMovement;
        }
        currentMinimalPath = possibleWays.Peek();
        lowestSquareMagnitude = Vector3.SqrMagnitude(ghost.GetCurrentTarget() - (ghost.transform.position + possibleWays.Dequeue()));
        while (possibleWays.Count != 0)
        {
            currentSquareMagnitude = Vector3.SqrMagnitude(ghost.GetCurrentTarget() - (ghost.transform.position + possibleWays.Peek()));
            if (currentSquareMagnitude < lowestSquareMagnitude)
            {
                lowestSquareMagnitude = currentSquareMagnitude;
                currentMinimalPath = possibleWays.Dequeue();
            }
            else
            {
                possibleWays.Dequeue();
            }
        }
  
        return currentMinimalPath;
    }
    private static Queue<Vector3> CheckAllPossibleWays(Ghost ghost) {
        Queue<Vector3> directions = new Queue<Vector3>();
        if (!ColliderCheck.CheckForWall(ghost.transform.position, Vector3.down, Global.Maze) && ghost.CurrentMovement != Vector3.up)
        {
            directions.Enqueue(Vector3.down);
        }
        if (!ColliderCheck.CheckForWall(ghost.transform.position, Vector3.up, Global.Maze) && ghost.CurrentMovement != Vector3.down)
        {
            directions.Enqueue(Vector3.up);
        }
        if (!ColliderCheck.CheckForWall(ghost.transform.position, Vector3.right, Global.Maze) && ghost.CurrentMovement != Vector3.left)
        {
            directions.Enqueue(Vector3.right);
        }
        if (!ColliderCheck.CheckForWall(ghost.transform.position, Vector3.left, Global.Maze) && ghost.CurrentMovement != Vector3.right)
        {
            directions.Enqueue(Vector3.left);
        }
        return directions;
    }
}

