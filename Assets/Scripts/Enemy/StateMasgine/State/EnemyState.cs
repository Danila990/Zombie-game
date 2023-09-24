using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    protected Player _player;
    protected EnemyStateMashine _stateMashine;

    public void Enter(Player target, EnemyStateMashine stateMashine)
    {
        _player = target;
        _stateMashine = stateMashine;
    }

    public abstract void Exit();
}