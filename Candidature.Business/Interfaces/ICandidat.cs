using Candidature.Module.Helper;
using Candidature.Module.Modules;
using Candidature.Module.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidature.Business.Interfaces
{
    public interface ICandidat
    {
        Task<RESTServiceResponse<bool>> Add(CandidatModule model);
        Task<RESTServiceResponse<bool>> Delete(CandidatModule model);
        Task<RESTServiceResponse<List<CandidatModule>>> Get(string Keyword);
    }
}
