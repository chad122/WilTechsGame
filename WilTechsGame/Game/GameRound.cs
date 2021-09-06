using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilTechsGame.Extensions;

namespace WilTechsGame.Game
{
    /// <summary>
    /// 游戏回合
    /// </summary>
    class GameRound : IGameRound
    {
        private List<int> CurrentState;
        private IPlayer Player1;
        private IPlayer Player2;
        private IPlayer CurrentPlayer;
        private IPlayer Winner;
        private GameRoundStatus Status;

        /// <summary>
        /// 初始化游戏
        /// </summary>
        /// <param name="initState"></param>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        public GameRound(int[] initState, IPlayer player1, IPlayer player2)
        {
            Status = GameRoundStatus.NotStarted;
            if (initState.Length == 0 || initState.All(x => x <= 0))
            {
                Console.WriteLine("回合初始值设置错误，请重新设置");
                return;
            }
            if (player1 == null || player2 == null)
            {
                Console.WriteLine("玩家不能为空");
                return;
            }

            CurrentState = initState.ToList();
            Player1 = player1;
            Player2 = player2;
            CurrentPlayer = player1;
            Status = GameRoundStatus.Playing;
        }

        /// <summary>
        /// 玩家操作
        /// </summary>
        /// <returns></returns>
        public bool Play(int rowNum, int takeCount)
        {
            if (CheckStatus())
            {
                // 校验参数
                if (rowNum <= 0 || rowNum > CurrentState.Count)
                {
                    // 行号错误
                    return false;
                }
                var rowIndex = rowNum - 1;
                if (takeCount <= 0 || CurrentState[rowIndex] < takeCount)
                {
                    // 提取数量错误
                    return false;
                }

                var res = CurrentPlayer.Take(CurrentState, rowIndex, takeCount);
                if (res)
                {
                    // 检查是否还有剩余牙签，如果没有，则GameOver
                    if (!CurrentState.Any(x => x > 0))
                    {
                        Winner = CurrentPlayer == Player1 ? Player2 : Player1;
                        Status = GameRoundStatus.Over;
                    }
                }
                return res;
            }
            return false;
        }

        /// <summary>
        /// 切换玩家
        /// </summary>
        public void SwitchPlayer()
        {
            if (CheckStatus())
            {
                CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
            }
        }

        /// <summary>
        /// 获取当前玩家
        /// </summary>
        /// <returns></returns>
        public IPlayer GetCurrentPlayer()
        {
            return CurrentPlayer;
        }

        /// <summary>
        /// 获取赢家
        /// </summary>
        /// <returns></returns>
        public IPlayer GetWinner()
        {
            return Winner;
        }

        /// <summary>
        /// 打印当前局势
        /// </summary>
        public List<int> GetCurrentState()
        {
            return CurrentState;
        }

        /// <summary>
        /// 获取游戏结果
        /// </summary>
        public GameRoundStatus GetStatus()
        {
            return Status;
        }

        /// <summary>
        /// 检查游戏状态
        /// </summary>
        /// <returns></returns>
        private bool CheckStatus()
        {
            if (Status == GameRoundStatus.Playing)
            {
                return true;
            }
            Console.WriteLine($"当前游戏状态为{Status.GetDescription()}，请勿操作");
            return false;
        }
    }
}
