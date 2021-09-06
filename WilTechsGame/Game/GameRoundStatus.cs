using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilTechsGame.Game
{
    public enum GameRoundStatus
    {
        [Description("未开始")]
        NotStarted = 0,
        [Description("进行中")]
        Playing = 1,
        [Description("已结束")]
        Over = 2
    }
}
