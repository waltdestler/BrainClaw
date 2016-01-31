using UnityEngine;

public class AudioSourceRemover : MonoBehaviour
{
	public void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	public void Update()
	{
		AudioSource audioSource = GetComponent<AudioSource>();
		if (!audioSource.isPlaying)
			Destroy(gameObject);
	}
}