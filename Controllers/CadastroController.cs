using CadastroUsuarios.Data;
using CadastroUsuarios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuarios.Controllers
{
    public class CadastroController : Controller
    {

        private readonly BancoContext _BancoContext;

        public CadastroController(BancoContext contexto)
        {
            _BancoContext = contexto;
        }

        //public CadastroModel Usuario = new CadastroModel();

        public async Task<IActionResult> Index()
        {

            return View(await _BancoContext.Usuarios.ToListAsync());
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Criar(CadastroModel usuario)
        {
            await _BancoContext.Usuarios.AddAsync(usuario);
            await _BancoContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int usuarioId)
        {
            CadastroModel usuario = await _BancoContext.Usuarios.FindAsync(usuarioId);

            return View(usuario);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(CadastroModel usuario)
        {
            _BancoContext.Usuarios.Update(usuario);
            await _BancoContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ApagarConfirmacao()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ApagarConfirmacao(int usuarioId)
        {
            CadastroModel usuario = await _BancoContext.Usuarios.FindAsync(usuarioId);
            _BancoContext.Usuarios.Remove(usuario);
            await _BancoContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}