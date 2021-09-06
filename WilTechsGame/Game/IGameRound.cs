using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilTechsGame.Game
{
    /// <summary>
    /// 游戏回合
    /// </summary>
    public interface IGameRound
    {
        /// <summary>
        /// 玩家操作
        /// </summary>
        bool Play(int rowNum, int takeCount);

        /// <summary>
        /// 切换玩家
        /// </summary>
        void SwitchPlayer();

        /// <summary>
        /// 获取当前玩家
        /// </summary>
        /// <returns></returns>
        IPlayer GetCurrentPlayer();

        /// <summary>
        /// 获取赢家
        /// </summary>
        /// <returns></returns>
        IPlayer GetWinner();

        /// <summary>
        /// 返回当前局势
        /// </summary>
        List<int> GetCurrentState();

        /// <summary>
        /// 获取游戏状态
        /// </summary>
        GameRoundStatus GetStatus();
    }
}
