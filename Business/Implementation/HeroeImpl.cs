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
    public static class HeroeImpl
    {
        public static Tuple<MessageVO, Heroe> Select(int id)
        {
            return new HeroeService().Select(id);
        }

        public static Tuple<MessageVO, Heroe> Insert(HeroeInsertDTO heroeInsertDTO)
        {
            return new HeroeService().Insert(heroeInsertDTO);
        }

        public static Tuple<MessageVO, bool?> Update(Heroe heroe)
        {
            return new HeroeService().Update(heroe);
        }

        public static Tuple<MessageVO, bool?> Delete(int id)
        {
            return new HeroeService().Delete(id);
        }

        public static Tuple<MessageVO, List<Heroe>> List(HeroeListDTO heroeListDTO)
        {
            return new HeroeService().List(heroeListDTO);
        }

        public static Tuple<MessageVO, long?> TotalRecords()
        {
            return new HeroeService().TotalRecords();
        }

        public static Tuple<MessageVO, HeroeExcelDTO> Excel()
        {
            return new HeroeService().Excel();
        }

        public static Tuple<MessageVO, HeroePDFDTO> PDF()
        {
            return new HeroeService().PDF();
        }
    }
}
