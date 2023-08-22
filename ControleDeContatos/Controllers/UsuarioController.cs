using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ControleDeContatos.Controllers
{
    [PaginaAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio; 
        private readonly IContatoRepositorio _contatoRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IContatoRepositorio contatoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos(); 
            return View(usuarios);  
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);

            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Não foi possível apagar o usuário!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível apagar o usuário! Erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ListarContatosPorUsuarioId(int id)
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos(id);
            return PartialView("_ContatosUsuario", contatos);
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario); 
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o usuário! Erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioEditModel usuarioEdit)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioEdit.Id,
                        Nome = usuarioEdit.Nome,
                        Login = usuarioEdit.Login,
                        Email = usuarioEdit.Email,
                        Perfil = usuarioEdit.Perfil
                    };

                    usuario =_usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");

                }

                return View(usuario);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar o usuário! Erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

