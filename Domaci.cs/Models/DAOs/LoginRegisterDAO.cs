using Domaci.cs.Data;
using Domaci.cs.PasswordHashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit;
using Org.BouncyCastle.Utilities.Collections;

namespace Domaci.cs.Models.DAOs
{
    public class LoginRegisterDAO
    {
        private readonly DataDbContext _db;

        public LoginRegisterDAO()
        {
            _db = new DataDbContext();

        }
        public void Register(string Name, string Surname, string Email, string Password) {
            try
            {
                if (usedEmail(Email) == true)
                {
                    throw new Exception();
                }
                Referent newRef = new Referent();
                newRef.Name = Name;
                newRef.Surname = Surname;
                newRef.Email = Email;
                newRef.Password = Password;
                _db.Referents.Add(newRef);
                _db.SaveChanges();

            } catch (Exception e)
            {

            }
        }

        public bool usedEmail(string Email)
        {
            List<Referent> referenti = getAllReferents();
            foreach (Referent referent in referenti)
            {
                if (referent.Email == Email)
                {
                    return true;
                }
            }
            return false;
        }

        public bool usedStudentEmail(string Email)
        {
            List<Student> students = getAllStudents();
            foreach (Student student in students)
            {
                if (student.E_Mail == Email)
                {
                    return true;
                }
            }
            return false;
        }


        public List<Referent> getAllReferents()
        {
            return _db.Referents.ToList();
        }

        public List<Student> getAllStudents()
        {
            return _db.Students.ToList();
        }

        public void changePassword(string Email, string newPass)
        {
            //newPass se ocekuje hesirana
            Referent referent = _db.Referents.FirstOrDefault(c => c.Email == Email);
            if (referent != null)
            {
                Referent refer = new Referent();
                if (referent.TempPassword == string.Empty)
                {
                    refer = referent;
                    refer.Password = newPass;
                    _db.Referents.Update(refer);
                    _db.SaveChanges();
                }
                else
                {
                    refer = referent;
                    refer.Password = newPass;
                    refer.TempPassword = string.Empty;
                    _db.Referents.Update(refer);
                    _db.SaveChanges();
                }
            }
            else
            {
                Student student = _db.Students.FirstOrDefault(c => c.E_Mail == Email);
                Student stud = new();
                stud = student;
                stud.Sifra = newPass;
                _db.Students.Update(stud);
                _db.SaveChanges();
            }
        }

        
        public void changeStudentPassword(string Email, string newPass)
        {
            //newPass se ocekuje hesirana
            Student student = _db.Students.FirstOrDefault(c => c.E_Mail == Email);
            if (student != null)
            {
                Student stud = new Student();
                if (student.TempPassword == string.Empty)
                {
                    stud = student;
                    stud.Sifra = newPass;
                    _db.Students.Update(stud);
                    _db.SaveChanges();
                }
                else
                {
                    stud = student;
                    stud.Sifra = newPass;
                    stud.TempPassword = string.Empty;
                    _db.Students.Update(stud);
                    _db.SaveChanges();
                }
            }
            
        }

        public void findByEmailAndChangeToRecoveryPassword(string Email, string tempPassword)
        {
            string HashedPass = HashPassword(tempPassword);
            Referent referent = _db.Referents
                                .Where(c=> c.Email.Contains(Email))
                                .FirstOrDefault();
            if (referent != null)
            {
                Referent refer = new Referent();
                refer = referent;
                refer.TempPassword = HashedPass;
                _db.Referents.Update(refer);
                _db.SaveChanges();

            }
            else
            {
                Student student = _db.Students
                                    .Where(c => c.E_Mail.Contains(Email))
                                    .FirstOrDefault();
                Student stud = new();
                stud = student;
                stud.TempPassword = HashedPass;
                _db.Students.Update(stud);
                _db.SaveChanges();
                
            }
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public Referent findReferentByEmail(string EMail)
        {
            return _db.Referents
                            .Where(c => c.Email.Contains(EMail))
                            .FirstOrDefault();
        }


        public void Login(string Email, string Password)
        {
            Referent referent = _db.Referents.FirstOrDefault(c => c.Email == Email);

        }

        public string findHash(string Email)
        {
            Referent referent = _db.Referents
                               .Where(c => c.Email.Contains(Email))
                               .FirstOrDefault();
            if (referent != null)
            {
                return referent.Password;

            }
            else
            {
                return string.Empty;

            }


        }

        
        public string findStudentHash(string Email)
        {
            
            Student student = _db.Students.Where(c => c.E_Mail.Contains(Email))
                                          .FirstOrDefault();

            if (student == null) 
            {
                return string.Empty;
            }
            else
            {
                return student.Sifra;
            }

        }

        public string findRecoveryHash(string Email)
        {
            return _db.Referents.FirstOrDefault(c => c.Email == Email).TempPassword;
        }

        public string findStudentRecoveryHash(string Email)
        {
            return _db.Students.FirstOrDefault(c => c.E_Mail == Email).TempPassword;
        }

        public void forgotPassword(string Email)
        {
            if (usedEmail(Email) == true)
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("Password Recovery", "oisisiprojekat@gmail.com"));
                message.To.Add(MailboxAddress.Parse(Email));

                message.Subject = "Password recovery";

                String tempPassword = randomStringGenerator();

                message.Body = new TextPart("plain")
                {
                    Text = @"Token za izmenu sifre za " + Email + " je: " + tempPassword
                };

                SmtpClient client = new SmtpClient();

                try
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("antonijeerdeljan01@gmail.com", "");
                    client.Send(message);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }
                finally
                {

                    findByEmailAndChangeToRecoveryPassword(Email, tempPassword);
                    client.Disconnect(true);
                    client.Dispose();
                }
            }

        }

        public bool unusedEmail(string Email)
        {
            if (_db.Students.Where(s => s.E_Mail.Contains(Email)).FirstOrDefault() != null || _db.Referents.Where(r=> r.Email.Contains(Email)).FirstOrDefault() != null)
                return true;
            else
                return false;
           
        }

        public void forgotPasswordStudent(string Email)
        {
            if (usedStudentEmail(Email) == true)
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("Password Recovery", "oisisiprojekat@gmail.com"));
                message.To.Add(MailboxAddress.Parse(Email));

                message.Subject = "Password recovery";

                String tempPassword = randomStringGenerator();

                message.Body = new TextPart("plain")
                {
                    Text = @"Token za izmenu sifre za " + Email + " je: " + tempPassword
                };

                SmtpClient client = new SmtpClient();

                try
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("antonijeerdeljan01@gmail.com", "");
                    client.Send(message);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }
                finally
                {

                    findByEmailAndChangeToRecoveryPassword(Email, tempPassword);
                    client.Disconnect(true);
                    client.Dispose();
                }
            }

        }

        public void checkRecovery(string Email)
        {
            Referent referent = _db.Referents.FirstOrDefault(r => r.Email == Email);
            if(referent.TempPassword != null)
            {
                referent.TempPassword = string.Empty;
                _db.Referents.Update(referent);
                _db.SaveChanges();
            }
        }

        
        public void checkStudentRecovery(string Email)
        {
            Student student = _db.Students.FirstOrDefault(r => r.E_Mail == Email);
            if (student.TempPassword != null)
            {
                student.TempPassword = string.Empty;
                _db.Students.Update(student);
                _db.SaveChanges();
            }
        }


        public string randomStringGenerator()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
       
        }



    }
}
