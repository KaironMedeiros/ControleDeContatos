﻿using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ContatoModel> BuscarTodos(int usuarioId)
        {
            return _bancoContext.Contatos.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges(); 
            return contato;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.Id); 

            if (contatoDb == null) throw new System.Exception("Houve um erro na atualização do contato"); 

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDb); 
            _bancoContext.SaveChanges(); 

            return contatoDb;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarPorId(id); 

            if (contatoDb == null) throw new System.Exception("Houve um erro na deleção do contato!"); 

            _bancoContext.Contatos.Remove(contatoDb); 
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
