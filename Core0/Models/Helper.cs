using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core0.Models
{
    public  static class Helper
    {
        public static bool NameCheck(this string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length >= 3 && char.IsUpper(name[0]) && name.Split(' ').Length == 1;
        }
        public static bool SurnameCheck(this string surname)
        {
            return surname.NameCheck();
        }

        public static bool ClassNameCheck(this string classroomName)
        {
            return classroomName.Length ==5 && char.IsUpper(classroomName[0]) && char.IsUpper(classroomName[1]) && char.IsDigit(classroomName[2]) && char.IsDigit(classroomName[3] ) && char.IsDigit(classroomName[4]);
        }
    }
}
