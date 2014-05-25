using UnityEngine;
using System.Collections;


public class GUINameOfAvatar : Photon.MonoBehaviour
{


    Vector3 pos;
    Vector3 worldPos;
    public string textUnderAvatar = "";
    GUIStyle style;
    public bool isNetworking = true;

	// Use this for initialization
	void Start () {
        if(isNetworking)
            textUnderAvatar = photonView.owner.name;
        style = new GUIStyle();
        style.fontSize = 14;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.white;
        style.alignment = TextAnchor.MiddleCenter;
	}

    void FixedUpdate()
    {
        pos = new Vector3(this.transform.position.x, this.transform.position.y + 3f, this.transform.position.z);
        worldPos = Camera.main.WorldToScreenPoint(pos);
        worldPos.y = Screen.height - worldPos.y;
    }

	// Update is called once per frame
	void Update () {
        
	}

    void OnGUI()
    {
        GUI.Label(new Rect(worldPos.x - 120, worldPos.y, 240, 18), textUnderAvatar, style);
    }
}
