using System;
using System.Collections.Generic;
using System.Linq;
using DTO_Automapper_Template.Models;

namespace DTO_Automapper_Template.Data
{
    public class DummyDatabase
    {
        public List<User> userList { get; set; }
        public DummyDatabase()
        {
            if (userList == null)
            {
                userList = GetSampleData();
            }
        }

        public User AddUser(User user)
        {
            var userId = GenerateId();
            var newUser = new User { BirthDate = user.BirthDate, Name = user.Name, IdentificationNumber = user.IdentificationNumber, Id = userId };
            userList.Add(newUser);

            return newUser;
        }

        public void UpdateUser(string id, User updatedUser)
        {
            foreach (var user in userList.Where(p => p.Id == id))
            {
                user.BirthDate = updatedUser.BirthDate;
                user.Name = updatedUser.Name;
            }
        }

        public void RemoveUser(string id)
        {
            userList.Remove(userList.First(u => u.Id == id));
        }
        private List<User> GetSampleData()
        {
            var rng = new Random();
            return Enumerable.Range(1, 2).Select(index => new User
            {
                Id = GenerateId(),
                Name = GenerateName(rng.Next(0, 20)),
                IdentificationNumber = rng.Next(0, 999999999).ToString(),
                BirthDate = DateTime.Now.AddDays(rng.Next(-50, 0))
            })
            .ToList();
        }

        private static string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
        private static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }
    }
}