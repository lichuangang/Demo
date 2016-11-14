using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class HxResult
    {
        public HxResult() { Success = true; }

        public HxResult(string msg)
        {
            Success = false;
            Msg = msg;
        }

        public bool Success { get; set; }

        public string _msg;

        public string Msg
        {
            get { return _msg; }
            set
            {
                _msg = value;
                Success = false;
            }
        }

        public object Data { get; set; }
    }
}
