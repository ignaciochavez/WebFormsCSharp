using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class ExampleInsertDTO
    {
        public string Rut { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }

        public ExampleInsertDTO()
        {

        }

        public ExampleInsertDTO(string rut, string name, string lastName, DateTimeOffset birthDate, bool active, string password)
        {
            Rut = rut;
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Active = active;
            Password = password;
        }
    }

    public class ExampleListDTO
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public ExampleListDTO()
        {

        }

        public ExampleListDTO(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }

    public class ExampleExcelDTO
    {        
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }

        public ExampleExcelDTO()
        {

        }

        public ExampleExcelDTO(string fileName, byte[] fileContent)
        {
            FileName = fileName;
            FileContent = fileContent;
        }
    }

    public class ExamplePDFDTO
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }

        public ExamplePDFDTO()
        {

        }

        public ExamplePDFDTO(string fileName, byte[] fileContent)
        {
            FileName = fileName;
            FileContent = fileContent;
        }
    }
}
