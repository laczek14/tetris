using Raylib_cs;
using System.Numerics;
namespace tetris
{
    internal class Program 
    {
        static void Main(string[] args) 
        {
            tetromino t = new tetromino();
            Raylib.InitWindow(800, 600,"tetris ig");
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);
                t.gambling();
                DrawGrid(800,600,50,Color.LightGray);
                Raylib.EndDrawing();
            }
            #region Grid
            static void DrawGrid(int width, int height, int cellSize, Color color)
            {
                for (int x = 0; x <= width; x += cellSize)
                {
                    Raylib.DrawLine(x, 0, x, height, color);
                }

                for (int y = 0; y <= height; y += cellSize)
                {
                    Raylib.DrawLine(0, y, width, y, color);
                }
            }
            #endregion
        }
    }
}
