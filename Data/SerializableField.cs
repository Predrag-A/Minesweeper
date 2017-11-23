using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{
    [Serializable]
    public class SerializableField
    {

        #region Attributes

        int _x;
        int _y;
        int _minecount;
        Panel[,] _matrix;
        bool _firstClick;

        #endregion

        #region Properties

        [XmlElementAttribute("X Dimension")]
        public int X { get { return _x; } set { _x = value; } }

        [XmlElementAttribute("Y Dimension")]
        public int Y { get { return _y; } set { _y = value; } }

        [XmlElementAttribute("Mine Count")]
        public int Minecount { get { return _minecount; } set { _minecount = value; } }

        [XmlIgnore]
        public Panel[,] Matrix { get => _matrix; }

        [XmlArray("Matrix")]
        public Panel[][] SerializedMatrix
        {
            get {
                Panel[][] jaggedArray = new Panel[_x][];
                for(int i = 0; i < _x; i++)
                {
                    jaggedArray[i] = new Panel[_y];
                    for (int j = 0; j < _y; j++)
                        jaggedArray[i][j] = _matrix[i, j];
                
                }
                return jaggedArray;
            }

            set {
                Panel[][] jaggedArray = value;
                if (_matrix == null)
                    _matrix = new Panel[_x, _y];

                for (int i = 0; i < _x; i++){
                    for (int j = 0; j < _y; j++)
                        _matrix[i, j] = jaggedArray[i][j];
                }
            }
        }

        [XmlElementAttribute("First Click Status")]
        public bool FirstClick { get { return _firstClick; } set { _firstClick = value; } }


        #endregion

        #region Constructors

        private SerializableField()
        {

        }

        public SerializableField(int x, int y, int minecount)
        {
            _matrix = new Panel[x, y];
            X = x;
            Y = y;
            Minecount = minecount;
            FirstClick = true;
        }

        #endregion

    }
}
