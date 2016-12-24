using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfHouses.MechanicsExperiments.DotNet
{
    public class Player
    {
        public Player()
        {
            House = null;
        }
        public Game Game { get; set; }

        public House House { get; set; }
        public void SettleNewLordship(Lordship sourceLordship, Lordship targetLordship, Household lordsHouseHold, List<Household> peasantHouseholds)
        {
            if (sourceLordship.PlayerMoves.Count(p => p == this) < Constants.ALLOWED_MOVES_PER_YEAR)
            {
                Lordship.PopulateLordship(targetLordship, lordsHouseHold, peasantHouseholds);
                sourceLordship.PlayerMoves.Add(this);
            }
        }
        public PlayerType PlayerType { get; set; }
        public void DoPlayerTurn(Random rnd)
        {
            switch (PlayerType)
            {
                case PlayerType.Live:
                    DoLivePlayerTurn(rnd);
                    break;
            }
        }
        public void DoAggressivePlayerTurn()
        {
            //conscript all, summon all 
            //aggro attacks closest lordship with the least defenders 
            //if army is less than half the size of aggro's then aggro will conquor
            //if defender is more than half the size of aggro will accept fealty, otherwise retreat
        }
        public void DoLivePlayerTurn(Random rnd)
        {
            var player = this;
            var world = player.House.World;
            Console.WriteLine("Year: " + world.Year);
            //Console.WriteLine(player.House.Seat.GetMapOfKnownWorld());
            Console.WriteLine("Enter to continue. CTRL-C to quit.");
            var input = "hacky";
            while (input.ToLower() != "i")
            {
                Console.WriteLine("Enter lordship name or [i]ncrement year");
                input = Console.ReadLine();
                var command = input.Split(' ');
                if (command.Length > 0)
                {
                    var subjectLordship = world.Lordships.FirstOrDefault(l => l.Name.ToLower() == command[0].ToLower());
                    if (subjectLordship != null)
                    {
                        if (command.Length == 1)
                        {
                            //get details on lordship
                            var lordshipCommand = "";
                            Console.WriteLine(subjectLordship.GetDetailsAsString());
                            while (lordshipCommand.ToLower() != "x")
                            {
                                Console.WriteLine("[D]etails, [H]ouse, [N]obles, [M]ap, [I]nvestigate, [C]onscript, Dischar[g]e, [A]ttack, [S]ummon, E[x]it " + subjectLordship.Name);
                                lordshipCommand = Console.ReadLine();
                                switch (lordshipCommand.ToLower())
                                {
                                    case "d":
                                    case "details":
                                        Console.WriteLine(subjectLordship.GetDetailsAsString());
                                        break;
                                    case "h":
                                    case "house":
                                        Console.WriteLine(subjectLordship.Lord.House.GetDetailsAsString());
                                        break;
                                    case "nobles":
                                    case "n":
                                        {
                                            var nobleHouseholds = subjectLordship.Lord.House.Lordships.SelectMany(l => l.Households.Where(h => h.HeadofHousehold.Class == SocialClass.Noble)).ToList();
                                            var householdCommand = "";
                                            while (householdCommand.ToLower() != "x")
                                            {
                                                Console.WriteLine("Noble households of " + subjectLordship);
                                                for (var i = 0; i < nobleHouseholds.Count(); i++)
                                                {
                                                    Console.WriteLine(
                                                        string.Format(
                                                            "{0}. {1}",
                                                            i + 1,
                                                            nobleHouseholds[i].HeadofHousehold.FullNameAndAge
                                                            )
                                                        );
                                                }
                                                Console.WriteLine("Enter Household Number for more details or E[x]it");
                                                int householdNumber = -1;
                                                householdCommand = Console.ReadLine();
                                                int.TryParse(householdCommand, out householdNumber);
                                                if (householdNumber >= 1 && householdNumber <= nobleHouseholds.Count)
                                                {
                                                    var household = nobleHouseholds[householdNumber - 1];
                                                    var individualHouseholdCommand = "";
                                                    while (individualHouseholdCommand.ToLower() != "x")
                                                    {
                                                        Console.WriteLine(household.GetDetailsAsString());
                                                        for(var i = 0; i<household.Members.Count(); i++)
                                                        {
                                                            Console.WriteLine(
                                                                string.Format(
                                                                    "{0}. {1}",
                                                                    i + 1,
                                                                    household.Members[i].FullNameAndAge
                                                                    )
                                                                );
                                                        }
                                                        Console.WriteLine("Enter Household Number for more details or E[x]it");
                                                        individualHouseholdCommand = Console.ReadLine();
                                                        var memberNumber = -1;
                                                        int.TryParse(individualHouseholdCommand, out memberNumber);
                                                        if (memberNumber>=1 && memberNumber <= household.Members.Count)
                                                        {
                                                            var person = household.Members[memberNumber - 1];
                                                            var personCommand = "";
                                                            while (personCommand.ToLower() != "x")
                                                            {
                                                                Console.WriteLine(person.GetDetailsAsString());
                                                                Console.WriteLine("E[x]it");
                                                                personCommand = Console.ReadLine();
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "m":
                                    case "map":
                                        {
                                            Console.WriteLine(subjectLordship.GetMapOfKnownWorld());
                                        }
                                        break;
                                    case "i":
                                    case "investigate":
                                        {
                                            if (command.Length > 2)
                                            {
                                                switch (command[2].ToLower())
                                                {
                                                    case "lordship":
                                                        {
                                                            Lordship objectLordship = null;
                                                            if (command.Length == 4)
                                                            {
                                                                objectLordship = world.Lordships.FirstOrDefault(l => l.Name.ToLower() == command[3].ToLower());
                                                            }
                                                            else if (command.Length == 5)
                                                            {
                                                                int x;
                                                                int y;
                                                                if (int.TryParse(command[3], out x) && int.TryParse(command[4], out y))
                                                                {
                                                                    objectLordship = world.Lordships.FirstOrDefault(l => l.MapX == x && l.MapY == y);
                                                                }
                                                            }
                                                            var visibleLordships = player.House.Seat.GetVisibleLordships();
                                                            if (objectLordship != null && visibleLordships.Contains(objectLordship))
                                                            {
                                                                Console.WriteLine(objectLordship.GetDetailsAsString());
                                                            }
                                                        }
                                                        break;
                                                    case "person":
                                                        {
                                                            if (command.Length == 5)
                                                            {
                                                                var name = command[3];
                                                                var house = command[4];
                                                                var persons = world.Population.Where(p => p.Name.ToLower() == name.ToLower() && p.House.Name.ToLower() == house.ToLower());
                                                                foreach (var person in persons)
                                                                {
                                                                    Console.WriteLine(person.GetDetailsAsString());
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    case "world":
                                                        {
                                                            Console.WriteLine(world.GetDetailsAsString());
                                                        }
                                                        break;
                                                    case "people":
                                                        {

                                                        }
                                                        break;
                                                }
                                            }
                                        }
                                        break;
                                    case "c":
                                    case "conscript":
                                        {
                                            int soldiersToConscript = int.MaxValue;
                                            string prompt = "";
                                            while ((!int.TryParse(prompt, out soldiersToConscript)) || !(soldiersToConscript <= subjectLordship.EligibleForConscription.Count()))
                                            {
                                                Console.Write(
                                                    subjectLordship.Name + " has " + subjectLordship.Farmers.Count(f => f.IsAlive) + " farmers and " + subjectLordship.Army.Count(s => s.IsAlive) + " soldiers.\n"
                                                    + "There are " + subjectLordship.EligibleForConscription.Count() + " subjects available for conscription. \n"
                                                    + "How many soldiers would you like to conscript?\n"
                                                    );
                                                prompt = Console.ReadLine();
                                            }
                                            subjectLordship.ConscriptSoldiers(soldiersToConscript);

                                            Console.Write(string.Format(
                                                "{0} conscripted {1} soldiers into the army of {2}.\n"
                                                + "{2} now has {3} farmers and {4} soldiers.\n",
                                                subjectLordship.Lord.FullNameAndAge,
                                                soldiersToConscript,
                                                subjectLordship.Name,
                                                subjectLordship.Farmers.Count(f => f.IsAlive),
                                                subjectLordship.Army.Count(s => s.IsAlive)
                                                ));
                                        }
                                        break;
                                    case "g":
                                    case "discharge":
                                        {
                                            int soldiersToDischarge = int.MaxValue;
                                            string prompt = "";
                                            while ((!int.TryParse(prompt, out soldiersToDischarge)) || !(soldiersToDischarge <= subjectLordship.Army.Count(s => s.IsAlive)))
                                            {
                                                Console.Write(string.Format(
                                                    "{0} has {1} farmers and {2} soldiers.\n"
                                                    + "How many soldiers would you like to discharge?\n",
                                                    subjectLordship.Name,
                                                    subjectLordship.Farmers.Count(f => f.IsAlive),
                                                    subjectLordship.Army.Count(s => s.IsAlive)
                                                    ));
                                                prompt = Console.ReadLine();
                                            }
                                            subjectLordship.DischargeSoldiers(soldiersToDischarge);
                                            Console.Write(
                                                "{0} discharged {1} soldiers into the army of {2}.\n"
                                                + "{2} now has {3} farmers and {4} soldiers.\n",
                                                subjectLordship.Lord.FullNameAndAge,
                                                soldiersToDischarge,
                                                subjectLordship.Name,
                                                subjectLordship.Farmers.Count(),
                                                subjectLordship.Army.Count()
                                                );
                                        }
                                        break;
                                    case "a":
                                    case "attack":
                                        {
                                            var allies = subjectLordship.GetAllies();
                                            var attackableLordships =
                                                world.Lordships
                                                .Where(l => !allies.Contains(l) && !double.IsPositiveInfinity(subjectLordship.LocationOfLordAndArmy.GetShortestAvailableDistanceToLordship(l, allies)))
                                                .ToList();
                                            var targetNumber = -1;
                                            var attackCommand = "";
                                            while (!(targetNumber >= 0 && targetNumber <= attackableLordships.Count()) && attackCommand.ToLower() != "x")
                                            {
                                                for (var i = 0; i < attackableLordships.Count(); i++) {
                                                    Console.WriteLine(
                                                        string.Format(
                                                            "{0}. {1} ({2},{3})",
                                                            i + 1,
                                                            attackableLordships[i].Name,
                                                            attackableLordships[i].MapX,
                                                            attackableLordships[i].MapY
                                                        )
                                                    );
                                                }
                                                Console.WriteLine("Enter the number of a lordship to attack or e[x]it.");
                                                attackCommand = Console.ReadLine();
                                                int.TryParse(attackCommand, out targetNumber);
                                            }
                                            if (targetNumber > 0)
                                            {
                                                var targetLordship = attackableLordships[targetNumber - 1];
                                                subjectLordship.Attack(targetLordship, rnd);
                                            }
                                            //Lordship objectLordship = null;
                                            //if (command.Length == 3)
                                            //{
                                            //    objectLordship = world.Lordships.FirstOrDefault(l => l.Name.ToLower() == command[2].ToLower());
                                            //}
                                            //else if (command.Length == 4)
                                            //{
                                            //    int x;
                                            //    int y;
                                            //    if (int.TryParse(command[2], out x) && int.TryParse(command[3], out y))
                                            //    {
                                            //        objectLordship = world.Lordships.FirstOrDefault(l => l.MapX == x && l.MapY == y);
                                            //    }
                                            //}
                                            //if (objectLordship != null)
                                            //{
                                            //    var attackingLordship = subjectLordship;
                                            //    var targetLordship = objectLordship;
                                            //    if (attackingLordship != null && targetLordship != null && !attackingLordship.Vacant && !targetLordship.Vacant)
                                            //    {
                                            //        attackingLordship.Attack(targetLordship, rnd);
                                            //    }
                                            //}
                                        }
                                        break;
                                    //case "pledgefealty":
                                    //    {
                                    //        if (command.Length == 3)
                                    //        {
                                    //            var allegience = world.Lordships.FirstOrDefault(l => l.Name.ToLower() == command[2].ToLower());
                                    //            if (allegience != null)
                                    //            {
                                    //                allegience.AddVassle(subjectLordship);
                                    //            }
                                    //        }
                                    //    }
                                    //    break;
                                    case "s":
                                    case "summon":
                                        {
                                            /*
                                            if (command.Length == 3)
                                            {
                                                var summoned = world.Lordships.FirstOrDefault(l => l.Name.ToLower() == command[2].ToLower());
                                                if (summoned != null)
                                                {
                                                    summoned.DestinationOfLordshipAndArmy = subjectLordship.LocationOfLordAndArmy;
                                                }
                                            }*/
                                            var houseAndVasslLordships = subjectLordship.Lord.House.Lordships.Where(l => l != subjectLordship).Union(subjectLordship.Lord.House.Vassles.SelectMany(v => v.Lordships)).ToList();
                                            //which lordship would you like to summon?
                                            int lordshipIndex = -1;

                                            while (!(lordshipIndex >= 1 && lordshipIndex <= houseAndVasslLordships.Count))
                                            {
                                                Console.WriteLine("Which lordship would " + subjectLordship.Name + " like to summon?");
                                                for (var i = 1; i <= houseAndVasslLordships.Count(); i++)
                                                {
                                                    Console.WriteLine(
                                                        string.Format(
                                                            "{0}. {1}, House {2}, {3} eligible fighters",
                                                            i,
                                                            houseAndVasslLordships[i - 1].Name,
                                                            houseAndVasslLordships[i - 1].Lord.House.Name,
                                                            houseAndVasslLordships[i - 1].EligibleForConscription.Count() + houseAndVasslLordships[i - 1].Army.Count() //those eligible for conscription will always be first-line defenders
                                                        )
                                                  );
                                                }
                                                int.TryParse(Console.ReadLine(), out lordshipIndex);
                                            }
                                            var summoned = houseAndVasslLordships[lordshipIndex - 1];
                                            var numberOfTroopsToSummon = -1;
                                            while (!(numberOfTroopsToSummon >= 0 && numberOfTroopsToSummon <= summoned.EligibleForConscription.Count()))
                                            {
                                                Console.WriteLine(summoned.Name + " has " + (summoned.EligibleForConscription.Count() + summoned.Army.Count()) + " eligible fighters.  How many does " + subjectLordship.Name + " wish to summon?");
                                                int.TryParse(Console.ReadLine(), out numberOfTroopsToSummon);
                                            }
                                            summoned.DeploymentRequest = new DeploymentRequest()
                                            {
                                                RequestingHouse = subjectLordship.Lord.House,
                                                Destination = subjectLordship.LocationOfLordAndArmy,
                                                NumberOfTroops = numberOfTroopsToSummon
                                            };
                                            Console.WriteLine("SUMMONS: " + subjectLordship.Lord.House.Lord.FullNameAndAge + " HAS SUMMONED " + numberOfTroopsToSummon + " fighters from " + summoned.Lord.FullNameAndAge + " to " + subjectLordship.Name);
                                        }
                                        break;

                                }
                            }
                        }
                        //else if (command.Length > 1)
                        //{
                        //    switch (command[1].ToLower())
                        //    {
                        //    }
                        //}
                    }
                }
            }

        }
    }

}
