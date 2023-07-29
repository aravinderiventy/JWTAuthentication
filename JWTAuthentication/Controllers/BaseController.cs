/// <summary>
    /// Default Controller Settings
    /// Services are registered in the <see cref="Startup.ConfigureServices(IServiceCollection)"/>
    /// </summary>
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        private IConfiguration configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public BaseController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Handles the responses
        /// </summary>
        /// <typeparam name="T">DTO to return</typeparam>
        /// <param name="result">Detailed Status codes reponses</param>
        /// <returns></returns>
        protected IActionResult ProcessResult<T>(Result<T> result)
        {
            switch (result.Status)
            {
                case StatusTypeEnum.NotFound:
                    return NotFound();

                case StatusTypeEnum.Failed:
                    if (string.IsNullOrEmpty(result.Message))
                    {
                        return BadRequest();
                    }
                    else
                    {
                        return BadRequest(result.Message);
                    }

                case StatusTypeEnum.Forbidden:
                    return Forbid();

                case StatusTypeEnum.Unauthorized:
                    return Unauthorized();

                case StatusTypeEnum.Created:
                    if (result.Uri != null)
                    {
                        return Created(result.Uri, result.Entity);
                    }
                    else
                    {
                        return Created(result.Message ?? "", result.Entity);
                    }

                case StatusTypeEnum.Ok:
                    return Ok(result.Entity);

                default:
                    return StatusCode(500);
            }
        }
    }
