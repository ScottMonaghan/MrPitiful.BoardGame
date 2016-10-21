﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
namespace MrPitiful.BoardGame.Base
{
 
    [Route("api/[controller]")]
    public class GamePieceController : GameObjectController
    {
        private BoardGameDbContext _context;
 
        public GamePieceController(BoardGameDbContext context):base(context)
        {
            _context = context;
        }
    }
}
