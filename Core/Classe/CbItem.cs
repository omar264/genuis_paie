namespace Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CbItem
    {
        #region Fields

        private string _Display;
        private int _Value;
        private short _ValueSH;
        private string _ValueST;

        #endregion Fields

        #region Constructors

        public CbItem(string display, int value)
        {
            Display = display;
            Value = value;
        }

        public CbItem(string display, short value)
        {
            Display = display;
            ValueSH = value;
        }

        public CbItem(string display, string value)
        {
            Display = display;
            ValueST = value;
        }

        #endregion Constructors

        #region Properties

        public string Display
        {
            get {return _Display;}
            set {_Display = value;}
        }

        public int Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public short ValueSH
        {
            get { return _ValueSH; }
            set { _ValueSH = value; }
        }

        public string ValueST
        {
            get { return _ValueST; }
            set { _ValueST = value; }
        }

        #endregion Properties
    }
}