using System;
using Pathfinding;

public class AIPatrolPath : AIPath
{
    public Action TargetReached;

    public override void OnTargetReached()
    {
        base.OnTargetReached();
        DispatchTargetReached();
    }

    protected virtual void DispatchTargetReached()
    {
        TargetReached?.Invoke();
    }
}
