using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(LaserController))]


public class LaserVisuals : MonoBehaviour {
    LaserController laser;
    LineRenderer lineRenderer;
    ParticleSystem laserParticleSystem;
    [SerializeField]Transform laserParticleTransform;
    void Awake()
    {
        laser = GetComponent<LaserController>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);        
        laserParticleSystem = GetComponentInChildren<ParticleSystem>();


    }

    void Update()
    {
        if (laser.canShootLaser && laser.LaserEndPoint != null)
        {
            lineRenderer.enabled = true;

            lineRenderer.SetPosition(0, laser.LaserPointer.position);
            lineRenderer.SetPosition(1, laser.LaserEndPoint);

            if (laserParticleSystem != null)
            {
                if (laserParticleTransform != null)
                {
                    laserParticleTransform.position = laser.LaserEndPoint;
                }

                if (!laserParticleSystem.isPlaying)
                {
                    laserParticleSystem.Play();
                }
            }
        }
        else
        {
            lineRenderer.enabled = false;

            if (laserParticleSystem != null && laserParticleSystem.isPlaying)
            {
                laserParticleSystem.Stop();
            }
        }
    }

}