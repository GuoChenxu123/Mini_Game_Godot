using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Game_Godot.Entity
{
    public class BaseLeveInfo
    {
        public string Name { get; set; }
        public int TrueRequired { get; set; }
        public int FalseAllowed { get; set; }
        public int Score { get; set; }

        public string background;
    }
}
