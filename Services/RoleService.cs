using Microsoft.EntityFrameworkCore;
using SecureAuthSystem.Data;
using SecureAuthSystem.DTOs;
using SecureAuthSystem.Models;
using SecureAuthSystem.Services.Interface;


namespace SecureAuthSystem.Services
{
    public class RoleService : IRoleService
    {

        private readonly ApplicationDBContext _context;


        public RoleService(ApplicationDBContext context)
        {
            _context = context;
        }


        // Get All Roles

        public async Task<List<RoleDto>> GetRoles()
        {

            var roles = await _context.Roles
                .Select(x => new RoleDto
                {

                    RoleId = x.RoleId,

                    RoleName = x.RoleName

                })
                .ToListAsync();


            return roles;

        }




        // Get Role By Id

        public async Task<RoleDto> GetRoleById(int id)
        {

            var role =
            await _context.Roles
            .FirstOrDefaultAsync(x => x.RoleId == id);



            if (role == null)
            {

                return new RoleDto();

            }



            return new RoleDto()
            {

                RoleId = role.RoleId,

                RoleName = role.RoleName

            };

        }






        // Add Role

        public async Task<string> AddRole(RoleDto dto)
        {


            var exists =
            await _context.Roles
            .AnyAsync(x => x.RoleName == dto.RoleName);



            if (exists)
            {

                return "Role Already Exists";

            }




            Role role = new Role()
            {

                RoleName = dto.RoleName

            };



            _context.Roles.Add(role);


            await _context.SaveChangesAsync();



            return "Role Added Successfully";


        }







        // Update Role


        public async Task<string> UpdateRole(
            int id,
            RoleDto dto)
        {


            var role =
            await _context.Roles.FindAsync(id);



            if (role == null)
            {

                return "Role Not Found";

            }



            role.RoleName = dto.RoleName;



            await _context.SaveChangesAsync();



            return "Role Updated Successfully";


        }








        // Delete Role


        public async Task<string> DeleteRole(int id)
        {


            var role =
            await _context.Roles.FindAsync(id);



            if (role == null)
            {

                return "Role Not Found";

            }



            _context.Roles.Remove(role);



            await _context.SaveChangesAsync();



            return "Role Deleted Successfully";


        }


    }
}