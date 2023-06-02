using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Dtos.General
{
    public class GeneralResponse
    {
        public string Message { get; set; }
        public GeneralResponse(string msg) 
        { 
            Message = msg;
        }
    }
}
