using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.SageMaker.Internal;
//using Amazon.Lambda.Serialization.Json;
using Newtonsoft.Json;
using Amazon.SageMaker.Model;
using Belcorp.ML.Entity.Response;
using Belcorp.ML.Entity.Request;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Belcorp.ML.Lambda
{
    public class Functions
    {
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public Functions()
        {
        }

        public APIGatewayProxyResponse ValidateUser(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");
            var resp = request.Body;
            if (string.IsNullOrEmpty(resp))
            {
                return RetornaBadRequest("Debe enviar contenido en el Body");
            }

            ValidateUserReq createTrainingJobReq = JsonConvert.DeserializeObject<ValidateUserReq>(resp);
            context.Logger.LogLine("Req " + resp);

            ValidateUserRes createTrainingJobRes = new ValidateUserRes();
            createTrainingJobRes.Token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI3MWNlNWUwYi1kMzViLTQ5NDUtYWNhNy1hMzA4Y2I5MzhjNGUiLCJ1c2VybmFtZSI6InRlc3QiLCJ0b2tlbl91c2UiOiJhY2Nlc3MiLCJpc3MiOiJodHRwczovL2NvZ25pdG8taWRwLnVzLWVhc3QtMS5hbWF6b25hd3MuY29tL3VzLWVhc3QtMV9lWEY2T1B3NDUiLCJpYXQiOjE1MzcxOTgzNjAsIm5iZiI6MTUzNzE5ODM2MCwiZXhwIjoxNTM3MjAxOTYwLCJqdGkiOiI2ZGUyNzA5ZjlmNGQ0MmZkYTFiOTE5Y2JlZDBkNjA4NCJ9.QMddu_77AUR7kn0TBwpDKJoVH7QOcLCOR9nlbRledNma7zSIqISFWHQsDXg0IaLnhkruCUsILwxg4fg9KFSyIckk_xb75YgOdVcgbR1CV_kHRiNJcRn42HmORFqf_AzFCOqTGSpjMWTtAOqRfFLr0sIIu8tHx5ogj6_sT-1I7L8urTNgDRlsd1SGn_Xt1UVQkSgQ-PUCnxf7sdFSOq6jvOpH44uTTLsP3g9TxAQyMkpJGWLwcMqXQlS1N8SlG-xzlTIoKN7Kz5TA73F7C9z1Wifg_A2SrOKY1OdN6F6K-hQK2t2D4fMXQWyhXUqoXEaWq_dROgfL1oi0Mlm2LGFPDw";

            //return RetornaOk<CreateTrainingJobRes>(createTrainingJobRes);
            return RetornaOk(createTrainingJobRes);
        }


        
        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The list of blogs</returns>
        public APIGatewayProxyResponse CreateTrainingJob(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");
            var resp = request.Body;
            if (string.IsNullOrEmpty(resp))
            {
                return RetornaBadRequest("Debe enviar contenido en el Body CreateTrainingJob");
            }

            CreateTrainingJobReq createTrainingJobReq = JsonConvert.DeserializeObject<CreateTrainingJobReq>(resp);
            context.Logger.LogLine("Req " + resp);

            CreateTrainingJobRes createTrainingJobRes = new CreateTrainingJobRes();
            createTrainingJobRes.BankId = createTrainingJobReq.BankId;

            //return RetornaOk<CreateTrainingJobRes>(createTrainingJobRes);
            return RetornaOk(createTrainingJobRes);
        }

        public APIGatewayProxyResponse GetStatusTraining(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");
            var resp = request.Body;
            if (string.IsNullOrEmpty(resp))
            {
                return RetornaBadRequest("Debe enviar contenido en el Body");
            }

            GetStatusTrainingReq createTrainingJobReq = JsonConvert.DeserializeObject<GetStatusTrainingReq>(resp);
            context.Logger.LogLine("Req " + resp);

            GetStatusTrainingRes createTrainingJobRes = new GetStatusTrainingRes();
            createTrainingJobRes.Status = "COMPLETED";

            //return RetornaOk<CreateTrainingJobRes>(createTrainingJobRes);
            return RetornaOk(createTrainingJobRes);
        }


        public APIGatewayProxyResponse PredictionData(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");
            var resp = request.Body;

            if (string.IsNullOrEmpty(resp))
            {
                return RetornaBadRequest("Debe enviar contenido en el Body");
            }
            context.Logger.LogLine("request " + resp);
            PredictionDataReq predictionDataReq = JsonConvert.DeserializeObject<PredictionDataReq>(resp);


            PredictionDataRes predictionDataRes = new PredictionDataRes();
            predictionDataRes.OutputDataFile = predictionDataReq.OutputDataConfig;

            //return RetornaOk<CreateTrainingJobRes>(createTrainingJobRes);
            return RetornaOk(predictionDataRes);
        }

        public APIGatewayProxyResponse GetStatusPrediction(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");
            var resp = request.Body;

            if (string.IsNullOrEmpty(resp))
            {
                return RetornaBadRequest("Debe enviar contenido en el Body");
            }
            context.Logger.LogLine("request " + resp);
            GetStatusPredictionReq predictionDataReq = JsonConvert.DeserializeObject<GetStatusPredictionReq>(resp);


            GetStatusPredictionRes predictionDataRes = new GetStatusPredictionRes();
            predictionDataRes.Status = "COMPLETED";

            //return RetornaOk<CreateTrainingJobRes>(createTrainingJobRes);
            return RetornaOk(predictionDataRes);
        }


        #region Utilitarios

        internal APIGatewayProxyResponse RetornaOk<T>(T data)
        {
            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Body = JsonConvert.SerializeObject(data),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }

        internal APIGatewayProxyResponse RetornaBadRequest(string message)
        {
            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Body = message,
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }


        #endregion


        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The list of blogs</returns>
        public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            if (request != null && request.RequestContext != null)
            {
                context.Logger.LogLine("Get Path " + request.Path);

                context.Logger.LogLine("Get ResourcePath " + request.RequestContext.ResourcePath);
                context.Logger.LogLine("Get RequestContext.Path " + request.RequestContext.Path);

                switch (request.RequestContext.Path)
                {
                    case "/ml/createtrainingjob":
                        return CreateTrainingJob(request, context);
                    case "/ml/predictiondata":
                        return PredictionData(request, context);
                    default:
                        return RetornaOk("Ruta de Api Gateway no mapeada");
                }
                
            }
            else
            {
                context.Logger.LogLine("Get Path, No se recibio request");

                return RetornaOk("No se ejecuto desde el Api Gateway");
            }

            ////Amazon.SageMaker.in

            //var response = new APIGatewayProxyResponse
            //{
            //    StatusCode = (int)HttpStatusCode.OK,
            //    Body = "Hello AWS Serverless",
            //    Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            //};

            //return response;
        }
    }
}
