using System;
using System.Xml.Serialization;

namespace Data
{
    [Serializable]
    public class Panel
    {

        #region Fields

        Type _type;
        int _value;
        bool _revealed;
        bool _flagged;

        #endregion

        #region Properties

        [XmlElement("Panel Type")]
        public Type Type { get => _type; set => _type = value; }

        [XmlElement("Neighboring Mine Count")]
        public int Value { get => _value; set => _value = value; }

        [XmlElement("Revealed Status")]
        public bool Revealed { get => _revealed; set => _revealed = value; }

        [XmlElement("Flagged Status")]
        public bool Flagged { get => _flagged; set => _flagged = value; }

        #endregion

        #region Constructors

        //Class used to store info about the type, value and statuses of a cell.
        public Panel()
        {
            _type = Type.Empty;
            _value = 0;
            _revealed = false;
            _flagged = false;
        }

        public Panel(Type type)
        {
            _type = type;
            _value = 0;
            _revealed = false;
            _flagged = false;
        }

        public Panel(Type type, int value)
        {
            _type = type;
            _value = value;
            _revealed = false;
            _flagged = false;
        }

        public Panel(Type type, int value, bool revealed, bool flagged)
        {
            _type = type;
            _value = value;
            _revealed = revealed;
            _flagged = flagged;
        }

        #endregion
        
    }
}
