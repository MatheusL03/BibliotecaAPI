using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Models;
using BibliotecaApi.Utils;

namespace BibliotecaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsuariosController : ControllerBase
    {
        public readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        private async Task<bool> UsarioExistente(string username)
        {
            if(await _context.TB_USUARIOS.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if(await UsarioExistente(user.Username))
                    throw new System.Exception("Nome do usuário já existe");

                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.TB_USUARIOS.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);

            }
            catch (System.Exception ex)
            {
                
               return BadRequest(ex.Message);
            }
        }

        
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario? usuario = await _context.TB_USUARIOS
                    .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if(usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado");
                }

                else if(!Criptografia
                    .VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta");
                }
                else
                {
                    return Ok(usuario);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> AlterarSenhaUsuario(Usuario credenciais)
        {
            try
            {
                Usuario? usuario = await _context.TB_USUARIOS
                    .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if(usuario == null)
                    throw new System.Exception("Usuário não encontrado");

                 Criptografia.CriarPasswordHash(credenciais.PasswordString, out byte[] hash, out byte[] salt);
                 usuario.PasswordHash = hash;
                 usuario.PasswordSalt = salt;

                 _context.TB_USUARIOS.Update(usuario);
                 int linhasAfetadas = await _context.SaveChangesAsync();
                 return Ok(linhasAfetadas);                   
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticaUsuario(Usuario credenciais)
        { 
            try
            {
                Usuario? usuario = await _context.TB_USUARIOS
                    .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if(usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado");
                }
                else if(!Criptografia.VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha Incorreta."); 
                }    
                else
                {
                    usuario.DataAcesso = System.DateTime.Now;
                    _context.TB_USUARIOS.Update(usuario);
                    await _context.SaveChangesAsync();

                    return Ok(usuario);
                }

            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

     


        



        


        



    }
}