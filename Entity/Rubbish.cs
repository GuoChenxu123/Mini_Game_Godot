using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Game_Godot.Entity
{
    /*
         类名 ： 垃圾类
      */
    public class Rubbish
    {
        public int id { get; set; }
        public string name { get; set; }
        public int description { get; set; }
        public string image { get; set; }

        public override string ToString()
        {
            return "id : " + id + " , name : " + name + " , description : " + description + " , image : " + image;
        }
    }
}
