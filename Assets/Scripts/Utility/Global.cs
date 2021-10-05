using UnityEngine;
using UnityEngine.Tilemaps;

public class Global : MonoBehaviour
{
    private static Tilemap _maze;
    private static PlayerMovement _pacman;

    public static Tilemap Maze
    {
        get { return _maze; }
    }
    public static PlayerMovement Pacman
    {
        get { return _pacman; }
    }
    private void Start()
    {
        _maze = FindObjectOfType<Tilemap>();
        _pacman = FindObjectOfType<PlayerMovement>();
    }
}

