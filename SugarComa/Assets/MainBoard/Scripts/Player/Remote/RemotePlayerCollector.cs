using Assets.MainBoard.Scripts.GameManaging;
using Assets.MainBoard.Scripts.Player.Utils;
using UnityEngine;

namespace Assets.MainBoard.Scripts.Player.Remote
{
    public class RemotePlayerCollector : MonoBehaviour
    {
        #region Public Fields
        public int health;
        public int gold;
        public int goblet;
        public bool isDead;
        #endregion

        #region SerializeFields
        [SerializeField] private GameController _gameController;
        //[SerializeField] private GobletSelection _gobletSelection;
        //[SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private RemoteScriptKeeper _scriptKeeper;
        //[SerializeField] Item item;
        #endregion

        #region Properties
        public GameController GameController { set => _gameController = value; }
        public RemoteScriptKeeper ScriptKeeper { get => _scriptKeeper; }
        #endregion

        public void UpdateSpecs(int gold, int health, int goblet)
        {
            this.gold = gold;
            this.health = health;
            this.goblet = goblet;
            _gameController.ChangeText(_scriptKeeper);
        }

        /*public void AddItem()
        {
            //int i = Random.Range(1, 11);
            int i = 8;
            switch (i)
            {
                case 1:
                    item.shield.OnAddItem();
                    break;
                case 2:
                    item.car.OnAddItem();
                    break;
                case 3:
                    // TODO: �smi d�zelt
                    item.sapan.OnAddItem();
                    break;
                case 4:
                    item.teleport.OnAddItem();
                    break;
                case 5:
                    item.bee.OnAddItem();
                    break;
                case 6:
                    item.magnet.OnAddItem();
                    break;
                case 7:
                    item.randombox.OnAddItem();
                    break;
                case 8:
                    item.boxgloves.OnAddItem();
                    break;
                case 9:
                    item.healbox.OnAddItem();
                    break;
                case 10:
                    item.hook.OnAddItem();
                    break;
                default:
                    break;
            }
            _gameController.ChangeInventory();
        }

        void RandomJackpot(int value)
        {
            int i = Random.Range(1, 4);
            switch (i)
            {
                //case 1: AddItem(); break;
                case 2: AddGold(Random.Range(value, 8)); break;
                case 3: AddHealth(value); break;
            }
        }

        [System.Serializable]
        public class Item
        {
            public ItemObject shield;
            public ItemObject car;
            public ItemObject sapan;
            public ItemObject teleport;
            public ItemObject bee;
            public ItemObject magnet;
            public ItemObject randombox;
            public ItemObject boxgloves;
            public ItemObject healbox;
            public ItemObject hook;
        }
        */
    }
}