using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestarter : MonoBehaviour
{
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}