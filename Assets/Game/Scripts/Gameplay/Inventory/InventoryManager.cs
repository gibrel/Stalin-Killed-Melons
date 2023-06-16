using System.Collections.Generic;
using UnityEngine;

namespace StalinKilledMelons.Gameplay.Inventory
{
    /// <summary>
    /// Classe responsável pelo gerenciamento do inventário do jogador.
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        private Dictionary<InventoryItem, int> inventory; // Dicionário para armazenar os itens e suas quantidades

        private void Start()
        {
            inventory = new Dictionary<InventoryItem, int>();
        }

        /// <summary>
        /// Adiciona um item ao inventário.
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
        /// Remove um item do inventário.
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
        /// Verifica se o jogador possui um item específico.
        /// </summary>
        /// <param name="item">O item a ser verificado.</param>
        /// <returns>True se o jogador possui o item, False caso contrário.</returns>
        public bool HasItem(InventoryItem item)
        {
            return inventory.ContainsKey(item);
        }

        /// <summary>
        /// Obtém a quantidade de um item no inventário.
        /// </summary>
        /// <param name="item">O item desejado.</param>
        /// <returns>A quantidade do item no inventário.</returns>
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
        /// Obtém todos os itens no inventário.
        /// </summary>
        /// <returns>Uma lista de itens no inventário.</returns>
        public List<InventoryItem> GetAllItems()
        {
            List<InventoryItem> items = new List<InventoryItem>(inventory.Keys);
            return items;
        }
    }

    /// <summary>
    /// Classe que representa um item no inventário.
    /// </summary>
    [CreateAssetMenu(menuName = "Inventory/InventoryItem")]
    public class InventoryItem : ScriptableObject
    {
        [SerializeField] private string itemName; // Nome do item
        [SerializeField] private Sprite icon; // Ícone do item

        /// <summary>
        /// Nome do item.
        /// </summary>
        public string ItemName => itemName;

        /// <summary>
        /// Ícone do item.
        /// </summary>
        public Sprite Icon => icon;
    }
}
