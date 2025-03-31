using Es.Udc.DotNet.PracticaMaD.Model.UserProfileDao;
using Es.Udc.DotNet.PracticaMaD.Model.UserService.Exceptions;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;
using System;
using System.Collections.Generic;


namespace Es.Udc.DotNet.PracticaMaD.Model.UserService
{
    public interface IUserService
    {
        [Inject]
        IUserProfileDao UserProfileDao { set; }

        [Transactional]
        void ChangePassword(long userProfileId, String oldClearPassword,
            String newClearPassword);


        [Transactional]
        UserProfileDetails FindUserProfileDetails(long userProfileId);


        [Transactional]
        UserProfile FindUserProfile(String loginName);

        [Transactional]
        UserProfile FindUserProfileById(long userId);

        [Transactional]
        LoginResult Login(String loginName, String password,
            Boolean passwordIsEncrypted);


        [Transactional]
        long RegisterUser(String loginName, String clearPassword,
            UserProfileDetails userProfileDetails);

        [Transactional]
        void UpdateUserProfileDetails(long userProfileId,
            UserProfileDetails userProfileDetails);

        [Transactional]
        bool UserExists(string loginName);

        [Transactional]
        void SeguirUsuario(long seguidoId, long seguidorId);

        [Transactional]
        void Unfollow(long seguidoId, long seguidorId);

        [Transactional]
        UsersBlock FindAllSeguidores(UserProfile user, int startIndex, int count);

        [Transactional]
        UsersBlock FindAllSeguidos(UserProfile user, int startIndex, int count);

        [Transactional]
        Boolean UserFollowUser(long userId, long userToCheckId);

    }
}