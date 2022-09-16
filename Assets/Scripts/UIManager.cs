using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameClearPanel;
    private bool gameOverPanelFlag = false;
    private bool gameClearPanelFlag = false;

    public void ChangeGameOverPanel()
    {
        gameOverPanelFlag = !gameOverPanelFlag;
        gameOverPanel.SetActive(gameOverPanelFlag);
    }

    public void ChangeGameClearPanel()
    {
        gameClearPanelFlag = !gameClearPanelFlag;
        gameClearPanel.SetActive(gameClearPanelFlag);
    }

    public void ReloadScene()
    {
        Debug.Log("Reload");
        SceneManager.LoadScene("SampleScene");
    }
}