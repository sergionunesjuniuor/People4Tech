using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain;
using WebApi.Domain.DTO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UsuarioEdicaoDto model)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound("Usuário não encontrado");

            user.Email = model.Email;
            user.UserName = model.Email; 

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
                return BadRequest(updateResult.Errors);

            if (!string.IsNullOrWhiteSpace(model.NewPassword))
            {
                var passwordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (!passwordResult.Succeeded)
                    return BadRequest(passwordResult.Errors);
            }

            return Ok("Dados atualizados com sucesso");
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _userManager.Users.ToList();

            var result = users.Select(u => new
            {
                u.Id,
                u.UserName,
                u.Email,
                u.PhoneNumber
            });

            return Ok(result);
        }

        [Authorize(Roles = "Administrador")] // opcional, restringe a admins
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound("Usuário não encontrado");

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("Usuário excluído com sucesso");
        }


        [Authorize(Roles = "Administrador")]
        [HttpPost("{userId}/roles/add/Administrador")]
        public async Task<IActionResult> AddUserToRoleAdmin(string userId)
        {
            var role = "Administrador";
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("Usuário não encontrado");

            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            var result = await _userManager.AddToRoleAsync(user, role);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok($"Usuário adicionado ao papel '{role}'");
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost("{userId}/roles/add/Vendedor")]
        public async Task<IActionResult> AddUserToRole(string userId)
        {
            var role = "Vendedor";
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("Usuário não encontrado");

            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            var result = await _userManager.AddToRoleAsync(user, role);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok($"Usuário adicionado ao papel '{role}'");
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost("{userId}/roles/remove/Administrador")]
        public async Task<IActionResult> RemoveUserFromRoleAdministrador(string userId)
        {
            var role = "Administrador";
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("Usuário não encontrado");

            if (!await _userManager.IsInRoleAsync(user, role))
                return BadRequest($"Usuário não pertence ao papel '{role}'");

            var result = await _userManager.RemoveFromRoleAsync(user, role);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok($"Papel '{role}' removido do usuário");
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost("{userId}/roles/remove/Vendedor")]
        public async Task<IActionResult> RemoveUserFromRoleVendedor(string userId)
        {
            var role = "Vendedor";
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("Usuário não encontrado");

            if (!await _userManager.IsInRoleAsync(user, role))
                return BadRequest($"Usuário não pertence ao papel '{role}'");

            var result = await _userManager.RemoveFromRoleAsync(user, role);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok($"Papel '{role}' removido do usuário");
        }

        [Authorize]
        [HttpGet("{userId}/roles")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("Usuário não encontrado");

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(roles);
        }

        [Authorize]
        [HttpGet("role/Administrador")]
        public async Task<IActionResult> GetUsersInRoleAdministrador()
        {
            var roleName = "Administrador";
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
                return NotFound($"Papel '{roleName}' não encontrado.");

            var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);

            var result = usersInRole.Select(u => new
            {
                u.Id,
                u.UserName,
                u.Email,
                u.PhoneNumber
            });

            return Ok(result);
        }

        [Authorize]
        [HttpGet("role/Vendedor")]
        public async Task<IActionResult> GetUsersInRoleVendedor()
        {
            var roleName = "Vendedor";
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
                return NotFound($"Papel '{roleName}' não encontrado.");

            var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);

            var result = usersInRole.Select(u => new
            {
                u.Id,
                u.UserName,
                u.Email,
                u.PhoneNumber
            });

            return Ok(result);
        }

    }
}
