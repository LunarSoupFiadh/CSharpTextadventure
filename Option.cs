﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textadventure
{
    public class Option
    {
        private OptionIdentifier _identifier;
       
        public OptionIdentifier Identifier
        {
            get { return _identifier; }
            set { _identifier = value; }
        }
        private string _optionText;

        public string OptionText
        {
            get { return _optionText; }
            set { _optionText = value; }
        }
        private string[] _nextScene;

        public string[] NextScene
        {
            get { return _nextScene; }
            set { _nextScene = value; }
        }
        public Option(OptionIdentifier Identifier, string OptionText, string[] NextScene)
        {
            this.Identifier = Identifier;
            this.OptionText = OptionText;
            this.NextScene = NextScene;
        }
    }
}