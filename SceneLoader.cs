using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public string playscene, optionsscene, levelsscene, home;
	
    public void loadplay()
    {
        SceneManager.LoadScene(playscene);
        Debug.Log(playscene);
    }

    public void loadoptions()
    {
        SceneManager.LoadScene(optionsscene);
    }

    public void loadlevels()
    {
        SceneManager.LoadScene(levelsscene);
    }
    public void loadhome()
    {
        SceneManager.LoadScene(home);
    }

}
