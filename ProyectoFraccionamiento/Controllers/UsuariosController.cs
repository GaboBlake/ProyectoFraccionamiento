using System.Linq.Expressions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoFraccionamiento.Models
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
         private readonly SignInManager<IdentityUser> _signInManager;
         private readonly ApplicationDBContext _context;
         public UsuariosController( UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager,
        ApplicationDBContext context)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._context = context;
        }
        [AllowAnonymous]
        public IActionResult Login(string mensaje = null)
        {
            if (mensaje is not null)
            {
                ViewData["mensaje"]=mensaje;

            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            var resultado = await _signInManager.PasswordSignInAsync(modelo.Email, modelo.Password, modelo.Recuerdame, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Nombre de usuario o password incorrecto");
                return View(modelo);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index","Home");
        }

        //Checar videos de LogIn para ver error
        [HttpGet]
        [Authorize(Roles =ConstantExpression.RolAdmin)]
        public async Task<IActionResult> Listado(string mensaje = null)
        {
            var usuarios = await _context.Users.Select(u => new UsuarioViewModel
            {
                Email=u.Email
            }).ToListAsync();
            
            var modelo = new UserListadoViewModel();
            modelo.Usuarios = usuarios;
            modelo.Mensaje = mensaje;
            return View(modelo);
        }
    }
}
