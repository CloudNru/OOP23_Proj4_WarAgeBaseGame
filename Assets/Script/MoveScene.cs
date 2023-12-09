using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveScene : MonoBehaviour
{
   public void MoveToMain()
    {
        SceneManager.LoadScene("TestSystemScene");
    }
    public void RestartGame()
    {
        // 현재 씬을 다시 로드하여 게임을 재시작
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

}
