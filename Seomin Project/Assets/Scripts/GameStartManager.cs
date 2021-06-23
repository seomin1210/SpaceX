using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
