using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/********************************************
 * ZoomInAnimator is the component of the portal ring.
 * 
 * Naty Kozelkova
 * February 07, 2024 Version 1.0
 *******************************************/

public class ZoomInAnimator : MonoBehaviour
{
    private Vector3 desiredScale;
    private Vector3 initialScale = Vector3.one.normalized;
    private float zoomInRate = 1.06f;
    private float zoomInFrequency = 0.03f;

    // Store the desired scale, set the initial scale then call the zoom in method.
    private void OnEnable()
    {
        desiredScale = transform.localScale;
        transform.localScale = initialScale;
        InvokeRepeating("ZoomIn", 0, zoomInFrequency);
    }


    private void OnDisable()
    {
        transform.localScale = desiredScale;
    }

    // Slowly growing the scale from initial to desired.
    private void ZoomIn()
    {
        if (transform.localScale.magnitude < desiredScale.magnitude)
        {
            transform.localScale *= zoomInRate;
        }
        else
        {
            CancelInvoke();
        }
    }

}
