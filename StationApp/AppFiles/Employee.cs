//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StationApp.AppFiles
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public int WorkExperience { get; set; }
        public int IdBrigade { get; set; }
        public int IdDepartment { get; set; }
    
        public virtual Brigade Brigade { get; set; }
        public virtual Department Department { get; set; }
    }
}
