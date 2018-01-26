using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MSS.DMSS.WebService.Scenarios
{
    public class ConvertAndSaveWordDocScenario : IScenario
    {
        IConverterService _csrv;

        public ConvertAndSaveWordDocScenario(IConverterService converter)
        {
            _csrv = converter;
        }

        public bool Run(object doc)
        {
            _csrv.Convert(doc);
            return false;
        }

        public Task<bool> RunAsync()
        {
            return Task.FromResult(false);
        }
    }
}