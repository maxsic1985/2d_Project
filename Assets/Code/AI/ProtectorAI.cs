using Pathfinding;
using UnityEngine;

public class ProtectorAI : IProtector
{
    private readonly PlayerProvider _playerview;
    private readonly PatrolAIModel _model;
    private readonly AIDestinationSetter _destinationSetter;
    private readonly AIPatrolPath _patrolPath;

    private bool _isPatrolling;

    public ProtectorAI(PlayerProvider view, PatrolAIModel model, AIDestinationSetter destinationSetter, AIPatrolPath patrolPath)
    {
        _playerview = view;
        _model = model;
        _destinationSetter = destinationSetter;
        _patrolPath = patrolPath;
    }

    public void Init()
    {
        _destinationSetter.target = _model.GetNextTarget();
        _isPatrolling = true;
        _patrolPath.TargetReached += OnTargetReached;
    }

    public void Deinit()
    {
        _patrolPath.TargetReached -= OnTargetReached;
    }

    private void OnTargetReached()
    {
        if (_destinationSetter.target == _isPatrolling)
            _model.GetNextTarget();
    }

    public void StartProtection(GameObject invader)
    {
        _isPatrolling = false;
        _destinationSetter.target = invader.transform;
    }

    public void FinishProtection(GameObject invader)
    {
        _isPatrolling = true;
        _destinationSetter.target = _model.GetClosestTarget(_playerview.transform.position);
    }
}
