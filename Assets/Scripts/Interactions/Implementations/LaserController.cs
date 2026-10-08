using UnityEngine;

public class LaserController : MonoBehaviour
{


    private Vector3 laserDirection;
    public int incomingLasers = 0;
    public bool canShootLaser
    {
        get { return isLaserOrigin || incomingLasers > 0; }
    }
    public bool isLaserOrigin;
    private LaserController otherLaser;

    [SerializeField] Transform laserPointer;

    // Update is called once per frame
    void Update()
    {
        laserDirection = laserPointer.forward;
        if (canShootLaser)
        { ThrowRay(); }
        else
        {
            if (otherLaser != null)
            {
                otherLaser.incomingLasers--;
                otherLaser = null;
            }
        }
        if (otherLaser!= null)
        {
            Debug.DrawLine(transform.position, otherLaser.transform.position);
        }
    }


    void ThrowRay()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, laserDirection * 2, Color.red);

        LaserController currentAimedLaser = null;

        if (Physics.Raycast(transform.position, laserDirection, out hit))
        {
            hit.transform.TryGetComponent<LaserController>(out currentAimedLaser);

        }

        if (currentAimedLaser != otherLaser)
        {
            if (otherLaser != null)
            {
                otherLaser.incomingLasers--;
            }
            if (currentAimedLaser != null)
            {
                currentAimedLaser.incomingLasers++;
            }
            otherLaser = currentAimedLaser;

        }






    }
}
