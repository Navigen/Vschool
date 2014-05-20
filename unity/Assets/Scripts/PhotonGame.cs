// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorkerInGame.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

public class PhotonGame : Photon.MonoBehaviour
{
    public Transform playerPrefab;

    //avatars
    public Transform Robot;
    public Transform Joan;
    public Transform Alexis;
    public Transform Golem;
    public Transform Justin;
    public Transform Vincent;
    public Transform Solder;
    public Transform Mia;
    public Transform Punk;
    public Transform Carl;

    public Transform SpawnPlace;

    public string nameOfAvatar;

    public void Awake()
    {
        //select avatar
        nameOfAvatar = /*"Solder"*/CharacterCust.nameOfAvatar;


        Debug.Log("Avatar is " + nameOfAvatar);

        switch (nameOfAvatar)
        {
            case "Robot": playerPrefab = Robot; break;
            case "Joan": playerPrefab = Joan; break;
            case "Alexis": playerPrefab = Alexis; break;
            case "Justin": playerPrefab = Justin; break;
            case "Vincent": playerPrefab = Vincent; break;
            case "Solder": playerPrefab = Solder; break;
            case "Mia": playerPrefab = Mia; break;
            case "Punk": playerPrefab = Punk; break;
            case "Carl": playerPrefab = Carl; break;
        }

        playerPrefab.GetComponent<NetworkCharacterAnimSync>().enabled = true;
        playerPrefab.GetComponent<BotControlScript>().enabled = true;

        // in case we started this demo with the wrong scene being active, simply load the menu scene
        if (!PhotonNetwork.connected)
        {
            Application.LoadLevel(PhotonMenu.SceneNameMenu);
            return;
        }
        // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
        PhotonNetwork.Instantiate(this.playerPrefab.name, SpawnPlace.position, Quaternion.identity, 0);
       // Debug.Log("this.playerPrefab.name " + this.playerPrefab.name);
        GameObject instantiatedPlayer = GameObject.Find(nameOfAvatar + "(Clone)");
        Debug.Log("instantiatedPlayer.name " + instantiatedPlayer.name);
        //instantiatedPlayer.name = PhotonNetwork.playerName;
        //instantiatedPlayer.GetComponent<NetworkCharacterAnimSync>().enabled = true;
        //instantiatedPlayer.GetComponent<BotControlScript>().enabled = true;
        Camera.main.GetComponent<OrbitCam>().target = instantiatedPlayer.transform;
    }

    public void OnGUI()
    {
        if (GUILayout.Button("Return to Lobby"))
        {
            PhotonNetwork.LeaveRoom();  // we will load the menu level when we successfully left the room
        }
    }

    public void OnMasterClientSwitched(PhotonPlayer player)
    {
        Debug.Log("OnMasterClientSwitched: " + player);

        string message;
        InRoomChat chatComponent = GetComponent<InRoomChat>();  // if we find a InRoomChat component, we print out a short message

        if (chatComponent != null)
        {
            // to check if this client is the new master...
            if (player.isLocal)
            {
                message = "You are Master Client now.";
            }
            else
            {
                message = player.name + " is Master Client now.";
            }


            chatComponent.AddLine(message); // the Chat method is a RPC. as we don't want to send an RPC and neither create a PhotonMessageInfo, lets call AddLine()
        }
    }

    public void OnLeftRoom()
    {
        Debug.Log("OnLeftRoom (local)");
        
        // back to main menu        
        Application.LoadLevel(PhotonMenu.SceneNameMenu);
    }

    public void OnDisconnectedFromPhoton()
    {
        Debug.Log("OnDisconnectedFromPhoton");

        // back to main menu        
        Application.LoadLevel(PhotonMenu.SceneNameMenu);
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        Debug.Log("OnPhotonInstantiate " + info.sender);    // you could use this info to store this or react
    }

    public void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        Debug.Log("OnPhotonPlayerConnected: " + player);
    }

    public void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        Debug.Log("OnPlayerDisconneced: " + player);
    }

    public void OnFailedToConnectToPhoton()
    {
        Debug.Log("OnFailedToConnectToPhoton");

        // back to main menu        
        Application.LoadLevel(PhotonMenu.SceneNameMenu);
    }
}
