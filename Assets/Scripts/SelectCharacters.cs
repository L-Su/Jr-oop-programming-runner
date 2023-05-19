using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SelectCharacters : MonoBehaviour
{
    public List<GameObject> characters;

    private int index = 0;

    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // right arrow to increase index
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (index + 1 < characters.Count)
            {
                characters[index].SetActive(false);
                index++;
                characters[index].SetActive(true);
            }
            // exceed the length of list => return to index 0
            else
            {
                characters[index].SetActive(false);
                index = 0;
                characters[index].SetActive(true);
            }
        }
        // left arrow to decrease index
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (index - 1 >= 0)
            {
                characters[index].SetActive(false);
                index--;
                characters[index].SetActive(true);
            }
            // out of index => set index to list size - 1
            else
            {
                characters[index].SetActive(false);
                index = characters.Count - 1;
                characters[index].SetActive(true);
            }
        }


    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        if (MainManager.Instance != null)
        {
            MainManager.Instance.index = index;
            Debug.Log("index in main manager: "+index);

        }
    }

}
