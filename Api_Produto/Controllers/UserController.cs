﻿using Api_Produto.Configure;
using Api_Produto.Context;
using Api_Produto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Api_Produto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ProdutoContext _userDb;
        public UserController(ProdutoContext db)
        {
            _userDb = db;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            // Recupera o usuário
            var user = new User() { Name = "login", Password = "senha" };

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var prov = _userDb.Users.ToList();
            return prov;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            var prov = _userDb.Users.Find(id);
            return prov;
        }

        [HttpPost]
        public void Post([FromBody] User obj)
        {
            _userDb.Users.Add(obj);
            _userDb.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User obj)
        {
            _userDb.Users.Update(obj);
            _userDb.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var prov = _userDb.Users.Find(id);
            _userDb.Users.Remove(prov);
            _userDb.SaveChanges();
        }
    }
}