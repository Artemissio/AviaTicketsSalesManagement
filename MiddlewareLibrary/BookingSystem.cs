using System;
using System.Collections.Generic;
using System.Linq;

namespace MiddlewareLibrary
{
    public class BookingSystem
    {
        public IReadOnlyList<Passage> Passages => _passages.AsReadOnly();

        private readonly List<Passage> _passages;
        private readonly List<Train> _trains;
        private readonly List<User> _customers;

        public BookingSystem()
        {
            _passages = new List<Passage>();
            _trains = new List<Train>();
            _customers = new List<User>();
        }

        public Passage GetPassage(int index)
        {
            return _passages[index];
        }

        public Passage GetPassage(string id)
        {
            return _passages.First(x => x.ID == id);
        }

        public void AddPassage(Passage passage)
        {
            _passages.Add(passage);
        }

        public void RemovePassage(string id)
        {
            var passage = _passages.FirstOrDefault(x => x.ID == id);

            if (passage is not null)
            {
                _passages.Remove(passage);

                GetTrainsByPassage(id).ForEach(x => RemoveTrain(x.ID));
            }
        }

        public void EditPassage(Passage passage)
        {
            RemovePassage(passage.ID);
            AddPassage(passage);
        }

        public List<Passage> GetPassagesByDeparture(Endpoint departure)
        {
            return _passages.Where(x => x.Departure == departure).ToList();
        }

        public List<Passage> GetPassagesByDestination(Endpoint destination)
        {
            return _passages.Where(x => x.Destination == destination).ToList();
        }

        public void AddTrain(Train train)
        {
            _trains.Add(train);
        }

        public void RemoveTrain(string trainId)
        {
            var train = _trains.FirstOrDefault(x => x.ID == trainId);

            if (train is not null)
            {
                _trains.Remove(train);
            }
        }

        public void EditTrain(Train train)
        {
            RemoveTrain(train.ID);
            AddTrain(train);
        }

        public List<Train> GetTrainsByPassage(string passageId)
        {
            var passage = GetPassage(passageId);

            if (passage is null)
            {
                throw new Exception("This passage does not exist");
            }

            return _trains.Where(x => x.Passage.ID == passageId).ToList();
        }

        public User Login(string login, string password)
        {
            var user = _customers.FirstOrDefault(x => x.Login == login);

            if (user is null)
            {
                throw new Exception($"There is no customer with login '{login}'");
            }

            if (user.Password != password)
            {
                throw new Exception("Password is incorrect");
            }

            return user;
        }
    }
}
