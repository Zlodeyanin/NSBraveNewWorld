using System;

namespace NSBraveNewWorld
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool isPlaying = true;
            char[,] map = new char[,]
                {
                {'#','#','#','#','#','#'},
                {'#',' ',' ',' ',' ','#'},
                {'#',' ','#','#',' ','#'},
                {'#',' ','#',' ',' ','#'},
                {'#',' ','#',' ','#','#'},
                {'#',' ','#',' ',' ','#'},
                {'#','#','#','#','#','#'}
                };
            int positionUserX = 1;
            int positionUserY = 1;
            char wall = '#';
            char player = '@';
            char empty = ' ';

            DrawMap(map);
            DrawPlayer(positionUserY, positionUserX, player);

            while (isPlaying)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                GetDirection(key, out int directionX, out int directionY);

                if (directionX != 0 || directionY != 0)
                {
                    if (map[positionUserX + directionX, positionUserY + directionY] != wall)
                    {
                        MovePlayer(ref positionUserX, ref positionUserY, directionX, directionY, player, empty);
                    }
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    isPlaying = false;
                }
            }
        }

        private static void DrawPlayer(int positionY, int positionX, char player)
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(player);
        }

        private static void MovePlayer(ref int positionX, ref int positionY, int directionX, int directionY, char player, char empty)
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(empty);

            positionX += directionX;
            positionY += directionY;

            Console.SetCursorPosition(positionY, positionX);
            Console.Write(player);
        }

        private static void GetDirection(ConsoleKeyInfo key, out int directionX, out int directionY)
        {
            directionX = 0;
            directionY = 0;

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    directionX = -1;
                    break;

                case ConsoleKey.DownArrow:
                    directionX = 1;
                    break;

                case ConsoleKey.LeftArrow:
                    directionY = -1;
                    break;

                case ConsoleKey.RightArrow:
                    directionY = 1;
                    break;
            }
        }

        private static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}