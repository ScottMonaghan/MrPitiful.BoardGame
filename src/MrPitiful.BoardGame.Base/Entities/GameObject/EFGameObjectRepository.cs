using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public abstract class EFGameObjectRepository //: IGameObjectRepository
    {
        //private Dictionary<Guid, IGameObject> _gameObjects;
        private SerializedGameObjectDbContext _context;
        public EFGameObjectRepository(SerializedGameObjectDbContext context, IGameObject gameObject)
        {
            //_gameObjects = new Dictionary<Guid, IGameObject>();
            _context = context;
        }

        public IGameObject Create(IGameObject gameObject)
        {
            gameObject.Id = Guid.NewGuid();
            _context.SerializedGameObjects.Add(
                new SerializedGameObject()
                {
                    Id = gameObject.Id,
                    GameId = gameObject.Id,
                    value = JsonConvert.SerializeObject(
                        gameObject,
                        new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All }
                        )
                }
            );
            //_gameObjects.Add(gameObject.Id, gameObject);
            _context.SaveChanges();
            return gameObject;
        }

        public Dictionary<Guid,IGameObject> Get()
        {
            var _gameObjects = new Dictionary<Guid, IGameObject>();
            
            foreach (var stringDBEntity in _context.SerializedGameObjects)
            {
                _gameObjects.Add(stringDBEntity.Id,
                    JsonConvert.DeserializeObject<IGameObject>(
                        stringDBEntity.value,
                        new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All }
                        )
                );
            }
            return _gameObjects;
        }

        public IGameObject Get(Guid Id)
        {
            return JsonConvert.DeserializeObject<IGameObject>(
                       _context.SerializedGameObjects.Single(x => x.Id == Id).value,
                       new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All }
                       );
        }
    
        public Dictionary<Guid, IGameObject> GetByGameId(Guid gameId)
        {
            var _gameObjects = new Dictionary<Guid, IGameObject>();
            var serializedGameObjects = _context.SerializedGameObjects.Where(so => so.GameId == gameId).ToList();

            foreach (var serializedObject in serializedGameObjects)
            {
                _gameObjects.Add(serializedObject.Id,
                    JsonConvert.DeserializeObject<IGameObject>(
                        serializedObject.value,
                        new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All }
                        )
                );
            }
            return _gameObjects;
        }

        public void Save(IGameObject gameObject)
        {
            _context.Attach(
                new SerializedGameObject()
                {
                    Id = gameObject.Id,
                    GameId = gameObject.GameId,
                    value = JsonConvert.SerializeObject(
                        gameObject,
                        new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All }
                        )
                }
            );
            _context.SaveChanges();
        }

        public void Delete(IGameObject gameObject)
        {
            _context.SerializedGameObjects.Remove(_context.SerializedGameObjects.Single(x => x.Id == gameObject.Id));
            _context.SaveChanges();
        }

        public List<IGameObject> GetByStateProperties(Guid gameId, Dictionary<string, string> stateProperties)
        {
            var filteredGameObjects = GetByGameId(gameId).Values.ToList();
            
            /*
            foreach (KeyValuePair<string,string> stateProperty in stateProperties)
            {
                filteredGameObjects = (filteredGameObjects.Where(x => x.State[stateProperty.Key] == stateProperty.Value)).ToList();
            }
            */
            return filteredGameObjects;
        }
    }
}
