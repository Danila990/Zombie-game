using UnityEngine;

public class EnemyStateMashine : MonoBehaviour
{
    [SerializeField] private EnemyState[] _states;
    [SerializeField] private Player _player;

    private int _currentState = 0;

    private void Start() => ChangeState();


    public void Init(Player player)
    {
        _player = player;
    }

    public void TransitToNext()
    {
        _currentState++;
        if (_currentState > _states.Length)
            _currentState = _states.Length;
        ChangeState();
    }

    public void TransitToPrevious()
    {
        _currentState--;
        if (_currentState < 0)
            _currentState = 0;
        ChangeState();
    }

    private void ChangeState()
    {
        foreach (var state in _states)
            state.enabled = false;

        _states[_currentState].Enter(_player, this);
        _states[_currentState].enabled = true;
    }
}