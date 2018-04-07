using UnityEngine;

namespace Hackathon2018._1.NuPogodiScripts
{
    public class EatGenerator
    {
        public static Eat GetRandomEat()
        {
            var random = new System.Random();
		
            var positions = new[]
            {
                new Vector3(12, 2.3f), new Vector3(12, 4), new Vector3(12, 8),  
                new Vector3(-13, 2), new Vector3(-13, 4), new Vector3(-13, 8)   
            };

            var randomPosition = random.Next(0, 6);
            var height = GetHeight(randomPosition);
            var hor = GetHorisontal(randomPosition);
            var IsPoison = new[] {true, false}[random.Next(0,2)];
		
		
            return new Eat(IsPoison, positions[randomPosition], height, hor);

        }

        private static Height GetHeight(int position)
        {
            switch (position)
            {
                    case 0:
                        return Height.Down;
                    case 1:
                        return Height.Mid;
                    case 2:
                        return Height.Up;
                    case 3:
                        return Height.Down;
                    case 4:
                        return Height.Mid;
                    case 5:
                        return Height.Up;
            }

            return Height.Down;
        }

        private static Horisontal GetHorisontal(int position)
        {
            switch (position)
            {
                case 0:
                case 1:
                case 2:
                    return Horisontal.Right;
                case 3:
                case 4:
                case 5:
                    return Horisontal.Left;
            }

            return Horisontal.Left;
        }

    }
}