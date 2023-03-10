using Domaci.cs.Models;
using Domaci.cs.Models.DAOs;
using Domaci.cs.PasswordHashing;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Controller
{
    public class LoginRegisterController
    {
        private readonly LoginRegisterDAO _logregDAO;


        public LoginRegisterController()
        {
            _logregDAO = new LoginRegisterDAO();
        }

        public void Register(string Name, string Surname, string Email, string Password)
        {
            _logregDAO.Register(Name, Surname, Email, Password);
        }

        public void Login(string Email, string Password)
        {
            _logregDAO.Login(Email, Password);
        }

        public string findHash(string Email)
        {
            return _logregDAO.findHash(Email);
        }

        public string findStudentHash(string Email)
        {
            return _logregDAO.findStudentHash(Email);
        }



        public string findRecoveryHash(string Email)
        {
            return _logregDAO.findRecoveryHash(Email);
        }

        public string findStudentRecoveryHash(string Email)
        {
            return _logregDAO.findStudentRecoveryHash(Email);
        }

        public void changePassword(string Email, string newPass)
        {
            _logregDAO.changePassword(Email,newPass);
        }


        public bool checkEmail(string Email)
        {
            return _logregDAO.unusedEmail(Email);
        }


        public void changeStudentPassword(string Email, string newPass)
        {
            _logregDAO.changeStudentPassword(Email, newPass);
        }


        public void forgotPassword(string Email) 
        { 
            _logregDAO.forgotPassword(Email);
        }
        

        public void forgotPasswordStudent(string Email)
        {
            _logregDAO.forgotPasswordStudent(Email);
        }
        
        public Referent findReferentByEmail(string Email)
        {
            return _logregDAO.findReferentByEmail(Email);
        }


        public void checkRecovery(string Email)
        {
            _logregDAO.checkRecovery(Email);
        }

        

        public void checkStudentRecovery(string Email)
        {
            _logregDAO.checkStudentRecovery(Email);
        }

    }
}
