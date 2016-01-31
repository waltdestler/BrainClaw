using UnityEngine;

[ExecuteInEditMode]
public class BrainSpriteController : MonoBehaviour
{
	public CharacterBody Body;
	public SpriteRenderer BrainSprite;

	public void Update()
	{
		if (Body != null && BrainSprite != null)
		{
			BrainSprite.enabled = Body.brainBehavior != null;
			if (Body.brainBehavior != null) {
				BrainSprite.color = Body.brainBehavior.brainColor;
				GetComponent<SpriteRenderer> ().enabled = true;
			}
			else {
				GetComponent<SpriteRenderer> ().enabled = false;
			}
		}
	}
}