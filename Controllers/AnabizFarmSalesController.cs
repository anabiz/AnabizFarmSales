using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using AnabizFarmSales.Data;
using AnabizFarmSales.Dtos;
using AnabizFarmSales.Modals;

namespace AnabizFarmSales.Controllers
{
    //api commands
    [Route("apiv1/farmsales")]
    [ApiController]
    public class AnabizFarmSalesController : ControllerBase
    {
        private readonly IAnabizFarmSalesRepo _repository;
        private readonly IMapper _mapper;

        public AnabizFarmSalesController(IAnabizFarmSalesRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        // api/commands
        [HttpGet]
        public ActionResult<IEnumerable<AnabizFarmSalesReadDto>> GetAllSales()
        {
            var salesItems = _repository.GetAllSales();
            return Ok(_mapper.Map<IEnumerable<AnabizFarmSalesReadDto>>(salesItems));
        }

        // api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<AnabizFarmSalesReadDto> GetSalesById(int id)
        {
            var salesItem = _repository.GetSalesById(id);

            if (salesItem != null)
            {
                return Ok(_mapper.Map<AnabizFarmSalesReadDto>(salesItem));
            }

            return NotFound();
        }

       // Post api/commands
                 [HttpPost]
                 public ActionResult<AnabizFarmSalesReadDto> CreateFarmSale(AnabizFarmSalesCreateDto AnabizFarmSalesCreateDto)
        {
            var farmsaleModel = _mapper.Map<FarmSale>(AnabizFarmSalesCreateDto);

            _repository.CreateFarmSale(farmsaleModel);
            _repository.SaveChanges();

            return Ok(farmsaleModel);
        }

    }
}