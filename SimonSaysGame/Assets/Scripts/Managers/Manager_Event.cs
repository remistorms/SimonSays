using UnityEngine;
using System.Collections;
using System;

public class Manager_Event : Manager {

	public static Manager_Event EM;

	public Action EVT_Game_Start;
	public Action EVT_Game_Over;
    public Action EVT_Game_Setup;
    public Action EVT_Presentation_Start;
    public Action EVT_Presentation_Finished;
    public Action<Node> EVT_Node_Pressed;
    public Action<int> EVT_Button_Pushed;
    public Action EVT_Sequence_Completed;
    public Action<int> EVT_Score_Changed;


	// Use this for initialization
	public override void Initialize () 
	{
		EM = this;
	}

    //Better structure
    public void Fire_EVT_Score_Changed(int score)
    {
        if (EVT_Score_Changed != null) EVT_Score_Changed(score);
    }

    public void Fire_EVT_Sequence_Completed(){
        if (EVT_Sequence_Completed!= null) EVT_Sequence_Completed();
    }

    public void Fire_EVT_Node_Pressed(Node node){
        if (EVT_Node_Pressed != null) EVT_Node_Pressed(node);
    }

    public void Fire_EVT_Presentation_Start(){
        if (EVT_Presentation_Start != null) EVT_Presentation_Start();
    }

    public void Fire_EVT_Presentation_Finished(){
        if (EVT_Presentation_Finished != null) EVT_Presentation_Finished();
    }

    public void Fire_EVT_Game_Setup()
    {
        if (EVT_Game_Setup != null)
        {
            EVT_Game_Setup();
        }
    }

    public void Fire_EVT_Game_Start()
	{
		if (EVT_Game_Start != null) 
		{
			EVT_Game_Start ();
		}
	}

	public void Fire_EVT_Game_Over()
	{
		if (EVT_Game_Over != null) 
		{
			//Debug.LogError ("Gave Over Event Has Been Fired");
			EVT_Game_Over ();	
		}
	}

    public void Fire_EVT_Button_Pushed(int buttonID) {
        if (EVT_Button_Pushed != null)
        {
            EVT_Button_Pushed(buttonID);
        }
    }

}
