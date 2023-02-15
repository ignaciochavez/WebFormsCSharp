using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class HeroeInsertDTO
    {
        public string Name { get; set; }
        public string Home { get; set; }
        public DateTimeOffset Appearance { get; set; }
        public string Description { get; set; }
        public string ImgBase64String { get; set; }

        public HeroeInsertDTO()
        {

        }

        public HeroeInsertDTO(string name, string home, DateTimeOffset appearance, string description, string imgBase64String)
        {
            Name = name;
            Home = home;
            Appearance = appearance;
            Description = description;
            ImgBase64String = imgBase64String;
        }    
    }

    public class HeroeListDTO
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public HeroeListDTO()
        {

        }

        public HeroeListDTO(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }

    public class HeroeExcelDTO
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }

        public HeroeExcelDTO()
        {

        }

        public HeroeExcelDTO(string fileName, byte[] fileContent)
        {
            FileName = fileName;
            FileContent = fileContent;
        }
    }

    public class HeroePDFDTO
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }

        public HeroePDFDTO()
        {

        }

        public HeroePDFDTO(string fileName, byte[] fileContent)
        {
            FileName = fileName;
            FileContent = fileContent;
        }
    }
}
