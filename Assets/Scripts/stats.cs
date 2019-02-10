using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour {

    public Text t1, t2, t3, t4, t5;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("Won"))
            t1.text = "Games Won: " + PlayerPrefs.GetInt("Won");
        else
            t1.text = "Games Won: 0";

        if (PlayerPrefs.HasKey("TotalMoves"))
            t2.text = "Average Moves: " + (int)PlayerPrefs.GetInt("TotalMoves")/PlayerPrefs.GetInt("Won");
        else
            t2.text = "Average Moves: 0";

        if (PlayerPrefs.HasKey("TotalTime"))
            t3.text = "Average Time: " + gettimefixed(PlayerPrefs.GetFloat("TotalTime") / PlayerPrefs.GetInt("Won"));
        else
            t3.text = "Average Time: 00:00";

        if (PlayerPrefs.HasKey("BestMoves"))
            t4.text = "Best Moves: " + PlayerPrefs.GetInt("BestMoves");
        else
            t4.text = "Best Moves: 0";

        if (PlayerPrefs.HasKey("BestTime"))
            t5.text = "Best Time: " + gettimefixed(PlayerPrefs.GetFloat("BestTime"));
        else
            t5.text = "Best Time: 00:00";

    }

    // Update is called once per frame
    void Update () {
        if (PlayerPrefs.HasKey("Won"))
            t1.text = "Games Won: " + PlayerPrefs.GetInt("Won");
        else
            t1.text = "Games Won: 0";

        if (PlayerPrefs.HasKey("TotalMoves"))
            t2.text = "Average Moves: " + (int)PlayerPrefs.GetInt("TotalMoves") / PlayerPrefs.GetInt("Won");
        else
            t2.text = "Average Moves: 0";

        if (PlayerPrefs.HasKey("TotalTime"))
            t3.text = "Average Time: " + gettimefixed(PlayerPrefs.GetFloat("TotalTime") / PlayerPrefs.GetInt("Won"));
        else
            t3.text = "Average Time: 00:00";

        if (PlayerPrefs.HasKey("BestMoves"))
            t4.text = "Best Moves: " + PlayerPrefs.GetInt("BestMoves");
        else
            t4.text = "Best Moves: 0";

        if (PlayerPrefs.HasKey("BestTime"))
            t5.text = "Best Time: " + gettimefixed(PlayerPrefs.GetFloat("BestTime"));
        else
            t5.text = "Best Time: 00:00";
    }

    public string gettimefixed(float secondsCount)
    {
        int k2 = (int)(secondsCount / 60);
        int k1 = (int)(secondsCount % 60);
        return k2.ToString("00") + ":" + k1.ToString("00");
    }
}
