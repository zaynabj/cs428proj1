using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class WeatherAPIScript : MonoBehaviour
{
    public GameObject weatherTextObject;
    public GameObject TemperatureTextObject;
    public GameObject HumidityTextObject;
    public GameObject WindSpeedTextObject;
    string url = "http://api.openweathermap.org/data/2.5/weather?q=Chicago&APPID=556b8026b9546d89209a4933242e909b&units=imperial";

   
    void Start()
    {

    // wait a couple seconds to start and then refresh every 900 seconds

       Debug.Log("I am alive!");
       InvokeRepeating("GetDataFromWeb", 2f, 900f);
   }

   void GetDataFromWeb()
   {

       StartCoroutine(GetRequest(url));
   }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                // print out the weather data to make sure it makes sense
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                string weatherInfo = webRequest.downloadHandler.text;

                //Set Temperature Game Object
                int temp = weatherInfo.IndexOf("temp") + "temp::".Length;
                Debug.Log(":\n index of temp: " + temp);
                string temperature = weatherInfo.Substring(temp, 2);
                Debug.Log(temperature);
                TemperatureTextObject.GetComponent<TextMeshPro>().text = temperature;

                //Set Humidity Game Object
                int humid = weatherInfo.IndexOf("humidity") + "humidity::".Length;
                Debug.Log(":\n index of humidity: " + humid);
                string humidity = weatherInfo.Substring(humid, 2);
                Debug.Log(humidity);
                HumidityTextObject.GetComponent<TextMeshPro>().text = "Humidity: " + humidity + "%";

                //Set Wind Speed Game Object
                int speed = weatherInfo.IndexOf("speed") + "speed::".Length;
                Debug.Log(":\n index of speed: " + speed);
                string windSpeed = weatherInfo.Substring(speed, 4);
                Debug.Log(windSpeed);
                WindSpeedTextObject.GetComponent<TextMeshPro>().text = "Wind Speed: " + windSpeed + "mph";


                //Set Wind Direction Game Object

            }
        }
    }
}
