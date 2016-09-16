using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Base.Models.Interfaces
{
    public interface IGameObject
    {
        Guid Id { get; set; }
        void BeforeStep(string stepName, object parameters);
        void DuringStep(string stepName, object parameters);
        void AfterStep(string stepName, object parameters);
    }
}
