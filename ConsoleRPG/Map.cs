using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Map
    {
        public enum Danger // 타일 위험도
        {
            safe,
            danger,
            VeryDanger,
            special,
        }
        public enum Type // 타일 타입
        {
            forest,
            swamp,
            flat,
            shop,
            start,
            end,
        }
        // 타일 정보
        private int[,] tileDanger;
        private int[,] tileInfo;
        // 타일
        private char[,] tile;
        // 맵 크기
        private int X;
        private int Y;
        // 상점 위치
        private int[] shopX = new int[5];
        private int[] shopY = new int[5];
        // 랜덤 클래스
        Random rand = new Random();

        public char[,] GetTile()
        {
            return tile;
        }
        public int GetTileDanger(int X, int Y)
        {
            return tileDanger[X, Y];
        }
        public int GetTileType(int X, int Y)
        {
            return tileInfo[X, Y];
        }
        public int[] GetShopX()
        {
            return shopX;
        }
        public int[] GetShopY()
        {
            return shopY;
        }
        public void SetTileSafe(int x, int y)
        {
            tileDanger[x, y] = (int)Danger.safe;
        }
        public void SetTileNormal(int x, int y)
        {
            tileInfo[x, y] = (int)Type.flat;
        }
        public void CreateTile()
        {
            X = GameManager.Instance.settings.GetHorizontal();
            Y = GameManager.Instance.settings.GetVertical();

            // 타일 생성 시 플레이어 위치 초기화
            GameManager.Instance.playerClass.ResetPos(0, 0);

            for (int i = 1; i <= 4; i++) // 상점 위치 생성
            {
                if (i == 1) // 1사분면
                {
                    shopX[i] = rand.Next(X / 2, X - 1);
                    shopY[i] = rand.Next(1, Y / 2);
                }
                else if (i == 2)// 2사분면
                {
                    shopX[i] = rand.Next(1, X / 2);
                    shopY[i] = rand.Next(1, Y / 2);
                }
                else if (i == 3)// 3사분면
                {
                    shopX[i] = rand.Next(1, X / 2);
                    shopY[i] = rand.Next(Y / 2, Y - 1);
                }
                else if (i == 4)// 4사분면
                {
                    shopX[i] = rand.Next(X / 2, X - 1);
                    shopY[i] = rand.Next(Y / 2, Y - 1);
                }
            }

            tile = new char[X, Y];
            tileInfo = new int[X, Y];
            tileDanger = new int[X, Y];

            for(int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    if (i == 0 && j == 0) // 시작 지점
                    {
                        tileInfo[i, j] = (int)Type.start;
                        tileDanger[i, j] = (int)Danger.special;
                    }
                    else if (i == Y - 1 && j == X - 1) // 도착 지점
                    {
                        tileInfo[i, j] = (int)Type.end;
                        tileDanger[i, j] = (int)Danger.special;
                    }
                    else if ((i == shopX[1] && j == shopY[1]) || // 상점
                        (i == shopX[2] && j == shopY[2]) ||
                        (i == shopX[3] && j == shopY[3]) ||
                        (i == shopX[4] && j == shopY[4]))
                    {
                        tile[i, j] = '◈';
                        tileInfo[i, j] = (int)Type.shop;
                        tileDanger[i, j] = (int)Danger.safe;
                    }
                    else // 일반 타일
                    {
                        tile[i, j] = '■'; ;
                        tileInfo[i, j] = rand.Next((int)Type.forest, (int)Type.flat + 1);
                        tileDanger[i, j] = rand.Next((int)Danger.safe, (int)Danger.VeryDanger + 1);
                    }
                }
            }
        }
    }
}
