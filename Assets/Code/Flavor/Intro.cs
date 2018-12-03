using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Intro : MonoBehaviour 
{

	public TextMeshProUGUI mesh;
	public Animator animator;

	private string[] lines = {"I saw my life branching out before me like the green fig tree in the story.\n",
							"One fig was a husband and a happy home and children,\n",
							" and another fig was a famous poet and another fig was a brilliant professor\n",
							"...I wanted each and every one of them, but choosing one meant losing the rest." +
							"\n~Silvia Plath - The Bell Jar"};

	private string quote;
	private int index = 1;
	public float maxTimer;
	private float timeout;
	bool toAdvance = false;

	public void Start()
	{
		quote = lines[0];
		mesh.SetText(quote);
		timeout = maxTimer;
	}

	public void Update()
	{
		if(Input.anyKeyDown)
		{
			toAdvance = true;
		}

		if(timeout > 0) timeout -=  Time.deltaTime;
		if(timeout <= 0)
		{
			if(toAdvance)
			{
				toAdvance = false;
				if(index < lines.Length)
				{
					quote += lines[index++];
					mesh.SetText(quote);
					timeout = maxTimer;
				}
				else
				{
					animator.Play("FadeIn");
				}
			}
		}
	}

	public void OnWhite()
	{
		mesh.enabled = false;
	}

	public void OnFinished()
	{
		gameObject.SetActive(false);
	}
	
}
