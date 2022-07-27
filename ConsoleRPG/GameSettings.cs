using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class GameSettings
    {
        private int horizontal;
        private int vertical;

        public GameSettings()
        {
            horizontal = 20;
            vertical = 20;
        }
        public int GetHorizontal()
        {
            return horizontal;
        }
        public int GetVertical()
        {
            return vertical;
        }
        public void SetHorizontal(int X)
        {
            horizontal = X;
        }
        public void SetVertical(int X)
        {
            vertical = X;
        }
        public void SetWindow(int width, int height)
        {
            Console.SetWindowSize(width, height);
        }
        public void SetTileSize(int X, int Y)
        {
            SetHorizontal(X);
            SetVertical(Y);
            GameManager.Instance.mapClass.CreateTile();
            Console.Clear();
        }
    }
}
