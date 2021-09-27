using UnityEngine;
using UnityEngine.Tilemaps;

public class ColliderCheck
{
    public static bool CheckForWall(Vector3 position, Vector3 direction,Tilemap walls)
    {
        Vector3Int tilePosition = walls.WorldToCell(position);
        Vector3Int moveDirection = new Vector3Int(Mathf.FloorToInt(direction.x), Mathf.FloorToInt(direction.y), Mathf.FloorToInt(direction.z));
        return walls.HasTile(tilePosition + moveDirection);
  
    }
    public static bool CheckForWall(Vector3 position, Tilemap walls)
    {
        Vector3Int tilePosition = walls.WorldToCell(position);
        return walls.HasTile(tilePosition);
    }
}
