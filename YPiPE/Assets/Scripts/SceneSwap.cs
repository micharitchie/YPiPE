using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
	public string SceneName;

    public void SceneMover()
	{
		SceneManager.LoadScene(SceneName);
	}
}
