using UnityEngine;

public class BlinkyChaseState : GhostState
{
    private Blinky _context;

    public BlinkyChaseState(Blinky context) {
        _context = context;
    }

    public Vector3 GetCurrentTarget()
    {
        return Global.Pacman.transform.position;
    }
}

