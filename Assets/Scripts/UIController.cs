using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text dayText;
    [SerializeField]
    private Text cityText;
    [SerializeField]
    private City city;

    private void Start()
    {
        city = GetComponent<City>();
    }

    public void UpdateCityData()
    {
        cityText.text = string.Format("Cash: ${0}\nJobs: {1}/{2}\nPop: {3}/{4}\nFood: {5}",
            city.Cash, city.JobsCurrent, city.JobsCeiling, 
            (int)city.PopulationCurrent, 
            (int)city.PopulationCeiling, (int)city.Food);
    }

    public void UpdateDayCount()
    {
        dayText.text = string.Format("Day: {0}", city.Day.ToString());
    }
}
