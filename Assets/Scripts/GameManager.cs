using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController playerScript;
    public Transform startingPoint;
    public float lerpSpeed;
    public List<GameObject> characters;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = MainManager.Instance.index;
        Instantiate(characters[index], new Vector3(-5, 0, 0), transform.rotation);
        Debug.Log("index in game manager: " + index);
        playerScript = GameObject.Find("Player"+index).GetComponent<PlayerController>();
        playerScript.gameOver = true;
        StartCoroutine(PlayIntro());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerScript.transform.position;
        Vector3 endPos = startingPoint.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;

        playerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            playerScript.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }

        playerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
        playerScript.gameOver = false;
    }
}
