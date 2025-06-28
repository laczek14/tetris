using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    internal class tetromino
    {
        public Vector2 Vector = new Vector2(0, 0);
        int gamble = Raylib.GetRandomValue(1, 7);
        #region gambling
        public void gambling()
        {
            #region if'y
            if (gamble == 1)
            {
                Kwadrat();
            }
            if (gamble == 2)
            {
                I();
            }
            if (gamble == 3)
            {
                Kwadrat();
            }
            if (gamble == 4)
            {
                LeftL();
            }
            if (gamble == 5) 
            {
                W();
            }
            if (gamble == 6)
            {
                Z();
            }
            if (gamble == 7) 
            {
                LeftZ();
            }
            #endregion
        }
        #endregion
        #region tetrominoes
        #region Kwadrat
        public void Kwadrat()
        {
            Vector2 figura = new Vector2(100, 100);
            Raylib.DrawRectangleV(Vector, figura, Color.Red);
        }
        #endregion
        #region I
        public void I()
        {
            Vector2 figura = new Vector2(50, 100);
            Vector2 figura2 = new Vector2(50, 200);
            Raylib.DrawRectangleV(Vector, figura, Color.Brown);
            Raylib.DrawRectangleV(Vector, figura2, Color.Brown);
        }
        #endregion
        #region L
        public void L()
        {
            Vector2 figura1 = new Vector2(50, 150);
            Vector2 figura2 = new Vector2(50, 50);
            Vector2 vector2 = new Vector2(Vector.X + 50, Vector.Y + 100);
            Raylib.DrawRectangleV(Vector, figura1, Color.SkyBlue);
            Raylib.DrawRectangleV(vector2, figura2, Color.SkyBlue);
        }
        #endregion
        #region LeftL
        public void LeftL()
        {
            Vector2 figura1 = new Vector2(50, 150);
            Vector2 figura2 = new Vector2(50, 50);
            Vector2 vector3 = new Vector2(Vector.X, Vector.Y + 100);
            Vector2 vector2 = new Vector2(Vector.X + 50, Vector.Y);
            Raylib.DrawRectangleV(vector2, figura1, Color.SkyBlue);
            Raylib.DrawRectangleV(vector3, figura2, Color.SkyBlue);
        }
        #endregion
        #region W
        public void W()
        {
            Vector2 figura1 = new Vector2(150,50);
            Vector2 figura2 = new Vector2(50,50);
            Vector2 vector2 = new Vector2(Vector.X+50,Vector.Y+50);
            Raylib.DrawRectangleV(Vector,figura1,Color.Beige);
            Raylib.DrawRectangleV(vector2,figura2,Color.Beige);
        }
        #endregion
        #region Z
        public void Z()
        {
            Vector2 figura = new Vector2(50,100);
            Vector2 vector2 = new Vector2(Vector.X,Vector.Y+50);
            Vector2 vector3 = new Vector2(Vector.X+50,Vector.Y);
            Raylib.DrawRectangleV(vector2,figura,Color.Violet);
            Raylib.DrawRectangleV(vector3,figura,Color.Violet);
        }
        #endregion
        #region LeftZ
        public void LeftZ()
        {
            Vector2 figura = new Vector2(50, 100);
            Vector2 vector2 = new Vector2(Vector.X+50, Vector.Y + 50);
            Raylib.DrawRectangleV(vector2, figura, Color.Violet);
            Raylib.DrawRectangleV(Vector, figura, Color.Violet);
        }
        #endregion
        #endregion
        public void Game()
        {
            bool IsGamerunning = true;
            while (IsGamerunning)
            {
                gambling();
            }
        }
    }
}

