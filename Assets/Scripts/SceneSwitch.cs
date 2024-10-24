using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SellOut()
    {
        SceneManager.LoadScene("SellOut");
    }

    public void Success()
    {
        SceneManager.LoadScene("Success");
    }
}
