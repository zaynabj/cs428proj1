using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveCondition : MonoBehaviour
{
    public List <GameObject> conditions = new List<GameObject>();
    public GameObject sunny;
    public GameObject fewClouds;
    public GameObject scatteredClouds;
    public GameObject brokenClouds;
    public GameObject showers;
    public GameObject rain;
    public GameObject thunderstorm;
    public GameObject snow;
    public GameObject mist;
    private int currIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        conditions.Add(sunny);
        conditions.Add(fewClouds);
        conditions.Add(scatteredClouds);
        conditions.Add(brokenClouds);
        conditions.Add(showers);
        conditions.Add(rain);
        conditions.Add(thunderstorm);
        conditions.Add(snow);
        conditions.Add(mist);

        fewClouds.SetActive(false);
        scatteredClouds.SetActive(false);
        brokenClouds.SetActive(false);
        showers.SetActive(false);
        rain.SetActive(false);
        thunderstorm.SetActive(false);
        snow.SetActive(false);
        mist.SetActive(false);
        currIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            conditions[currIndex].SetActive(false);
            if (currIndex > 0){
                currIndex--;
            }
            else{
                currIndex = 8;
            }
            Debug.Log("\ncurrIndex: " + currIndex);
            Debug.Log("\nActive object: " + conditions[currIndex]);
      
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            Debug.Log("Right arrow pressed");
            conditions[currIndex].SetActive(false);
            if (currIndex < 8)
                currIndex++;
            else 
                currIndex = 0;
            //Debug.Log("Curr Index is: " + currIndex);
            Debug.Log("\ncurrIndex: " + currIndex);
            Debug.Log("\nActive object: " + conditions[currIndex]);
        }
        conditions[currIndex].SetActive(true);
        //Debug.Log("\ncurrIndex: " + currIndex);
        //Debug.Log("\nActive object: " + conditions[currIndex]);

    }
}
