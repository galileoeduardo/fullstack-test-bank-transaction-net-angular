using Bank.Data.Repositories;
using Bank.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IRepository<TransactionEntity> _transactionRepository;

        public TransactionController(IRepository<TransactionEntity> repository)
        {
                _transactionRepository = repository;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                var result = await _transactionRepository.SelectAsync();
                return Results.Ok(result);
            }
            catch (Exception e)
            {
                var errors = (e.Data.Count > 0) ?
                e.Data :
                new Dictionary<string, string>
                {
                    {"Source", (e.Source == null) ? "Empty" : e.Source },
                    {"Message", e.Message }
                };

                return Results.Json(errors, null, "application/json", 500);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                var result = await _transactionRepository.SelectAsync(id);
                if(result == null)
                    return Results.NotFound();
                
                return Results.Ok(result);
            }
            catch (Exception e)
            {

                var errors = (e.Data.Count > 0) ?
                e.Data :
                new Dictionary<string, string>
                {
                    {"Source", (e.Source == null) ? "Empty" : e.Source },
                    {"Message", e.Message }
                };

                return Results.Json(errors, null, "application/json", 500);
            }
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] TransactionEntity record)
        {
            try
            {
                var result = await _transactionRepository.InsertAsync(record);
                if(result == null)
                    return Results.Empty;

                return Results.Created($"/api/transaction/{record.Id}",result);

            }
            catch (Exception e)
            {

                var errors = (e.Data.Count > 0) ?
                e.Data :
                new Dictionary<string, string>
                {
                    {"Source", (e.Source == null) ? "Empty" : e.Source },
                    {"Message", e.Message }
                };

                return Results.Json(errors, null, "application/json", 500);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] TransactionEntity record)
        {
            try
            {
                var result = await _transactionRepository.UpdateAsync(id, record);
                if (result == null)
                    return Results.Empty; 
                
                return Results.Ok(result);

            }
            catch (Exception e)
            {

                var errors = (e.Data.Count > 0) ?
                e.Data :
                new Dictionary<string, string>
                {
                    {"Source", (e.Source == null) ? "Empty" : e.Source },
                    {"Message", e.Message }
                };

                return Results.Json(errors, null, "application/json", 500);
            }
            
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var result = await _transactionRepository.DeleteAsync(id);
                if (result)
                {
                    return Results.NoContent();
                }
                else { 
                    return Results.NotFound();
                }
                    
            }
            catch (Exception e)
            {

                var errors = (e.Data.Count > 0) ?
                 e.Data :
                 new Dictionary<string, string>
                 {
                    {"Source", (e.Source == null) ? "Empty" : e.Source },
                    {"Message", e.Message }
                 };

                return Results.Json(errors, null, "application/json", 500);
            }
            
        }
    }
}
