using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class InputMananger
    {
        //[System.Runtime.InteropServices.DllImport("User32.dll")]
        //public static extern short GetAsyncKeyState(int myKey);
        //private short myKey = 0;
        public void GetKey()
        {
            if (Console.KeyAvailable) // 키입력이 존재한다면
            {
                ConsoleKeyInfo myKey = Console.ReadKey(true); // 전방

                if(myKey.Key == ConsoleKey.W)
                {
                    GameManager.Instance.playerClass.SetNowX(-1); // 좌측
                }
                else if (myKey.Key == ConsoleKey.A)
                {
                    GameManager.Instance.playerClass.SetNowY(-1); // 후방
                }
                else if (myKey.Key == ConsoleKey.S)
                {
                    GameManager.Instance.playerClass.SetNowX(1); // 우측
                }
                else if (myKey.Key == ConsoleKey.D)
                {
                    GameManager.Instance.playerClass.SetNowY(1);
                }
                else if(myKey.Key == ConsoleKey.P)
                {
                    GameManager.Instance.display.Setting();
                }
                else if(myKey.Key == ConsoleKey.F)
                {
                    GameManager.Instance.playerClass.UseItem();
                }
                /*
                myKey = GetAsyncKeyState((int)ConsoleKey.W);
                if ((myKey & 0x8000) == 0x8000)
                {
                    GameManager.Instance.playerClass.SetNowX(-1);
                }
                myKey = GetAsyncKeyState((int)ConsoleKey.A);
                if ((myKey & 0x8000) == 0x8000)
                {
                    GameManager.Instance.playerClass.SetNowY(-1);
                }
                myKey = GetAsyncKeyState((int)ConsoleKey.S);
                if ((myKey & 0x8000) == 0x8000)
                {
                    GameManager.Instance.playerClass.SetNowX(1);
                }
                myKey = GetAsyncKeyState((int)ConsoleKey.D);
                if ((myKey & 0x8000) == 0x8000)
                {
                    GameManager.Instance.playerClass.SetNowY(1);
                }
                */
            }
        }
    }
}
