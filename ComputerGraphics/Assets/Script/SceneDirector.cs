using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainSceneChange() //메인Scene으로 이동
    {
        SceneManager.LoadScene("GameScene"); 
    }
    public void PassportSceneChange() //여권Scene으로 이동
    {
        SceneManager.LoadScene("PassportScene"); 
    }
    
    //USA게임
    public void USAstartSceneChange() //USA 게임시작 Scene으로 이동
    {
        SceneManager.LoadScene("USAstartScene"); 
    }
    public void USAgameSceneChange() //USA 게임 Scene으로 이동
    {
        SceneManager.LoadScene("USAGameScene");
    }
    public void ParisstartSceneChange() //Paris 게임시작 Scene으로 이동
    {
        SceneManager.LoadScene("ParisStartScene");
    }
    public void ParisgameSceneChange() //Paris 게임시작 Scene으로 이동
    {
        SceneManager.LoadScene("ParisGameScene");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
