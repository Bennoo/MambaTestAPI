using MambaTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MambaTestApi.Repo.Interfaces
{
    public interface IJawboneRepository
    {
        ActivityItems GetActivity();
        HeartRateItems GetHeartRates();
    }
}
