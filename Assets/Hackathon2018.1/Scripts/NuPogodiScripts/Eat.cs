using UnityEngine;

namespace Hackathon2018._1.NuPogodiScripts
{
    public class Eat
    {
        public bool IsPoison { get; set; }
        public Vector3 Position { get; set; }
        public Height Height { get; set; }
        public Horisontal Horisontal { get; set; }

        public Eat(bool isPoison, Vector3 position, Height height, Horisontal horisontal)
        {
            IsPoison = isPoison;
            Position = position;
            Height = height;
            Horisontal = horisontal;
        }
    }
}