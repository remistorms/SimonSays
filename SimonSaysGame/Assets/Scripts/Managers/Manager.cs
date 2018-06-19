using UnityEngine;
using System.Collections;

public abstract class Manager : MonoBehaviour {

	public virtual void Initialize()
	{
		Debug.Log ("This is a Manager Specific Class");
	}

}
