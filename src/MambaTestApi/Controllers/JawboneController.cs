using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MambaTestApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MambaTestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class JawboneController : Controller
    {
        private readonly MambaTestApi.Repo.Interfaces.IJawboneRepository _repo;

        public JawboneController(Repo.Interfaces.IJawboneRepository repo)
        {
            _repo = repo;
        }
        // GET: api/values
        [HttpGet]
        public string GetActivity()
        {
            return _repo.GetActivity().content;
        }        
        [HttpGet]
        public HeartRateItems GetHeartRate()
        {
            //return _repo.GetHeartRates().content;
            return _repo.GetHeartRates();
        }


    }
}
