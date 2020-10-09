using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherDecorations : MonoBehaviour
{

    private WeatherManager weatherInst = WeatherManager.Inst;
    private RingOfObjects ringScript;


    private void Awake()
    {
        ringScript = GetComponent<RingOfObjects>();
    }


    private IEnumerator Start()
    {
        yield return new WaitUntil(() => weatherInst.gotDatas);

        switch (weatherInst.mainWeather)
        {
            case "Clouds": LoadAndInstanciate("Glasses").transform.parent = this.transform;
                ringScript.objectRing = Resources.Load("Prefabs/Cloud") as GameObject; break;
            case "Clear": LoadAndInstanciate("Mustang").transform.parent = this.transform;
                ringScript.objectRing = Resources.Load("Prefabs/Sun") as GameObject; break;
            case "Rain": LoadAndInstanciate("Umbrella").transform.parent = this.transform;
                ringScript.objectRing = Resources.Load("Prefabs/Rain") as GameObject; break;
            case "Snow": ringScript.objectRing = Resources.Load("Prefabs/Snowflake") as GameObject; break;
        }
        /*
        if (float.Parse(weatherInst.temp) < 10)
        {
            LoadAndInstanciate("Beanie");
        }
        if (float.Parse(weatherInst.temp) > 10)
        {
            // do something
        }*/
    }


    private GameObject LoadAndInstanciate (string objectName)
    {
        GameObject prefab = Resources.Load("Prefabs/" + objectName) as GameObject;
        GameObject obj = Instantiate(prefab, prefab.transform);
        return obj;
    }
}
