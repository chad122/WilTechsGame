using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilTechsGame.Game
{
    /// <summary>
    /// 游戏生成器
    /// </summary>
    public interface IGameGenerator
    {
        /// <summary>
        /// 生成游戏
        /// </summary>
        /// <returns></returns>
        IGameRound Generate();
    }
}
