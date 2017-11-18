using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class Matrix
    {
        Panel[][] _matrix;
        int _x;
        int _y;

        Matrix(int x, int y)
        {
            _x = x;
            _y = y;
            _matrix = new Panel[x][y];
        }

        void addMines(int count)
        {
            Random rnd = new Random();
            int i = 0;
            int x, y;

            while (i < count)
            {
                x = rnd.Next(0, _x);
                y = rnd.Next(0, y);
                if (_matrix[x][y].Type != Type.Mine)
                {
                    _matrix[x][y].Type = Type.Mine;
                    i++;
                }
            }
        }

        void setNumbers()
        {
            for(int i=0; i<_x; i++)
                for(int j=0; j<_y; j++)
                {
                    int count = 0;
                                        
                    if (_matrix[i][j].Type == Type.Mine)
                        count++;

                }
        }
        
    }
}
