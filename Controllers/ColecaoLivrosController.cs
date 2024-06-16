using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Data;


namespace BibliotecaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColecaoLivrosController : ControllerBase
    {
         private static List<Livro> TipoLivros = new List<Livro>()
         {
            new Livro() { Id = 1, NomedoLivro = "Bíblia", Autor = "Deus", Genero= "Livro Sagrado", Disponibilidade= true, DataLivro = "Desconhecido" , preco = 50 },
            new Livro() { Id = 2, NomedoLivro = "1984", Autor = "George Orwell", Genero = "Ficção política", Disponibilidade= true, DataLivro = "1949", preco = 30},
            new Livro() { Id = 3, NomedoLivro = "O Menino, a Toupeira, a Raposa e o Cavalo", Autor = "Charlie Mackesy", Genero= "Animação", Disponibilidade= true, DataLivro = "2020" , preco = 60},
            new Livro() { Id = 4, NomedoLivro = "O Poder do Hábito", Autor = "Charles Duhigg", Genero = "Livro de autoajuda", Disponibilidade= true, DataLivro = "2012" , preco = 55},
            new Livro() { Id = 5, NomedoLivro = "A tríade do tempo", Autor = "Christian Barbosa", Genero= "Livro de autoajuda", Disponibilidade= true, DataLivro = "2008" , preco =40}
         };


        private readonly DataContext _context;

        public ColecaoLivrosController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Livro l = await _context.TB_LIVRO.
                FirstOrDefaultAsync(mBusca => mBusca.Id == id);

                return Ok(l);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Livro> lista = await _context.TB_LIVRO.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Livro novaLivro)
        {
            try
            {
                await _context.TB_LIVRO.AddAsync(novaLivro);
                await _context.SaveChangesAsync();
           
                return Ok(novaLivro.Id);
            }
           catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update(Livro novaLivro)
        {
            try
            {
                _context.TB_LIVRO.Update(novaLivro);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
           catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Livro mRemover = await _context.TB_LIVRO.FirstOrDefaultAsync(m => m.Id == id);

                _context.TB_LIVRO.Remove(mRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);

            }
           catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

/*
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(TipoLivros);
        }


        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(TipoLivros.FirstOrDefault(inve => inve.Id == id));
        }



        [HttpPut]
        public IActionResult UpdateLivro(Livro i)
        {

            Livro LivroAlterado = TipoLivros.Find(inv => inv.Id == i.Id);
            LivroAlterado.NomedoLivro = i.NomedoLivro;
            LivroAlterado.Autor = i.Autor;
            LivroAlterado.Genero = i.Genero;
            LivroAlterado.DataLivro = i.DataLivro;
            LivroAlterado.preco = i.preco;
            LivroAlterado.Disponibilidade = i.Disponibilidade;
            return Ok(TipoLivros);
        }


         [HttpPost]
        public IActionResult AddLivro(Livro novoLivro)
        {
            TipoLivros.Add(novoLivro);
            return Ok(TipoLivros);
        }



         [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            TipoLivros.RemoveAll(inv => inv.Id == id);

            return Ok(TipoLivros);
        }
*/
    }
}