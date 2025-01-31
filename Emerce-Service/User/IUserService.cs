﻿using Emerce_Model;
using Emerce_Model.User;

namespace Emerce_Service.User
{
    public interface IUserService
    {
        public General<UserViewModel> Insert( UserCreateModel newUser );
        public General<UserViewModel> Login( UserLoginModel user );
        public General<UserViewModel> Get();
        public General<UserViewModel> GetById( int id );
        public General<UserViewModel> Update( UserUpdateModel updatedUser, int id );
        public General<UserViewModel> Delete( int id );
    }
}
