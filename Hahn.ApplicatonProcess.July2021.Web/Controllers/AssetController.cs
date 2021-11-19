using Hahn.ApplicatonProcess.July2021.Data.BusinessLogic;
using Hahn.ApplicatonProcess.July2021.Data.Interfaces;
using Hahn.ApplicatonProcess.July2021.Data.UnitOfWork;
using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Web.Controllers
{
    [Route("api/assets")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AssetController> _logger;
        public AssetController(IUnitOfWork unitOfWork, ILogger<AssetController> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetAsset(string id)
        {
            _logger.LogInformation("calliing Get method...");
             return await _unitOfWork.Assets.GetById(id);
        }
        [HttpPost]
        public async Task<ActionResult<Asset>> PostAsset([FromBody]Asset asset)
        {
            _logger.LogInformation("calliing Post Book method...");

            var newAsset = await _unitOfWork.Assets.Create(asset);
            return CreatedAtAction(nameof(GetAsset), new { id = newAsset.Id }, newAsset);
        }
        [HttpPut]
        public async Task<ActionResult> PutBooks(string id, [FromBody] Asset book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            await _unitOfWork.Assets.Update(book);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var book = await _unitOfWork.Assets.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            await _unitOfWork.Assets.Delete(book.Id);
            return NoContent();
        }

    }
}
