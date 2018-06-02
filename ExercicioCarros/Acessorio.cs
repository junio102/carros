using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioCarros
{
    class Acessorio
    {
        public string descricao;
        public double preco;
        Carro carro;

        public Acessorio(string descricao, double preco, Carro carro)
        {
            this.descricao = descricao;
            this.preco = preco;
            this.carro = carro;
        }
    }

    
}
