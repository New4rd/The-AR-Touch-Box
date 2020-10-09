
// Script tiré de la page :
// https://tutorialsforar.com/create-an-ar-weather-app-using-unity-ar-foundation-and-openweathermap/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using SimpleJSON;
public class WeatherManager : MonoBehaviour 
{
    static private WeatherManager _inst;
    static public WeatherManager Inst
    {
        get { return _inst; }
    }

    public string apiKey;
    public string currentWeatherApi = "api.openweathermap.org/data/2.5/weather?";
    [Header("UI")]
    public string statusText;
    public string location;
    public string mainWeather;
    public string description;
    public string temp;
    public string feels_like;
    public string temp_min;
    public string temp_max;
    public string pressure;
    public string humidity;
    public string windspeed;
    private LocationInfo lastLocation;


    public bool gotDatas;

    private void Awake()
    {
        _inst = this;
    }


    void Start()
    {
        StartCoroutine(FetchLocationData());
    }
    
    private IEnumerator FetchLocationData()
    {
        // First, check if user has location service enabled
        //if (!Input.location.isEnabledByUser) yield break;
        // Start service before querying location
        Input.location.Start();
        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1); maxWait--;
        }
        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            statusText = "Location Timed out"; yield break;
        }
        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            statusText = "Unable to determine device location";
            yield break;
        }
        else
        {
            lastLocation = Input.location.lastData;
            UpdateWeatherData();
        }
        Input.location.Stop();
    }
    
    private void UpdateWeatherData()
    {
        StartCoroutine(FetchWeatherDataFromApi(lastLocation.latitude.ToString(), lastLocation.longitude.ToString()));
    }
    
    private IEnumerator FetchWeatherDataFromApi(string latitude, string longitude)
    {
        string url = currentWeatherApi + "lat=" + latitude + "&lon=" + longitude + "&appid=" + apiKey + "&units=metric";
        UnityWebRequest fetchWeatherRequest = UnityWebRequest.Get(url);
        yield return fetchWeatherRequest.SendWebRequest();
        if (fetchWeatherRequest.isNetworkError || fetchWeatherRequest.isHttpError)
        {
            //Check and print error
            statusText = fetchWeatherRequest.error;
        }
        else
        {
            Debug.Log(fetchWeatherRequest.downloadHandler.text);
            var response = JSON.Parse(fetchWeatherRequest.downloadHandler.text);
            location = response["name"];
            mainWeather = response["weather"][0]["main"];
            description = response["weather"][0]["description"];
            temp = response["main"]["temp"] + " C";
            feels_like = "Feels like " + response["main"]["feels_like"] + " C";
            temp_min = "Min is " + response["main"]["temp_min"] + " C";
            temp_max = "Max is " + response["main"]["temp_max"] + " C";
            pressure = "Pressure is " + response["main"]["pressure"] + " Pa";
            humidity = response["main"]["humidity"] + " % Humidity";
            windspeed = "Windspeed is " + response["wind"]["speed"] + " Km/h";
            gotDatas = true;
        }
    }
}