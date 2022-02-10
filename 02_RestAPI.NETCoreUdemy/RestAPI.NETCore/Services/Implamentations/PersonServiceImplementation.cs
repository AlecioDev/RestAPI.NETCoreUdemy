﻿using RestAPI.NETCore.Model;

namespace RestAPI.NETCore.Services.Implamentations
{
    public class PersonServiceImplementation : IPersonService
    {
        private int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }



        public Person FindById(long id)
        {
            return new Person
            {
                ID = 1,
                firstName = "Gabriel",
                lastName = "Almeida",
                Adress = "Nações - Fazenda Rio Grande - PR - Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                ID = IncrementAndGet(),
                firstName = "Person Name" + i,
                lastName = "Person Last Name" + i,
                Adress = "Some Adress" + i ,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
