using UnityEngine;
using UnityEngine.Tilemaps;

public class Global : MonoBehaviour
{
    private static Tilemap _maze;

    public static Tilemap Maze
    {
        get { return _maze; }
    }
    private void Start()
    {
        _maze = FindObjectOfType<Tilemap>();
    }
}

