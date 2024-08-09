using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechsysLog.Domain.ObjectValue
{
    public class ContractResult : IContractResult
    {
        public bool Valid { get; set; } = false;
        public string Message { get; set; }
        public object Data { get; set; }
        public Exception Exception { get; set; }

        public ContractResult Valido()
        { 
            var model = new ContractResult();
            model.Valid = true;
            model.Message = "Sucesso";
            return model;
        }

        public ContractResult InValido()
        {
            var model = new ContractResult();
            model.Valid = false;
            model.Message = "Erro";
            return model;
        }
    }

    public interface IContractResult
    {
        bool Valid { get; set; }
        string Message { get; set; }
        object Data { get; set; }
        Exception Exception { get; set; }
    }
}

