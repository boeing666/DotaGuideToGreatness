using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.Domain.Enums
{
    public enum StatusCodes
    {
        Success = 200,
        GeneralError = 400,
        FailedToSave = 401,
        NotFound = 404,
        ServerException = 500
    }
}
