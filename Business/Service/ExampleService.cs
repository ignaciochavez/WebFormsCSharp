using Business.DTO;
using Business.Entity;
using Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class ExampleService
    {
        private SOAPCSharpExampleService.ExampleServiceSoapClient ExampleServiceSoapClient { get; set; }
        private SOAPCSharpExampleService.SOAPKeyAuth SOAPKeyAuth { get; set; }
        private MessageVO MessageVO { get; set; }

        public ExampleService()
        {
            ExampleServiceSoapClient = new SOAPCSharpExampleService.ExampleServiceSoapClient();
            SOAPKeyAuth = new SOAPCSharpExampleService.SOAPKeyAuth();
            SOAPKeyAuth.Key = Useful.SOAPCSharpKey();
        }

        public Tuple<MessageVO, Example> Select(int id)
        {
            Example example = null;
            SOAPCSharpExampleService.ExampleServiceSelect exampleServiceSelect = ExampleServiceSoapClient.Select(SOAPKeyAuth, id);
            if (exampleServiceSelect.MessageVO != null)
                MessageVO = new MessageVO(exampleServiceSelect.MessageVO.Id, exampleServiceSelect.MessageVO.Title, exampleServiceSelect.MessageVO.Messages.ToList());
            else if (exampleServiceSelect.Example != null)
                example = new Example(exampleServiceSelect.Example.Id, exampleServiceSelect.Example.Rut, exampleServiceSelect.Example.Name, exampleServiceSelect.Example.LastName, DateTimeOffset.Parse(exampleServiceSelect.Example.BirthDate), exampleServiceSelect.Example.Active, exampleServiceSelect.Example.Password);

            return new Tuple<MessageVO, Example>(MessageVO, example);
        }

        public Tuple<MessageVO, Example> Insert(ExampleInsertDTO exampleInsertDTO)
        {
            Example example = null;
            SOAPCSharpExampleService.ExampleInsertDTO insert = new SOAPCSharpExampleService.ExampleInsertDTO()
            {
                Rut = exampleInsertDTO.Rut,
                Name = exampleInsertDTO.Name,
                LastName = exampleInsertDTO.LastName,
                BirthDate = exampleInsertDTO.BirthDate.ToString("o"),
                Active = exampleInsertDTO.Active,
                Password = exampleInsertDTO.Password
            };
            SOAPCSharpExampleService.ExampleServiceInsert exampleServiceInsert = ExampleServiceSoapClient.Insert(SOAPKeyAuth, insert);
            if (exampleServiceInsert.MessageVO != null)
                MessageVO = new MessageVO(exampleServiceInsert.MessageVO.Id, exampleServiceInsert.MessageVO.Title, exampleServiceInsert.MessageVO.Messages.ToList());
            else if (exampleServiceInsert.Example != null)
                example = new Example(exampleServiceInsert.Example.Id, exampleServiceInsert.Example.Rut, exampleServiceInsert.Example.Name, exampleServiceInsert.Example.LastName, DateTimeOffset.Parse(exampleServiceInsert.Example.BirthDate), exampleServiceInsert.Example.Active, exampleServiceInsert.Example.Password);

            return new Tuple<MessageVO, Example>(MessageVO, example);
        }

        public Tuple<MessageVO, bool?> Update(Example example)
        {
            bool? isUpdated = null;
            SOAPCSharpExampleService.Example update = new SOAPCSharpExampleService.Example()
            {
                Id = example.Id,
                Rut = example.Rut,
                Name = example.Name,
                LastName = example.LastName,
                BirthDate = example.BirthDate.ToString("o"),
                Active = example.Active,
                Password = example.Password
            };
            SOAPCSharpExampleService.ExampleServiceUpdate exampleServiceUpdate = ExampleServiceSoapClient.Update(SOAPKeyAuth, update);
            if (exampleServiceUpdate.MessageVO != null)
                MessageVO = new MessageVO(exampleServiceUpdate.MessageVO.Id, exampleServiceUpdate.MessageVO.Title, exampleServiceUpdate.MessageVO.Messages.ToList());
            else
                isUpdated = exampleServiceUpdate.Updated;

            return new Tuple<MessageVO, bool?>(MessageVO, isUpdated);
        }

        public Tuple<MessageVO, bool?> Delete(int id)
        {
            bool? isDeleted = null;
            SOAPCSharpExampleService.ExampleServiceDelete exampleServiceDelete = ExampleServiceSoapClient.Delete(SOAPKeyAuth, id);
            if (exampleServiceDelete.MessageVO != null)
                MessageVO = new MessageVO(exampleServiceDelete.MessageVO.Id, exampleServiceDelete.MessageVO.Title, exampleServiceDelete.MessageVO.Messages.ToList());
            else
                isDeleted = exampleServiceDelete.Delete;

            return new Tuple<MessageVO, bool?>(MessageVO, isDeleted);
        }

        public Tuple<MessageVO, List<Example>> List(ExampleListDTO exampleListDTO)
        {
            List<Example> examples = new List<Example>();
            SOAPCSharpExampleService.ExampleListDTO list = new SOAPCSharpExampleService.ExampleListDTO()
            {
                PageIndex = exampleListDTO.PageIndex,
                PageSize = exampleListDTO.PageSize
            };
            SOAPCSharpExampleService.ExampleServiceList exampleServiceList = ExampleServiceSoapClient.List(SOAPKeyAuth, list);
            if (exampleServiceList.MessageVO != null)
            {
                MessageVO = new MessageVO(exampleServiceList.MessageVO.Id, exampleServiceList.MessageVO.Title, exampleServiceList.MessageVO.Messages.ToList());
            }
            else if (exampleServiceList.Examples != null && exampleServiceList.Examples.Count() > 0)
            {
                foreach (var item in exampleServiceList.Examples)
                {
                    Example example = new Example(item.Id, item.Rut, item.Name, item.LastName, DateTimeOffset.Parse(item.BirthDate), item.Active, item.Password);
                    examples.Add(example);
                }
            }
            return new Tuple<MessageVO, List<Example>>(MessageVO, examples);
        }

        public Tuple<MessageVO, long?> TotalRecords()
        {
            long? totalRecords = null;
            SOAPCSharpExampleService.ExampleServiceTotalRecords exampleServiceTotalRecords = ExampleServiceSoapClient.TotalRecords(SOAPKeyAuth);
            if (exampleServiceTotalRecords.MessageVO != null)
                MessageVO = new MessageVO(exampleServiceTotalRecords.MessageVO.Id, exampleServiceTotalRecords.MessageVO.Title, exampleServiceTotalRecords.MessageVO.Messages.ToList());
            else
                totalRecords = exampleServiceTotalRecords.TotalRecords;

            return new Tuple<MessageVO, long?>(MessageVO, totalRecords);
        }

        public Tuple<MessageVO, ExampleExcelDTO> Excel()
        {
            ExampleExcelDTO exampleExcelDTO = null;
            SOAPCSharpExampleService.ExampleServiceExcel exampleServiceExcel = ExampleServiceSoapClient.Excel(SOAPKeyAuth);
            if (exampleServiceExcel.MessageVO != null)
                MessageVO = new MessageVO(exampleServiceExcel.MessageVO.Id, exampleServiceExcel.MessageVO.Title, exampleServiceExcel.MessageVO.Messages.ToList());
            else if (exampleServiceExcel.Excel != null)
                exampleExcelDTO = new ExampleExcelDTO(exampleServiceExcel.Excel.FileName, exampleServiceExcel.Excel.FileContent);

            return new Tuple<MessageVO, ExampleExcelDTO>(MessageVO, exampleExcelDTO);
        }

        public Tuple<MessageVO, ExamplePDFDTO> PDF()
        {
            ExamplePDFDTO examplePDFDTO = null;
            SOAPCSharpExampleService.ExampleServicePDF exampleServicePDF = ExampleServiceSoapClient.PDF(SOAPKeyAuth);
            if (exampleServicePDF.MessageVO != null)
                MessageVO = new MessageVO(exampleServicePDF.MessageVO.Id, exampleServicePDF.MessageVO.Title, exampleServicePDF.MessageVO.Messages.ToList());
            else if (exampleServicePDF.PDF != null)
                examplePDFDTO = new ExamplePDFDTO(exampleServicePDF.PDF.FileName, exampleServicePDF.PDF.FileContent);

            return new Tuple<MessageVO, ExamplePDFDTO>(MessageVO, examplePDFDTO);
        }
    }
}
