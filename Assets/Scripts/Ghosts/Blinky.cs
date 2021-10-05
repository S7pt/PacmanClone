using UnityEngine;

public class Blinky : Ghost
{
    public override void SetChaseState()
    {
        SetState(new BlinkyChaseState(this));
    }

    public override void SetDeadState()
    {
        throw new System.NotImplementedException();
    }

    public override void SetFrightenedState()
    {
        throw new System.NotImplementedException();
    }

    public override void SetScatterState()
    {
        throw new System.NotImplementedException();
    }
}

