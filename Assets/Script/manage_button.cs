using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class manage_button : MonoBehaviour
{
    // Start is called before the first frame update
    public Button playagain;
    void Start()
    {
        playagain.onClick.AddListener(RetryGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetryGame()
    {
        // Làm lại game (Ví dụ: load lại scene hiện tại)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
