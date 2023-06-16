using System.Collections.Generic;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.Inventory
{
    /// <summary>
    /// Classe respons�vel pelo gerenciamento do invent�rio do jogador.
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        private Dictionary<InventoryItem, int> inventory; // Dicion�rio para armazenar os itens e suas quantidades

        private void Start()
        {
            inventory = new Dictionary<InventoryItem, int>();
        }

        /// <summary>
        /// Adiciona um item ao invent�rio.
        /// </summary>
        /// <param name="item">O item a ser adicionado.</param>
        /// <param name="quantity">A quantidade do item.</param>
        public void AddItem(InventoryItem item, int quantity = 1)
        {
            if (inventory.ContainsKey(item))
            {
                inventory[item] += quantity;
            }
            else
            {
                inventory[item] = quantity;
            }
        }

        /// <summary>
        /// Remove um item do invent�rio.
        /// </summary>
        /// <param name="item">O item a ser removido.</param>
        /// <param name="quantity">A quantidade do item a ser removida.</param>
        public void RemoveItem(InventoryItem item, int quantity = 1)
        {
            if (inventory.ContainsKey(item))
            {
                inventory[item] -= quantity;

                if (inventory[item] <= 0)
                {
                    inventory.Remove(item);
                }
            }
        }

        /// <summary>
        /// Verifica se o jogador possui um item espec�fico.
        /// </summary>
        /// <param name="item">O item a ser verificado.</param>
        /// <returns>True se o jogador possui o item, False caso contr�rio.</returns>
        public bool HasItem(InventoryItem item)
        {
            return inventory.ContainsKey(item);
        }

        /// <summary>
        /// Obt�m a quantidade de um item no invent�rio.
        /// </summary>
        /// <param name="item">O item desejado.</param>
        /// <returns>A quantidade do item no invent�rio.</returns>
        public int GetItemQuantity(InventoryItem item)
        {
            if (inventory.TryGetValue(item, out int quantity))
            {
                return quantity;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Obt�m todos os itens no invent�rio.
        /// </summary>
        /// <returns>Uma lista de itens no invent�rio.</returns>
        public List<InventoryItem> GetAllItems()
        {
            List<InventoryItem> items = new List<InventoryItem>(inventory.Keys);
            return items;
        }
    }

    /// <summary>
    /// Classe que representa um item no invent�rio.
    /// </summary>
    [CreateAssetMenu(menuName = "Inventory/InventoryItem")]
    public class InventoryItem : ScriptableObject
    {
        [SerializeField] private string itemName; // Nome do item
        [SerializeField] private Sprite icon; // �cone do item

        /// <summary>
        /// Nome do item.
        /// </summary>
        public string ItemName => itemName;

        /// <summary>
        /// �cone do item.
        /// </summary>
        public Sprite Icon => icon;
    }
}
