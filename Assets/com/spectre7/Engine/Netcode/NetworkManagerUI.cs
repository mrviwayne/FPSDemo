using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace com.spectre7.Engine.Netcode
{
    public class NetworkManagerUI : MonoBehaviour
    {
        [SerializeField] private Button clientBtn;
        [SerializeField] private Button hostBtn;


        private void Awake()
        {
            clientBtn.onClick.AddListener(() => NetworkManager.Singleton.StartClient());
            hostBtn.onClick.AddListener(() => NetworkManager.Singleton.StartHost());

        }
    }
}
