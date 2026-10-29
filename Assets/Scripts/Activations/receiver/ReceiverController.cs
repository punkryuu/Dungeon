using UnityEngine;
[RequireComponent(typeof(Collider))]
public class ReceiverController : ActivatorBase, ILaserReceiver
{
    public int incomingLasers = 0;
    float tiempo = 0;
    void Update() 
    {
        if (incomingLasers > 0)
        { 
            tiempo += Time.deltaTime;
            if (tiempo > 0.5f && !_isActivated )
            {
                _isActivated = true;
                ActivateObjects(_isActivated);
            }
        }
        else if(_isActivated)
        {
            tiempo = 0;
            _isActivated = false;
            ActivateObjects(_isActivated);

        }
    }
    public void AddLaser()
    {
        incomingLasers++;
    }
    public void SubstractLaser()
    {
        incomingLasers--;
    }
}
