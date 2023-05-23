using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerController playerScript;
    public Transform startingPoint;
    public float lerpSpeed;
    public List<GameObject> characters;
    private int index;
    public List<MonoBehaviour> scripts;
    public List<Component> scr2;

    private BlackFarmerMan bfm;
    private BrownFarmerWoman bfw;
    private WhiteBusinessMan wbm;
    private WhiteWaitressWoman www;

    private Vector3 startPos;
    public Button backButton;


    // Start is called before the first frame update
    void Start()
    {
        index = MainManager.Instance.index;
        //Instantiate(characters[index], new Vector3(-5, 0, 0), transform.rotation);
        Debug.Log("index in game manager: " + index);
        // set the chosen character active
        characters[index].SetActive(true);

        if (MainManager.Instance.index == 0)
        {
            bfm = GameObject.Find("Player" + MainManager.Instance.index).GetComponent<BlackFarmerMan>();
            bfm.gameOver = true;
            startPos = bfm.transform.position;
        }
        else if (MainManager.Instance.index == 1)
        {
            bfw = GameObject.Find("Player" + MainManager.Instance.index).GetComponent<BrownFarmerWoman>();
            bfw.gameOver = true;
            startPos = bfw.transform.position;
        }
        else if (MainManager.Instance.index == 2)
        {
            wbm = GameObject.Find("Player" + MainManager.Instance.index).GetComponent<WhiteBusinessMan>();
            wbm.gameOver = true;
            startPos = wbm.transform.position;
        }
        else if (MainManager.Instance.index == 3)
        {
            www = GameObject.Find("Player" + MainManager.Instance.index).GetComponent<WhiteWaitressWoman>();
            www.gameOver = true;
            startPos = www.transform.position;
        }
        else
        {
            Debug.Log("index of main manager is out of bound");
        }
        StartCoroutine(PlayIntro());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayIntro()
    {
        //Vector3 startPos = playerScript.transform.position;
        Vector3 endPos = startingPoint.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;
        if (bfm != null)
        {
            bfm.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);
        }
        else if (bfw != null)
        {
            bfw.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);
        }
        else if (wbm != null)
        {
            wbm.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);
        }
        else if (www != null)
        {
            www.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);
        }

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            if (bfm != null)
            {
                bfm.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);

            }
            else if (bfw != null)
            {
                bfw.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);

            }
            else if (wbm != null)
            {
                wbm.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);

            }
            else if (www != null)
            {
                www.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);

            }
            yield return null;
        }

        if (bfm != null)
        {
            bfm.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);
            bfm.gameOver = false;
        }
        else if (bfw != null)
        {
            bfw.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);
            bfw.gameOver = false;
        }
        else if (wbm != null)
        {
            wbm.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);
            wbm.gameOver = false;
        }
        else if (www != null)
        {
            www.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);
            www.gameOver = false;
        }
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
