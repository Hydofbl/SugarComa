using Assets.MainBoard.Scripts.Networking;
using UnityEngine;

public class RemoteMessageHandler : MonoBehaviour
{
    private void Awake()
    {
        SteamServerManager.Instance.OnMessageReceived += OnMessageReceived;
    }

    private void OnDestroy()
    {
        SteamServerManager.Instance.OnMessageReceived -= OnMessageReceived;
    }


    // TODO: Alt�n, Can g�ncellemelerini ilet.
    private void OnMessageReceived(Steamworks.SteamId steamid, byte[] buffer)
    {
    }
}
