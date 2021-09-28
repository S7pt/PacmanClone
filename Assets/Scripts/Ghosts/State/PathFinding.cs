using System.Collections.Generic;
using UnityEngine;

static class PathFinding
{
    public static Vector3 FindTheShortestPath(Ghost ghost)
    {
        List<Vector3> possibleWays = new List<Vector3>();
        float lowestSquareMagnitude;
        float currentSquareMagnitude;
        Vector3 currentMinimalPath;
        if (!ColliderCheck.CheckForWall(ghost.transform.position, Vector3.right, Global.Maze))
        {
            possibleWays.Add(Vector3.right);
        }
        if(!ColliderCheck.CheckForWall(ghost.transform.position, Vector3.left, Global.Maze))
        {
            possibleWays.Add(Vector3.left);
        }
        if (!ColliderCheck.CheckForWall(ghost.transform.position, Vector3.up, Global.Maze))
        {
            possibleWays.Add(Vector3.up);
        }
        if (!ColliderCheck.CheckForWall(ghost.transform.position, Vector3.down, Global.Maze))
        {
            possibleWays.Add(Vector3.down);
        }
        currentMinimalPath = possibleWays[0];
        lowestSquareMagnitude = Vector3.SqrMagnitude(ghost._pacmanPosition.position-(ghost.gameObject.transform.position + currentMinimalPath));
        for(int i = 1; i < possibleWays.Count; i++)
        {
            currentSquareMagnitude = Vector3.SqrMagnitude(ghost._pacmanPosition.position - (ghost.gameObject.transform.position + possibleWays[i]));
            if (currentSquareMagnitude < lowestSquareMagnitude)
            {
                lowestSquareMagnitude = currentSquareMagnitude;
                currentMinimalPath = possibleWays[i];
            }
        }
        return currentMinimalPath;
    }
}

