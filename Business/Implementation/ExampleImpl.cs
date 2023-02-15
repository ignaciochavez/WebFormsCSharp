using Business.DTO;
using Business.Entity;
using Business.Service;
using Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public static class ExampleImpl
    {
        public static Tuple<MessageVO, Example> Select(int id)
        {
            return new ExampleService().Select(id);
        }
        
        public static Tuple<MessageVO, Example> Insert(ExampleInsertDTO exampleInsertDTO)
        {          
            return new ExampleService().Insert(exampleInsertDTO);
        }

        public static Tuple<MessageVO, bool?> Update(Example example)
        {
            return new ExampleService().Update(example);
        }

        public static Tuple<MessageVO, bool?> Delete(int id)
        {
            return new ExampleService().Delete(id);
        }

        public static Tuple<MessageVO, List<Example>> List(ExampleListDTO exampleListDTO)
        {
            return new ExampleService().List(exampleListDTO);
        }

        public static Tuple<MessageVO, long?> TotalRecords()
        {
            return new ExampleService().TotalRecords();
        }

        public static Tuple<MessageVO, ExampleExcelDTO> Excel()
        {
            return new ExampleService().Excel();
        }

        public static Tuple<MessageVO, ExamplePDFDTO> PDF()
        {
            return new ExampleService().PDF();
        }
    }
}
