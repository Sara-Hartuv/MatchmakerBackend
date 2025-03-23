using AutoMapper.Configuration.Conventions;
using HungarianAlgorithm;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interfaces;
using Service.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HungarianAlgorithmController : ControllerBase
    {

        private readonly IHungarianAlgorithm _matchingService;

        public HungarianAlgorithmController(IHungarianAlgorithm matchingService)
        {
            _matchingService = matchingService;
        }
        // GET: api/<MachingController>
        [HttpGet("all")]
        public ActionResult<Candidate[][]> Get()
        {

            _matchingService.MatrixFilling(_matchingService.CostMatrix);
            if (_matchingService.CostMatrix == null)
            {
                return StatusCode(500, "CostMatrix is not initialized.");
            }

            Candidate[,] idAssignments = _matchingService.RunHungarianAlgorithm(_matchingService.CostMatrix);

            int rows = idAssignments.GetLength(0);
            int cols = idAssignments.GetLength(1);

            Candidate[][] jaggedArray = new Candidate[rows][];
            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new Candidate[cols];
                for (int j = 0; j < cols; j++)
                {
                    jaggedArray[i][j] = idAssignments[i, j];
                }
            }
            return Ok(jaggedArray); // מחזיר JSON תקין של מערך


        }
        [HttpGet("male")]
        public ActionResult<Candidate[][]> Get10Male()
        {

            _matchingService.MatrixFilling(_matchingService.CostMatrixMale);
            if (_matchingService.CostMatrix == null)
            {
                return StatusCode(500, "CostMatrix is not initialized.");
            }

            Candidate[,] idAssignments = _matchingService.RunHungarianAlgorithm(_matchingService.CostMatrixMale);

            int rows = idAssignments.GetLength(0);
            int cols = idAssignments.GetLength(1);

            Candidate[][] jaggedArray = new Candidate[rows][];
            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new Candidate[cols];
                for (int j = 0; j < cols; j++)
                {
                    jaggedArray[i][j] = idAssignments[i, j];
                }
            }
            return Ok(jaggedArray); // מחזיר JSON תקין של מערך


        }
        [HttpGet("female")]
        public ActionResult<Candidate[][]> Get10Female()
        {

            _matchingService.MatrixFilling(_matchingService.CostMatrixFemale);
            if (_matchingService.CostMatrix == null)
            {
                return StatusCode(500, "CostMatrix is not initialized.");
            }

            Candidate[,] idAssignments = _matchingService.RunHungarianAlgorithm(_matchingService.CostMatrixFemale);

            int rows = idAssignments.GetLength(0);
            int cols = idAssignments.GetLength(1);

            Candidate[][] jaggedArray = new Candidate[rows][];
            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new Candidate[cols];
                for (int j = 0; j < cols; j++)
                {
                    jaggedArray[i][j] = idAssignments[i, j];
                }
            }
            return Ok(jaggedArray); // מחזיר JSON תקין של מערך


        }

    }
}
