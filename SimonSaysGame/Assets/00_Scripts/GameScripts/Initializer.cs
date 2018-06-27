using UnityEngine;
using System.Collections;

public class Initializer : MonoBehaviour {

	
	public Manager_Event manager_event_ref;
	public Manager_Sound manager_sound_ref;

	// Use this for initialization
	void Awake () 
	{
		manager_event_ref.Initialize ();
		manager_sound_ref.Initialize ();
	}

}
