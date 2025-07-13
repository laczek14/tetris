using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    internal class tetromino
    {
    // Add timer fields
    double fallInterval = 0.5; // seconds between falls
    double lastFallTime = 0;
    List<Vector2> SavedPos = new List<Vector2>(); // List to save block positions
    List<int> SavedBlocks = new List<int>(); // List to save block types (1-7)
    static int BlockCount = 7; // Total number of block types
        public Vector2 Vector = new Vector2(0, 0);
        int gamble = Raylib.GetRandomValue(1,BlockCount);
        #region gambling
        public void gambling(int i, Vector2 V = new Vector2())
        {
            #region switch

            switch (i)
            {
                case 1:
                    Square(V);
                    break;

                case 2:
                    I(V); 
                    break;

                case 3:
                    L(V);
                    break;
                case 4:
                    LeftL(V);
                    break;

                case 5:
                    W(V);
                    break;

                case 6:
                    Z(V);
                    break;

                case 7:
                    LeftZ(V);
                    break;
            }
            #endregion
        }
        #endregion
        #region tetrominoes
        #region Square
        public void Square(Vector2 V = new Vector2())
        {
            Vector2 figuraK = new Vector2(100, 100);
            Raylib.DrawRectangleV(V, figuraK, Color.Red);
        }
        #endregion
        #region I
        public void I(Vector2 V = new Vector2())
        {
            Vector2 figura = new Vector2(50, 100);
            Vector2 figura2 = new Vector2(50, 200);
            Raylib.DrawRectangleV(V, figura, Color.Brown);
            Raylib.DrawRectangleV(V, figura2, Color.Brown);
        }
        #endregion
        #region L
        public void L(Vector2 V = new Vector2())
        {
            Vector2 figura1 = new Vector2(50, 150);
            Vector2 figura2 = new Vector2(50, 50);
            Vector2 vector2 = new Vector2(V.X + 50, V.Y + 100);
            Raylib.DrawRectangleV(V, figura1, Color.SkyBlue);
            Raylib.DrawRectangleV(vector2, figura2, Color.SkyBlue);
        }
        #endregion
        #region LeftL
        public void LeftL(Vector2 V = new Vector2())
        {
            Vector2 figura1 = new Vector2(50, 150);
            Vector2 figura2 = new Vector2(50, 50);
            Vector2 vector3 = new Vector2(V.X, V.Y + 100);
            Vector2 vector2 = new Vector2(V.X + 50, V.Y);
            Raylib.DrawRectangleV(vector2, figura1, Color.SkyBlue);
            Raylib.DrawRectangleV(vector3, figura2, Color.SkyBlue);
        }
        #endregion
        #region W
        public void W(Vector2 V = new Vector2())
        {
            Vector2 figura1 = new Vector2(150,50);
            Vector2 figura2 = new Vector2(50,50);
            Vector2 vector2 = new Vector2(V.X+50,V.Y+50);
            Raylib.DrawRectangleV(V,figura1,Color.Beige);
            Raylib.DrawRectangleV(vector2,figura2,Color.Beige);
        }
        #endregion
        #region Z
        public void Z(Vector2 V = new Vector2())
        {
            Vector2 figura = new Vector2(50,100);
            Vector2 vector2 = new Vector2(V.X,V.Y+50);
            Vector2 vector3 = new Vector2(V.X+50,V.Y);
            Raylib.DrawRectangleV(vector2,figura,Color.Violet);
            Raylib.DrawRectangleV(vector3,figura,Color.Violet);
        }
        #endregion
        #region LeftZ
        public void LeftZ(Vector2 V = new Vector2())
        {
            Vector2 figura = new Vector2(50, 100);
            Vector2 vector2 = new Vector2(V.X+50, V.Y + 50);
            Raylib.DrawRectangleV(vector2, figura, Color.Violet);
            Raylib.DrawRectangleV(V, figura, Color.Violet);
        }
        #endregion
        #endregion
        #region movement
        public void movement()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.A) & Vector.X != 0 & Vector.Y != 550  || Raylib.IsKeyDown(KeyboardKey.A) & Vector.X != 0 & Vector.Y != 550)
            {
                Vector.X -= 50;
            }
            if (Raylib.IsKeyPressed(KeyboardKey.D) & Vector.X < 700 & Vector.Y != 550 || Raylib.IsKeyDown(KeyboardKey.D) & Vector.X<300 & Vector.Y != 550)
            {
                Vector.X += 50;
            }
            if (Raylib.IsKeyDown(KeyboardKey.S) & Vector.Y != 550)
            {
                // Move down
                Vector.Y += 50;
            }
        }
        #endregion
        #region SaveBlock
        public void SaveBlock()
        {
            Vector2 savedPos = Vector; // Save the current position of the block
            int savedBlock = gamble; // Save the current block type
            SavedPos.Add(savedPos);
            SavedBlocks.Add(savedBlock); // Add the saved block type to the list
            gamble = Raylib.GetRandomValue(1, BlockCount); // Get a new random block type
        }
        #endregion
        public void PrintBlocks()
        { 
            foreach (Vector2 V in SavedPos)
            {
                
            }
        }
        public void Game()
        {
            bool IsGamerunning = true;
            Raylib.InitWindow(600, 700, "tetris ig");
            lastFallTime = Raylib.GetTime(); // Initialize timer

            while (!Raylib.WindowShouldClose())
            {
                if (IsGamerunning)
                {
                double currentTime = Raylib.GetTime();

                // Move block down every fallInterval seconds
                if (Vector.Y != 550 && currentTime - lastFallTime >= fallInterval)
                {
                    Vector.Y += 50;
                    movement();
                    // Reset the timer
                    lastFallTime = currentTime;
                }
                        Raylib.ClearBackground(Color.White);
                        Raylib.BeginDrawing();
                        Raylib.DrawText(Vector.ToString(), 400, 0, 40, Color.Red);
                        gambling(gamble,Vector);
                        DrawGrid(400, 700, 50, Color.LightGray);
                        Raylib.EndDrawing();
                }
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

