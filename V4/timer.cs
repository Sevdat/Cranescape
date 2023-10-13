using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    public TMP_Text time;
    public static float timeCount = 0; 
    string text = "";
    string record = "";
    public static string thanks = "";
    public static bool boxOut = false;
    public static float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        time.text = timeCount.ToString("0.00");
        if (PlayerPrefs.HasKey("record")){
        string currentPrefs = PlayerPrefs.GetString("record");
        if (float.Parse(currentPrefs) < 8.32f) record = currentPrefs; else record = "8.32";
        } else record = "8.32";
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        text = $"Record: {record} \n {timeCount.ToString("0.00")} \n {thanks}";
        if (thanks != "" && timeCount - currentTime > 3f) thanks = "";
        time.text = text;
        if (boxOut == true) {
            if (record == "") {
                PlayerPrefs.SetString("record", $"{timeCount.ToString("0.00")}");
                record = timeCount.ToString("0.00");
                } else if (float.Parse(record) > timeCount) {
                PlayerPrefs.DeleteKey("record");
                PlayerPrefs.SetString("record", $"{timeCount.ToString("0.00")}");
                record = timeCount.ToString("0.00");
                };
                print(record);
            timeCount = 0;
            boxOut = false;
            }
    }
}
