using UnityEngine;

public class LaserController : MonoBehaviour, ILaserReceiver
{


    private Vector3 laserDirection;
    public int incomingLasers = 0;
    public bool canShootLaser
    {
        get { return isLaserOrigin || incomingLasers > 0; }
    }
    public bool isLaserOrigin;
    private ILaserReceiver currentTarget;
    private Transform targetTransform;
    public Transform TargetTransform{  get { return targetTransform; } }
    public Vector3 LaserEndPoint { get; private set; }
    private ReceiverController receiver;


    [SerializeField] Transform laserPointer;
    public Transform LaserPointer { get { return laserPointer; } }


    // Update is called once per frame
    void Update()
    {
        laserDirection = laserPointer.forward;
        if (canShootLaser)
        { 
            ThrowRay(); 
        }
        else
        {
            if (currentTarget != null)
            {
                currentTarget.SubstractLaser();
                currentTarget = null;
                targetTransform = null;
            }
 
        }
        if (targetTransform != null)
        {
            //Debug.DrawLine(transform.position, targetTransform.transform.position);
        }
    }


    void ThrowRay()
    {
        RaycastHit hit;

        ILaserReceiver hitReceiver = null;
        Transform hitTransform = null;

        Vector3 rayOrigin = laserPointer.position;
        Vector3 rayDirection = laserPointer.forward;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit))
        {
            LaserEndPoint = hit.point;

            if (hit.transform.TryGetComponent<ILaserReceiver>(out hitReceiver))
            {
                hitTransform = hit.transform;
            }
        }
        else
        {
            LaserEndPoint = rayOrigin + rayDirection * 100f;
        }

        if (hitReceiver != currentTarget)
        {
            if (currentTarget != null)
            {
                currentTarget.SubstractLaser();
            }

            if (hitReceiver != null)
            {
                hitReceiver.AddLaser();
            }

            currentTarget = hitReceiver;
            targetTransform = hitTransform;
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
