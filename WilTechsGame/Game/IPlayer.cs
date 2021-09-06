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
    public interface IPlayer
    {
        /// <summary>
        /// 拿牙签
        /// </summary>
        /// <param name="gameState"></param>
        /// <param name="rowIndex"></param>
        /// <param name="takeCount"></param>
        bool Take(List<int> gameState, int rowIndex, int takeCount);

        /// <summary>
        /// 获取玩家名字
        /// </summary>
        /// <returns></returns>
        string GetName();
    }
}
