using Assets.MainBoard.Scripts.Networking;
using Assets.MainBoard.Scripts.Networking.Utils;
using Assets.MainBoard.Scripts.Player.Utils;
using UnityEngine;

public class RemoteMessageHandler : MonoBehaviour
{
    public RemoteScriptKeeper[] scriptKeepers;

    private void Awake()
    {
        SteamServerManager.Instance.OnMessageReceived += OnMessageReceived;
    }

    private void OnDestroy()
    {
        SteamServerManager.Instance.OnMessageReceived -= OnMessageReceived;
    }

    private void OnMessageReceived(Steamworks.SteamId steamid, byte[] buffer)
    {
        if (NetworkHelper.TryGetNetworkData(buffer, out NetworkData networkData))
        {
            // Player'lar�n kaymas�n� engellemek i�in �nceki g�nderilen pozisyona eri�ti�inde player yeni pozisyon hedef olarak al�ns�n.
            // Bunu mesaj� g�nderdi�imiz yerde yapabiliriz belki
            if (networkData.type == MessageType.InputDown)
            {
                scriptKeepers[NetworkManager.Instance.Index].remotePlayerMovement.UpdatePosition(networkData.position);
            }
        }
        else if (NetworkHelper.TryGetAnimationData(buffer, out AnimationStateData animationStateData))
        {
            scriptKeepers[NetworkManager.Instance.Index].playerAnimation.UpdateAnimState(animationStateData.animBoolHash);
        }
        else if (NetworkHelper.TryGetPlayerSpecData(buffer, out PlayerSpecNetworkData playerSpecData))
        {
            scriptKeepers[NetworkManager.Instance.Index].playerCollector.UpdateSpecs(playerSpecData.gold, playerSpecData.health, playerSpecData.goblet);
        }
    }
}
