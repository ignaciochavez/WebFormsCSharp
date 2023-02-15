using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Tool;

namespace Business.Service
{
    public class CheckService
    {
        private SOAPCSharpCheckService.CheckServiceSoapClient CheckServiceSoapClient { get; set; }
        private SOAPCSharpCheckService.SOAPKeyAuth SOAPKeyAuth { get; set; }

        public CheckService()
        {
            CheckServiceSoapClient = new SOAPCSharpCheckService.CheckServiceSoapClient();
        }

        public MessageVO Check()
        {
            SOAPCSharpCheckService.MessageVO check = CheckServiceSoapClient.Check();
            MessageVO messageVO = new MessageVO(check.Id, check.Title, check.Messages.ToList());
            return messageVO;
        }

        public MessageVO CheckAuth()
        {
            SOAPKeyAuth = new SOAPCSharpCheckService.SOAPKeyAuth();
            SOAPKeyAuth.Key = Useful.SOAPCSharpKey();
            SOAPCSharpCheckService.MessageVO checkAuth = CheckServiceSoapClient.CheckAuth(SOAPKeyAuth);
            MessageVO messageVO = new MessageVO(checkAuth.Id, checkAuth.Title, checkAuth.Messages.ToList());
            return messageVO;
        }
    }
}
