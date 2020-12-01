using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameObject gameOverPanel;
    private bool gameOverPanelFlag = false;

    public void ChangeGameOverPanel () {
        gameOverPanelFlag = !gameOverPanelFlag;
        gameOverPanel.SetActive (gameOverPanelFlag);
    }

    public void ReloadScene () {
        Debug.Log ("Reload");
        SceneManager.LoadScene ("SampleScene");
    }
}