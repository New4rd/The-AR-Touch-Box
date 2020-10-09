using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [Header("Rotating Object")]
    public bool rotating;

    /// <summary>
    /// Vitesse de rotation de l'object
    /// </summary>
    public float rotatingSpeed;

    [Header("Bouncing Object")]
    public bool bouncing;
    /// <summary>
    /// Hauteur maximale atteinte pendant le rebond
    /// </summary>
    public float topYThreshold;

    /// <summary>
    /// Haute minimale atteinte pendant le rebond
    /// </summary>
    public float bottomYThreshold;

    /// <summary>
    /// Vitesse de rebond
    /// </summary>
    public float floatingSpeed;

    /// <summary>
    /// True: l'objet monte. False: l'objet descend
    /// </summary>
    private bool upBouncing = false;

    void Update()
    {
        if (bouncing)
        {
            if (transform.position.y < bottomYThreshold || transform.position.y > topYThreshold)
            {
                upBouncing = !upBouncing;
            }

            if (upBouncing)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + (floatingSpeed / 10000) * Time.deltaTime, transform.position.z);
            }

            if (!upBouncing)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - (floatingSpeed / 10000) * Time.deltaTime, transform.position.z);
            }
        }
        
        if (rotating)
        {
            transform.Rotate(0, rotatingSpeed, 0);
        }
    }
}
