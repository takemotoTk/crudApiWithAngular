using GolAirlines.Business.Interfaces;
using GolAirlines.DataAccess;
using GolAirlines.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GolAirlines.Business.Business
{
    public class AirplaneComponent : IAirplaneComponent
    {
        private AirplaneDbContext _context;

        public AirplaneComponent(AirplaneDbContext context)
        {
            _context = context;
        }

        public Airplane Obter(int codAviao)
        {
            if (codAviao > 0)
            {
                return _context.Airplanes.Where(p => p.CodigoDoAviao == codAviao).FirstOrDefault();
            }
            else
                return null;
        }

        public List<Airplane> ListarTodos()
        {
            return _context.Airplanes.OrderBy(p => p.CodigoDoAviao).ToList();
        }

        public Resultado Incluir(Airplane dadosProduto)
        {
            Resultado resultado = DadosValidos(dadosProduto);
            resultado.Acao = "Inclusão de Avião";

            try
            {
                if (resultado.Inconsistencias.Count == 0 && _context.Airplanes.Where(p => p.CodigoDoAviao == dadosProduto.CodigoDoAviao).Count() > 0)
                {
                    resultado.Inconsistencias.Add("Avião já cadastrado");
                }

                if (resultado.Inconsistencias.Count == 0)
                {
                    _context.Airplanes.Add(dadosProduto);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                resultado.Inconsistencias.Add("Não foi possível fazer a Inclusão do Avião");
            }

            return resultado;
        }

        public Resultado Atualizar(Airplane dadosAirplane)
        {
            Resultado resultado = DadosValidos(dadosAirplane);
            resultado.Acao = "Atualização de Avião";

            try
            {
                if (resultado.Inconsistencias.Count == 0)
                {
                    Airplane airplane = _context.Airplanes.Where(p => p.CodigoDoAviao == dadosAirplane.CodigoDoAviao).FirstOrDefault();

                    if (airplane == null)
                    {
                        resultado.Inconsistencias.Add("Avião não encontrado");
                    }
                    else
                    {
                        airplane.CodigoDoAviao = dadosAirplane.CodigoDoAviao;
                        airplane.Modelo = dadosAirplane.Modelo;
                        airplane.QuantidadePassageiros = dadosAirplane.QuantidadePassageiros;
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                resultado.Inconsistencias.Add("Não foi possível fazer a Atualização do Avião");
            }

            return resultado;
        }

        public Resultado Excluir(int codAviao)
        {
            Resultado resultado = new Resultado();
            resultado.Acao = "Exclusão de Avião";

            try
            {
                Airplane airplane = Obter(codAviao);
                if (airplane == null)
                {
                    resultado.Inconsistencias.Add("Avião não encontrado");
                }
                else
                {
                    _context.Airplanes.Remove(airplane);
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {
                resultado.Acao = "Não foi possível fazer a Exclusão do Avião";
            }

            return resultado;
        }

        private Resultado DadosValidos(Airplane airplane)
        {
            var resultado = new Resultado();
            if (airplane == null)
            {
                resultado.Inconsistencias.Add(
                    "Preencha os Dados do Avião");
            }
            else
            {
                if (airplane.Modelo <= 0)
                {
                    resultado.Inconsistencias.Add(
                        "Preencha o Modelo do Avião");
                }
                if (airplane.QuantidadePassageiros <= 0)
                {
                    resultado.Inconsistencias.Add(
                        "A quantidade de passageiros deve ser maior do que zero");
                }
            }

            return resultado;
        }
    }
}
