using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Classe permettant de faire clignoter un objet selon un rythme défini par une variable publique
/// </summary>
public class BlinkingObject : MonoBehaviour
{

    // Vitesse de clignotement
    public float blinkTime;

    private bool _blinker;
    public bool blinker
    {
        get { return _blinker; }
        set
        {
            _blinker = value;
            GetComponent<Text>().enabled = value;
        }
    }

    private void Start()
    {
        StartCoroutine(Blinker());
    }


    private IEnumerator Blinker ()
    {
        yield return new WaitForSecondsRealtime(1);
        blinker = !blinker;
        StartCoroutine(Blinker());
    }
}