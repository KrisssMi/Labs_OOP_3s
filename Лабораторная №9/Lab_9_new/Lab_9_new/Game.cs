using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9_new
{
	public static class Game
	{
        public static event Action<string> OnAttack;
        public static event Action<string> OnHeal;
        public static event Action OnStartWork;
        public static event Action OnEndWork;

        public static void StartWorkWithItem(Items items)
        {
            OnStartWork += items.living_true;
            OnEndWork += items.living_false;

            OnStartWork?.Invoke();
        }

        public static void EndWorkWithItem(Items items)
        {
            if (items.IsLiving == false)
                throw new ArgumentException("The item isn't living now.");

            OnEndWork?.Invoke();

            OnStartWork -= items.living_true;
            OnEndWork -= items.living_false;
        }

        public static void Attack(Items items, string newLife)
        {
            OnAttack += items.ChangeLife;

            OnAttack?.Invoke(newLife);

            OnAttack -= items.ChangeLife;
        }

        public static void Heal(Items items, string newLife)
        {
            OnHeal += items.ChangeLife;

            OnHeal?.Invoke(newLife);

            OnHeal += items.ChangeLife;
        }
    }
}
