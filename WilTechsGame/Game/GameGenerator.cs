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
    public class GameGenerator : IGameGenerator
    {
        private int[] initState = new int[] { 3, 5, 7 };

        /// <summary>
        /// 生成游戏
        /// </summary>
        /// <returns></returns>
        public IGameRound Generate()
        {
            return new GameRound(initState, new Player("1号"), new Player("2号"));
        }
    }
}
