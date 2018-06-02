using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ExercicioCarros
{
    class Marca
    {
        public int codigo;
        public string nome;
        public string pais;
        public List<Carro> carros;

        public Marca(int codigo, string nome, string pais)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.pais = pais;
            carros = new List<Carro>();
            
        }


        public override string ToString()
        {
            String s = "\nCarros da marca " + nome + ": ";
            foreach (Carro listaCarros in carros)
            {
                s = s + "\n" + listaCarros.codigo + ", " + listaCarros.modelo + ", Ano: " + listaCarros.ano + ", Preço básico: " + listaCarros.precoBasico.ToString("F2", CultureInfo.InvariantCulture);
            }

            return s;
        }
    }
}
