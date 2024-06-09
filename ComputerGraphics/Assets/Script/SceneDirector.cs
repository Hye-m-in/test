using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainSceneChange() //����Scene���� �̵�
    {
        SceneManager.LoadScene("GameScene"); 
    }
    public void PassportSceneChange() //����Scene���� �̵�
    {
        SceneManager.LoadScene("PassportScene"); 
    }
    
    //USA����
    public void USAstartSceneChange() //USA ���ӽ��� Scene���� �̵�
    {
        SceneManager.LoadScene("USAstartScene"); 
    }
    public void USAgameSceneChange() //USA ���� Scene���� �̵�
    {
        SceneManager.LoadScene("USAGameScene");
    }
    public void ParisstartSceneChange() //Paris ���ӽ��� Scene���� �̵�
    {
        SceneManager.LoadScene("ParisStartScene");
    }
    public void ParisgameSceneChange() //Paris ���ӽ��� Scene���� �̵�
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