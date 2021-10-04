using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFund : MonoBehaviour
{
    public Text totalTime;
    public Image background;
    private bool isShown = false;
    private float transition = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShown)
            return;
        transition += Time.deltaTime;
        background.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
    }

    public void displayMainMenu(float piket)
    {
        totalTime.text = "Total time: " + ((int)piket).ToString();
        gameObject.SetActive(true);
        isShown = true;
    }

    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}

