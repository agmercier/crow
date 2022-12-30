using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void playLvL1()
    {
        SceneManager.LoadScene(1);
    }
    public void playLvL2()
    {
        SceneManager.LoadScene(2);
    }
}
