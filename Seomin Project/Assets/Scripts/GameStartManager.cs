using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnClickHowtoPlay()
    {
        gameObject.SetActive(true);

    }
    public void OnClickHowtoPlayText()
    {
        gameObject.SetActive(false);
    }
}
