using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using AnabizFarmSales.Data;
using AnabizFarmSales.Dtos;
using AnabizFarmSales.Modals;
using Microsoft.AspNetCore.JsonPatch;

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
        // api/farmsales
        [HttpGet]
        public ActionResult<IEnumerable<AnabizFarmSalesReadDto>> GetAllSales()
        {
            var salesItems = _repository.GetAllSales();
            return Ok(_mapper.Map<IEnumerable<AnabizFarmSalesReadDto>>(salesItems));
        }

        // api/farmsales/{id}
        [HttpGet("{id}", Name = "GetSalesById")]
        public ActionResult<AnabizFarmSalesReadDto> GetSalesById(int id)
        {
            var salesItem = _repository.GetSalesById(id);

            if (salesItem != null)
            {
                return Ok(_mapper.Map<AnabizFarmSalesReadDto>(salesItem));
            }

            return NotFound();
        }

        // Post api/farmsales
        [HttpPost]
        public ActionResult<AnabizFarmSalesReadDto> CreateFarmSale(AnabizFarmSalesCreateDto AnabizFarmSalesCreateDto)
        {
            var farmsaleModel = _mapper.Map<FarmSale>(AnabizFarmSalesCreateDto);

            _repository.CreateFarmSale(farmsaleModel);
            _repository.SaveChanges();

            var farmSalesReadDto = _mapper.Map<AnabizFarmSalesReadDto>(farmsaleModel);

            return CreatedAtRoute(nameof(GetSalesById), new { Id = farmSalesReadDto.Id }, farmSalesReadDto);

            //return Ok(farmSalesReadDto);
        }

        //put api/farmsales/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateFarmsale(int id, AnabizFarmSalesUpdateDto anabizFarmSalesUpdateDto)
        {
            var anabizFarmSalesModelFromRepo = _repository.GetSalesById(id);
            if(anabizFarmSalesModelFromRepo == null)
            {
                return NotFound();
            };

            _mapper.Map(anabizFarmSalesUpdateDto, anabizFarmSalesModelFromRepo);

            _repository.UpdateFarmSale(anabizFarmSalesModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //patch api/farmsales/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialFarmSaleUpdate(int id, JsonPatchDocument<AnabizFarmSalesUpdateDto> patchDoc)
        {
            var anabizFarmSalesModelFromRepo = _repository.GetSalesById(id);
            if (anabizFarmSalesModelFromRepo == null)
            {
                return NotFound();
            };

            var farmSalePatch = _mapper.Map<AnabizFarmSalesUpdateDto>(anabizFarmSalesModelFromRepo);

            patchDoc.ApplyTo(farmSalePatch, ModelState);

            //if (TryValidateModel(farmSalePatch))
            //{
            //    return ValidationProblem(ModelState);
            //}

            _mapper.Map(farmSalePatch, anabizFarmSalesModelFromRepo);

            _repository.UpdateFarmSale(anabizFarmSalesModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //Delete api/farmsales/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteFarmSale(int id)
        {

            var anabizFarmSalesModelFromRepo = _repository.GetSalesById(id);
            if (anabizFarmSalesModelFromRepo == null)
            {
                return NotFound();
            };
            _repository.DeleteFarmSale(anabizFarmSalesModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

    }
}