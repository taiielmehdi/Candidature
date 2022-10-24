using Candidature.Module.Helper;
using Candidature.Module.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidature.Business.Interfaces
{
    public interface IRef
    {
        Task<RESTServiceResponse<List<REFResult>>> RefNiveauEtude();
    }
}
