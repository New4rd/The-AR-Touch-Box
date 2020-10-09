using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObjectBehavior : MonoBehaviour
{
    private void OnMouseDown()
    {
        gameObject.SetActive(false);
    }
}
