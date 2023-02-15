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
    public class HeroeService
    {
        public SOAPCSharpHeroeService.HeroeServiceSoapClient HeroeServiceSoapClient { get; set; }
        public SOAPCSharpHeroeService.SOAPKeyAuth SOAPKeyAuth { get; set; }
        public MessageVO MessageVO { get; set; }

        public HeroeService()
        {
            HeroeServiceSoapClient = new SOAPCSharpHeroeService.HeroeServiceSoapClient();
            SOAPKeyAuth = new SOAPCSharpHeroeService.SOAPKeyAuth();
            SOAPKeyAuth.Key = Useful.SOAPCSharpKey();
        }

        public Tuple<MessageVO, Heroe> Select(int id)
        {
            Heroe heroe = null;
            SOAPCSharpHeroeService.HeroeServiceSelect heroeServiceSelect = HeroeServiceSoapClient.Select(SOAPKeyAuth, id);
            if (heroeServiceSelect.MessageVO != null)
                MessageVO = new MessageVO(heroeServiceSelect.MessageVO.Id, heroeServiceSelect.MessageVO.Title, heroeServiceSelect.MessageVO.Messages.ToList());
            else if (heroeServiceSelect != null)
                heroe = new Heroe(heroeServiceSelect.Heroe.Id, heroeServiceSelect.Heroe.Name, heroeServiceSelect.Heroe.Home, DateTimeOffset.Parse(heroeServiceSelect.Heroe.Appearance), heroeServiceSelect.Heroe.Description, heroeServiceSelect.Heroe.ImgBase64String);

            return new Tuple<MessageVO, Heroe>(MessageVO, heroe);
        }

        public Tuple<MessageVO, Heroe> Insert(HeroeInsertDTO heroeInsertDTO)
        {
            Heroe heroe = null;
            SOAPCSharpHeroeService.HeroeInsertDTO insert = new SOAPCSharpHeroeService.HeroeInsertDTO()
            {
                Name = heroeInsertDTO.Name,
                Home = heroeInsertDTO.Home,
                Appearance = heroeInsertDTO.Appearance.ToString("o"),
                Description = heroeInsertDTO.Description
            };
            SOAPCSharpHeroeService.HeroeServiceInsert heroeServiceInsert = HeroeServiceSoapClient.Insert(SOAPKeyAuth, insert);
            if (heroeServiceInsert.MessageVO != null)
                MessageVO = new MessageVO(heroeServiceInsert.MessageVO.Id, heroeServiceInsert.MessageVO.Title, heroeServiceInsert.MessageVO.Messages.ToList());
            else if (heroeServiceInsert != null)
                heroe = new Heroe(heroeServiceInsert.Heroe.Id, heroeServiceInsert.Heroe.Name, heroeServiceInsert.Heroe.Home, DateTimeOffset.Parse(heroeServiceInsert.Heroe.Appearance), heroeServiceInsert.Heroe.Description, heroeServiceInsert.Heroe.ImgBase64String);

            return new Tuple<MessageVO, Heroe>(MessageVO, heroe);
        }

        public Tuple<MessageVO, bool?> Update(Heroe heroe)
        {
            bool? isUpdate = null;
            SOAPCSharpHeroeService.Heroe update = new SOAPCSharpHeroeService.Heroe()
            {
                Id = heroe.Id,
                Name = heroe.Name,
                Home = heroe.Home,
                Appearance = heroe.Appearance.ToString("o"),
                Description = heroe.Description,
                ImgBase64String = heroe.ImgBase64String
            };
            SOAPCSharpHeroeService.HeroeServiceUpdate heroeServiceUpdate = HeroeServiceSoapClient.Update(SOAPKeyAuth, update);
            if (heroeServiceUpdate.MessageVO != null)
                MessageVO = new MessageVO(heroeServiceUpdate.MessageVO.Id, heroeServiceUpdate.MessageVO.Title, heroeServiceUpdate.MessageVO.Messages.ToList());
            else
                isUpdate = heroeServiceUpdate.Update;

            return new Tuple<MessageVO, bool?>(MessageVO, isUpdate);
        }

        public Tuple<MessageVO, bool?> Delete(int id)
        {
            bool? isDelete = null;
            SOAPCSharpHeroeService.HeroeServiceDelete heroeServiceDelete = HeroeServiceSoapClient.Delete(SOAPKeyAuth, id);
            if (heroeServiceDelete.MessageVO != null)
                MessageVO = new MessageVO(heroeServiceDelete.MessageVO.Id, heroeServiceDelete.MessageVO.Title, heroeServiceDelete.MessageVO.Messages.ToList());
            else
                isDelete = heroeServiceDelete.Delete;

            return new Tuple<MessageVO, bool?>(MessageVO, isDelete);
        }

        public Tuple<MessageVO, List<Heroe>> List(HeroeListDTO heroeListDTO)
        {
            List<Heroe> heroes = new List<Heroe>();
            SOAPCSharpHeroeService.HeroeListDTO list = new SOAPCSharpHeroeService.HeroeListDTO()
            {
                PageIndex = heroeListDTO.PageIndex,
                PageSize = heroeListDTO.PageSize
            };
            SOAPCSharpHeroeService.HeroeServiceList heroeServiceList = HeroeServiceSoapClient.List(SOAPKeyAuth, list);
            if (heroeServiceList.MessageVO != null)
            {
                MessageVO = new MessageVO(heroeServiceList.MessageVO.Id, heroeServiceList.MessageVO.Title, heroeServiceList.MessageVO.Messages.ToList());
            }
            else if (heroeServiceList.Heroes != null && heroeServiceList.Heroes.Count() > 0)
            {
                foreach (var item in heroeServiceList.Heroes)
                {
                    Heroe heroe = new Heroe(item.Id, item.Name, item.Home, DateTimeOffset.Parse(item.Appearance), item.Description, item.ImgBase64String);
                    heroes.Add(heroe);
                }
            }
            return new Tuple<MessageVO, List<Heroe>>(MessageVO, heroes);
        }

        public Tuple<MessageVO, long?> TotalRecords()
        {
            long? totalRecords = null;
            SOAPCSharpHeroeService.HeroeServiceTotalRecords heroeServiceTotalRecords = HeroeServiceSoapClient.TotalRecords(SOAPKeyAuth);
            if (heroeServiceTotalRecords.MessageVO != null)
                MessageVO = new MessageVO(heroeServiceTotalRecords.MessageVO.Id, heroeServiceTotalRecords.MessageVO.Title, heroeServiceTotalRecords.MessageVO.Messages.ToList());
            else
                totalRecords = heroeServiceTotalRecords.TotalRecords;

            return new Tuple<MessageVO, long?>(MessageVO, totalRecords);
        }

        public Tuple<MessageVO, HeroeExcelDTO> Excel()
        {
            HeroeExcelDTO heroeExcelDTO = null;
            SOAPCSharpHeroeService.HeroeServiceExcel heroeServiceExcel = HeroeServiceSoapClient.Excel(SOAPKeyAuth);
            if (heroeServiceExcel.MessageVO != null)
                MessageVO = new MessageVO(heroeServiceExcel.MessageVO.Id, heroeServiceExcel.MessageVO.Title, heroeServiceExcel.MessageVO.Messages.ToList());
            else if (heroeServiceExcel.Excel != null)
                heroeExcelDTO = new HeroeExcelDTO(heroeServiceExcel.Excel.FileName, heroeServiceExcel.Excel.FileContent);

            return new Tuple<MessageVO, HeroeExcelDTO>(MessageVO, heroeExcelDTO);
        }

        public Tuple<MessageVO, HeroePDFDTO> PDF()
        {
            HeroePDFDTO heroePDFDTO = null;
            SOAPCSharpHeroeService.HeroeServicePDF heroeServicePDF = HeroeServiceSoapClient.PDF(SOAPKeyAuth);
            if (heroeServicePDF.MessageVO != null)
                MessageVO = new MessageVO(heroeServicePDF.MessageVO.Id, heroeServicePDF.MessageVO.Title, heroeServicePDF.MessageVO.Messages.ToList());
            else if (heroeServicePDF.PDF != null)
                heroePDFDTO = new HeroePDFDTO(heroeServicePDF.PDF.FileName, heroeServicePDF.PDF.FileContent);

            return new Tuple<MessageVO, HeroePDFDTO>(MessageVO, heroePDFDTO);
        }
    }
}
