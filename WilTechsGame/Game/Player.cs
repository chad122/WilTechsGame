using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilTechsGame.Game
{
    /// <summary>
    /// 玩家
    /// </summary>
    public class Player : IPlayer
    {
        private string Name;
        public Player(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 拿牙签
        /// </summary>
        /// <param name="gameState"></param>
        /// <param name="rowIndex"></param>
        /// <param name="takeCount"></param>
        public bool Take(List<int> gameState, int rowIndex, int takeCount)
        {
            // 校验通过，提取牙签
            gameState[rowIndex] -= takeCount;
            return true;
        }

        /// <summary>
        /// 获取玩家名字
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return Name;
        }
    }
}
