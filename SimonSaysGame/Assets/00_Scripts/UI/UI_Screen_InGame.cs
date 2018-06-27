using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Screen_InGame : UI_Screen {

    public TextMeshProUGUI scoreLabel;

    public override Enum_Screen GetScreenType()
    {
        return Enum_Screen.InGame;
    }

    protected override void OnStart() {
        GLOBAL.instance.M_event.EVT_Score_Changed += OnScoreChanged;
    }

    void OnScoreChanged(int score) {
        scoreLabel.text = score.ToString();
    }
}
