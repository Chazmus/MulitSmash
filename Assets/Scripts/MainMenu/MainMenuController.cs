using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuController : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private Button startBtn;

        [SerializeField]
        private TMP_InputField usernameInput;

        private void Awake()
        {
            startBtn.onClick.AddListener(StartBtnClickHandler);
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
    }
}
