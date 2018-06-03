using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ExercicioCarros
{
    class Carro
    {
        public int codigo;
        public string modelo;
        public int ano;
        public double precoBasico;
        Marca marca;
        public List<Acessorio>acessorios = new List<Acessorio>();

        public Carro(int codigo, string modelo, int ano, double precoBasico, Marca marca)
        {
            this.codigo = codigo;
            this.modelo = modelo;
            this.ano = ano;
            this.precoBasico = precoBasico;
            this.marca = marca;
        }

        public double precoTotal()
        {
            foreach(Acessorio listaAce in acessorios)
            {
                precoBasico += listaAce.preco;
            }
            return precoBasico;
        }

        public override string ToString()
        {
            string s = codigo + ", " + modelo
                + ", Ano: " + ano
                + ", Preço básico: " + precoBasico.ToString("F2", CultureInfo.InvariantCulture)
                + ", Preço total: " + precoTotal().ToString("F2", CultureInfo.InvariantCulture)
                + "\nMarca: " + marca.nome
            + "\nAcessórios: ";
            
            foreach(Acessorio listaAce in acessorios)
            {
                s = s + listaAce.descricao + ", Preço: " + listaAce.preco.ToString("F2", CultureInfo.InvariantCulture);
            }

            return s;
                
        }
    }
}
