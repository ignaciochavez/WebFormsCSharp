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
    public static class CheckImpl
    {
        public static MessageVO Check()
        {
            return new CheckService().Check();
        }

        public static MessageVO CheckAuth()
        {
            return new CheckService().CheckAuth();
        }
    }
}
