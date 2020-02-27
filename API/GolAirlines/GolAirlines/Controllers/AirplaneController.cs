using System.Collections.Generic;
using GolAirlines.Business.Interfaces;
using GolAirlines.Common;
using GolAirlines.Entities;
using GolAirlines.Model;
using Microsoft.AspNetCore.Mvc;

namespace GolAirlines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneController : ControllerBase
    {
        private readonly IAirplaneComponent _airplaneComponent;
        public AirplaneController(IAirplaneComponent airplaneComponent)
        {
            _airplaneComponent = airplaneComponent;
        }

        [HttpGet]
        public List<AirplaneModel> Get()
        {
            List<AirplaneModel> airplanes = null;
            var response = _airplaneComponent.ListarTodos();
            if (response != null)
            {
                var convertToJson = CommonHelper.Instance.SerializerObjectToJson(response);
                if (!string.IsNullOrEmpty(convertToJson))
                {
                    var convertJsonToObj = CommonHelper.Instance.DeserializerJsonToListObject<AirplaneModel>(convertToJson);
                    if(convertJsonToObj != null)
                    {
                        airplanes = convertJsonToObj;
                    }
                }
            }

            return airplanes;
        }

        [HttpGet("{codigoAviao}")]
        public ActionResult<AirplaneModel> Get(int codigoAviao)
        {
            AirplaneModel airplane = null;
            var response = _airplaneComponent.Obter(codigoAviao);
            if (response != null)
            {
                airplane = CommonHelper.Instance.BuildResultComponent<AirplaneModel>(response);
                return airplane;
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public ResultadoModel Post([FromBody]AirplaneModel request)
        {
            ResultadoModel resultMethod = null;
            var airplaneRequest = new Airplane();
            airplaneRequest.CodigoDoAviao = request.CodigoDoAviao;
            airplaneRequest.Modelo = request.Modelo;
            airplaneRequest.QuantidadePassageiros = request.QuantidadePassageiros;

            var response = _airplaneComponent.Incluir(airplaneRequest);
            if (response != null)
            {
                resultMethod = CommonHelper.Instance.BuildResultComponent<ResultadoModel>(response);
            }

            return resultMethod;
        }

        [HttpPut]
        public ResultadoModel Put([FromBody]AirplaneModel request)
        {
            ResultadoModel resultMethod = null;
            var airplaneRequest = new Airplane();
            airplaneRequest.CodigoDoAviao = request.CodigoDoAviao;
            airplaneRequest.Modelo = request.Modelo;
            airplaneRequest.QuantidadePassageiros = request.QuantidadePassageiros;

            var response = _airplaneComponent.Atualizar(airplaneRequest);
            if (response != null)
            {
                resultMethod = CommonHelper.Instance.BuildResultComponent<ResultadoModel>(response);
            }

            return resultMethod;
        }

        [HttpDelete("{codigoAviao}")]
        public ResultadoModel Delete(int codigoAviao)
        {
            ResultadoModel resultMethod = null;
            var response = _airplaneComponent.Excluir(codigoAviao);
            if (response != null)
            {
                resultMethod = CommonHelper.Instance.BuildResultComponent<ResultadoModel>(response);
            }

            return resultMethod;
        }
    }
}