using UnityEngine;
using System.Collections;

public class CameraFrustrum : MonoBehaviour
{

	private bool currentlyTriggered = false;
	private string triggerTag = "Player";
	[SerializeField]
	private Color red;
	[SerializeField]
	private Color green;

	private Renderer coneRenderer;

	void Awake()
	{
		Renderer[] childObjects = gameObject.GetComponentsInChildren<Renderer>();
		foreach (Renderer go in childObjects)
		{
			coneRenderer = go;
		}

		coneRenderer.material.color = red;

	}


    void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(triggerTag))
		{
			coneRenderer.material.color = green;
			currentlyTriggered = true;
		}

	}

	void OnTriggerStay(Collider other)
	{

		if (other.CompareTag(triggerTag))
		{
			coneRenderer.material.color = green;
			currentlyTriggered = true;
		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag(triggerTag))
		{
			coneRenderer.material.color = red;
			currentlyTriggered = false;
		}

	}

	public bool isTriggered()
	{
		return currentlyTriggered;
	}

	public void setTriggerTag(string newTriggerTag)
	{
		triggerTag = newTriggerTag;
	}


}
