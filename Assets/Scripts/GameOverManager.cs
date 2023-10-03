using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private Text textHighScore = null;

    private void Start()
    {
        textHighScore.text = string.Format("HighScore\n{0}", PlayerPrefs.GetInt("HIGHSCORE", 0));
    }
    public void OnClickRetry()
    {
        SceneManager.LoadScene("Main");
    }
}
