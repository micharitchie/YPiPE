using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script can be deleted
public class SceneSwap : MonoBehaviour
{
	public string SceneName;

    public void SceneMover()
	{
		SceneManager.LoadScene(SceneName);
	}
}
