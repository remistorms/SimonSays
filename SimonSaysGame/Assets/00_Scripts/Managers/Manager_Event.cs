using UnityEngine;
using System.Collections;
using System;

public class Manager_Event : Manager {

	public static Manager_Event EM;

	//Game EVENTS
    public Action EVT_Game_Setup;
    public Action EVT_Game_Start;
    public Action EVT_Replay_Game;
    //public Action EVT_Game_Restarted;
    public Action EVT_Game_Over;
    //Presentation EVENTS
    public Action EVT_Presentation_Start;
    public Action EVT_Presentation_Finished;
    public Action<string> EVT_Display_Blackboard;
    public Action<Node> EVT_Node_Pressed;
    public Action<int> EVT_Button_Pushed;
    public Action EVT_Sequence_Completed;
    public Action<int> EVT_Score_Changed;

    public Action EVT_Tutorial_Started;
    public Action EVT_Tutorial_Finished;
    public Action EVT_Repeat_Tutorial;
   

    //Animation Related EVENTS
    public Action EVT_WaitingForPlayerInput;
    public Action EVT_PayAttention;



	// Use this for initialization
	public override void Initialize () 
	{
        Debug.Log("Initializing...." + this.name);
		EM = this;
	}

    public void Fire_EVT_Replay_Game()
    {
        if (EVT_Replay_Game != null) EVT_Replay_Game();
    }

    public void Fire_EVT_PayAttention() {
        if (EVT_PayAttention != null) EVT_PayAttention();
    }

    public void Fire_EVT_WaitingForPlayerInput()
    {
        if (EVT_WaitingForPlayerInput != null) EVT_WaitingForPlayerInput();
    }

    public void Fire_EVT_Repeat_Tutorial()
    {
        if (EVT_Repeat_Tutorial != null) EVT_Repeat_Tutorial();
    }

    public void Fire_EVT_Tutorial_Started()
    {
        if (EVT_Tutorial_Started != null) EVT_Tutorial_Started();
    }

    public void Fire_EVT_Tutorial_Finished()
    {
        if (EVT_Tutorial_Finished != null) EVT_Tutorial_Finished();
    }


    //Better structure
    public void Fire_EVT_Display_Blackboard(string text)
    {
        if (EVT_Display_Blackboard != null) EVT_Display_Blackboard(text);
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
        Debug.Log("Game Setup Fired from manager");
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
