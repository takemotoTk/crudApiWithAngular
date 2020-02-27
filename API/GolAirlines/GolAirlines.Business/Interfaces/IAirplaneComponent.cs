using GolAirlines.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolAirlines.Business.Interfaces
{
    public interface IAirplaneComponent
    {
        Airplane Obter(int codAviao);

        List<Airplane> ListarTodos();

        Resultado Incluir(Airplane dadosProduto);

        Resultado Atualizar(Airplane dadosAirplane);

        Resultado Excluir(int codAviao);
    }
}
