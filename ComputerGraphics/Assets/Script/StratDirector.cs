using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StratDirector : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("GameScene"); //메인Scene으로 이동
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
