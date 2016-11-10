using System;
using System.Linq;
using System.Collections.Generic;

namespace MrPitiful.BoardGame.Base
{
    public class ListStatePropertyRepository : IStatePropertyRepository
    {
        private List<IStateProperty> _stateProperties;

        public ListStatePropertyRepository(IStateProperty stateProperty)
        {
            _stateProperties = new List<IStateProperty>();
        }

        public string Get(Guid gameObjectId, string name)
        {
            return _stateProperties.Single(sp => sp.GameObjectId == gameObjectId && sp.Name == name).Value;
        }
        public List<Guid> GetGameGameObjectIdsByStateProperties(Guid gameId, List<StateProperty> filterStateProperties)
        {
            //first filter by gameId
            var retList = _stateProperties.Where(sp => sp.GameId == gameId
            //now filter down by name & value
            && filterStateProperties.Any(fsp => fsp.Name == sp.Name && fsp.Value == sp.Value))
            //next group by gameobject
            .GroupBy(sp => sp.GameObjectId)
            //now filter down to groups that have the same number of stateproperties as the filter
            .Where(grp => grp.Count() == filterStateProperties.Count())
            //now return the remaining gameobjects
            .Select(grp => grp.Key).ToList();
            return retList;
        }

        public void Set(Guid gameId, Guid gameObjectId, string name, string value)
        {
            if (_stateProperties.Any(sp=>sp.GameId==gameId && sp.GameObjectId==gameObjectId && sp.Name == name))
            {
                _stateProperties.Single(sp => sp.GameId == gameId && sp.GameObjectId == gameObjectId && sp.Name == name).Value = value;
            } else
            {
                _stateProperties.Add(new StateProperty()
                {
                    GameId = gameId,
                    GameObjectId = gameObjectId,
                    Name = name,
                    Value = value
                });
            }
        }
        public void Delete(Guid gameObjectId, string name)
        {
            _stateProperties.Remove(_stateProperties.Single(sp => sp.GameObjectId == gameObjectId && sp.Name == name));       
        }

    }
}