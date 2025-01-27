using Assets.MainBoard.Scripts.Player.Movement;
using Assets.MainBoard.Scripts.Player.Remote;
using TMPro;

namespace Assets.MainBoard.Scripts.UI
{
    public interface IObserver
    {
        void OnNotify();
    }

    public class TextChanger : IObserver
    {
        public PlayerCollector playerCollector;
        public RemotePlayerCollector remotePlayerCollector;
        public TMP_Text playerName, playerGold, playerHealth, playerGoblet;

        // For Local player's
        public TextChanger(TMP_Text playerName,  TMP_Text playerGold, TMP_Text playerHealth,TMP_Text playerGoblet, PlayerCollector collector)
        {
            this.playerName = playerName;
            this.playerGold = playerGold;
            this.playerHealth = playerHealth;
            this.playerGoblet = playerGoblet;
            playerCollector = collector;
        }

        // For Remote player's
        public TextChanger(TMP_Text playerName,  TMP_Text playerGold, TMP_Text playerHealth, TMP_Text playerGoblet, RemotePlayerCollector collector)
        {
            this.playerName = playerName;
            this.playerGold = playerGold;
            this.playerHealth = playerHealth;
            this.playerGoblet = playerGoblet;
            remotePlayerCollector = collector;
        }

        void ChangeText()
        {
            if (playerCollector != null)
            {
                playerGold.text = "Gold: " + playerCollector.gold.ToString();
                playerHealth.text = "Health: " + playerCollector.health.ToString();
                playerGoblet.text = "Goblet: " + playerCollector.goblet.ToString();
            }
            else
            {
                playerGold.text = "Gold: " + remotePlayerCollector.gold.ToString();
                playerHealth.text = "Health: " + remotePlayerCollector.health.ToString();
                playerGoblet.text = "Goblet: " + remotePlayerCollector.goblet.ToString();
            }
        }

        public void OnNotify()
        {
            ChangeText();
        }
    }
}