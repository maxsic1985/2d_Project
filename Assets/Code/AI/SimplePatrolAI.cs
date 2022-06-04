using UnityEngine;

public class SimplePatrolAI
{
    private readonly EnemyProvider _view;
    private readonly SimplePatrolAIModel _model;

    public SimplePatrolAI(EnemyProvider view, SimplePatrolAIModel model)
    {
        _view = view;
        _model = model;
    }
    public void FixedUpdate()
    {
        _view.Rigidbody.velocity = _model.CalculateVelocity(_view.transform.position) * Time.fixedDeltaTime;
    }
}
