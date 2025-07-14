using Raylib_cs;
using System.Numerics;
namespace tetris
{
    internal class Program 
    {
        static void Main(string[] args) 
        {
            Tetromino t = new Tetromino();
            t.Game();
        }
    }
}
