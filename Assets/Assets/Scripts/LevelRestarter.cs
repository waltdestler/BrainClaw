using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestarter : MonoBehaviour
{
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);


		if (Input.GetKeyDown (KeyCode.M)) {
			Application.LoadLevel (Application.loadedLevel+1);
		}
		if (Input.GetKeyDown (KeyCode.N)) {
			Application.LoadLevel (Application.loadedLevel-1);
		}
	}
}