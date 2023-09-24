using UnityEngine;

public class EnemyStateMashine : MonoBehaviour
{
    [SerializeField] private EnemyState[] _states;
    [SerializeField] private Player _player;

    private int _currentState = 0;
    private bool _needTransit = false;

    private void Start() => ChangeState(0);

    private void Update()
    {
        if (_needTransit == false)
            return;

        ChangeState(_currentState);
    }

    public void Init(Player player)
    {
        _player = player;
    }

    public void TransitToNext()
    {
        _currentState++;
        if (_currentState > _states.Length)
            _currentState = _states.Length;
        _needTransit = true;

    }

    public void TransitToPrevious()
    {
        _currentState--;
        if (_currentState < 0)
            _currentState = 0;
        _needTransit = true;
    }

    private void ChangeState(int currentState)
    {
        foreach (var state in _states)
        {
            state.enabled = false;
        }

        _states[currentState].enabled = true;
        _states[currentState].Enter(_player, this);
        _needTransit = false;
    }
}