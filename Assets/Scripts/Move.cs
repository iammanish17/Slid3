using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Move : MonoBehaviour
{
    public float mSpeed = 9f;
    public int r=0;
    private static int moves = 0, z=0, uco = 0;
    private static float secondsCount;
    public GameObject pb, k1, k2;
    public Text moveText, timerText, anotherText, disp1;
    public Transform p1;
    // Use this for initialization
    void Start()
    {
        moves = 0;
        z = 0;
        uco = (int)Time.time;
        moveText.text = "Moves: " + moves.ToString ();
        timerText.text = "";
        anotherText.text = "";
        disp1.text = "";

    }

    void FixedUpdate()
    {
        if (r == 1)
        {
            if (transform.position != p1.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, p1.position, mSpeed * Time.deltaTime);

            }
            else
            {
                r = 0;
                if (Checkwinner())
                {
                    UpdateStats();
                    String rt = timerText.text.Replace("Time: ", "");
                    moveText.text = "";
                    timerText.text = "";
                    z = 1;
                    GameObject[] congo = GameObject.FindGameObjectsWithTag("congo");
                    GameObject con = Instantiate(congo[0], new Vector3((float)-0.002, (float)-0.042, 0), transform.rotation);
                    con.transform.localScale = new Vector3((float)3.683872, (float)3.388171, 1);
                    anotherText.text = "You have successfully completed the level.";
                    disp1.text = "        Time Taken: " + rt + " \n " + " Moves Required: " + moves;
                    GameObject[] pblist = GameObject.FindGameObjectsWithTag("pb");
                    foreach (GameObject pb in pblist)
                    {
                        if (pb.transform.position == new Vector3((float)4.2, (float)-2.3, (float)0))
                            Destroy(pb);
                    }
                    if (CheckForEmpty())
                    {
                        GameObject m1 = Instantiate(k1, new Vector3((float)-4.6, (float)2.3, 0), transform.rotation);
                        GameObject m2 = Instantiate(k2, new Vector3((float)4.3, (float)2.3, 0), transform.rotation);
                        m1.transform.localScale = new Vector3((float)0.15, (float)0.15, 0);
                        m2.transform.localScale = new Vector3((float)0.15, (float)0.15, 0);

                    }
                }
            }
        }
    }

     void Update()
    {
        if (CheckIfEmpty())
        {
            Time.timeScale = 1;
            if (z == 0)
            {
                moveText.text = "Moves: " + moves.ToString();
                secondsCount = Time.time - uco;
                int k2 = (int)(secondsCount / 60);
                int k1 = (int)(secondsCount % 60);
                timerText.text = "Time: " + k2.ToString("00") + ":" + k1.ToString("00");
            }
        }
        else
        {
            Time.timeScale = 0;
            timerText.text = "";
            moveText.text = "";
        }
    }

    void UpdateStats()
    {
        if (PlayerPrefs.HasKey("Won"))
            PlayerPrefs.SetInt("Won", PlayerPrefs.GetInt("Won") + 1);
        else
            PlayerPrefs.SetInt("Won", 1);

        if (PlayerPrefs.HasKey("TotalMoves"))
            PlayerPrefs.SetInt("TotalMoves", PlayerPrefs.GetInt("TotalMoves") + moves);
        else
            PlayerPrefs.SetInt("TotalMoves", moves);

        if (PlayerPrefs.HasKey("TotalTime"))
            PlayerPrefs.SetFloat("TotalTime", PlayerPrefs.GetFloat("TotalTime") + secondsCount);
        else
            PlayerPrefs.SetFloat("TotalTime", secondsCount);

        if (PlayerPrefs.HasKey("BestMoves"))
        {
            if (PlayerPrefs.GetInt("BestMoves") > moves)
            PlayerPrefs.SetInt("BestMoves", moves);
        }
        else
            PlayerPrefs.SetInt("BestMoves", moves);

        if (PlayerPrefs.HasKey("BestTime"))
        {
            if (PlayerPrefs.GetFloat("BestTime") > secondsCount)
                PlayerPrefs.SetFloat("BestTime", secondsCount);
        }
        else
            PlayerPrefs.SetFloat("BestTime", secondsCount);
    }


    void OnMouseDown()
    {
        Transform[] poslist = new Transform[16];
        int k = 0;
        GameObject[] allMovable = GameObject.FindGameObjectsWithTag("invisible");
        foreach (GameObject current in allMovable)
        {
            poslist[k] = current.transform;
           k += 1;
        }
        foreach (Transform p in poslist)
        {
            double d2 = Math.Ceiling(Math.Abs(transform.position.y - p.position.y));
            double d1 = Math.Ceiling(Math.Abs(transform.position.x - p.position.x));
            if ((d1 == 1 && d2 == 0) || (d1 == 0 && d2 == 1))
            {
                if (checkIfPosEmpty(p.position) == true)
                {
                    moves += 1;
                    moveText.text = "Moves: " + moves.ToString();
                    p1 = p;
                    r = 1;
                    break;
                }
            }
        }

    }
    public bool checkIfPosEmpty(Vector3 targetPos)
    {
        GameObject[] allMovableThings = GameObject.FindGameObjectsWithTag("numbers");
        foreach (GameObject current in allMovableThings)
        {
            if (current.transform.position.x == targetPos.x && current.transform.position.y == targetPos.y)
                return false;
        }
        return true;
    }

    public bool Checkwinner()
    {
        int counter = 0;
        GameObject[] allMovableThings = GameObject.FindGameObjectsWithTag("numbers");
        foreach (GameObject current in allMovableThings)
        {
            int num = Int32.Parse(current.name.Replace(" (1)","").Replace("(Clone)",""));
            int r = num % 4;
            double xco = 0.0, yco = 0.0;
            if (r == 0) {
                xco = 1.02;
                yco = 2.35 - 0.96 * (int)(num / 4);
            }
            else {
                xco = 1.02 - 0.96 * (4 - r);
                yco = 1.39 - 0.96 * (int)(num / 4);
            }
            if (Math.Abs(xco - current.transform.position.x) <= 0.05 && Math.Abs(yco - current.transform.position.y) <= 0.05)
            {
                counter += 1;
            }
        }
        if (counter >= 15) return true;
        return false;
    }

    public bool CheckIfEmpty()
    {
        GameObject[] p = GameObject.FindGameObjectsWithTag("paused");
        foreach (GameObject go in p)
        {
            if (go.transform.position == new Vector3((float)-0.384, (float)-0.071, 0))
                return false;
        }
        return true;
    }

    public bool CheckForEmpty()
    {
        GameObject[] p = GameObject.FindGameObjectsWithTag("buttons");
        foreach (GameObject go in p)
        {
            if (go.transform.position == new Vector3((float)-4.6, (float)2.3, 0))
                return false;
        }
        return true;
    }
}

