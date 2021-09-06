using System;
using System.Collections.Generic;
using System.Text;
using WilTechsGame.Extensions;
using WilTechsGame.Game;

namespace WilTechsGame
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IGameGenerator generator = new GameGenerator();

            bool isStartNewRound = true; // 是否开始新一局
            while (isStartNewRound)
            {
                bool isGameContinue = true; // 游戏是否继续
                var gameRound = generator.Generate();
                while (isGameContinue)
                {
                    Console.WriteLine("-----------------------------------------------");
                    var state = gameRound.GetCurrentState();
                    PrintState(state);

                    Console.WriteLine($"请【{gameRound.GetCurrentPlayer().GetName()}】玩家输入行号和要拿取的牙签数量（格式：行号,牙签数量），并点击Enter");
                    var input = Console.ReadLine();
                    int rowNum, takeCount;
                    if(ParseInput(input, out rowNum, out takeCount))
                    {
                        if(gameRound.Play(rowNum, takeCount))
                        {
                            Console.WriteLine($"玩家【{gameRound.GetCurrentPlayer().GetName()}】在第{rowNum}行拿取了{takeCount}根牙签");

                            // 检查状态
                            var status = gameRound.GetStatus();
                            if (status == GameRoundStatus.Over)
                            {
                                isGameContinue = false;
                                var winner = gameRound.GetWinner();
                                if (winner == null)
                                {
                                    Console.WriteLine("未产生赢家");
                                }
                                else
                                {
                                    Console.WriteLine($"**********\r\n本回合赢家为{winner.GetName()}\r\n**********");
                                }

                                Console.WriteLine("是否要开始新的回合？  [开始]请输入1；[退出]请输入其他任意键，并点击Enter\r\n请输入：");
                                isStartNewRound = Console.ReadLine() == "1";
                            }
                            else
                            {
                                gameRound.SwitchPlayer();
                            }
                        }
                        else
                        {
                            Console.WriteLine("输入的值无效，请重新输入");
                        }
                    }
                    else
                    {
                        Console.WriteLine("输入的内容无法解析，请输入正确的格式");
                    }
                }
            }
            Console.WriteLine("游戏结束！");
            Console.Read();
        }

        /// <summary>
        /// 解析输入的字符串
        /// </summary>
        /// <param name="input"></param>
        /// <param name="rowNum"></param>
        /// <param name="takeCount"></param>
        /// <returns></returns>
        static bool ParseInput(string input, out int rowNum,out int takeCount)
        {
            rowNum = 0;
            takeCount = 0;
            // 校验输入的字符串
            var inputArray = input.Split(',');
            if (inputArray.Length != 2)
            {
                return false;
            }
            var parseSuccess = true;
            parseSuccess = parseSuccess && int.TryParse(inputArray[0], out rowNum);
            parseSuccess = parseSuccess && int.TryParse(inputArray[1], out takeCount);
            return parseSuccess;
        }

        /// <summary>
        /// 打印当前局势
        /// </summary>
        /// <param name="state"></param>
        static void PrintState(List<int> state)
        {
            var contentStr = new StringBuilder();
            contentStr.Append("【当前局势】\r\n\r\n");
            for (var i = 0; i < state.Count; i++)
            {
                contentStr.AppendFormat("第{0}行：\t", i + 1);
                for (var j = 0; j < state[i]; j++)
                {
                    contentStr.Append("1\t");
                }
                contentStr.Append("\r\n\r\n");
            }
            Console.WriteLine(contentStr);
        }
    }
}
