using System;
using System.Xml.Serialization;

namespace Data
{
    [Serializable]
    public class SerializableField
    {

        #region Fields

        int _x;
        int _y;
        int _minecount;
        bool _firstClick;

        #endregion

        #region Properties

        [XmlElement("X Dimension")]
        public int X { get => _x; set => _x = value; }

        [XmlElement("Y Dimension")]
        public int Y { get => _y; set => _y = value; }

        [XmlElement("Mine Count")]
        public int Minecount { get => _minecount; set => _minecount = value; }

        [XmlIgnore]
        public Panel[,] Matrix { get; private set; }

        [XmlArray("Matrix")]
        public Panel[][] SerializedMatrix
        {
            get {
                var jaggedArray = new Panel[_x][];
                for(var i = 0; i < _x; i++)
                {
                    jaggedArray[i] = new Panel[_y];
                    for (var j = 0; j < _y; j++)
                        jaggedArray[i][j] = Matrix[i, j];
                
                }
                return jaggedArray;
            }

            set {
                var jaggedArray = value;
                if (Matrix == null)
                    Matrix = new Panel[_x, _y];

                for (var i = 0; i < _x; i++){
                    for (var j = 0; j < _y; j++)
                        Matrix[i, j] = jaggedArray[i][j];
                }
            }
        }

        [XmlElement("First Click Status")]
        public bool FirstClick { get => _firstClick; set => _firstClick = value; }


        #endregion

        #region Constructors

        //Helper class which allows XML Serialization.
        private SerializableField()
        {

        }

        public SerializableField(int x, int y, int minecount)
        {
            Matrix = new Panel[x, y];
            X = x;
            Y = y;
            Minecount = minecount;
            FirstClick = true;
        }

        #endregion

    }
}
