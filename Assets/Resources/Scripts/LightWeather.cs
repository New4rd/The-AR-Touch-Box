using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWeather : MonoBehaviour
{

    private Light lightComp;

    private void Awake()
    {
        lightComp = GetComponent<Light>();
    }


    private IEnumerator Start()
    {
        yield return new WaitUntil(() => WeatherManager.Inst.gotDatas);

        switch (WeatherManager.Inst.mainWeather) {
            case "Clear": lightComp.color = new Color(0.8962264f, 0.7974874f, 0.2409665f); break;
            case "Clouds": lightComp.color = new Color(0.745283f, 0.745283f, 0.745283f); break;
            case "Snow": lightComp.color = new Color(1f, 1f, 1f); break;
            case "Rain": lightComp.color = new Color(0.3207547f, 0.3207547f, 0.3207547f); break;
        }
    }
}
