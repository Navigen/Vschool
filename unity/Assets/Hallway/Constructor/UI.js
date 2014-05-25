private var show = true;
private var chat;

var LBL1 = "Управление";
var LBL2 = "ЛКМ - взаимодействие";
var LBL3 = "ПКМ - камера";
var LBL4 = "W/A/S/D - движение";
var LBL5 = "Space - прыжок";
var LBL6 = "X - скрыть чат";
var LBL7 = "I - скрыть очки";
var LBL8 = "Z - скрыть это окно";

function Update() 
{
	if (Input.GetKeyDown(KeyCode.Z)) show = !show;
    if (Input.GetKeyDown(KeyCode.X))
    {
        chat = GameObject.Find("Bootstrap").GetComponent("InRoomChat");
        if(chat.IsVisible)
            chat.IsVisible = false;
        else
            chat.IsVisible = true;
    }
}

function OnGUI () 
{
	if (InterfaceIdiom.Current == InterfaceIdiom.Values.Phone)
		return;
	
	if (show) 
	{
		var old_fontStyle = GUI.skin.box.fontStyle; GUI.skin.box.fontStyle = FontStyle.Bold;
		var old_fontSize = GUI.skin.box.fontSize; GUI.skin.box.fontSize = 16;
		var old_alignment = GUI.skin.box.alignment;
		
		GUI.skin.box.alignment = TextAnchor.UpperCenter;
		GUI.Box(Rect(Screen.width - 215, Screen.height - 295, 205, 290), LBL1+":");
		GUI.skin.box.alignment = TextAnchor.UpperLeft;
		GUI.Box(Rect(Screen.width - 210, Screen.height - 260, 195, 35), LBL2);
		GUI.Box(Rect(Screen.width - 210, Screen.height - 225, 195, 35), LBL3);
		GUI.Box(Rect(Screen.width - 210, Screen.height - 190, 195, 35), LBL4);
		GUI.Box(Rect(Screen.width - 210, Screen.height - 155, 195, 35), LBL5);
		GUI.Box(Rect(Screen.width - 210, Screen.height - 120, 195, 35), LBL6);
		GUI.Box(Rect(Screen.width - 210, Screen.height - 85, 195, 35), LBL7);
		GUI.Box(Rect(Screen.width - 210, Screen.height - 50, 195, 35), LBL8);
		
		GUI.skin.box.fontStyle = old_fontStyle;
		GUI.skin.box.fontSize = old_fontSize;
		GUI.skin.box.alignment = old_alignment;
	}
}