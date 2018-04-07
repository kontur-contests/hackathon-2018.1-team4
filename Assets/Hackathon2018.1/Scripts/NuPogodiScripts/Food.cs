using UnityEngine;

namespace Hackathon2018._1.NuPogodiScripts
{
    public class Food
    {
        public bool IsPoison { get; set; }
        public Vector3 Position { get; set; }
        public StateEnum FallFrom { get; set; }
        public Horisontal Horisontal { get; set; }

        public Food(bool isPoison, Vector3 position, StateEnum fallFrom, Horisontal horisontal)
        {
            IsPoison = isPoison;
            Position = position;
            FallFrom = fallFrom;
            Horisontal = horisontal;
        }
    }
}