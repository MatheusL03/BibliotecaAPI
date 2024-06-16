using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using BibliotecaApi.Models;

namespace BibliotecaApi.Utils
{
    public class Criptografia
    {
        // Variavel de Saida
        public static void CriarPasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerificarPasswordHash(string password, byte[] hash, byte[] salt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if(computedHash[i] != hash[i])
                        {
                            return false;
                        }

                    }
                    return false;
            }
        }
 
    }
}