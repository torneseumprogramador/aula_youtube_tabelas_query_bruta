using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using aula_youtube_tabelas_query_bruta.Models.Dominio.Entidades;

namespace aula_youtube_tabelas_query_bruta.Models.Infraestrutura.Database.Repositorios
{
    public class ClienteRepositorio
    {
        public ClienteRepositorio(){
            this.contexto = new ContextoLoja1();
        }
        private ContextoLoja1 contexto;

        public Cliente BuscaClientePorId(int id)
        {
            return contexto.Clientes.Find(id);
        }
        
    }
}
