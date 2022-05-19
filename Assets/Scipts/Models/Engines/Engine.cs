using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scipts.Model
{
    public class Engine
    {
        public readonly string Name;
        public readonly float MoveSpeed;
        public readonly float RotationSpeed;
        public readonly int Width;
        public readonly int Height;
        public readonly int Price;
        public readonly int MinLvl;

        public Engine(
            string name,
            float ms, 
            float rs,
            int width,
            int height,
            int price,
            int minLvl)
        {
            Name = name;
            MoveSpeed = ms;
            RotationSpeed = rs;
            Width = width;
            Height = height;
            Price = price;
            MinLvl = minLvl;

        }
    }
}
