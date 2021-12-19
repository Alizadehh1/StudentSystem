using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskStudentMenu
{
    [Serializable]
    class Student
    {
        
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public string School { get; set; }
        public string Grade { get; set; }
        public Gender Gender { get; set; }
        


        public override string ToString()
        {
            return $"{Name} {SurName} / {Gender} / {Age} / {School} / {Grade}";
                
                
        }

    }
    enum Gender
    {
        Male=1,
        Female
    }
}
