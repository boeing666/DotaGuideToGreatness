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
        NotFound = 404,
        GeneralError = 400,
        ServerException = 500
    }
}
