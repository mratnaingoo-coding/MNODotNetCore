using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MNODotNetCore.RestAPIwithNLayer.Features.MyanmarProverbs;

[Route("api/[controller]")]
[ApiController]
public class MyanmarProverbsController : ControllerBase
{
    private async Task<Tbl_MMProverbsResponse> GetDataFromAPI()
    {
        /*HttpClient client = new HttpClient();
        var response = await client.GetAsync("https://raw.githubusercontent.com/sannlynnhtun-coding/Myanmar-Proverbs/main/MyanmarProverbs.json");
        if (!response.IsSuccessStatusCode) return null;

        string jsonStr = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<Tbl_MMProverbs>(jsonStr);
        return model!;*/

        var jsonStr = await System.IO.File.ReadAllTextAsync("BurmaProvs.json");
        var model = JsonConvert.DeserializeObject<Tbl_MMProverbsResponse>(jsonStr);
        return model!;

    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var model = await GetDataFromAPI();
        return Ok(model.Tbl_MMProverbsTitle);
    }
    // Proverbs Details
    /*[HttpGet("{titleName}")]
    public async Task<IActionResult> Get(string titleName)
    {
        var model = await GetDataFromAPI();
        var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
        if (item is null)
        {
            return NotFound("No data was found.");
        };

        var titleId = item.TitleId;
        var lst = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);
        return Ok(lst);
    }*/

    // Proverbs Headonly
    [HttpGet("{titleName}")]
    public async Task<IActionResult> GetHead(string titleName)
    {
        var model = await GetDataFromAPI();
        var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
        if (item is null)
        {
            return NotFound("No data was found.");
        };

        var titleId = item.TitleId;
        var result = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);

        List<Tbl_MmproverbsHead> lst = result.Select(x => new Tbl_MmproverbsHead
        {
            TitleId = x.TitleId,
            ProverbId = x.ProverbId,
            ProverbName = x.ProverbName
        }).ToList();
        return Ok(lst);
    }
    
    [HttpGet("{titleId}/{proverbId}")]
    public async Task<IActionResult> GetDetails(int titleId, int proverbId)
    {
        var model = await GetDataFromAPI();
        var item = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId && x.ProverbId == proverbId);

        return Ok(item);
    }

}



public class Tbl_MMProverbsResponse
{
    public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
    public Tbl_MmproverbsDetails[] Tbl_MMProverbs { get; set; }
   
}

public class Tbl_Mmproverbstitle
{
    public int TitleId { get; set; }
    public string TitleName { get; set; }
}

public class Tbl_MmproverbsDetails
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
    public string ProverbDesp { get; set; } 
}

public class Tbl_MmproverbsHead
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
}





