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
    [Produces("application/json")]
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
        /// <summary>
        /// return an Asset with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>the specific Asset with the given id </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetAsset(string id)
        {
            _logger.LogInformation("calliing Get method...");
             return await _unitOfWork.Assets.GetById(id);
        }
        /// <summary>
        /// create an new Asset  
        /// </summary>
        /// <param name="asset"></param>
        /// <returns>return the created asset</returns>
        [HttpPost]
        public async Task<ActionResult<Asset>> PostAsset([FromBody]Asset asset)
        {
            _logger.LogInformation("calliing Post Book method...");

            var newAsset = await _unitOfWork.Assets.Create(asset);
            return CreatedAtAction(nameof(GetAsset), new { id = newAsset.Id }, newAsset);
        }
        /// <summary>
        /// update an Asset if changes 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="asset"></param>
        /// <returns>return the updated asset</returns>
        [HttpPut]
        public async Task<ActionResult> PutBooks(string id, [FromBody] Asset asset)
        {
            if (id != asset.Id)
            {
                return BadRequest();
            }
            await _unitOfWork.Assets.Update(asset);
            return NoContent();
        }
        /// <summary>
        /// delete an asset
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return if deletion is successful</returns>
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
