using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class ResultAPIModel
    {
        public ResultAPIModel()
        {
            _ok = true;
            _error = "";
        }
         bool _ok { get; set; }
         string _error { get; set; }
        int _clienteId { get; set; }

        public bool ok { get { return _ok; } set { _ok = value; } }
        public string error { get { return _error; }
                set {
                _error = value;
                if(_error != "")
                {
                    _ok = false;
                }
                else
                {
                    _ok = true;
                }
            } }

        public int clienteId { get { return _clienteId; } set { _clienteId = value; } }
    }
}
