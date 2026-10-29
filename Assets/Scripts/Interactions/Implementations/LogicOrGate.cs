using UnityEngine;

public class LogicOrGate : ActivatorBase, IActivable {
    private int _activeSignals = 0;

    public void Activate(bool activate)
    {
        if (activate)
        {
            _activeSignals++;
        }
        else
        {
            _activeSignals--;
        }

        if (_activeSignals < 0) _activeSignals = 0;

        bool shouldBeActivated = _activeSignals > 0;

        if (shouldBeActivated != _isActivated)
        {
            _isActivated = shouldBeActivated;
            ActivateObjects(_isActivated);
        }
    }
}