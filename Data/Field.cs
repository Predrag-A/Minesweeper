//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Serialization;

//namespace Data
//{
//    [Serializable]
//    public class Field
//    {
//        //TO DO
//        int _x;
//        int _y;
//        int _minecount;
//        Panel[,] _matrix;
//        List<Panel> _mineList;
//        int _flagCount;
//        bool _firstClick;

//        [XmlIgnore]
//        public int FlagCount { get => _flagCount; set => _flagCount = value; }
//        [XmlElementAttribute("X")]
//        public int X { get => _x; }
//        [XmlElementAttribute("Y")]
//        public int Y { get => _y; }
//        [XmlElementAttribute("FirstClick")]
//        public bool FirstClick { get => _firstClick; set => _firstClick = value; }
//        [XmlElementAttribute("Minecount")]
//        public int Minecount { get => _minecount; }
//        [XmlArrayItem("Matrix", typeof(Panel))]
//        public Panel[,] Matrix { get => _matrix;}
//        [XmlIgnore]
//        public List<Panel> MineList { get => _mineList;}

//        public Field()
//        {

//        }

//        public Field(int x, int y, int minecount)
//        {
//            _matrix = new Panel[x, y];
//            _x = x;
//            _y = y;
//            _minecount = minecount;
//            _mineList = new List<Panel>();
//            _flagCount = 0;           
//            _firstClick = true;
//        }

//        public void PopulateMines()
//        {
//            Random rnd = new Random();
//            int x, y;
//            int counter = 0;
//            while (counter < Minecount)
//            {
//                x = rnd.Next(0, X);
//                y = rnd.Next(0, Y);
//                if (Matrix[x, y].Type != Data.Type.Mine)
//                {
//                    Matrix[x, y].Type = Data.Type.Mine;
//                    counter++;
//                    MineList.Add(Matrix[x, y]);
//                }
//            }
//        }


//        public List<Panel> CheckEndState()
//        {
//            foreach (var m in MineList)
//                if (!m.Flagged)
//                    return null;
//            if ((_flagCount - _minecount) != 0)
//                return null;
//            return MineList;
//        }
//    }
//}
