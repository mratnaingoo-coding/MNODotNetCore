using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MNODotNetCore.RestAPIwithNLayer.Features.Birds
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {

        private async Task<Birds> GetDataAsync()
        {

            string jsonTest = await System.IO.File.ReadAllTextAsync("Birds.json");
            var model = JsonConvert.DeserializeObject<Birds>(jsonTest);
            return model;
        }
        // api/Birds/types
        [HttpGet("tbl_bird")]
        public async Task<IActionResult> GetBirds()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_Bird);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> TypeOfBirds(int id)
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_Bird.FirstOrDefault(x => x.Id == id));
        }

    }


    public class Birds
    {
        public Tbl_Bird[] Tbl_Bird { get; set; }
    }

    public class Tbl_Bird
    {
        public int Id { get; set; }
        public string BirdMyanmarName { get; set; }
        public string BirdEnglishName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }

}
