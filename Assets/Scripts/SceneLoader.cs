using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void SceneTransition(int num)
    {
        if (num == 0) SceneManager.LoadScene("SampleScene");
        if (num == 1) SceneManager.LoadScene("Title");
    }
}
