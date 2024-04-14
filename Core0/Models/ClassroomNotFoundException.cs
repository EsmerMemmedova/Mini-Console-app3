using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core0.Models
{
    public class ClassroomNotFoundException:Exception
    {
        public ClassroomNotFoundException(string message):base(message)
        {
               
        }
    }
}
