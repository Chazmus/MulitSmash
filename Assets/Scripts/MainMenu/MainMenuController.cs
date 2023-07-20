using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuController : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Button startBtn;

        [SerializeField] private TMP_InputField usernameInput;

        private void Awake()
        {
            startBtn.onClick.AddListener(StartBtnClickHandler);
            PhotonNetwork.AddCallbackTarget(new ConnectionCallback());
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Joined room");
            PhotonNetwork.LoadLevel("Game");
        }

        private void StartBtnClickHandler()
        {
            var userName = usernameInput.text;
            PhotonNetwork.NickName = userName;
            PhotonNetwork.JoinOrCreateRoom("theRoom", new RoomOptions(), TypedLobby.Default);
        }

        class ConnectionCallback : IConnectionCallbacks
        {
            public void OnConnected()
            {
            }

            public void OnConnectedToMaster()
            {
                if (Application.isEditor) // For debugging
                {
                    PhotonNetwork.NickName = "Debug";
                    PhotonNetwork.JoinOrCreateRoom("theRoom", new RoomOptions(), TypedLobby.Default);
                }
            }

            public void OnDisconnected(DisconnectCause cause)
            {
            }

            public void OnRegionListReceived(RegionHandler regionHandler)
            {
            }

            public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
            {
            }

            public void OnCustomAuthenticationFailed(string debugMessage)
            {
            }
        }
    }
}