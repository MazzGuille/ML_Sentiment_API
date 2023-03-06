using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using static MLAPI.MLModel;

namespace MLAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentimentController : ControllerBase
    {
       

        [HttpPost]
        public ActionResult<string> Get(PredictionEnginePool<MLModel.ModelInput, MLModel.ModelOutput> predictionEnginePool, MLModel.ModelInput input)
        {
           var answer = string.Empty;
           var data = predictionEnginePool.Predict(input);

            if(data.PredictedLabel == 0)
            {
                answer = "Positive";
            }
            else
            {
                answer = "Negative";
            }

            return answer;
        }
    }
}
