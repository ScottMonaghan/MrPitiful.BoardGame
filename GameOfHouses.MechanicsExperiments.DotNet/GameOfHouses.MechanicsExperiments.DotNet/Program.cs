using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfHouses.MechanicsExperiments
{
    public class Constants
    {
        public const bool PLAY_INTRO = false;
        public const double CHILDBEARING_CHANCE_IN_PRIME = 0.6;
        public const double DEPENDENT_COST = 1;
        public const double DEPENDENT_INCOME = 0;
        public const double PEASANT_COST = 1;
        public const double PEASANT_INCOME = 10;
        public const double SOLDIER_TOWN_COST = 0;
        public const double SOLDIER_HOUSE_COST = 2;
        public const double SOLDIER_INCOME = 0;
        public const string MALE_NAMES =
            "Abelar,Addam,Addison,Adrack,Adrian,Aegon,Aegor,Aemon,Aemond,Aenar,Aenys,Aerion,Aeron,Aerys,Aethan,Aethelmure,Aggar,Aladale,Alan,Alaric,Albar,Albett,Alebelly,Alekyne,Alesander,Alesandor,Alester,Alf,Alfred,Alfyn,Alios,Allaquo,Allar,Allard,Alleras,Alliser,Alvyn,Alyn,Alys,Ambrose,Amory,Andahar,Andar,Anders,Andrew,Andrey,Andrik,Andros,Androw,Anguy,Antario,Archibald,Ardrian,Areo,Argilac,Arlan,Armen,Armond,Arneld,Arnell,Arnolf,Aron,Arrec,Arron,Arryk,Arson,Arstan,Arthor,Arthur,Artos,Artys,Arwood,Arys,Aurane,Axell,Ayrmidon,AzorAhai,Bael,Baelon,Baelor,Balaq,Ballabar,Balman,Balon,Bannen,Baqq,Barre,Barristan,Barth,Bartimos,Bartimus,Bass,Bayard,Bean,Beans,Beck,Bedwyck,Belaquo,Beldecar,Belicho,Belis,Belwas,Ben,Benedar,Benedict,Benerro,Benethon,Benfred,Benfrey,Benjen,Benjicot,Bennarion,Bennet,Beqqo,Beren,Beric,Bernarr,Beron,Bertram,Bhakaz,Bharbo,BigBoil,Bill,Billy,Biter,BlackFist,Blane,Bloodbeard,Bluetooth,Bodger,Bokkoko,Bonifer,Books,Borcas,Boremund,Boros,Borroq,Borros,Bors,Bowen,Bradamar,Brandon,Brendel,Brenett,Briar,Brogg,Bronn,Brus,Brusco,Bryan,Bryce,Bryen,Brynden,Bryndon,Bump,Burton,Butterbumps,Butts,Byam,Byan,Byron,Cadwyl,Cadwyle,Cadwyn,Caggo,Caleotte,Calon,Calor,Camarron,Canty,Carrot,Casper,Caspor,Casso,Cayn,Cedric,Cedrik,Cellador,Cetherys,Chains,Chayle,Chett,Chezdhar,Chiggen,Chiswyck,Clarence,Clarent,Clayton,Clement,Cleon,Cleos,Cletus,Cley,Clifford,Clydas,Cohollo,Colemon,Colen,Colin,Collio,Colloquo,Colmar,Conn,Conwy,Coratt,Corliss,Corlys,Cortnay,Cossomo,Cotter,Courtenay,Craghas,Cragorn,Craster,Crawn,Cregan,Creighton,Cressen,Creylen,Criston,Cromm,Cugen,Cuger,Cutjack,Daario,Dacks,Daegon,Daemon,Daeron,Dafyn,Dagmer,Dagon,Dagos,Dake,Dalbridge,Dale,Dalton,Damion,Damon,Dan,Dannel,Danny,Danos,Danwell,Dareon,Darla,Daryn,Daven,Davos,Del,Delp,Denestan,Dennet,Dennett,Dennis,Denyo,Denys,Denzo,Dermot,Desmond,Devan,Devyn,Deziel,Dick,Dickon,Dirk,Dobber,Dolf,Domeric,Donal,Donel,Doniphos,Donnel,Donnis,Donnor,Dontos,Doran,Dorden,Dormund,Dorren,Doss,Drennan,Drogo,Dryn,Dudley,Dunaver,Duncan,Dunsen,Dunstan,Duram,Duran,Durran,Dykk,Dywen,Earl,Easy,Ebben,Ebrose,Eddard,Edderion,Eddison,Edgerran,Edmund,Edmure,Edmyn,Edric,Edrick,Edwyd,Edwyle,Edwyn,Eggen,Eggon,Egon,EladonGoldenhair,Elbert,Eldiss,Eldon,Eldred,Ellendor,Ellery,Elmar,Elron,Elwood,Elyas,Elys,Emmett,Emmon,Emmond,Emrick,Endehar,Endrew,Enger,Eon,Erik,Erreck,Erreg,Erren,Errok,Erryk,Ethan,Euron,Eustace,Eyron,Ezzelyno,Faezhar,Farlen,Ferrego,Fingers,Flement,Florian,Fogo,Forley,Fornio,Forrest,Fralegg,Franklyn,Frenken,Frynne,Fulk,Gage,Galbart,Galendro,Galladon,Galyeon,Gared,Garibald,Garigus,Garin,Garlan,Garrett,Garrison,Garse,Garth,Gascoyne,Gavin,Gawen,Gelmar,Gendel,Gendry,Gerald,Gerardys,Geremy,Gergen,Gerion,Germund,Gerold,Gerren,Gerrick,Gerris,Gerrold,Gevin,Ghael,Ghazdor,Gilbert,Gillam,Gilwood,Gladden,Glendon,Goady,Godric,Godry,Godwyn,Goghor,Gorghan,Gormon,Gormond,Gorne,Gorold,Gorys,Gorzhak,Gowen,Gran,Grance,Grazdan,Grazdar,Grazdhan,Grazhar,Greenguts,Gregor,Grenn,GreyWorm,Greydon,Grigg,Grimtongue,Groleo,Grubbs,Grunt,Gueren,Gulian,Guncer,Gunthor,Gurn,Guthor,Guyard,Gwayne,Gylbert,Gyldayn,Gyleno,Gyles,Gylo,Gyloro,Gynir,Haereg,Hagen,Haggo,Haggon,Hake,Hal,Halder,Haldon,Halleck,Hallis,Hallyne,Halmon,Halys,Hamish,Hammer,Harbert,Hareth,Harghaz,Harl,Harlan,Harle,Harlen,Harlon,Harmen,Harmond,Harmund,Harmune,Harrag,Harras,Harren,Harrion,Harrold,Harry,Harsley,Harwin,Harwood,Harwyn,Harys,Hayhead,Hazrak,Heke,Helliweg,Helman,Hendry,Henk,Henly,Herbert,Hero,Heward,Hibald,Hildy,Hilmar,Hizdahr,Hoarfrost,Hobb,Hobber,Hobert,Hod,Hoke,Holger,Hop-Bean,Hop-Robin,Horas,Horonno,Horton,Hosman,Hosteen,Hoster,HotPie,Hother,Hotho,Howd,Howland,Hubard,Hugh,Hugo,Hugor,Hullen,Humfrey,Hunnimore,Husband,Hyle,Iggo,Igon,Illifer,Illyrio,Ilyn,Imry,Ironbelly,Ithoke,Izembaro,Jacaerys,Jace,Jacelyn,Jack,Jack-Be-Lucky,Jacks,Jaehaerys,Jafer,Jaggot,Jaime,Jalabhar,Jammos,Janos,Jaqen,Jared,Jaremy,Jarl,Jarman,Jason,Jasper,Jate,Jax,Jeffory,Jeor,Jeren,Jhaqo,Jhogo,Jodge,Joffrey,John,Jojen,Jokin,Jommo,Jommy,Jon,Jonnel,Jonos,Jonothor,Jorah,Joramun,Jorquen,Jory,Joseran,Joseth,Josmyn,Joss,Josua,Joth,Jothos,Jurne,Justin,Jyck,Kaeth,Karl,Karlon,Karyl,Kasporio,Kedge,Kedry,Kegs,Kem,Kemmett,Kenned,Kennet,Kennos,Kerwin,Ketter,Kevan,Khorane,Khrazz,Kirth,Koss,Kraznys,Kromm,Kurleket,Kurz,Kyle,Kyleg,Kym,Laenor,Lambert,Lancel,Lann,Larence,Lark,Larraq,Larys,Laswell,Leathers,Lem,Lenn,Lennocks,Lenwood,Lenyl,Leo,Leobald,Leslyn,Lester,Lew,Lewyn,Lewys,Leyton,Lharys,Lister,Lomas,Lommy,Lomys,Longleaf,Longwater,Loras,Loren,Lorent,Loreth,Lorimas,Lorimer,Lormelle,Lorren,Lothar,Lotho,Lothor,LoyalSpear,Lucamore,Lucan,Lucantine,Lucas,Luceon,Lucerys,Lucias,Lucifer,Lucimore,Lucion,Luco,Lucos,Luke,Lum,Lump,Luthor,Luton,Luwin,Lyle,Lyman,Lymond,Lyn,Lync,Lyonel,Lysono,Mace,MadAxe,Maegor,Maekar,Maelor,Maelys,Maezon,Mag,Maggo,Mago,Malaquo,Malcolm,Malegorn,Mallador,Malleon,Malliard,Mallor,Malo,Malwyn,Mance,Mandon,Manfred,Manfrey,Manfryd,Manly,Marghaz,Maric,Marillion,Mark,Marlon,Maron,Marq,Marselen,Marston,Martyn,Marwyn,Maslyn,Matarys,Mathis,Mathos,Matt,Matthar,Matthos,Mawney,Maynard,Mazdhan,Mebble,Medger,Medrick,Medwick,Meizo,Mekko,Meldred,Mellos,Melwys,Meribald,Merion,Mern,Mero,Merrel,Merrell,Merrett,Merriman,Merrit,Methyso,Michael,Mikken,Mohor,Mollander,Mollono,Mollos,Monford,Monterys,MoonBoy,Moqorro,Mord,Moredo,Moreo,Morgan,Morgarth,Morghaz,Morgil,Morgo,Moribald,Moro,Moroggo,Morosh,Morrec,Morros,Mors,Morton,Moryn,Mossador,Motho,Mudge,Mullin,Mully,Munciter,Munken,Murch,Murenmure,Murmison,Mushroom,Mycah,Mychel,Myles,Myrio,Myrmello,Nage,Nagga,Naggle,Nail,Narbert,Narbo,Ned,Nestor,Noho,Norbert,Norjen,Normund,Norne,Norren,Notch,Nurse,Nute,Nyessos,Oberyn,Ogo,Ollidor,Ollo,Olymer,Olyvar,Omer,Ondrew,Oppo,Orbelo,Orbert,Ordello,Orell,Orivel,Orland,Ormond,Ormund,Oro,Orson,Orton,Orwyle,Orys,Osbert,Osfryd,Osgood,Osmund,Osmynd,Osney,Osric,Oss,Ossifer,Ossy,Oswell,Oswyn,Othell,Otho,Othor,Otter,Otto,Ottyn,Owen,Oznak,Paezhar,Parmen,Parquello,Patchface,Pate,Patrek,Paul,Paxter,Pearse,Pello,Perestan,Perkin,Perros,Perwyn,Peter,Petyr,Philip,Plummer,Podrick,Pollitor,Pono,Porther,Portifer,Poul,PoxyTym,Praed,Prendahl,Preston,Puckens,Puddingfoot,Pyat,Pycelle,Pyg,Pykewood,Pylos,Pynto,Pypar,Pytho,Qalen,Qarl,Qarlton,Qarro,Qavo,Qhored,Qhorin,Qos,Qotho,Quaro,Quellon,Quence,Quenn,Quent,Quenten,Quentin,Quenton,Quentyn,Quhuru,Quill,Quincy,Quort,Qyburn,Qyle,Racallio,Rafford,Ragnor,Ragwyle,Rakharo,Ralf,Ralph,Ramsay,Randyll,Rast,Rattleshirt,Rawney,Raymar,Raymond,Raymun,Raymund,Raynald,Raynard,Redwyn,Regenard,Renfred,Renly,Rennifer,Rey,Reysen,Reznak,Rhaegar,Rhaegel,Rhodry,Rhogoro,Ricasso,Richard,Rickard,Rickon,Rigney,Robar,Robb,Robert,Robett,Robin,Robyn,Roderick,Rodrik,Rodwell,Roger,Roggo,Roggon,Roland,Rolder,Rolfe,Rollam,Rolland,Rolley,Rolly,Rolph,Rommo,Romny,Ronald,Ronel,Ronnel,Ronnet,Rook,Roone,Roose,Rorge,Roro,Rory,Roryn,Rossart,Royce,Rudge,Rufus,Rugen,Runceford,Runcel,Runciter,Rupert,Rus,Russ,Russell,Rusty,Ryam,Rycherd,Ryger,Ryk,Ryles,Ryman,Rymolf,Rymund,Ryn,Ryon,Saathos,Salladhor,Sallor,Salloreon,Samwell,Sandor,Sargon,Satin,Sawane,Sawwood,Scar,Scarb,Sebastion,Sebaston,Sedgekins,Selmond,Selwyn,Serwyn,Shadd,Shadrich,Shagga,Shagwell,Sharako,Sherrit,Shortear,Sigfry,Sigfryd,Sigorn,Sigrin,Silveraxe,Simon,Skahaz,Skinner,Skittrick,Skyte,Snatch,Softfoot,Soren,SpareBoot,Squint,Stafford,Stalwart,Stannis,Steelskin,Steffar,Steffarion,Steffon,Stevron,Stiv,StoneThumbs,Stonehand,Stonesnake,Stygg,Styr,Sumner,Sybassion,Sylas,Symeon,Symon,Symond,Syrio,Tagganaro,Tal,Talbert,Tallad,Tanton,Tarber,Tarle,Temmo,Ternesio,Terrance,Terrence,Terro,Thaddeus,TheTickler,Theo,Theobald,Theodan,Theodore,Theomar,Theomore,Theon,Therry,Thomax,Thoren,Thormor,Thoros,ThreeToes,Tim,Timeon,Timett,Timon,Timoth,Tion,Titus,Tobbot,Tobho,Todder,Todric,Toefinger,Togg,Tom,Tomard,Tommen,TomToo,Torbert,Toregg,Torghen,Torgon,Torman,Tormo,Tormund,Torrek,Torren,Torrhen,Torwold,Torwynd,Tothmure,Trebor,Tregar,Tremond,Tristan,Tristifer,Tristimun,Triston,Trombo,Trystane,Tuffleberry,Tumberjon,Tumco,Turnip,Turquin,Ty,Tybero,Tybolt,Tycho,Tygett,Tyland,Tyler,Tymor,Tyrek,Tyrion,Tytos,Tywin,Uhlan,Ulf,Uller,Ulmer,Ulwyck,Umar,Umfred,Unwin,Urek,Urho,Urragon,Urras,Urrathon,Urreg,Urrigon,Urron,Urswyck,Urzen,Uthero,Utherydes,Uthor,Utt,Vaellyn,Vaemond,Valarr,Vardis,Vargo,Varly,Varys,Vayon,Vickon,Victarion,Victor,Viserys,Vogarro,Vortimer,Vylarr,Vyman,Walder,Waldon,Walgrave,Wallace,Wallen,Walton,Waltyr,Walys,Warren,Warrick,Wat,Wate,Watkyn,Watt,Watty,Waymar,Wayn,Webber,Weese,Wendamyr,Wendel,Wendello,Werlag,Wex,Whalen,Wick,Wilbert,Will,Willam,Willamen,Willas,Willem,William,Willis,Willit,Woth,Wulfe,Wun,Wyl,Wylis,Wyman,Wynton,Xaro,Xhondo,Yandry,Yezzan,Ygon,Yohn,Yoren,Yorkel,Yorko,Yormwell,Yurkhaz,Zachery,Zharaq,Zollo";
        //"Recene,Wregan,Scur,Bealohydig,Paige,Gimm,Tamar,Nechtan,Sihtric,Bronson,Aldfrith,Ormod,Boniface,Gram,Earm,Irwyn,Ethelwulf,Alchfrith,Eamon,Earl,Gordie,Beowulf,Ord,Sherwin,Grimme,Aethelfrith,Jeffrey,Edward,Acennan,Tobrecan,Orvyn,Lin,Bryce,Felix,Snell,Courtland,Aethelbald,Earm,Rinc,Deman,Ethelbert,List,Agiefan,Cadwallon,Eldrid,Lynn,Shelley,Desmond,Geoff,Agilberht,Ancenned,Manton,Lyn,Beorn,Tracy,Agyfen,Offa,Egesa,Raedwald,Ine,Lynn,Scur,Edlin,Scead,Beadurinc,Putnam,Edgar,Baldlice,Abrecan,Arlice,Earle,Lyn,Bliss,Maccus,Edsel,Werian,Tracey,Germian,Caedwalla,Andsaca,Gordie,Broga,Treddian,Garrett,Cynric,Shelby,Beornwulf,Banan,Eldwin,Gareth,Alwin,Agyfen,Courtney,Stewart,Elmer,Kenway,Scrydan,Garberend,Banning,Sibley,Leof,Alwin,Raedwald,Pleoh,Eldwyn,Irwin,Shepard,Ruadson,Kim,Lufian,Wurt,Storm,Arlice,Ethelred,Pearce,Rinan,Eldwyn,Sherwin,Eadwyn,Beorn,Ethelbert,Beadurof,Sheply,Archard,Wallis,Fairfax,Sheply,Agiefan,Grimme,Selwin,Ahreddan,Eamon,Douglas,Govannon,Maccus,Wissian,Ethelbald,Geraint,Germian,Tedmund,Nodons,Seber,Cadman,Ord,Wright,Aethelbald,Ham,Woden,Shephard,Earle,Scowyrhta,Hererinc,Baldlice,Holt,Druce,Odi,Alden,Toland,Raedan,Lunden,Eadwyn,Edgar,Bordan,Aidan,Kent,Eddison,Brun,Athelstan,Bellinus,Feran,Isen,Wurt,Cynric,Wilbur,Verge,Bayen,Cyst,Camden,Theomund,Sheply,Andsaca,Earm,Andswarian,Ruadson,Atyhtan,Edwin,Aidan,Corey,Ealdian,Edred,Penda,Scand,Pleoh,Cerdic,Bowden,Kenway,Ceawlin,Roweson,Orlege,Caedwalla,Eldred,Seaver,Temman,Aldred,Ethelred,Brice,Stillman,Brecc,Shelby,Ealdian,Wright,Ine,Sceotend,Ruadson,Courtney,Birdoswald,Grendel,Hlaford,Penda,Tilian,Grendel,Anson,Hilderinc,Seaver,Ecgfrith,Courtland,Selwyn,Wann,Cynewulf,Algar,Ody,Bearn,Ethelwulf,Row,Leanian,Cnut,Anson,Devyn,Oswiu,Athelstan,Scand,Scowyrhta,Linn,Ware,Bronson,Drew,List,Benoic,Bronson,Sheldon,Seaver,Erian,Eldwin,Geoff,Wyman,Odel,Piers,Beornwulf,Devyn,Durwin,Wilbur,Audley,Selwyn,Aldred,Wallace,Cynegils,Faran,Denby,Larcwide,Ine,Acwellen,Albinus,Ceolfrith,Ealdian,Cyst,Tolan,Isen,Kent,Eadgard,Wregan,Bowden,Alden,Rinan,Stilwell,Cynegils,Aldfrith,Rinc,Maxwell,Andweard,Lange,Dalston,Rinan,Iden,Wulf,Agyfen,Awiergan,Courtland,Wyman,Aethelwulf,Tredan,Andswaru,Ro,Torhte,Birdoswald,Acey,Kenway,Durwin,Halwende,Awiergan,Tedman,Dreng,Tedman,Raedan,Atol,Awiergan,Arlys,Edwy,Erian,Anhaga,Geoff,Arlyss,Anson,Douglas,Godric,Werian,Boniface,Devyn,Penrith,Rawlins,Rodor,Woden,Aldwyn,Oswy,Tobrecan,Boden,Beowulf,Trace,Worthington,Arian,Rodor,Anfeald,Grindan,Alden,Scead,Gifre,Wright,Garrett,Wade,Govannon,Newton,Seber,Avery,Aethelbert,Alwalda,Caflice,Slecg,Aethelbald,Shelby,Grindan,Earm,Renweard,Raedwald,Cedd,Albinus,Astyrian,Paige,Stearc,Godric,Wissian,Rowe,Ahreddan,Gareth,Odel,Ellen,Beorn,Boniface,Betlic,Merton,Gildas,Deman,Trymian,Sihtric,Ahebban,Geoff,Gordie,Archibald,Douglas,Sheply,Iuwine,Stillman,Gordon,Aethelbald,Jeffrey,Archard,Wine,Shepard,Hlaford,Aldin,Oswald,Penrith,Agiefan,Leng,Orvin,Gildas,Adamnan,Slecg,Rheged,Lin,Byrtwold,Anfeald,Wallis,Holt,Attor,Steadman,Larcwide,Rodor,Kent,Halwende,Egesa,Gimm,Synn,Waelfwulf,Abeodan,Waelfwulf,Grahem,Page,Tedmund,Bordan,Arlys,Oxa,Firman,Ware,Barclay,Wyne,Arth,Edlin,Grimm,Mann,Drefan,Aldfrith,Desmond,Arlyss,Earh,Cyst,Sever,Kent,Rinc,Grindan,Wright,Norville,Bede,Bealohydig,Ablendan,Anhaga,Grindan,Finan,Seamere,Modig,Theomund,Benoic,Erian,Ord,Cnut,Wallis,Bowden,Alchfrith,Dalston,Norvel,Feran,Lufian,Temman,Erconberht,Odon,Kenway,Torhte,Gram,Anwealda,Sheply,Warian,Upton,Hengist,Birdoswald,Sherwyn,Wirt,Camden,Cynric,Ancenned,Eldwyn,Kim,Edmond,Andettan,Winchell,Dreng,Atelic,Grimbold,Lin,Torht,Bliss,Rodor,Agilberht,Snell,Andwyrdan,Ryce,Anna,Hlisa,Shephard,Andsaca,Fraomar,Scead,Grahem,Rowe,Firman,Kimball,Ruadson,Erian,Bar,Mann,Wilfrid,Tellan,Sar,Ahreddan,Eddison,Tolan,Fleming,Odell,Aart,Eadig,Kenric,Ormod,Fleming,Lange,Atelic,Beircheart,Wallis,Trymman,Nerian,Seaver,Winchell,Leng,Aglaeca,Wilbur,Fairfax,Stewart,Offa,Wilbur,Kent,Beadurof,Edlin,Edsel,Archard,Edric,Eldrid,Rinc,Temman,Gifre,Edgard,Acey,Slecg,Feran,Andwyrdan,Aglaeca,Nyle,Colby,Lidmann,Roweson,Aart,Aethelstan,Cynegils,Oswiu,Beadurof,Albinus,Boden,Sceadu,Orvin,Andswarian,Edmund,Lyn,Corey,Caedmon,Stewart,Roe,Sherwyn,Boden,Strang,Worthington,Denisc,Tedman,Isen,Kendrick,Sherard,Storm,Stefn,Tolan,Ruadson,Stedman,List,Nechtan,Lar,Offa,Norvel,Garberend,Arth,Gareth,Tobrytan,Caedmon,Garberend,Seaton,Selwin,Avery,Attor,Banan,Fairfax,Freeman,Lucan,Roweson,Ord,Camdene,Wylie,Eddison,Benoic,Earm,Garr,Finan,Freeman,Lang,Arlys,Bordan,Lar,Bealohydig,Stepan,Seward,Ace,Leng,Durwin,Broga,Toland,Bealohydig,Aethelfrith,Edson,Ethelred,Waelfwulf,Werian,Stewart,Aethelwulf,Alger,Ham,Tracy,Galan,Yrre,Garr,Erconberht,Tracy,Aethelred,Hrypa,Larcwide,Verge,Derian,Seward,Anfeald,Norvel,Ethelbert,Arlys,Andswarian,Byrtwold,Oxa,Ine,Brun,Snell,Iden,Bayen,Shelley,Earle,Stuart,Abrecan,Earm,Nerian,Rinan,Egbert,Linn,Cynewulf,Nyle,Ahreddan,Willan,Ham,Raedbora,Edwy,Cerdic,Aheawan,Archard,Aethelred,Orlege,Earm,Cerdic,Wilfrid,Rodor,Pierce,Pleoh,Edwin,Wissian,Rowson,Iuwine,Amaethon,Raedwald,Teon,Ordway,Byrtwold,Seaton,Teon,Halwende,Grahem,Broga,Tamar,Cadman,Slecg,Nerian,Beowulf,Upton,Teon,Acennan,Odell,Denby,Besyrwan,Edlin,Octha,Synn,Piers,Fyren,Lange,Scand,Row,Tolan,Aldwyn,Camdene,Eldwyn,Willan,Nyle,Awiergan,Gaderian,Kendryck,Cyneric,Wann,Cynegils,Bar,Archibald,Abrecan,Wulfgar,Nodons,Bede,Arth,Chad,Ody,Ethelbert,Elmer,Fugol,Baldlice,Ethelred,Eldwin,Manton,Edgard,Wellington,Ormod,Tedmund,Cynewulf,Gimm,Ody,Boden,Brun,Wright,Wann,Banan,Acennan,Birdoswald,Berkeley,Aethelhere,Grahem,Durwin,Raedan,Audley,Feran,Norton,Eadig,Hlaford,Putnam,Benwick,Chapman,Paige,Norton,Beadurinc,Tolan,Daegal,Bliss,Irwyn,Firman,Selwin,Aethelhere,Brogan,Alwalda,Perry,Aethelbert,Graeme,Trymian,Faran,Nyle,Bealohydig,Yrre,Chapman,Rypan,Anbidian,Hrypa,Maponus,Winter,Ham,Stefn,Ethelbald,Treddian,Perry,Birdoswald,Aethelbald,Nodons,Sever,Aethelbald,Nyle,Swift,Dalston,Teon,Toland,Synn,Tobrecan,Kent,Brogan,Cadman,Sherwyn,Ceawlin,Hrypa,Offa,Ormod,Sheply,Cyneric,Octha,Sever,Edwy,Gimm,Wulfgar,Byrtwold,Aglaeca,Geoffrey,Alwalda,Archard,Aethelfrith,Swithun,Germian,Boyden,Aidan,Bestandan,Aidan,Eldred,Bana,Swift,Daegal,Devyn,Bron,Birdoswald,Roe,Iuwine,Beadurof,Edgar,Fairfax,Bowdyn,Firman,Gildas,Wissian,Rodor,Kendryck,Eldwyn,Agyfen,Denby,Gar,Andwearde,Edsel,Ane,Aethelhere,Woden,Aethelbald,Octha,Brogan,Cyneric,Tredan,Tredan,Beorn,Acennan,Bowdyn,Oswald,Bana,Beornwulf,Courtnay,Wann,Andweard,Eorl,Tellan,Archibald,Trace,Tedman,Grimme,Grendel,Denby,Wilbur,Druce,Scead,Sherwin,Trace,Alger,Irwin,Courtland,Seward,Cedd,Heolstor,Earl,Andweard,Fleming,Grendel,Anfeald,Rice,Garberend,Farmon,Bawdewyn,Wallis,Grendel,Drefan,Druce,Awiergan,Baldlice,Aldwyn,Graham,Torht,Rinc,Elmer,Roweson,Halig,Aldin,Wyman,Wulfhere,Devon,Orvin,Norton,Woden,Mann,Edgar,Prasutagus,Avery,Seaver,Attor,Wissian,Andweard,Earle,Fairfax,Graeme,Raedwald,Cenwalh,Winchell,Andweard,Synn,Ator,Rheged,Wallace,Godric,Row,Geraint,Almund,Ann,Bertie,Woden,Norville,Aethelbald,Aldhelm,Rypan,Bealohydig,Anfeald,Bellinus,Shepard,Egbert,Alwin,Wissian,Edwy,Aethelhere,Nechtan,Norvel,Baecere,Lucan,Ine,Snell,Odon,Grimbold,Oswiu,Edwin,Acwel,Octa,Aglaeca,Snell,Camden,Eldred";
        public const string FEMALE_NAMES =
            "Aemma,Aglantine,Alannys,Alayaya,Alerie,Alia,Alicent,Alla,Allyria,Alyce,Alynne,Alys,Alysane,Alysanne,Alyse,Alyssa,Alyx,Amabel,Amarei,Amerei,Annara,Anya,Arianne,Arwyn,Arya,Asha,Ashara,Assadora,Baela,Bandy,Barba,Barbara,Barbrey,Barra,Barsena,Becca,Belandra,Bella,Bellegere,Bellena,Bellonara,Beony,Berena,Bess,Bessa,Beth,Bethany,Betharios,Brea,Brella,Brienne,Carellen,Carolei,Cass,Cassana,Catelyn,Cerenna,Cersei,Chataya,Chella,Corenna,Cynthea,Cyrenna,Dacey,Daella,Daena,Daenerys,Daeryssa,Dalla,Dancy,Danelle,Darlessa,Deana,Delena,Della,Delonne,Desmera,Dilly,Donella,Donyse,Dorcas,Dorea,Doreah,Dorna,Dyah,Eddara,Eglantine,Eleanor,Elenei,Elenya,Elia,Elinor,Ellaria,Ellyn,Elyana,Elyn,Emberlei,Emma,Erena,Ermesande,Eroeh,Esgred,Ezzara,Falia,Falyse,Ferny,Frenya,Galazza,Gella,Genna,Gilly,Gretchel,Grisel,Grisella,Gwin,Gwynesse,Gwyneth,Gysella,Hali,Harma,Harra,Hazzea,Helaena,Helly,Helya,Holly,Hostella,Irri,Jaehaera,Janei,Janna,Janyce,Jayde,Jayne,Jennelyn,Jenny,Jeyne,Jezhene,Jhiqui,Joanna,Jocelyn,Johanna,Jonelle,Jonquil,Jorelle,Joy,Joyeuse,Jyana,Jyanna,Jynessa,Jyzene,Kella,Kezmya,KojjaMo,Korra,Kyra,Lacey,Laena,Lanna,Larra,Layna,Leaf,Leana,Lemore,Leona,Leonella,Leonette,Leslyn,Lia,Lollys,Loreza,Lyanna,Lyessa,Lynesse,Lyra,Lysa,Lythene,Maddy,Maege,Maegelle,Maerie,Maggy,Marei,Margaery,Margot,Marianne,Maris,Marissa,Mariya,Marsella,Mary,Marya,Masha,Matrice,Meera,Megga,Meggett,Meha,Mela,Melara,Melesa,Melessa,Meliana,Melicent,Melisandre,Melissa,Mellara,Mellario,Mellei,Melly,Meralyn,Meredyth,Merianne,Meris,Mezzara,Mina,Minisa,Mirri,Missandei,Moelle,Mordane,Morna,Morra,Morya,Munda,Mya,Mylenda,Myranda,Myrcella,Myria,Myriah,Myrielle,Myrtle,Mysaria,Naerys,Nan,Nella,Nettles,NissaNissa,Nolla,Nymella,Nymeria,Nysterica,Obara,Obella,Olene,Olenna,Osha,Palla,Penny,Perra,Perriane,Pia,Qezza,Quaithe,Ravella,Rhaella,Rhaena,Rhaenyra,Rhaenys,Rhea,Robin,Roelle,Rosamund,Rosey,Roslin,Rowan,Rowena,Ryella,Rylene,Rylona,S'vrone,Saera,Sallei,Sansa,Sarella,Sarra,Sarya,Scolera,Selyse,Senelle,Serala,Serra,Shae,Sharna,Shella,Shiera,Shierle,Shireen,Shirei,Shyra,Sloey,Snowylocks,Squirrel,Su,Sybell,Sybelle,Sylva,Sylwa,Taena,Talea,Talla,Tanda,Tanselle,Tansy,Thistle,Three-Tooth,Trianna,Tya,Tyana,Tyene,Tysane,Tyta,Umma,Unella,Val,Victaria,Visenya,Walda,Weasel,Wenda,Willow,Wylla,Wynafrei,Wynafryd,Ygritte,Yna,Ynys,Ysilla,Zahrina,Zei,Zhoe,Zia";
        //"Viradecthis,Rheda,Whitney,Bodicea,Tate,Daryl,Ora,Silver,Hilda,Cyst,Engel,Nelda,Edith,Meghan,Bliss,Alodie,Etheswitha,Loretta,Eldrida,Edrys,Viradecthis,Moira,Ifield,Hamia,Chelsea,Beornia,Anlicnes,Juliana,Elga,Kendra,May,Garmangabis,Darel,Aethelflaed,Blythe,Eldrida,Bernia,Annis,Lyn,Daisy,Udele,Udele,Bliss,Megan,Eldrida,Darel,Anlicnes,Darlene,Arianrod,Moira,Dawn,Edrys,Eda,Odelia,Ellenweorc,Lora,Cwen,Darline,May,Nerthus,Sulis,Edlyn,Osberga,Elga,Elvina,Esma,Bisgu,Freya,Kendra,Tate,Aefentid,Estra,Don,Estra,Sibley,Kendra,Cartimandua,Silver,Ora,Diera,Mildred,Maida,Aethelthryth,Don,Rheda,Darelle,Mildred,Silver,Blythe,Bletsung,Odelia,Megan,Edrys,Cwen,Edris,Daisy,Brigantia,Engel,Lora,Wilona,Etheswitha,Wilona,Elvina,Diera,Juliana,Willa,Anlicnes,Aefentid,Andsware,Chelsea,Bernia,Eadgyth,Kendra,Alodie,Darline,Daryl,Orva,Andsware,Alodie,Don,Odelia,Diera,Mercia,Ashley,Claennis,Ellette,Cyst,Nelda,Cearo,Elswyth,Rowena,Cartimandua,Loretta,Elga,Freya,Alodie,Hilda,Sibley,Aethelflaed,Loretta,Catherine,Ifield,Ora,Dohtor,Aefre,Bletsung,Ellenweorc,Wilda,Aethelflaed,Maida,Anlicnes,Alodie,Elswyth,Linette,Silver,Kendra,Bliss,Ashley,Ifield,Maida,Juliana,Cearo,Harimilla,Bysen,Loretta,Freya,Edrys,Annis,Linette,Bearrocscir,Edmunda,Mae,Darlene,Mercia,Elene,Bodicea,Daisy,Ellette,Estra,Elga,Darel,Bliss,Darelle,Edrys,Ellette,Etheswitha,Garmangabis,Maida,Daedbot,May,Wilona,Elva,Edlyn,Brigantia,Brimlad,Sibley,Maida,Easter,Lyn,Ellenweorc,Megan,Mildred,Meghan,Anlicnes,Darelene,Ifield,Elvina,Bodicea,Odelia,Chelsea,Harimilla,Lyn,Bysen,Easter,Annis,Loretta,Wilona,Edlyn,Darel,Garmangabis,Viradecthis,Darel,Whitney,Etheswitha,Bodicea,Bernia,Cwen,Lyn,Maida,Aefre,Kendra,Don,Willa,Eacnung,Darelle,Eda,Cartimandua,Aethelthryth,Kendra,Coventina,Silver,Odelia,Sibley,Erlina,Dohtor,Hilda,Hamia,Moira,Estra,Hilda,Arianrod,Bletsung,Darline,Daryl,Lora,Edrys,Kendra,Kendra,Ashley,Easter,Coventina,Udele,Aefre,Eda,Harimilla,Daisy,Dawn,Darel,Mae,Aefentid,Cyst,Orva,Darel,Claennis,Alodie,Elene,Mercia,Coventina,Darel,Ar,Silver,Sibley,Elene,Mae,Megan,Cwen,Devona,Aefentid,Daryl,Estra,Loretta,Coventina,Don,Osberga,Odelia,Linette,Blythe,Edmunda,Daisy,Claennis,Bliss,May,Elvina,Arianrod,Sunniva,Whitney,Tate,Cyst,Mae,Esma,Bletsung,Nerthus,Megan,Silver,Ellette,Lora,Devona,Nerthus,Edris,Edmunda,Edith,Cyst,Coventina,Sulis,Aedre,Chelsea,Ashley,Daedbot,Elga,Hamia,Mercia,Edlyn,Audrey,Wilona,Ar,Aedre,Elene,Bletsung,Aethelthryth,Cyst,Estra,Ardith,Osberga,Orva,Don,Elvina,Cwen,Ar,Lora,Elga,Mildred,Mae,Bysen,Viradecthis,Engel,Odelia,Easter,Claennis,Aethelthryth,Elva,Edrys,Silver,Beornia,Blythe,Easter,Alodia,Bletsung,Loretta,Nerthus,Elvina,Esma,Udele,Elvina,Osberga,Rheda,Hamia,Lyn,Megan,Kendra,Cyst,Brigantia,Edlyn,Clover,Dawn,Orva,Cyst,Darelene,Claennis,Elva,Eadgyth,Lyn,Edmunda,Catherine,Coventina,Claennis,Bearrocscir,Aefentid,Mercia,Sibley,Beornia,Edmunda,Bliss,Lyn,Mercia,Harimilla,Aedre,Odelia,Cartimandua,Daryl,Rowena,Edith,Mildred,Shelley,Elene,Claennis,Eadgyth,Kendra,Claennis,Sunniva,Bisgu,Erlina,Hamia,Edith,Eadgyth,Ellette,Erlina,Cwen,Chelsea,Moira,Elswyth,Darelle,Orva,Aedre,Lora,Daisy,Elene,Edris,Rheda,Udele,Bernia,Mae,Estra,Bearrocscir,Cearo,Elswyth,Rowena,Edlyn,Elene,Erlina,Kendra,Eda,Sunniva,Megan,Claennis,Cartimandua,Eacnung,Edmunda,Engel,Chelsea,Bernia,Daisy,Bearrocscir,Sibley,Estra,Aefre,Wilda,Don,Arianrod,Elga,Eldrida,Nelda,Megan,Brigantia,Tate,Rheda,Chelsea,Whitney,Ifield,Elga,Nerthus,Meghan,Erlina,Harimilla,Elga,Beornia,Estra,Beornia,Viradecthis,Easter,Mae,Darlene,Alodie,Bearrocscir,Osberga,Eostre,Viradecthis,Silver,Eldrida,Darelene,Bletsung,Clover,Edith,Ardith,Don,Eostre,Darline,Aefentid,Eostre,Eostre,Kendra,Elvina,Orva,Maida,Mildred,Ashley,Eldrida,Eldrida,Edmunda,Meghan,Ifield,Cearo,Devona,Elvina,Ellenweorc,Estra,Audrey,Eacnung,Garmangabis,Esma,Ashley,Ardith,Brimlad,Aedre,Eadgyth,Wilda,Brigantia,Lyn,May,Ar,Chelsea,Claennis,Darelene,Whitney,Edith,Daisy,Eacnung,Sulis,Eadgyth,Bodicea,Shelley,Aethelflaed,Aefentid,Tate,Loretta,Sulis,Mercia,Edmunda,Darlene,Elene,Eda,Brigantia,Udele,Diera,Sunniva,Aedre,Claennis,Dawn,Bisgu,Bliss,Andsware,Esma,Audrey,Engel,Hamia,Brimlad,Cartimandua,Daryl,May,Osberga,Loretta,Alodia,Udele,Don,Garmangabis,Maida,Orva,May,Ora,Don,Acca,Viradecthis,Wilona,Bearrocscir,Wilona,Eacnung,Ifield,Garmangabis,Viradecthis,Wilona,Darelene,Eostre,Hilda,Lyn,Darelene,Darelle,Rheda,Osberga,Ellette,Tate,Aedre,Elvina,Bisgu,Blythe,Don,Viradecthis,Moira,Easter,Bletsung,Freya,Odelia,Willa,Ora,Linette,Brigantia,Aethelthryth,Daedbot,Alodia,Harimilla,Dohtor,Darel,Brimlad,Daisy,Alodie,Elva,Osberga,Edrys,Eda,Acca,Alodia,Sunniva,Eostre,Ashley,Engel,Arianrod,Elvina,Aefentid,Cwen,Annis,Devona,Nerthus,Juliana,Esma,Anlicnes,Aefre,Catherine,Lora,Bliss,Freya,Silver,Coventina,Aefre,Alodie,Daryl,Clover,Elvina,Aethelthryth,Andsware,Estra,Alodia,Sunniva,Hilda,Shelley,Darelle,Daryl,Elvina,Elva,Ellenweorc,Garmangabis,Bletsung,Audrey,Garmangabis,Ellenweorc,Bletsung,Sulis,Mae,Hilda,Moira,Ellenweorc,Bearrocscir,Andsware,Dawn,Mercia,Freya,Arianrod,Darlene,Darel,Acca,Eacnung,Rowena,Bernia,Brigantia,Elswyth,Willa,Darlene,Aefentid,Edith,Ardith,Claennis,Freya,Edmunda,Erlina,Coventina,Daisy,Darelene,Dohtor,Freya,Ellette,Aethelflaed,Mildred,Acca,Cearo,Lyn,Esma,Linette,Dawn,Dohtor,Bernia,Sulis,Darlene,Bernia,Shelley,Ar,Ar,Edlyn,Hilda,Garmangabis,Edith,Rowena,Alodia,Loretta,Bletsung,Mercia,Estra,Elswyth,Maida,Elene,Aefentid,Beornia,Diera,Arianrod,Bodicea,Dawn,Udele,Shelley,Diera,Engel,Aedre,Alodia,Ifield,Eda,Elvina,Megan,Garmangabis,May,Engel,Elvina,Linette,Cyst,Sibley,Wilda,Eacnung,Clover,Aedre,Wilona,Ellenweorc,Elvina,Lyn,Aedre,Easter,Nerthus,Esma,Beornia,Audrey,Elene,Edmunda,Viradecthis,Elga,Odelia,Meghan,Edith,Juliana,Aethelthryth,Clover,Sibley,Alodia,Aethelflaed,Odelia,Whitney,Aethelflaed,Bearrocscir,Blythe,Viradecthis,Clover,Mae,Ardith,Clover,Bernia,Viradecthis,Meghan,Rheda,Dawn,Maida,Catherine,Andsware,Nerthus,Eda,Whitney,Eacnung,Esma,Aefre,Anlicnes,Wilona,Andsware,Annis,Bletsung,Linette,Eadignes,Erlina,Bysen,Megan,Aedre,Udele,Daedbot,Bearrocscir,Edrys,Viradecthis,Shelley,Whitney,Rheda,Chelsea,Loretta,Orva,Ellenweorc,Daryl,Darlene,Chelsea,Ar,Chelsea,Elga,Ashley,Ellette,Dawn,Willa,Nelda,Catherine,Alodia,Juliana,Loretta,Erlina,Ar,Chelsea,Esma,Aefre,Wilona,Claennis,Diera,Bisgu,Elva,Osberga,Rowena,Don,Edmunda,Elvina,Ar,Silver,Nelda,Daryl,Mildred,Cearo,Bearrocscir,Cwen,Willa,Cartimandua,Rheda,Bernia,Aefentid,Elva,Tate,Edlyn,Edlyn,Lora,Viradecthis,Bysen,Bisgu,Bearrocscir,Lyn,Engel,Daryl,Orva,Mildred,Ifield,Brimlad,Harimilla,Andsware,Mae,Viradecthis,Darelene,Acca,Rowena,Loretta,Juliana,Darel,Sunniva,Tate,Willa,Lora,Darel,Osberga,Etheswitha,Lora,Sulis,Elga,Clover,Aethelthryth,Dawn,Bearrocscir,Mercia,Bodicea,Ora,Eostre,Alodie,Chelsea,Acca,Willa,Whitney,Ellette,Willa,Elga,Freya,Bisgu,Freya,Arianrod,Wilda,Elvina,Bysen,Brimlad,Megan,Andsware,Ashley,Aethelflaed,Ora,Cyst,Eostre,Nelda,Chelsea,Linette,Arianrod,Audrey,Hilda,Bernia,Eda,Acca,Odelia,Edith,Meghan,Bernia,Coventina,Bisgu,Darlene,Edrys,Chelsea,Eadgyth,Sulis,Bernia,Anlicnes,Acca,Meghan,Edrys,Beornia,Dohtor,Anlicnes,Cyst,Esma,Daisy,Daedbot,Tate,Sulis,Elva,Dawn,Diera,Eda,Elvina,Moira,Megan,Garmangabis,Cearo,Ardith,Chelsea,Cwen,Linette";
        public const string SURNAMES =
            "Allyrion,Ambrose,Antaryon,Arryn,Ashford,Baelish,Banefort,BarEmmon,Baratheon,Barleycorn,Beesbury,Belgrave,Belmore,Bentley,Bettley,Bigglestone,Blackbar,Blackberry,Blackfyre,Blackmont,Blacktyde,Blackwood,Blount,Bolling,Bolton,Bone,Borrell,Botley,Bracken,Branch,Brax,Broom,Broome,Browntooth,Brune,Buckler,Buckwell,Bulwer,Burley,Bushy,Butterwell,Byrch,Byrne,Bywater,Cafferen,Cargyll,Caron,Cassel,Caswell,Celtigar,Cerwyn,Chambers,Charlton,Chelsted,Chester,Chyttering,Clegane,Clifton,Cobb,Codd,Coldwater,Cole,Condon,Connington,Corbray,Corne,Correy,Costayne,Cox,Crabb,Crakehall,Crane,Cuy,D'han,Dalt,Darke,Darklyn,Darry,Dayne,Dedding,Deddings,Deem,Deremond,Dimittis,Dondarrion,Dothare,Drahar,Drinkwater,Drumm,Duckfield,Durrandon,Dustin,Edoryen,Egen,Emeros,Errol,Estermont,Estren,Farman,Farring,Farrow,Farwynd,Fell,Flatnose,Flint,Florent,Flowers,Follard,Foote,Footly,Forel,Fossoway,Fowler,Foxglove,Freeborn,Fregar,Frey,Galarre,Gardener,Gargalen,Gaunt,Gimpknee,Glover,Godsgrief,Goodbrook,Goodbrother,Goode,Gower,Graceford,Grafton,Grandison,Greenfield,Greenhill,Grell,Grey,Greyiron,Greyjoy,Greysteel,Grimm,H'ghar,Haigh,Harclay,Hardy,Hardyng,Harlaw,Harte,Hasty,Hayford,Heddle,Hetherspoon,Hewett,Hightower,Hill,Hoare,Hoat,Hogg,Hollard,Holt,Hornwood,Horpe,Hotah,Humble,Hungerford,Hunt,Hunter,Inchfield,Ironfoot,Ironmaker,Istarion,Jast,Jayn,Jordayne,Joth,Karstark,Kenning,Kettleblack,Kingsblood,Ladybright,Lannister,Lansdale,Lanster,Largent,Leek,Lefford,Lho,Liddle,Locke,Lohar,Long,Longaxe,Longbough,Longstrider,Longthorpe,Longwaters,Lonmouth,Lorch,Lornel,Lothston,Lychester,Lydden,Lynderly,Maar,Maegyr,Mahr,Malanon,Mallarawan,Mallery,Mallister,Manderly,Mandrake,Manwoody,MarTunDohWeg,Marbrand,Marsh,Martell,Massey,MazDuur,Meadows,Merlyn,Merrell,Merryweather,Mertyns,Mo,moEraz,moKandaq,moNakloz,moReznak,moUllhor,Mogat,Mollen,Moore,Mooton,Mopatis,Moreland,Mormont,Morrigen,Mott,Mudd,Mullendore,Musgood,Myrakis,Myre,naGhezn,Naharis,Nayland,Nestoris,Nogarys,Norcross,Norrey,Noye,Oakheart,OfDorne,OfSisterton,Oldfather,Orkwood,Ormollen,Otherys,Paege,Paenymion,Payne,Peake,Pease,Peasebury,Peckledon,Pemford,Penny,Penrose,Perryn,Piper,Plumm,Poole,Potter,Pox,Pree,Prestayn,Prester,Pyke,QarDeeth,Qhaedar,Qorgyle,Quaynis,Quickaxe,Quince,Rambton,Rankenfell,Rayder,Redback,Redbeard,Redfort,Redwyne,Reed,Reyne,Rhee,Rhegan,Rhysling,Rivers,Rodden,Roote,Rosby,Rowan,Roxton,Royce,Rustbeard,Ruttiger,Ryger,Rykker,Ryndoon,Ryswell,Saan,Saltcliffe,Sand,Santagar,Sarsfield,Sathmantes,Sawyer,Scales,Sealskinner,Seastar,Seaworth,Selmy,Serrett,Serry,Sharp,Shepherd,Shett,Shield,Shieldbreaker,Short,Slate,Slynt,Smallwood,Snow,Sparr,Spicer,Stackspear,Staedmon,Staegone,Stark,Staunton,Stilwood,Stokeworth,Stone,Stonehouse,Stonetree,Storm,Stormdrunk,Stout,Straw,Strickland,Stripeback,Strong,Suggs,Sunderland,Sunderly,Sunglass,Swann,Sweet,Swyft,Tallhart,Tangletongue,Tanner,Tarbeck,Targaryen,Tarly,Tarth,Tawney,Templeton,Tendyris,Terys,Thorne,Tidewood,Toland,Tollett,Toraq,Torrent,Toyne,Tully,Tumitis,Turnberry,Tyrell,Uhoris,Uller,Umber,Vaelaros,Vaith,Vance,Varner,Velaryon,Vhassar,Vikary,Volentin,Volmark,Votar,Votyris,Vypren,Vyrwel,Wagstaff,Wanderer,Waters,Waxley,Wayn,Waynwood,Weaver,WegWunDarWun,Wells,Westerling,Wheaton,Whent,Whitewater,Whittlestick,Willum,Wode,Woods,Woodwright,Wull,Wylde,Wynch,Wythers,Xho,XhoanDaxos,Yarwyck,Yew,YosDob,Yronwood,zoAhlaq,zoEraz,zoFaez,zoGalare,zoLoraq,zoMyraq,zoPahl,zoQaggaz,zoRhaezn,zoYunzak,zoZherzyn";
        public const double NOBLE_COST = 5;
        public const double NOBLE_INCOME = 0;
        public const double SOLDIER_RATIO = 0.1;
        public const double MIN_TAX_RATE = 0.1;
        public const int MAX_YEILD_HIGH = 2000;
        public const int MAX_YEILD_LOW = 1000;
        public const string TOWN_NAMES = 
            "Doddingtree,Winstree,Pershore,Uggescombe,Merton,Kerswell,Bountisborough,Patton,Bowcombe,Gartree,Hormer,Wotton,Spelhoe,Chilford,Arringford,Bibury,Amesbury,Blackwell,Calcewath,Ainsty,Cleyley,LandofCountAlan,Boldre,Redbridge,Navisford,Leintwardine,Acklam,Langbaurgh,Wittery,Agbrigg,Osgodcross,Walsham,Freebridge,[South]Greenhoe,Loningborough,Warmundestrou,Ailwood,Babergh,Condover,Bagstone,Baschurch,Cuttlestone,Grimboldestou,Pirehill,Horethorne,Rushcliffe,Bloxham,Hodnet,Dolesfield,Burghshire,Craven,Ixhill,Mow,Larkfield,Navisland,Wallington,Candleshoe,Skyrack,Beltisloe,Eastry,Salmonsbury,Staincross,Hamestan,Celfledetorn,NorthPetherton,Foxley,Lewknor,Strafforth,Witheridge,Langport,Bere[Regis],Offlow,Street,Amounderness,Sneculfcros,Elsdon,Tremlowe,Upton,Allerton,[West]Derby,Barkston,Corringham,Threo,Cannington,Dic,Lawress,Merset,Stotfold,Claydon,Lothingland,Leominster,Reweset,Wrockwardine,Alnodestreu,Earsham,Edwinstree,Thame,Blackheath,SouthErpingham,Stradel,Rotherfield,Wandelmestrei,Lodding,Carhampton,Leightonstone,NorthErpingham,Selkley,Holderness[MiddleHundred],Tring,Plomesgate,Clavering,StAlbans,Danish,Alderbury,Hinckford,Reading,Frustfield,Tewkesbury,Wilford,Dunley,Ongar,Bircholt,Lexden,Cosford,Boxgrove,Eyhorne,Fishborough,Culvestan,Ruloe,Bishop's,Aldrington,Bulford,Hartcliffe,Huxloe,Nakedthorn,Gallow,Sandford,Blachethorna,Williton,Scarsdale,Kirton,Whitstone,Manley,Blachelaue,Berkeley,Appletree,Bledisloe,Silverton,SouthMolton,Somerton,Pocklington,Bempstone,Morley,Litchurch,Goscote,Exestan,Goderthorn,Mansbridge,Winnibriggs,Barcombe,Studfold,Diptford,Chillington,Hartland,Broadwater,Fernecumbe,Carlford,Blything,Wonford,Henstead,Rushton,Axminster,Tendring,Fawley,Tunendune,Middlewich,Hamston,Coleshill,Colnes,Oswaldslow,Huntspill,Totmonslow,Nobottle,Epworth,Neatham,Stretford,Swanborough,Cerne,TotcombeandModbury,Stratton,Came,Seisdon,Fremington,Meonstoke,Lydney,Connerton,Newark,Bampton,Langley,Pathlow,Bradford,Louthesk,Bromsash,Normancross,BlackTorrington,Thurgarton,Uttlesford,Tornelaus,Easwrithe,Headington,Burnham,Maneshou,Gersdones,Andover,Redbornstoke,Thedwastre,Hertford,Glastonbury,Holderness[SouthHundred],Risberg,Hessle,Welford,Broxtowe,Steyning,Bumbelowe,Dunworth,Rillaton,Flaxwell,Hoddington,Willybrook,Portsdown,Wraggoe,Forehoe,Walecros,Halberton,NorthTawton,Blackbourne,Sutton,Marcham,Bucklow,Bewsbury,Milverton,Elmbridge,Odsey,Yarlestre,Wantage,Kirtlington,Torbar,Hunesberi,Clifton,Shirwell,Polebrook,Guthlaxton,Holderness[NorthHundred],Rowditch,Faversham,Tybesta,Wetherley,Rothwell,Binsted,Shipton,Bolingbroke,Braunton,Pimperne,Axton,Loose,Alleriga,KingsburyWest,Bosmere,Foxearle,Teignbridge,Hildslow,Shropham,WestFlegg,Wymersley,Guilsborough,Haverstoe,Hamfordshoe,Hill,Gravesend,Horncastle,Cliston,Exminster,Winterstoke,Whitley,Freshwell,Overton,Archenfield,Wibrihtesherne,Ashendon,Wye,Blackburn,Longbridge,Spelthorne,Wayland,Abdick,Rochford,Stone,Lifton,Cheveley,Cicementone,Stoke,Cranborne,Stoneleigh,Radlow,Copthorne,Whorwellsdown,Pucklechurch,Heytesbury,Cricklade,Tibblestone,Salford,Alstoe[South],Kilmersdon,Eggardon,Bassetlaw,Aveland,Depwade,Bingham,Hartismere,Manshead,Howden,Towcester,Ati'sCross,Hezetre,Cottesloe,Wacrescumbe,Aylesbury,Yardley,Warden,Wootton,Greston,Blewbury,Alboldstow,Biggleswade,Moulsoe,Ash,Aswardhurn,Puddlelordship,Whitchurch[Canonicorum],Taverham,Graffoe,Hunthow,Yarborough,Cave,Brentry,Fawton,Chafford,Plegelgete,Longtree,Lythe,Kintbury,Shirley,Somborne,Hemyock,Axmouth,Budleigh,Bradley,Plympton,Tunstead,Thornhill,Chelmsford,Binfield,Dudstone,Crondall,Staploe,Risbridge,Taunton,Wimundestreu,Cirencester,Thatcham,Brothercross,Driffield,Holt,Brixton,Thunderlow,Falmer,Radfield,Banbury,Guiltcross,Witley,Ness,Alwardsley,Barcheston,Gainfield,Downton,Barford,Cadworth,Barham,Framland,Charldon,Ruston,Becontree,Rotherbridge,Rinlau,Maidstone,Lothing,[North]Greenhoe,Willaston,Dunmow,SouthPetherton,Barrington,Thingoe,Witchley,Wangford,Barstable,Greytree,Odiham,Dinedor,Clackclose,Rowley,Flitton,Lackford,Swineshead,Barton,Docking,Edgegate,Slotisford,Basingstoke,Mitford,Staple,Bath,Branchbury,Hailesaltede,Conditre,Eynesford,Holford,Beaminster,Felborough,Cornilo,Willingdon,Bromley,Shrivenham,Oswaldbeck,Frome,Shamwell,Totnore,Fordingbridge,Buckelowe,Kinwardstone,Burghbeach,Rowbury,Colyton,Wichestanestou,Laundich,Bridge,Clent,Heane,Rolvenden,Keynsham,Hitchin,Wyndham,Loveden,Benson,Twyford,Bentley,Broughton,Welton,Witham,Marton,Easebourne,Roborough,Streat,Winfrith[Newburgh],Duddeston,Eastbourne,Kingsbridge,Parham,Bexhill,Helmestrei,Dorchester,Westbury,Chippenham,Chuteley,Bury,Langoe,Stanbridge,Newchurch,Walshcroft,Cullifordtree,Singleton,Burton,Droxford,Wittering,Scard,Beynhurst,Ossulstone,Stepleset,Tintinhull,Flexborough,Warminster,Bisley,Ringwood,Overs,Hasler,Worth,Combsditch,Thurstable,Corby,Andersfield,Whitstable,Tandridge,Risborough,Collingtree,Blofield,Scipa,Hurstingstone,Aslacoe,Stowting,Lambourn,Winnianton,Rialton,Tiverton,Stodden,Effingham,Boothby,Rochester,Bosham,Staine,Toseland,Boughton,Botloe,Longstowe,Deerhurst,Pevensey,Papworth,Higham,Humbleyard,Desborough,Startley,Sherborne,Morleystone,Mere,Seckley,Fexhole,EastGrinstead,Ashley,Well,Hallikeld,Holdshott,Westerham,Wincanton,Braughing,Bray,Aloesbridge,Diss,Bruton,Welesmere,Rapsgate,Cutestornes,Cresslow,Cawdon,Mawsley,Brightford,Cheltenham,Thriplow,Fleamdyke,Bosbarrow,Knowlton,Calne,Orlingbury,Avronhelle,Titchfield,Happing,Grimshoe,Reigate,Buckland[Newton],Bucklebury,Edivestone,Henhurst,RomneyMarsh,Woking,Weighton,Wyfold,Wolmersty,Stowmarket,Godley,Castlery,Edlogan,IsCoed,EastFlegg,Calbourne,Cambridge,Chewton,Wellow,Mainsborough,Bermondspit,Cogdean,[Bishops]Cannings,Canterbury,Willey,Ninfield,Brunsell,Eagle,Stowford,Chalton,Charborough,KingsburyEpiscopi,Calehill,Greenwich,Chart,Chatham,Ely1,Langtree,Tollerford,Hilton,Kingston,Chester,Chesterton,Rowborough,Chew,Stockbridge,Buddlesgate,Falemere,Waltham,Houndsborough,Elstub,Chislet,Dumpford,Portbury,Waddesdon,Buttinghill,Kingsclere,Evingar,Ripplesmere,York,Yetminster,Kiftsgate,[Sturminster]Newton,Colchester,Highworth,Elthorne,BrightwellsBarrow,Hurstbourne,Thorngrove,Godalming,Ghidenetroi,Sixpenny,Baldslow,Toreshou,Alstoe[North],Ludborough,Micheldever,Litlelee,Crediton,Crewkerne,Badbury,Wolfhay,Elloe,NorthCurry,WelshDistrict,Warter,Damerham,Wormelow,Eddredestane,Ely2,Mursley,Whittlesford,Summerdene,Lene,Ramsbury,WestGrinstead,Edmonton,Blagrove,Preston,Harlow,Goldspur,Weneslawe,Fareham,Farnham,Gillingham,Wingham,Folkestone,Fordwich,Poynings,Downhamford,Bunsty,Northstowe,Smethdon,Tollingtrough,Guestling,Littlefeld,Martinsley,Hounslow,Samford,Holmestrow,Gore,Hartfield,Dill,Shoyswell,Henfield,Cutsthorn,Langebrige,Hoo,Framfield,Pyrton,Ifield,WOR,Suffolk,Ipswich,Babinrerode,Letberge,Leyland,Wells,Ewias,Wyvern,Reculver,Maldon,Malling,Thanet,Martock,Melksham,Shrewsbury,EastMeon,Milton,Castle,Silverden,Newton,Norwich,Ham,Codsheath,OtteryStMary,Pagham,Oxney,Pawton,Petham,Stursete,Sandwich,Somerley,Teynham,Crickland,Sellack,Sturry,Thetford,Tidenham,LowyofTonbridge,Wechylstone,Hawkesborough,Warrington,Wonderditch,Wrotham,Hemreswel";
        public const int MINIMUM_VILLAGE_SIZE = 25;
        public const int MAP_WIDTH = 20;
        public const int MAP_HEIGHT = 10;
        public const int GENERATIONS_WITHOUT_SHARED_ANCESTOR = 3;
        public const int AGE_OF_MAJORITY = 18;
        public const int AGE_OF_RETIREMENT = 50;
        public const int MAX_BETROTHAL_AGE_DIFFERENCE = 10;
        public const double CHANCE_OF_RECRUITING_FOREIGN_HOUSE = 0.33;
        public const int NUMBER_OF_CHILDREN_FOR_NEW_LORD = 10;
        public const int YEARS_TO_ITERATE_NEW_HOUSES = 30;
        public const int YEARS_TO_ITERATE_PLAYER_HOUSES = 30;
        public const int MAX_RECRUITMENTS = 100;
        public const int NUMBER_OF_POSSIBLE_HEIRS_PER_GENERATION = 3;
        public const int HEIRS_TO_REPORT_ON = 1;
        public const double PERCENTAGE_OF_INCOME_TOWARD_SOLDIERS = 0.8;
        public const double PLAYER_MOVES_PER_YEAR = 1;
    }
    public static class Utility
    {
        public static string GetName(Sex sex, Random rnd)
        {
            var maleNames = Constants.MALE_NAMES.Split(',');
            var femaleNames = Constants.FEMALE_NAMES.Split(',');
            if (sex == Sex.Male)
            {
                return maleNames[rnd.Next(0, maleNames.Count())];
            }
            else
            {
                return femaleNames[rnd.Next(0, femaleNames.Count())];
            }
        }
    }
    public class Player
    {
        public Player()
        {
            House = null;
        }
        public House House { get; set; }
        public void SettleNewLordship(Lordship sourceLordship, Lordship targetLordship, Household lordsHouseHold, List<Household> peasantHouseholds)
        {
            if (sourceLordship.PlayerMoves.Count(p=>p==this) < Constants.PLAYER_MOVES_PER_YEAR) { 
                Lordship.PopulateLordship(targetLordship, lordsHouseHold, peasantHouseholds);
                sourceLordship.PlayerMoves.Add(this);
                sourceLordship.AddVassle(targetLordship);
            }
        }
    }
    public class AssessedIncome
    {
        public int Year { get; set; }
        public double Income { get; set; }
    }
    public enum Sex
    {
        Female = 0,
        Male = 1
    }
    public enum Profession
    {
        Dependant = 0,
        Peasant = 1,
        Noble = 2,
        Soldier = 3
    }
    public enum SocialClass
    {
        Noble = 0,
        Peasant = 1
    }
    public enum People
    {
        Saxon = 0,
        Dane = 1
    }
    public class World
    {
        private Random _rnd;
        public World(Random rnd)
        {
            Year = 0;
            Lordships = new List<Lordship>();
            Population = new List<Person>();
            NobleHouses = new List<House>();
            Bethrothals = new List<Bethrothal>();
            Player = null;
            _rnd = rnd;
        }
        public Player Player { get; set; }
        public int Year { get; set; }
        public List<Lordship> Lordships { get; set; }
        public List<Person> Population { get; set; }
        public List<House> NobleHouses { get; set; }
        public void AddLordship(Lordship lordship)
        {
            if (!Lordships.Contains(lordship))
            {
                if (lordship.World != null)
                {
                    lordship.World.RemoveLordship(lordship);
                }
                Lordships.Add(lordship);
                lordship.World = this;
            }
        }
        public void RemoveLordship(Lordship lordship)
        {
            if (Lordships.Contains(lordship))
            {
                Lordships.Remove(lordship);
                lordship.World = null;
            }
        }
        public void AddHouse(House house)
        {
            if (!NobleHouses.Contains(house))
            {
                if (house.World != null)
                {
                    house.World.RemoveHouse(house);
                }
                NobleHouses.Add(house);
                house.World = this;
            }
        }
        public void RemoveHouse(House house)
        {
            if (NobleHouses.Contains(house))
            {
                NobleHouses.Remove(house);
                house.World = null;
            }
        }
        public void AddPerson(Person person)
        {
            if (person.World != null)
            {
                person.World.RemovePerson(person);
            }
            Population.Add(person);
            person.World = this;
        }
        public void RemovePerson(Person person)
        {
            Population.Remove(person);
            person.World = null;
        }
        public void IncrementYear()
        {
            Year++;
            var population = new List<Person>();
            var nobleHouses = new List<House>();
            var lordships = new List<Lordship>();

            population.AddRange(Population);
            nobleHouses.AddRange(NobleHouses);
            lordships.AddRange(Lordships);
            population.ForEach(person => person.IncrementYear());
            nobleHouses.ForEach(house => house.IncrementYear(_rnd));
            lordships.ForEach(lordship => lordship.IncrementYear());
        }
        public string GetMapAsString(House house = null, Lordship lordship = null, int? people = null)
        {
            //output map
            List<Lordship> subVassles = null;
            if (lordship != null)
            {
                subVassles = lordship.GetAllSubVassles();
            }
            var map = "   |";
            for (var x = 1; x<=Constants.MAP_WIDTH; x++)
            {
                map += x.ToString("000") + "|";
            }
            map += "\n";
            for (var y = 1; y <= Constants.MAP_HEIGHT; y++)
            {
                map += y.ToString("000");
                for (var x = 1; x <= Constants.MAP_WIDTH; x++)
                {
                    map += "|";
                    var lordshipOnMap = Lordships.First(v => v.MapX == x && v.MapY == y);
                    //var vassles = lordshipOnMap
                    if (!lordshipOnMap.Vacant 
                        && (house == null || lordshipOnMap.Lords.Last().House == house) 
                        && (lordship == null || (lordshipOnMap == lordship || (subVassles != null && subVassles.Contains(lordshipOnMap)))) 
                        && (people == null || (int)lordshipOnMap.Lords.Last().People == people.Value))
                    {
                        if (house != null || (subVassles != null && subVassles.Contains(lordshipOnMap))){
                            map += lordshipOnMap.Fighters.Count.ToString("000");
                        } 
                        else
                        {
                            map += "  " + lordshipOnMap.Lords.Last().House.Symbol;
                        }
                    }
                    else 
                    {
                        map += "   ";
                    }
                }
                map += "|" + y.ToString("000") + "\n";
            }
            map += "   |";
            for (var x = 1; x <= Constants.MAP_WIDTH; x++)
            {
                map += x.ToString("000") + "|";
            }
            map += "\n";
            return map;
        }
        public string GetDetailsAsString()
        {
            var retString = "";
            var world = this;
            retString += world.GetMapAsString();
            retString += ("Dane Noble Houses: " + world.NobleHouses.Count(x => !x.Vacant && x.Lords.Last().People == People.Dane) + "\n");
            retString += ("Saxon Noble Houses: " + world.NobleHouses.Count(x => !x.Vacant && x.Lords.Last().People == People.Saxon) + "\n");
            retString += ("Lordships: " + world.Lordships.Count(x => x.Households.Count() > 0)) + "\n";
            retString += ("Total Population: " + world.Population.Count(x => x.IsAlive)) + "\n";
            retString += ("Total Saxon Population: " + world.Population.Count(x => x.IsAlive && x.People == People.Saxon)) + "\n";
            retString += ("Total Dane Population: " + world.Population.Count(x => x.IsAlive && x.People == People.Dane)) + "\n";
            retString += ("Total Noble Households: " + world.Lordships.Sum(x => x.Households.Count(y => y.HouseholdClass == SocialClass.Noble))) + "\n";
            retString += ("Total Peasant Households: " + world.Lordships.Sum(x => x.Households.Count(y => y.HouseholdClass == SocialClass.Peasant))) + "\n";
            retString += ("------------------------") + "\n";
            return retString;
        }
        public List<Bethrothal> Bethrothals
        {
            get; set;
        }
        public Bethrothal CreateBethrothal(Person headOfHouseoldToBe, Person spouseToBe, int year, bool echo = false)
        {
            //remove any existing bethrothals 
            Bethrothals.Where(b => b.HeadOfHouseholdToBe == headOfHouseoldToBe || b.SpouseToBe == spouseToBe).ToList()
                .ForEach(b => CancelBetrothal(b));
            var bethrothal = new Bethrothal()
            {
                HeadOfHouseholdToBe = headOfHouseoldToBe,
                SpouseToBe = spouseToBe,
                Year = year,
                world = this
            };
            headOfHouseoldToBe.Bethrothal = bethrothal;
            spouseToBe.Bethrothal = bethrothal;
            Bethrothals.RemoveAll(b => b.HeadOfHouseholdToBe == headOfHouseoldToBe || b.SpouseToBe == spouseToBe);
            Bethrothals.Add(bethrothal);

            if (echo && headOfHouseoldToBe.House == headOfHouseoldToBe.World.Player.House && headOfHouseoldToBe.World.Player.House.Lords.Last().GetCurrentHeirs().Contains(headOfHouseoldToBe))
            {
                Console.WriteLine("BETROTHAL: " + bethrothal.HeadOfHouseholdToBe.FullNameAndAge + " was BETROTHED to " + bethrothal.SpouseToBe.FullNameAndAge + " in " + year);
            }
            return bethrothal;
        }
        public void CancelBetrothal(Bethrothal bethrothal)
        {
            bethrothal.HeadOfHouseholdToBe.Bethrothal = null;
            bethrothal.SpouseToBe.Bethrothal = null;
            bethrothal.HeadOfHouseholdToBe = null;
            bethrothal.SpouseToBe = null;
            Bethrothals.Remove(bethrothal);
        }
    }
    public class House
    {
        public House()
        {
            Lords = new List<Person>();
            Members = new List<Person>();
            //Soldiers = new List<Person>();
            AvailableUnmarriedMembers = new List<Person>();
            //Vassles = new List<House>();
            AssessedIncome = new List<AssessedIncome>();
            Recruitments = 0;
            Player = null;
        }
        //public List<Person> Soldiers { get; set; }
        public int Recruitments { get; set; }
        public Player Player { get; set; }
        public void AddPlayer(Player player)
        {
            Player = player;
            player.House = this;
        }
        public Lordship Seat { get; set; }
        
        //public House Allegience { get; set; }

        //public List<House> Vassles { get; set; }
        public World World { get; set; }
        public char Symbol { get; set; }
        public String Name { get; set; }
        public bool Vacant { get; set; }
        public List<Person> Lords { get; set; }
        public List<Person> Members { get; set; }
        public List<Person> AvailableUnmarriedMembers { get; set; }
        public void AddMember(Person newMember)
        {
            if (!Members.Contains(newMember))
            {
                if (newMember.House != null)
                {
                    newMember.House.RemoveMember(newMember);
                }
                Members.Add(newMember);
                newMember.House = this;
            }
        }
        public void RemoveMember(Person oldMember)
        {
            if (Members.Contains(oldMember))
            {
                if (oldMember.House != null)
                {
                    oldMember.House = null;
                }
                Members.Remove(oldMember);
            }
        }
        public List<Person> GetOrderOfSuccession(int depth)
        {
            var successionList = new List<Person>();
            var lordIndex = Lords.Count - 1;
            while (successionList.Count() < depth && lordIndex >= 0)
            {
                var lordsHeirs = Lords[lordIndex].GetHeirs().Where(heir => heir.IsAlive);
                foreach (var heir in lordsHeirs)
                {
                    if (!successionList.Contains(heir) && !Lords.Contains(heir))
                    {
                        successionList.Add(heir);
                    }
                }
                lordIndex--;
            }
            return successionList.Take(depth).ToList();
        }
        //public void RecruitSoldiers(Random rnd)
        //{
        //    //remove dead and retired soldiers from ranks
        //    Soldiers.RemoveAll(s => !s.IsAlive || s.Age >= Constants.AGE_OF_RETIREMENT);
        //    var lastYearsAssessedIncome = AssessedIncome.FirstOrDefault(ai => ai.Year == World.Year - 1);
        //    if (lastYearsAssessedIncome != null)
        //    {
        //        var soldierBudget = lastYearsAssessedIncome.Income * Constants.PERCENTAGE_OF_INCOME_TOWARD_SOLDIERS;
        //        var soldierCost = Soldiers.Count() * Constants.SOLDIER_HOUSE_COST;
        //        var remainingSoldierBudget = soldierBudget - soldierCost;
        //        if (remainingSoldierBudget > 0)
        //        {
        //            var soldiersToRecruit = (int)Math.Floor(remainingSoldierBudget / Constants.SOLDIER_HOUSE_COST);
        //            var recruitableSubjects = World.Population.Where(p =>
        //                p.IsAlive
        //                && p.Profession != Profession.Soldier
        //                && p.Age >= Constants.AGE_OF_MAJORITY
        //                && p.Age <= Constants.AGE_OF_RETIREMENT
        //                && p.Household != null
        //                && p.Household.Lordship != null
        //                && p.Household.Lordship.Lords.Last().House == this
        //            ).ToList();
        //            while (soldiersToRecruit > 0 && recruitableSubjects.Count() > 0)
        //            {
        //                Soldiers.Add(recruitableSubjects[rnd.Next(0, recruitableSubjects.Count())]);
        //                soldiersToRecruit--;
        //            }
        //        }
        //    }
        //}
        public void IncrementYear(Random rnd)
        {
            var incumbentLord = Lords.Last();
            //CollectTaxes();
            //RecruitSoldiers(rnd);
            if (!incumbentLord.IsAlive)
            {
                //The lord is Dead!  Long live the lord!

                if (World.Player!=null && World.Player.House!= null && incumbentLord.House == World.Player.House)
                {
                    Console.WriteLine(String.Format("In {0} YOU DIED. Your family and your kingdom mourn for you.", World.Year));
                }

                Person heir = null;
                var orderOfSuccession = GetOrderOfSuccession(1);
                if (orderOfSuccession.Count > 0)
                {
                    heir = orderOfSuccession[0];
                }
                if (heir != null)
                {
                    AddLord(heir);
                    if (World.Player != null && World.Player.House!=null && (heir.House == World.Player.House || incumbentLord.House == World.Player.House))
                    {
                        Console.WriteLine();
                        Console.WriteLine(heir.FullNameAndAge + " INHERITED the Lordship of House " + Name + " from " + incumbentLord.FullNameAndAge + " in " + World.Year);
                        if (heir.House != incumbentLord.House)
                        {
                            Console.WriteLine("LOSS OF HOUSE! Control of House " + Name + " passed to " + heir.House.Name + " in " + World.Year);
                        }
                        Console.WriteLine("Enter to continue...");
                        Console.ReadLine();
                        Console.WriteLine("You are " + heir.FullNameAndAge);
                        Console.WriteLine("Enter to continue...");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Vacant = true;
                    if (incumbentLord.House == World.Player.House)
                    {
                        Console.WriteLine("END OF HOUSE: The Lordship of House " + Name + " is vacant.");
                    }
                }
            }

        }
        public void AddLord(Person newLord)
        {
            if (!newLord.HouseLordships.Contains(this))
            {
                newLord.HouseLordships.Add(this);
            }
            if (newLord.Household != null && newLord != newLord.Household.HeadofHousehold)
            {
                var newHousehold = new Household()
                {
                    HeadofHousehold = newLord
                };
                newHousehold.AddMember(newLord);
                if (newLord.Spouse != null && newLord.Spouse.IsAlive)
                {
                    newHousehold.AddMember(newLord.Spouse);
                    var spousesMinorChildren = newLord.Spouse.Children.Where(x => x.Age < Constants.AGE_OF_MAJORITY);
                    foreach (var child in spousesMinorChildren)
                    {
                        newHousehold.AddMember(child);
                    }
                }
                var lordsMinorChildren = newLord.Children.Where(x => x.Age < Constants.AGE_OF_MAJORITY);
                foreach (var child in lordsMinorChildren)
                {
                    newHousehold.AddMember(child);
                }
            }
            if (Seat != null && (newLord.Household.Lordship == null || newLord.Household.Lordship != Seat))
            {
                Seat.AddHousehold(newLord.Household);
            }
            Lords.Add(newLord);
        }
        //public List<House> GetAllSubVassles()
        //{
        //    var subVassles = new List<House>();
        //    foreach (var vassle in Vassles)
        //    {
        //        subVassles.Add(vassle);
        //        subVassles.AddRange(vassle.GetAllSubVassles());
        //    }
        //    return subVassles;
        //}
        public string GetDetailsAsString()
        {
            var retString = World.GetMapAsString(this);
            retString += ("House: " + Name + '\n');
            var incumentlord = Lords.Last();
            retString += ("Lord: " + incumentlord.FullNameAndAge + '\n');
            retString += ("Total Noble Households: " + World.Lordships.Sum(x => x.Households.Count(y => y.HeadofHousehold.Class == SocialClass.Noble && y.HeadofHousehold.House == this))) + "\n";
            retString += ("Total Peasant Households: " + World.Lordships.Where(ls=>!ls.Vacant && ls.Lords.Last().House == this).Sum(x => x.Households.Count(y => y.HeadofHousehold.Class == SocialClass.Peasant))) + "\n";
            retString += ("Wealth: " + Wealth.ToString("0.00") + '\n');
            var lastYear = World.Year - 1;
            var lastYearsIncome = AssessedIncome.FirstOrDefault(x => x.Year == lastYear);
            if (lastYearsIncome != null)
            {
                retString += lastYear + " Income: " + lastYearsIncome.Income.ToString("0.00") + "\n";
            }
            retString += "Lordships: " + World.Lordships.Where(t => !t.Vacant && t.Lords.Last().House == this).Count() + "\n";
            //retString += "Soldiers: " + Soldiers.Count(s => s.IsAlive) + "\n";
            retString += ("Order of Succession:" + '\n');
            var orderOfSuccession = GetOrderOfSuccession(10);
            for (int i = 0; i < orderOfSuccession.Count(); i++)
            {
                retString += ((i + 1) + ": " + orderOfSuccession[i].FullNameAndAge + '\n');
            }
            if (Seat.Allegience != null)
            {
                retString += "Allegience: " + Seat.Allegience.Name + "\n";
            }
            retString += "Vassles:\n";
            foreach (var vassle in Seat.Vassles)
            {
                retString += "\t" + vassle.Name + "(" + vassle.GetAllSubVassles().Count() + " sub-vassles)\n";
            }
            return retString;
        }
        /*
        public void AddVassle(House vassle)
        {
            if (!Vassles.Contains(vassle))
            {
                if (vassle.Allegience != null)
                {
                    vassle.Allegience.RemoveVassle(vassle);
                }
                Vassles.Add(vassle);
                vassle.Allegience = this;
            }
        }
        public void RemoveVassle(House vassle)
        {
            if (Vassles.Contains(vassle))
            {
                if (vassle.Allegience != null)
                {
                    vassle.Allegience = null;
                }
                Vassles.Remove(vassle);
            }
        }
        */
        public List<Person> GetIndespensibleMembers(int numberOfPossibleHeirsPerGeneration = Constants.NUMBER_OF_POSSIBLE_HEIRS_PER_GENERATION)
        {
            var indespensibleMembers = new List<Person>();
            //get house heirs
            var livingHeirs = Lords[0].GetHeirs().Where(member =>
                member.IsAlive
                &&
                (member.Father != null && member.Mother != null)
                && (
                    member.Father.Children.Where(child => child.IsAlive).OrderByDescending(child => child.Age).ToList().IndexOf(member) < numberOfPossibleHeirsPerGeneration
                    || member.Mother.Children.Where(child => child.IsAlive).OrderByDescending(child => child.Age).ToList().IndexOf(member) < numberOfPossibleHeirsPerGeneration
                )
            ).ToList();
            // get heirs of each house lordship
            var houseLordshipLords = Members.Where(m => m.Lordships.Count > 0).ToList();
            var lordshipHeirs = new List<Person>();
            houseLordshipLords.ForEach(lordshipLord =>
                lordshipHeirs.Union(
                    lordshipLord.GetHeirs().Where(member =>
                        member.IsAlive
                        &&
                        (member.Father != null && member.Mother != null)
                        && (
                            member.Father.Children.Where(child => child.IsAlive).OrderByDescending(child => child.Age).ToList().IndexOf(member) < numberOfPossibleHeirsPerGeneration
                            || member.Mother.Children.Where(child => child.IsAlive).OrderByDescending(child => child.Age).ToList().IndexOf(member) < numberOfPossibleHeirsPerGeneration
                        )
                    )
                )
            );
            return livingHeirs.Union(houseLordshipLords).Union(lordshipHeirs).ToList();
        }
        public List<Person> GetDispensibleMembers()
        {
            //return Members.Except(GetPossibleHeirs()).ToList();
            return Members.Except(GetIndespensibleMembers()).ToList();
        }
        public double Wealth { get; set; }
        public List<Lordship> GetLordships()
        {
            return World.Lordships.Where(lordship => !lordship.Vacant && lordship.Lords.Last().House == this).ToList();
        }
        //public void CollectTaxes()
        //{
        //    //set tax year for tax collection
        //    var previousTaxYear = World.Year - 1;
        //    double houseIncome = 0;

        //    //first collect assessed taxes from previous year from each lordship under house control
        //    var houseLordships = GetLordships();
        //    foreach (var houseLordship in houseLordships)
        //    {
        //        var assessedLordshipIncome = houseLordship.AssessedIncome.FirstOrDefault(income => income.Year == previousTaxYear);
        //        if (assessedLordshipIncome != null)
        //        {
        //            //move ALL income from lordship wealth to house coffers (the house lord controls all wealth for the house)
        //            houseLordship.Wealth -= assessedLordshipIncome.Income;
        //            houseIncome += assessedLordshipIncome.Income;
        //        }
        //    }
        //    //next collect assessed taxes from all vassle houses
        //    foreach (var vassle in Vassles)
        //    {
        //        var assessedVassleIncome = vassle.AssessedIncome.FirstOrDefault(income => income.Year == previousTaxYear);
        //        if (assessedVassleIncome != null)
        //        {
        //            //tax vassle income at tax rate
        //            var tax = assessedVassleIncome.Income * Constants.MIN_TAX_RATE;
        //            vassle.Wealth -= tax;
        //            houseIncome += tax;
        //        }
        //    }
        //    //add income to wealth
        //    Wealth += houseIncome;
        //    //add assessment for taxes
        //    AssessedIncome.Add(new AssessedIncome() { Year = World.Year, Income = houseIncome });
        //}
        public List<AssessedIncome> AssessedIncome { get; set; }
        public List<Person> GetPotentialSettlerLords()
        {
            var house = this;
            var potentialSettlerLords = house.Members.Where(x =>
            x.Lordships.Count() == 0
            && x.Household != null
            && x.Household.HeadofHousehold == x
            && x.GetHeirs().Count(heir => heir.House != house) == 0
            ).ToList();
            return potentialSettlerLords;

        }
        public void Attack(Lordship target, Person attackingLord, List<Person> attackingArmy, Random rnd)
        {
            //1-on-1 battle
            var defenders = new List<Person>();
            //var attackers = new List<Person>();
            //attackers.AddRange(army);
            //int defenderCasulties = 0;
            //int attackerCasulties = 0;
            foreach(var household in target.Households.Where(h=>h.HeadofHousehold.Class==SocialClass.Peasant))
            {
                defenders.AddRange(household.Members.Where(
                    m => m.IsAlive
                    && m.Age >= Constants.AGE_OF_MAJORITY
                    && m.Age <= Constants.AGE_OF_RETIREMENT)
                    );
            }
            var livingDefenders = defenders.ToList();
            var livingAttackers = attackingArmy.ToList();
            while (livingDefenders.Count()>0 && livingAttackers.Count() > 0)
            {
                var defender = livingDefenders[rnd.Next(0, livingDefenders.Count())];
                var attacker = livingAttackers[rnd.Next(0, livingAttackers.Count())];
                var battleResult = rnd.Next(0, 2);
                if (battleResult == 0)
                {
                    attacker.IsAlive = false;
                } else
                {
                    defender.IsAlive = false;
                }
                livingDefenders = defenders.Where(d => d.IsAlive).ToList();
                livingAttackers = attackingArmy.Where(a => a.IsAlive).ToList();
            }
            Console.WriteLine("ATTACK: " + attackingLord.FullNameAndAge + " ATTACKED " + target.Name);
            Console.WriteLine("\tAttacker Total: " + attackingArmy.Count());
            Console.WriteLine("\tDefender Total: " + defenders.Count());
            Console.WriteLine("\tAttacker Casulties: " + attackingArmy.Where(p=>!p.IsAlive).Count());
            Console.WriteLine("\tDefender Casulties: " + defenders.Where(p => !p.IsAlive).Count());
            Console.WriteLine("\tRemaining Attackers: " + attackingArmy.Where(p => p.IsAlive).Count());
            Console.WriteLine("\tDefender Defenders: " + defenders.Where(p => p.IsAlive).Count());
            if (livingDefenders.Count() == 0)
            {
                //clear the lords and make the town vacant
                target.Lords.Last().Lordships.Remove(target);
                target.Lords.Clear();
                target.Vacant = true;
            }
        }
    }
    public class Household
    {
        public Household()
        {
            Members = new List<Person>();
            Lordship = null;
            HouseholdClass = SocialClass.Peasant;
        }
        //The members of the family
        //public Person HouseFounder { get; set; }
        public Person HeadofHousehold { get; set; }
        public List<Person> Members { get; set; }
        //Where the family currently lives
        public Lordship Lordship { get; set; }
        public SocialClass HouseholdClass { get; set; }
        public void AddMember(Person newMember)
        {
            if (!Members.Contains(newMember))
            {
                if (newMember.Household != null)
                {
                    newMember.Household.RemoveMember(newMember);
                }
                Members.Add(newMember);
                newMember.Household = this;
            }
        }
        public void RemoveMember(Person oldMember)
        {
            Members.Remove(oldMember);
            oldMember.Household = null;
            if (Members.Count == 0)
            {
                if (Lordship != null)
                {
                    Lordship.Households.Remove(this);
                    Lordship = null;
                }
            }
            else if (oldMember == HeadofHousehold)
            {
                //make eldest head of household
                HeadofHousehold = Members.OrderBy(x => x.Age).Last();
            }
        }
        public string GetDetailsAsString()
        {
            var retStr = "";
            retStr += "Class:" + HouseholdClass + "\n"
            + "Lordship: " + Lordship.Name + "\n"
            + "Head of Household: " + HeadofHousehold.Name + "\n"
            + "Members:" + "\n";
            foreach (var member in Members)
            {
                retStr += "\t" + member.FullNameAndAge + "\n";
            }
            return retStr;
        }
        public static Household CreateMarriageHousehold(Person headOfHousehold, Person spouse, bool echo = false)
        {
            Household marriageHousehold;
            var headsOldHousehold = headOfHousehold.Household;
            var spousesOldHousehold = spouse.Household;
            if (echo)
            {
                if (headOfHousehold.House == headOfHousehold.World.Player.House && headOfHousehold.House.World.Player.House.Lords.Last().GetCurrentHeirs().Contains(headOfHousehold))
                {
                    Console.WriteLine("MARRIAGE: " + headOfHousehold.FullNameAndAge + " MARRIED " + spouse.FullNameAndAge + " in " + headOfHousehold.World.Year);
                }
            }
            //if headOfHousehold is already head then their house is the marriageHousehold
            if (headsOldHousehold != null && headsOldHousehold.HeadofHousehold == headOfHousehold)
            {
                marriageHousehold = headOfHousehold.Household;
            }
            else
            {
                marriageHousehold = new Household()
                {
                    HeadofHousehold = headOfHousehold
                };
                if (headsOldHousehold != null)
                {
                    marriageHousehold.HouseholdClass = headsOldHousehold.HouseholdClass;
                    marriageHousehold.Lordship = headsOldHousehold.Lordship;
                }
            }
            marriageHousehold.AddMember(headOfHousehold);
            marriageHousehold.AddMember(spouse);
            headOfHousehold.House.AddMember(spouse);
            if (marriageHousehold.Lordship != null)
            {
                marriageHousehold.Lordship.AddHousehold(marriageHousehold);
            }

            //add head's minor children to household
            var headsMinorChildren = headOfHousehold.Children.Where(x => x.Age < 18 & x.IsAlive).ToList();
            if (headsMinorChildren.Count() > 0)
            {
                headsMinorChildren.ForEach(x => {
                    marriageHousehold.AddMember(x);
                });
            }

            //add spouse's minor children to household
            var spousesMinorChildren = spouse.Children.Where(x => x.Age < 18 & x.IsAlive).ToList();
            if (spousesMinorChildren.Count() > 0)
            {
                spousesMinorChildren.ForEach(x => {
                    marriageHousehold.AddMember(x);
                    //kids house doesn't change
                });
            }
            headOfHousehold.Spouse = spouse;
            spouse.Spouse = headOfHousehold;
            return marriageHousehold;
        }
    }
    public class Bethrothal
    {
        public Person HeadOfHouseholdToBe { get; set; }
        public Person SpouseToBe { get; set; }
        public World world { get; set; }
        public int Year { get; set; }
    }
    public class Person
    {
        private Random _rnd;
        public Person(Random rnd)
        {
            _rnd = rnd;
            Id = Guid.NewGuid();
            Household = new Household();
            BirthPlace = null;
            Sex = (Sex)rnd.Next(0, 2);
            Name = GenerateName(_rnd, Sex);
            Age = 0;
            IsAlive = true;
            Children = new List<Person>();
            Spouse = null;
            if (Age >= 18 && Age < 50)
            {
                Profession = Profession.Peasant;
            }
            else
            {
                Profession = Profession.Dependant;
            }
            Lordships = new List<Lordship>();
            HouseLordships = new List<House>();
            Ancestors = new List<Person>();
        }
        public Guid Id { get; set; }
        public People People { get; set; }
        public World World { get; set; }
        public SocialClass Class { get; set; }
        public List<Person> Ancestors { get; set; }
        public House House { get; set; }
        //public int Year { get; set; }
        public Household Household { get; set; }
        public int BirthYear { get; set; }
        public Lordship BirthPlace { get; set; }
        public string Name { get; set; }
        public string FullNameAndAge
        {
            get
            {
                string fullNameAndAge = "";
                fullNameAndAge += this.Name + " " + House.Name;
                if (this.HouseLordships.Count > 0)
                {
                    if (Sex == Sex.Male)
                    {
                        fullNameAndAge += ", Lord of House " + HouseLordships[0].Name;
                    }
                    else
                    {
                        fullNameAndAge += ", Lady of House " + HouseLordships[0].Name;
                    }
                    if (HouseLordships.Count > 1)
                    {
                        for (int i = 1; i < HouseLordships.Count(); i++)
                        {
                            if (i == HouseLordships.Count - 1)
                            {
                                fullNameAndAge += ", and ";
                            }
                            else
                            {
                                fullNameAndAge += ", ";
                            }
                            fullNameAndAge += HouseLordships[i].Name;
                        }
                    }

                }
                if (this.Lordships.Count > 0)
                {
                    if (Sex == Sex.Male)
                    {
                        fullNameAndAge += ", Lord of " + Lordships[0].Name;
                    }
                    else
                    {
                        fullNameAndAge += ", Lady of " + Lordships[0].Name;
                    }
                    if (Lordships.Count > 1)
                    {
                        for (int i = 1; i < Lordships.Count(); i++)
                        {
                            if (i == Lordships.Count - 1)
                            {
                                fullNameAndAge += ", and ";
                            }
                            else
                            {
                                fullNameAndAge += ", ";
                            }
                            fullNameAndAge += Lordships[i].Name;
                        }
                    }
                }
                if (World != null)
                {
                    foreach (var house in World.NobleHouses)
                    {
                        var houseHeirs = house.Lords.Last().GetCurrentHeirs();
                        if (houseHeirs.Contains(this))
                        {
                            fullNameAndAge += string.Format(", heir of House {1}", houseHeirs.IndexOf(this) + 1, house.Name);
                        }
                    }
                    foreach (var lordship in World.Lordships)
                    {
                        if (!lordship.Vacant)
                        {
                            var lordshipHeirs = lordship.GetOrderOfSuccession(1);
                            if (lordshipHeirs.Contains(this))
                            {
                                fullNameAndAge += string.Format(", heir of {1}", lordshipHeirs.IndexOf(this) + 1, lordship.Name);
                            }
                        }
                    }
                }
                if (this.Father != null && this.Mother != null)
                {
                    if (this.Sex == Sex.Male)
                    {
                        fullNameAndAge += ", son of ";
                    }
                    else
                    {
                        fullNameAndAge += ", daughter of ";
                    }
                    fullNameAndAge += this.Father.Name + " " + Father.House.Name + " and " + this.Mother.Name + " " + Mother.House.Name;
                }
                if (Household != null && Household.Lordship != null)
                {
                    fullNameAndAge += ", residing in " + Household.Lordship.Name;
                }
                fullNameAndAge += ", age " + this.Age;
                return fullNameAndAge;
            }
        }
        //public Person HouseFounder { get; set; }
        public Profession Profession { get; set; }
        public List<Person> Children { get; set; }
        //public Person Newborn { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }
        public Person Spouse { get; set; }
        public int Age { get; set; }
        public bool IsAlive { get; set; }
        public Sex Sex { get; set; }
        public double Income
        {
            get
            {
                double income = 0;
                switch (Profession)
                {
                    case Profession.Dependant:
                        income = Constants.DEPENDENT_INCOME;
                        break;
                    case Profession.Peasant:
                        income = Constants.PEASANT_INCOME;
                        break;
                    case Profession.Noble:
                        income = Constants.NOBLE_INCOME;
                        break;
                    //case Profession.Soldier:
                    //    income = Constants.SOLDIER_INCOME;
                    //    break;
                }
                // +/- 50%
                return Math.Round(income + (income * (_rnd.NextDouble() * 0.5) * _rnd.Next(-1, 2)), 2);
            }
        }
        public double Cost
        {
            get
            {
                double cost = 0;
                switch (Profession)
                {
                    case Profession.Dependant:
                        cost = Constants.DEPENDENT_COST;
                        break;
                    case Profession.Peasant:
                        cost = Constants.PEASANT_COST;
                        break;
                    case Profession.Noble:
                        cost = Constants.NOBLE_COST;
                        break;
                    case Profession.Soldier:
                        cost = Constants.SOLDIER_TOWN_COST;
                        break;
                }
                return cost;
            }
        }
        public List<Lordship> Lordships { get; set; }
        public List<House> HouseLordships { get; set; }
        public void IncrementYear()
        {
            if (IsAlive)
            {
                //Death Check
                if (_rnd.Next(1, 100) < Age && _rnd.Next(1, 100) < Age && _rnd.Next(1, 100) < Age && _rnd.Next(1, 100) < Age)
                {
                    if (World.Player!=null && World.Player.House!=null && House == World.Player.House && World.Player.House.Lords.Count() > 0 && World.Player.House.Lords.Last().GetCurrentHeirs().Contains(this))
                    {
                        Console.WriteLine("DEATH OF HEIR: " + FullNameAndAge + " DIED in " + World.Year);
                    }
                    IsAlive = false;
                    Household.RemoveMember(this);
                    World.RemovePerson(this);
                }
                else
                {
                    Age++;
                    //Childbirth Check
                    //Must be female
                    //Can only happen between 18 and 50
                    //every year between 18 and 50 they have a percentage change of a childbirth check
                    //and then they roll a die between 18 and 51 and must roll larger than their age
                    if (
                        Sex == Sex.Female
                        && Age >= 18
                        && Spouse != null
                        && Spouse.IsAlive
                        && _rnd.NextDouble() <= Constants.CHILDBEARING_CHANCE_IN_PRIME
                        && _rnd.Next(18, 51) > Age
                        )
                    {
                        var childsMother = this;
                        var childsFather = Spouse;
                        var newborn = new Person(_rnd)
                        {
                            Household = childsMother.Household,
                            BirthYear = World.Year,
                            BirthPlace = childsMother.Household.Lordship,
                            Father = childsFather,
                            Mother = childsMother,
                            Profession = Profession.Dependant,
                            Class = childsMother.Class,
                            People = childsMother.People
                        };
                        if (childsMother.Profession == Profession.Noble)
                        {
                            newborn.Profession = Profession.Noble;
                        }
                        newborn.Ancestors.Add(childsFather);
                        newborn.Ancestors.Add(childsMother);
                        newborn.Ancestors.AddRange(childsFather.Ancestors);
                        newborn.Ancestors.AddRange(childsMother.Ancestors);
                        Children.Add(newborn);
                        Spouse.Children.Add(newborn);
                        Household.AddMember(newborn);
                        House.AddMember(newborn);
                        World.AddPerson(newborn);
                        if (World.Player!=null && World.Player.House != null && newborn.House == World.Player.House && World.Player.House.Lords.Count() > 0 && World.Player.House.Lords.Last().GetCurrentHeirs().Contains(newborn))
                        {
                            Console.WriteLine(String.Format("REJOICE! A new heir, a {0}, was born to {1} and {2}.\n What name do you give {3}?"
                                , newborn.Sex == Sex.Male ? "son" : "daughter",
                                Household.HeadofHousehold.FullNameAndAge,
                                Household.HeadofHousehold.Spouse.FullNameAndAge, newborn.Sex == Sex.Male ? "him" : "her"));
                            newborn.Name = Console.ReadLine();
                            Console.WriteLine("The kingdom rejoices at the news of the new heir, " + newborn.FullNameAndAge);
                            Console.WriteLine("Enter to continue...");
                            Console.ReadLine();
                        }
                    }
                }
            }
        }
        public bool IsEligibleForMarriage()
        {
            return (
                IsAlive
                && (Spouse == null || !Spouse.IsAlive)
                && Age >= 18
                && Age < 50
                );
        }
        public bool IsEligableForBetrothal()
        {
            return (
                IsAlive
                && (Bethrothal == null || !Bethrothal.HeadOfHouseholdToBe.IsAlive || !Bethrothal.SpouseToBe.IsAlive)
                && (Spouse == null || !Spouse.IsAlive)
                && Age < 50
                );
        }
        public bool IsCompatible(Person potentialSpouse)
        {
            var me = this;
            //I can't get married if I'm not eligible for marriage
            if (!me.IsEligibleForMarriage() || !potentialSpouse.IsEligibleForMarriage())
            {
                return false;
            }
            //I can't get married if either of us are dead
            if (!me.IsAlive || !potentialSpouse.IsAlive)
            {
                return false;
            }
            //not compatible if differnt peoples
            if (me.People != potentialSpouse.People)
            {
                return false;
            }
            //not compatible if differnt class
            if (me.Class != potentialSpouse.Class)
            {
                return false;
            }
            //must be opposite sex
            if (me.Sex == potentialSpouse.Sex)
            {
                return false;
            }
            //nobles can't share an ancestor

            if (me.Class == SocialClass.Noble && me.Ancestors.Intersect(potentialSpouse.Ancestors).Count() > 0)
            {
                return false;
            }

            //peasants can't share a grandparent
            if (me.Class == SocialClass.Peasant && me.GetAncestors().Intersect(potentialSpouse.GetAncestors(2)).Count() > 0)
            {
                return false;
            }
            //still here?  That means we're compatible!
            return true;
        }
        public bool IsCompatibleForBetrothal(Person potentialSpouse)
        {
            var me = this;
            //I can't get married if I'm not eligible for betrothal
            if (!me.IsEligableForBetrothal() || !potentialSpouse.IsEligableForBetrothal())
            {
                return false;
            }
            //I can't get married if either of us are dead
            if (!me.IsAlive || !potentialSpouse.IsAlive)
            {
                return false;
            }
            //not compatible if differnt peoples
            if (me.People != potentialSpouse.People)
            {
                return false;
            }
            //not compatible if differnt class
            if (me.Household != null && potentialSpouse.Household != null && me.Household.HouseholdClass != potentialSpouse.Household.HouseholdClass)
            {
                return false;
            }
            //not compatible if age difference is more than MAX_BETHROTHAL_AGE_DIFFERENCE
            if (Math.Abs(me.Age - potentialSpouse.Age) > Constants.MAX_BETROTHAL_AGE_DIFFERENCE)
            {
                return false;
            }
            //must be opposite sex
            if (me.Sex == potentialSpouse.Sex)
            {
                return false;
            }
            //nobles can't share an ancestor

            if (me.Class == SocialClass.Noble && me.Ancestors.Intersect(potentialSpouse.Ancestors).Count() > 0)
            {
                return false;
            }

            //peasants can't share a grandparent
            if (me.Class == SocialClass.Peasant && me.GetAncestors().Intersect(potentialSpouse.GetAncestors(2)).Count() > 0)
            {
                return false;
            }
            //still here?  That means we're compatible!
            return true;
        }
        public static string GenerateName(Random rnd, Sex sex)
        {
            string generatedName = "";
            string[] names;
            if (sex == Sex.Male)
            {
                names = Constants.MALE_NAMES.Split(',');
            }
            else
            {
                names = Constants.FEMALE_NAMES.Split(',');
            }
            generatedName = names[rnd.Next(0, names.Count())];
            return generatedName;
        }
        public List<Person> GetAncestors(int maxGenerations = Constants.GENERATIONS_WITHOUT_SHARED_ANCESTOR)
        {
            var ancestors = new List<Person>();
            if (maxGenerations > 0 && Father != null)
            {
                ancestors.Add(Father);
                ancestors.AddRange(Father.GetAncestors(maxGenerations - 1).Where(x => !ancestors.Contains(x)));
            }
            if (maxGenerations > 0 && Mother != null)
            {
                ancestors.Add(Father);
                ancestors.AddRange(Mother.GetAncestors(maxGenerations - 1).Where(x => !ancestors.Contains(x)));
            }
            return ancestors;
        }
        public List<Person> GetHeirs()
        {
            var heirs = new List<Person>();
            var ChildrenOrderedByAge = Children.OrderBy(child => child.BirthYear);
            foreach (var child in ChildrenOrderedByAge)
            {
                if (!heirs.Contains(child)) { heirs.Add(child); }
                heirs.AddRange(child.GetHeirs());
            }
            return heirs;
        }
        public List<Person> GetCurrentHeirs()
        {
            var heirs = new List<Person>();
            var ChildrenOrderedByAge = Children.OrderBy(child => child.BirthYear);
            var heirBranchIdentified = false;
            foreach (var child in ChildrenOrderedByAge)
            {
                if (!heirBranchIdentified)
                {
                    if (child.IsAlive)
                    {
                        heirs.Add(child);
                    }
                    heirs.AddRange(child.GetCurrentHeirs());
                    if (heirs.Count() > 0)
                    {
                        heirBranchIdentified = true;
                    }
                }
            }
            return heirs;
        }
        public static void CreateMarriages(List<Person> unmarriedPeople, Random rnd, bool echo = false)
        {
            var unmarriedMenInPrime = unmarriedPeople.Where(x => x.Sex == Sex.Male).OrderBy(x => x.Age).ToList();
            var unmarriedWomenInPrime = unmarriedPeople.Where(x => x.Sex == Sex.Female).OrderBy(x => x.Age).ToList();
            while (unmarriedMenInPrime.Count() > 0 && unmarriedWomenInPrime.Count() > 0)
            {
                var groom = unmarriedMenInPrime[0];
                var bride = unmarriedWomenInPrime.FirstOrDefault(x => x.IsCompatible(groom));
                if (bride != null)
                {
                    groom.Spouse = bride;
                    bride.Spouse = groom;
                    Person headOfHousehold;
                    Person spouse;
                    if (rnd.Next(0, 2) < 1)
                    {
                        headOfHousehold = bride;
                        spouse = groom;
                    }
                    else
                    {
                        headOfHousehold = groom;
                        spouse = bride;
                    }

                    Household.CreateMarriageHousehold(headOfHousehold, spouse);
                }
                unmarriedMenInPrime.Remove(groom);
                unmarriedWomenInPrime.Remove(bride);
            }
        }
        public Bethrothal Bethrothal { get; set; }
        public string GetDetailsAsString()
        {
            string retString = World.GetMapAsString(null, Household.Lordship);

            retString += "Name: " + FullNameAndAge + "\n";
            retString += "People: " + People + "\n";
            retString += "Class: " + Class + "\n";
            retString += "Lordships: ";
            if (Lordships.Count > 0)
            {
                foreach (var lordship in Lordships)
                {
                    retString += lordship.Name;
                    if (lordship != Lordships.Last())
                    {
                        retString += ", ";
                    } else
                    {
                        retString += "\n";
                    }
                }
            }else
            {
                retString += "none\n";
            }
            retString += "Fighters: ";
            var fighterCount = 0;
            if (Lordships.Count > 0)
            {
                foreach (var lordship in Lordships)
                {
                   foreach (var houseHold in lordship.Households)
                    {
                        fighterCount += houseHold.Members.Count(m=>m.IsAlive && m.Age >= Constants.AGE_OF_MAJORITY && m.Age <= Constants.AGE_OF_RETIREMENT);
                    }
                }
            }
            retString += fighterCount + "\n";
            if (Spouse != null && Spouse.IsAlive)
            {
                retString += "Spouse: " + Spouse.FullNameAndAge + "\n";
            }
            if (Bethrothal != null)
            {
                retString += "Betrothal:\n"
                + "\tBetrothal Year:" + Bethrothal.Year + "\n"
                + "\tHead of Household to Be:" + Bethrothal.HeadOfHouseholdToBe.FullNameAndAge + "\n"
                + "\tSpouce to Be: " + Bethrothal.SpouseToBe.FullNameAndAge + "\n";
            }
            if (Children.Count() > 0)
            {
                retString += "Children:\n";
                foreach (var child in Children.OrderByDescending(c => c.Age))
                {
                    retString += "\t" + child.FullNameAndAge + "\n";
                }
            }
            if (Household != null)
            {
                retString += "Head of Household:" + Household.HeadofHousehold.FullNameAndAge + "\n";
            }

            return retString;
        }
    }
    public class Lordship
    {
        private Random _rnd;
        private int _maxYeild;
        public Lordship(Random rnd)
        {
            _rnd = rnd;
            Households = new List<Household>();
            Lords = new List<Person>();
            Wealth = 0;
            Surplus = 0;
            _maxYeild = _rnd.Next(Constants.MAX_YEILD_LOW, Constants.MAX_YEILD_HIGH);
            AssessedIncome = new List<AssessedIncome>();
            Vassles = new List<Lordship>();
            Vacant = true;
            PlayerMoves = new List<Player>();
        }
        public World World { get; set; }
        public List<Lordship> Vassles { get; set; }
        public List<Player> PlayerMoves { get; set; }
        public Lordship Allegience { get; set; }
        public void AddVassle(Lordship vassle)
        {
            if (!Vassles.Contains(vassle))
            {
                if (vassle.Allegience != null)
                {
                    vassle.Allegience.RemoveVassle(vassle);
                }
                Vassles.Add(vassle);
                vassle.Allegience = this;
            }
        }
        public void RemoveVassle(Lordship vassle)
        {
            if (Vassles.Contains(vassle))
            {
                if (vassle.Allegience != null)
                {
                    vassle.Allegience = null;
                }
                Vassles.Remove(vassle);
            }
        }
        public List<Lordship> GetAllSubVassles()
        {
            var subVassles = new List<Lordship>();
            foreach (var vassle in Vassles)
            {
                subVassles.Add(vassle);
                subVassles.AddRange(vassle.GetAllSubVassles());
            }
            return subVassles;
        }
        public List<Household> GetPotentialSettlerLordHouseholds()
        {
            var potentialSettlerLordHouseholds = Households.Where(h =>
            h.HeadofHousehold.IsAlive
            && h.HeadofHousehold.Class==SocialClass.Noble
            && h.HeadofHousehold.Lordships.Count() == 0
            && h.HeadofHousehold.House == Lords.Last().House
            && h.HeadofHousehold.GetHeirs().Count(heir => heir.House != Lords.Last().House) == 0
            ).ToList();
            return potentialSettlerLordHouseholds;
        }
        public List<Person> Fighters {
            get {
                return Households.SelectMany(h => h.Members.Where(
                    m =>
                    m.IsAlive
                    && m.Class == SocialClass.Peasant
                    && m.Age >= Constants.AGE_OF_MAJORITY
                    && m.Age <= Constants.AGE_OF_RETIREMENT
                    )).ToList();
            }
        }
        public bool Vacant { get; set; }
        public int MapX { get; set; }
        public int MapY { get; set; }
        public int FoundingYear { get; set; }
        public String Name { get; set; }
        public List<Household> Households { get; set; }
        public List<AssessedIncome> AssessedIncome { get; set; }
        public double Yeild { get; set; }
        public double Cost { get; set; }
        public double Surplus { get; set; }
        public double Wealth { get; set; }
        public void IncrementYear()
        {
            PlayerMoves.Clear();
            //lets fix this economy!
            //var currentHeirs = 
            if (!Vacant)
            {
                var villagers = new List<Person>();
                Households.ForEach(x => villagers.AddRange(x.Members));

                //4. Marry villagers! 
                var villagersInPrime = villagers.Where(x => x.IsAlive && x.Age >= 18 && x.Age < 50 && x.Household.HouseholdClass == SocialClass.Peasant).ToList();
                Person.CreateMarriages(villagersInPrime, _rnd);
                //5. Check for succession of Lord
                var incumbentLord = Lords.Last();
                if (!incumbentLord.IsAlive && !Vacant)
                {
                    //The lord is Dead!  Long live the lord!

                    Person heir = null;
                    var orderOfSuccession = GetOrderOfSuccession(1);
                    if (orderOfSuccession.Count > 0)
                    {
                        heir = orderOfSuccession[0];
                    }
                    if (heir != null)
                    {
                        AddLord(heir);
                        if (World.Player!=null && World.Player.House!= null && heir.House == World.Player.House && World.Player.House.Lords.Last().GetCurrentHeirs().Contains(heir))
                        {
                            Console.WriteLine("INHERITANCE: " + heir.FullNameAndAge + " INHERITED the Lordship of " + Name + " from " + incumbentLord.FullNameAndAge + " in " + World.Year);
                            if (heir.House != incumbentLord.House)
                            {
                                Console.WriteLine("CHANGE OF HOUSE! " + Name + " passed from House " + incumbentLord.House.Name + " to " + heir.House.Name + " in " + World.Year);
                            }
                        }
                    }
                    else
                    {
                        Vacant = true;
                        if (incumbentLord.House == World.Player.House)
                        {
                            Console.WriteLine("VACANCY: The Lordship of " + Name + " is vacant.");
                        }
                    }
                }
                //6. Give jobs to unemployed villagers in prime
                var unemployedVillagersInPrime = villagersInPrime.Where(x => x.Profession == Profession.Dependant).ToList();
                foreach (var unemployedVillagerInPrime in unemployedVillagersInPrime)
                {
                    unemployedVillagerInPrime.Profession = Profession.Peasant;
                }
                //7. Calculate total cost
                Cost = villagers.Sum(x => x.Cost);
                //8. Calculate total yeild
                Yeild = villagers.Sum(x => x.Income);
                //+/- 20%
                var thisYearsMaxYeild = Math.Round(_maxYeild + (_maxYeild * (_rnd.NextDouble() * 0.2) * _rnd.Next(-1, 2)), 2);
                if (thisYearsMaxYeild < Yeild)
                {
                    Yeild = thisYearsMaxYeild;
                }
                //9. Add tax to income
                var income = Math.Round(Yeild * Constants.MIN_TAX_RATE, 2);
                //10. Calculate surplus/deficit
                Surplus = Yeild - Cost - income;
                //11. Add surplus to income if positive
                if (Surplus > 0) { income += Surplus; }
                //12. Add Income to treasury
                Wealth += income;
                //Add income to assessedIncome (for tax to house)
                AssessedIncome.Add(new AssessedIncome() { Year = World.Year, Income = income });
                //13. If there is a deficit then villagers die :(
                //if (Surplus < 0)
                //{
                //    var deficit = Surplus * -1;
                //    if (Wealth < 0)
                //    {
                //        deficit += Wealth * -1;
                //    }
                //    while (deficit > 0)
                //    {
                //        if (villagers.Count() > 0)
                //        {
                //            //kill a random villager
                //            var deadOne = villagers[_rnd.Next(0, villagers.Count())];

                //            deadOne.IsAlive = false;
                //            if (deadOne.Household != null)
                //            {
                //                deadOne.Household.RemoveMember(deadOne);
                //            }
                //            deficit -=
                //                deadOne.Cost;
                //        }
                //    }
                //}
                //Clear out any empty households
                Households.RemoveAll(x => x.Members.Count() == 0);
            }
        }
        public void AddHousehold(Household newHousehold)
        {
            if (!Households.Contains(newHousehold))
            {
                if (newHousehold.Lordship != null)
                {
                    newHousehold.Lordship.Households.Remove(newHousehold);
                    newHousehold.Lordship = null;
                }
                Households.Add(newHousehold);
                newHousehold.Lordship = this;
            }
        }
        public void Removehousehold(Household oldHousehold)
        {
            if (Households.Contains(oldHousehold))
            {
                oldHousehold.Lordship = null;
                Households.Remove(oldHousehold);
            }
        }
        public void AddLord(Person newLord)
        {
            if (!newLord.Lordships.Contains(this))
            {
                newLord.Lordships.Add(this);
            }
            Lords.Add(newLord);
        }
        public List<Lordship> GetAdjacentLordships()
        {
            return World.Lordships.Where(v => v != this && (Math.Abs(v.MapX - MapX) == 1 || v.MapX == MapX) && (Math.Abs(v.MapY - MapY) == 1 || v.MapY == MapY)).ToList();
        }
        public List<Person> Lords { get; set; }
        public List<Person> GetOrderOfSuccession(int depth)
        {
            var successionList = new List<Person>();
            var lordIndex = Lords.Count - 1;
            while (successionList.Count() < depth && lordIndex >= 0)
            {
                var lordsHeirs = Lords[lordIndex].GetHeirs();
                foreach (var heir in lordsHeirs)
                {
                    if (!successionList.Contains(heir) && !Lords.Contains(heir))
                    {
                        successionList.Add(heir);
                    }
                }
                lordIndex--;
            }
            return successionList.Where(x => x.IsAlive).Take(depth).ToList();
        }
        public string GetDetailsAsString()
        {
            var retString = ""; 
            if (!Vacant)
            {
                retString += World.GetMapAsString(null, this);
                retString += ("Lordship: " + Name + '\n');
                retString += ("Founding Year: " + FoundingYear + '\n');
                var incumentlord = Lords.Last();
                retString += ("Lord: " + incumentlord.FullNameAndAge + '\n');
                retString += ("Order of Succession:" + '\n');
                var orderOfSuccession = GetOrderOfSuccession(10);
                for (int i = 0; i < orderOfSuccession.Count(); i++)
                {
                    retString += ((i + 1) + ": " + orderOfSuccession[i].FullNameAndAge + '\n');
                }
                var villagers = Households.SelectMany(h => h.Members);
                retString += ("Noble Households:" + Households.Count(v => v.HouseholdClass == SocialClass.Noble) + '\n');
                retString += ("Peasant Households:" + Households.Count(v => v.HouseholdClass == SocialClass.Peasant) + '\n');
                retString += ("Population:" + villagers.Count() + '\n');
                retString += ("Defenders:" + villagers.Count(m => m.IsAlive
                        && m.Age >= Constants.AGE_OF_MAJORITY
                        && m.Age <= Constants.AGE_OF_RETIREMENT
                        && m.Class == SocialClass.Peasant) + '\n');
                retString += ("Seniors >= 50:" + villagers.Count(v => v.IsAlive && v.Age > 50) + '\n');
                retString += ("Children < 18: " + villagers.Count(v => v.IsAlive && v.Age < 18) + '\n');
                retString += ("Nobles: " + villagers.Count(v => v.Household.HouseholdClass == SocialClass.Noble && v.IsAlive) + '\n');
                retString += ("Peasants: " + villagers.Count(v => v.Household.HouseholdClass == SocialClass.Peasant && v.IsAlive) + '\n');
                retString += ("Yeild: " + Yeild + '\n');
                retString += ("Cost: " + Cost + '\n');
                retString += ("Surplus: " + Surplus + '\n');
                if (AssessedIncome.Count > 0) { 
                retString += ("Income: " + AssessedIncome.Last().Income.ToString("0.00") + '\n');
                }
                retString += ("Wealth: " + Wealth + '\n');
                retString += ("------------------------" + '\n');
            }
            return retString;
        }
        public static void PopulateLordship(Lordship newVillage, Household lordsHouseHold, List<Household> peasantHouseholds)
        {
            //add lord
            var newLord = lordsHouseHold.HeadofHousehold;
            newVillage.AddLord(newLord);
            var settlerHouseholds = new List<Household>();
            settlerHouseholds.Add(lordsHouseHold);
            settlerHouseholds.AddRange(peasantHouseholds);
            foreach (var settlerHousehold in settlerHouseholds)
            {
                newVillage.AddHousehold(settlerHousehold);
            }
            settlerHouseholds.ForEach(household => household.Members.ForEach(member => newVillage.World.AddPerson(member)));
            //var playerLords = newVillage.World.Player.House.Lords;

            if (newLord.World!= null && newLord.World.Player != null && newLord.House == newLord.World.Player.House) //&& playerLords.Count > 0 && playerLords.Last().GetCurrentHeirs().Contains(newLord))
            {
                Console.WriteLine("EXPANSION: " + newLord.FullNameAndAge + " FOUNDED " + newVillage.Name + " in " + newVillage.World.Year);
            }
            newVillage.Vacant = false;
        }
    }
    public class Program
    {
        public static void IncrementYear(World world, Random rnd)
        {
            //1. Houses make moves
            var housesToMakeMoves = new List<House>();
            housesToMakeMoves.AddRange(world.NobleHouses);
            while (housesToMakeMoves.Count() > 0)
            {
                var nextIndex = rnd.Next(0, housesToMakeMoves.Count());
                var houseToMakeMoves = housesToMakeMoves[nextIndex];
                HouseMoves(houseToMakeMoves, rnd);
                housesToMakeMoves.Remove(houseToMakeMoves);
            }
            PerformNobleMarriages(world);
            //2. Increment Word Year
            world.IncrementYear();
        }
        public static List<Household> GetRandomSettlerHouseholds(House house, Random rnd, int numberOfHouseHolds = Constants.MINIMUM_VILLAGE_SIZE)
        {
            var housesLordships = house.GetLordships();
            var potentialSettlerPeasantHouseholds = new List<Household>();
            var settlerHouseholds = new List<Household>();
            foreach (var housesLordship in housesLordships)
            {
                var peasantHouseholds = housesLordship.Households.Where(x => x.HeadofHousehold.Class == SocialClass.Peasant).ToList();
                while (peasantHouseholds.Count() > Constants.MINIMUM_VILLAGE_SIZE)
                {
                    var potentialSettlerPeasantHousehold = peasantHouseholds[rnd.Next(0, peasantHouseholds.Count())];
                    potentialSettlerPeasantHouseholds.Add(potentialSettlerPeasantHousehold);
                    peasantHouseholds.Remove(potentialSettlerPeasantHousehold);
                }
            }
            while (potentialSettlerPeasantHouseholds.Count() > 0 && settlerHouseholds.Count() < numberOfHouseHolds)
            {
                var settlerHousehold = potentialSettlerPeasantHouseholds[rnd.Next(0, potentialSettlerPeasantHouseholds.Count())];
                settlerHouseholds.Add(settlerHousehold);
                potentialSettlerPeasantHouseholds.Remove(settlerHousehold);
            }
            return settlerHouseholds;
        }
        public static List<Person> RaiseARandomArmy(House house, Random rnd, int armySize = 100)
        {
            var housesLordships = house.GetLordships();
            var potentialRecruits = new List<Person>();
            var army = new List<Person>();
            foreach (var housesLordship in housesLordships)
            {
                var peasantHouseholds = housesLordship.Households.Where(x => x.HeadofHousehold.Class == SocialClass.Peasant).ToList();
                foreach(var peasantHousehold in peasantHouseholds)
                {
                    potentialRecruits.AddRange(peasantHousehold.Members.Where(m => 
                    m.IsAlive
                    &&m.Age>=Constants.AGE_OF_MAJORITY
                    &&m.Age<=Constants.AGE_OF_RETIREMENT
                    ));
                }
            }
            while(potentialRecruits.Count() > 0 && army.Count() <= armySize)
            {
                var recruit = potentialRecruits[rnd.Next(0, potentialRecruits.Count())];
                army.Add(recruit);
                potentialRecruits.Remove(recruit);
            }
            return army;
        }
        public static void HouseMoves(House house, Random rnd)
        {

            //colonize
            if (house != house.World.Player.House)
            {
                var housesLordships = house.GetLordships();
                foreach (var lordship in housesLordships)
                {
                    var adjacentUnclaimedLands = GetAdjacentUnclaimedLands(lordship);
                    var peasantHouseholds = lordship.Households.Where(h => h.HeadofHousehold.Class == SocialClass.Peasant).ToList();
                    var potentialSettlerLordHouseholds = lordship.Lords.Last().House.GetPotentialSettlerLords().Select(p => p.Household).ToList();//lordship.GetPotentialSettlerLordHouseholds().ToList();
                    while (potentialSettlerLordHouseholds.Count() > 0 && peasantHouseholds.Count() >= Constants.MINIMUM_VILLAGE_SIZE * 2 && adjacentUnclaimedLands.Count() > 0)
                    {
                        var settlerLordship = adjacentUnclaimedLands[rnd.Next(0, adjacentUnclaimedLands.Count())];
                        var settlerPeasantHouseholds = peasantHouseholds.Take(peasantHouseholds.Count()/2).ToList();
                        //settlerLordship.FoundingYear = house.World.Year;
                        adjacentUnclaimedLands.Remove(settlerLordship);
                        var settlerLordHousehold = potentialSettlerLordHouseholds[rnd.Next(0, potentialSettlerLordHouseholds.Count())];
                        potentialSettlerLordHouseholds.Remove(settlerLordHousehold);
                        house.Player.SettleNewLordship(lordship, settlerLordship, settlerLordHousehold, settlerPeasantHouseholds);
                    }
                }
            }

            //Matchmaker
            var potentialHeads = house.GetIndespensibleMembers().Where(x => x.IsEligableForBetrothal()).ToList();

            var potentialSpouses= new List<Person>();
            foreach (var otherHouse in house.World.NobleHouses)
            {
                potentialSpouses.AddRange(otherHouse.GetDispensibleMembers().Where(x => x.IsEligableForBetrothal()));
            }
            MatchBetrothals(potentialHeads, potentialSpouses);
        
            if (potentialHeads.Count(x => x.Age > 5 && x.Age < 25 && x.IsEligableForBetrothal() && x.GetHeirs().Count == 0) > 0)
            {
                //no heirs!  Try to invite a new house from the homeland!
                if (rnd.NextDouble() <= Constants.CHANCE_OF_RECRUITING_FOREIGN_HOUSE && house.Recruitments < Constants.MAX_RECRUITMENTS)
                {
                    var maxX = Constants.MAP_WIDTH;
                    var minX = 1;
                    if(house.Lords.Last().People == People.Dane)
                    {
                        minX = Constants.MAP_WIDTH / 2;
                    } else
                    {
                        maxX = Constants.MAP_WIDTH / 2;
                    }

                    var unclaimedLands = house.World.Lordships.Where(t => t.Vacant && t.MapX >= minX && t.MapX <= maxX).ToList();//GetUnclaimedLands(house);
                    if (unclaimedLands.Count() > 0)
                    {
                        //var eldest = unmatchedLordsAndHeirs.Max(h => h.Age) + 5;
                        var newLand = unclaimedLands[rnd.Next(0, unclaimedLands.Count())];
                        var surnames = Constants.SURNAMES.Split(',');
                        var newHouseName = "";
                        while (newHouseName == "" || house.World.NobleHouses.Any(h => h.Name == newHouseName)){
                            newHouseName = surnames[rnd.Next(0, surnames.Count())];
                        }

                        var newHouse = CreateNewHouse(newHouseName, (char)rnd.Next(33, 126), house.Lords.Last().People, newLand, rnd,null);
                        var recruitingLord = house.Lords.Last();
                        var recruitedLord = newHouse.Lords.Last();
                        if (recruitingLord.House == house.World.Player.House)
                        {
                            Console.WriteLine("RECRUITMENT: " + recruitingLord.FullNameAndAge + " RECRUITED " + recruitedLord.FullNameAndAge + " from the " + recruitingLord.People + " homeland.");
                        }
                        house.Recruitments++;
                        MatchBetrothals(potentialHeads, newHouse.GetDispensibleMembers());
                    }
                }
            }

        }
        public static void MatchBetrothals(List<Person> potentialHeads, List<Person> potentialSpouses)
        {
            var headsLeftToMatch = new List<Person>();
            var spousesLeftToMatch = new List<Person>();
            headsLeftToMatch.AddRange(potentialHeads);
            spousesLeftToMatch.AddRange(potentialSpouses);

            while (headsLeftToMatch.Count() > 0 && spousesLeftToMatch.Count() > 0)
            {
                var eligableLordOrHeir = headsLeftToMatch.First();
                var matches = spousesLeftToMatch.Where(x => x.IsCompatibleForBetrothal(eligableLordOrHeir)).ToList();

                if (matches.Count() > 0)
                {
                    //find match closest in age
                    matches = matches.OrderBy(m => Math.Abs(m.Age - eligableLordOrHeir.Age)).ToList();
                    var match = matches.First();
                    eligableLordOrHeir.World.CreateBethrothal(eligableLordOrHeir, match, eligableLordOrHeir.World.Year, true);
                    spousesLeftToMatch.Remove(match);
                }
                headsLeftToMatch.Remove(eligableLordOrHeir);
            }
        }
        public static List<Lordship> GetAdjacentUnclaimedLands(Lordship lordship)
        {
            var unclaimedLands = new List<Lordship>();
            var lordshipAndSubVassles = new List<Lordship>();
            lordshipAndSubVassles.Add(lordship);
            lordshipAndSubVassles.AddRange(lordship.GetAllSubVassles());
            //houseAndSubVassles.AddRange(house.GetAllSubVassles());
            //var houseLordships = house.World.Lordships.Where(lordship => !lordship.Vacant && lordship.Lords.Last().House == house).ToList();
            foreach (var controlledLordship in lordshipAndSubVassles)
            {
                unclaimedLands.AddRange(controlledLordship.GetAdjacentLordships().Where(x => x.Vacant && !unclaimedLands.Contains(x)));
            }
            return unclaimedLands;
        }
        public static House CreateNewHouse(string name, char symbol, People people, Lordship lordship, Random rnd, Lordship allegience = null, int yearsToIterate = Constants.YEARS_TO_ITERATE_NEW_HOUSES)
        {
            Person newLord = null;
            World oldWorld = null;
            World newWorld = null;
            Lordship oldLordship = null;
            Person lord = null;
            while (newLord == null || !newLord.IsAlive) { 
            oldWorld = new World(rnd) { Year = lordship.World.Year - Constants.YEARS_TO_ITERATE_NEW_HOUSES };//lordship.World;
            newWorld = lordship.World;
            oldLordship = new Lordship(rnd) { Name = "OldLordship" };
            oldWorld.AddLordship(oldLordship);
            //create settlers
            var firstSettlers = new List<Household>();
            for (int i = 0; i < 100; i++)
            {
                var husband = new Person(rnd)
                {
                    Age = rnd.Next(18, 36),
                    Sex = Sex.Male,
                    Profession = Profession.Peasant,
                    Class = SocialClass.Peasant,
                    People = people
                };
                husband.House = new House() { Name = husband.Name };
                oldWorld.AddPerson(husband);
                var wife = new Person(rnd)
                {
                    Age = husband.Age,
                    Sex = Sex.Female,
                    Profession = Profession.Peasant,
                    Class = SocialClass.Peasant,
                    People = people
                };
                oldWorld.AddPerson(wife);
                var settlerHousehold = Household.CreateMarriageHousehold(husband, wife);
                settlerHousehold.HouseholdClass = SocialClass.Peasant;
                firstSettlers.Add(settlerHousehold);
            }

            lord = new Person(rnd)
            {
                Age = 18,
                Sex = Sex.Male,
                Profession = Profession.Noble,
                Class = SocialClass.Noble,
                People = people,
                BirthYear = oldWorld.Year - 18
            };
            oldWorld.AddPerson(lord);
            var lady = new Person(rnd)
            {
                Age = 18,
                Sex = Sex.Female,
                Profession = Profession.Noble,
                Class = SocialClass.Noble,
                People = people,
                BirthYear = oldWorld.Year - 18
            };
            oldWorld.AddPerson(lady);
            lord.House = new House() { Name = name, Symbol = symbol };
            lord.House.AddLord(lord);
                lord.House.AddPlayer(new Player());
            oldWorld.AddHouse(lord.House);
            var lordsHousehold = Household.CreateMarriageHousehold(lord, lady);
            lordsHousehold.HouseholdClass = SocialClass.Noble;
            Lordship.PopulateLordship(oldLordship, lordsHousehold, firstSettlers);
            for (var i = 0; i < yearsToIterate; i++)
            {
                oldWorld.IncrementYear();
                var eligibleNobles = oldWorld.Population.Where(x => x.Class == SocialClass.Noble && x.IsEligibleForMarriage());
                while (eligibleNobles.Count() > 0)
                {
                    //create a spouse for each
                    var eligibleNoble = eligibleNobles.First();
                    var spouse = new Person(rnd) { Age = eligibleNoble.Age, Class = SocialClass.Noble, BirthYear = eligibleNoble.BirthYear, People = people };
                    if (eligibleNoble.Sex == Sex.Male)
                    {
                        spouse.Sex = Sex.Female;
                    }
                    else
                    {
                        spouse.Sex = Sex.Male;
                    }
                    oldWorld.AddPerson(spouse);
                    var marriageHousehold = Household.CreateMarriageHousehold(eligibleNoble, spouse);
                    if (!firstSettlers.Contains(marriageHousehold))
                    {
                        firstSettlers.Add(marriageHousehold);
                    }
                }
            }
            //old world is iterated now prepare for the new world
            //1. get the lord's household
            newLord = oldLordship.Lords.Last();
        }
            var newLordsHouseHold = oldLordship.Lords.Last().Household;
            //2. get the households with all of the lords decendents
            var newLordsDescendents = newLord.GetHeirs();
            var nobleHouseholds = oldLordship.Households.ToList(); //.Where(h => h.Members.Intersect(newLordsDescendents).Count() > 0).ToList();
            //3. get commoners
            var peasantHouseholds = oldLordship.Households.ToList(); //.Where(h => h.HeadofHousehold.Class == SocialClass.Peasant).Take(Constants.MINIMUM_VILLAGE_SIZE).ToList();
            if (allegience != null)
            {
                allegience.AddVassle(lordship);
            }
            newWorld.AddHouse(lord.House);
            lord.House.Seat = lordship;
            var settlerHouseholds = new List<Household>();
            settlerHouseholds.AddRange(nobleHouseholds);
            settlerHouseholds.AddRange(peasantHouseholds);
            //everyone else from the old world dies.  It's rough out there.
            oldWorld.Population.Where(p => !newLordsHouseHold.Members.Contains(p) && settlerHouseholds.Count(sh => sh.Members.Contains(p)) == 0).ToList().ForEach(p => p.IsAlive = false);
            Lordship.PopulateLordship(lordship, newLordsHouseHold, settlerHouseholds);
            return lord.House;
        }
        public static void PerformNobleMarriages(World world)
        {
            var bethrothalsToCheck = new List<Bethrothal>();
            bethrothalsToCheck.AddRange(world.Bethrothals);
            while (bethrothalsToCheck.Count() > 0)
            {
                var betrothalToCheck = bethrothalsToCheck[0];
                if (!betrothalToCheck.HeadOfHouseholdToBe.IsAlive || !betrothalToCheck.SpouseToBe.IsAlive)
                {
                    //cancel betrothal is someone dies!
                    world.CancelBetrothal(betrothalToCheck);
                }
                else if (betrothalToCheck.HeadOfHouseholdToBe.Age >= Constants.AGE_OF_MAJORITY && betrothalToCheck.SpouseToBe.Age >= Constants.AGE_OF_MAJORITY)
                {
                    Household.CreateMarriageHousehold(betrothalToCheck.HeadOfHouseholdToBe, betrothalToCheck.SpouseToBe, true);
                    world.CancelBetrothal(betrothalToCheck);
                }
                bethrothalsToCheck.Remove(betrothalToCheck);
            }
        }
        public static void InitializeWorld(World world, Random rnd, Player player, string playerName = "Eddard", string playerHouse = "Stark", Sex playerSex = Sex.Male)
        {
            var lordshipNames = Constants.TOWN_NAMES.Split(',').ToList();
            for (var y = 1; y <= Constants.MAP_HEIGHT; y++)
            {
                for (var x = 1; x <= Constants.MAP_WIDTH; x++)
                {
                    var villageName = lordshipNames[0];
                    world.AddLordship(new Lordship(rnd) { Name = villageName, MapX = x, MapY = y });
                    lordshipNames.Remove(villageName);
                }
            }
            var houseNames = new List<string>()
            {
                "Stark",
                "Tully",
                "Arryn",
                "Lannister",
                "Baratheon",
                "Tyrell",
                "Martell",
                "Greyjoy",
                "Targaryen"
            };
            var houseSeats = new List<string>()
            {
                "Winterfell",
                "Riverrun",
                "The Eyrie",
                "Casterly Rock",
                "Storm's End",
                "High Garden",
                "Dorne",
                "Pyke",
                "Dragonstone"
            };
            var houseSymbols = new List<Char>()
            {
                '!',
                '@',
                '#',
                '$',
                '%',
                '^',
                '&',
                '*',
                '+'
            };
            //}
            var easternLordships = world.Lordships.Where(x => x.Vacant && x.MapX == 1).ToList();
            var westernLordships = world.Lordships.Where(x => x.Vacant && x.MapX == Constants.MAP_WIDTH).ToList();

            //create first dane house
            var daneLordship = westernLordships[rnd.Next(0, westernLordships.Count())];
            daneLordship.Name = "Winterfell";
            var firstHouse = CreateNewHouse("Firstmen", '@', People.Dane, daneLordship, rnd, null, Constants.YEARS_TO_ITERATE_PLAYER_HOUSES);
            /*
            while (firstHouse.Vassles.Count() == 0)
            {
                IncrementYear(world,rnd);
            }*/
            firstHouse.AddPlayer(player);
            player.House.Symbol = '*';
            var playerLord = player.House.Lords.Last();
            player.House.Name = playerHouse;
            playerLord.Name = playerName;
            playerLord.Sex = playerSex;
            if (playerLord.Spouse != null)
            {
                if (playerLord.Sex == Sex.Male)
                {
                    playerLord.Spouse.Sex = Sex.Female;
                    playerLord.Spouse.Name = Utility.GetName(Sex.Female, rnd);
                }
                else
                {
                    playerLord.Spouse.Sex = Sex.Male;
                    playerLord.Spouse.Name = Utility.GetName(Sex.Male, rnd);
                }
            }

            //create first saxon house
            var saxonLordship = easternLordships[rnd.Next(0, easternLordships.Count())];
            saxonLordship.Name = "Casterly Rock";
            CreateNewHouse("Lannister", '$', People.Saxon, saxonLordship, rnd);
            //for (int k = 0; k < houseNames.Count(); k++)
            //{
            //    var vacantVillages = world.Lordships.Where(x => x.Vacant && (x.MapY == 1 || x.MapY == Constants.MAP_HEIGHT)).ToList();
            //    var firstVillage = vacantVillages[rnd.Next(0, vacantVillages.Count)];
            //    firstVillage.Name = houseSeats[k];
            //    CreateNewHouse(houseNames[k], houseSymbols[k], People.Saxon, firstVillage, rnd);
            //}
        }
        public static void InitializeWorldWithIntro(World world, Random rnd, Player player, string playerName = "Eddard", string playerHouse = "Stark", Sex playerSex = Sex.Male)
        {
            Console.WriteLine("What is your name?");
            playerName = Console.ReadLine();
            playerSex = Sex.Male;
            var sexResponse = "";
            while (sexResponse == "")
            {
                Console.WriteLine(string.Format("\nHello {0}!\n\nAre you a man or a woman?", playerName));
                sexResponse = Console.ReadLine();
                switch (sexResponse.ToLower())
                {
                    case "man":
                        playerSex = Sex.Male;
                        break;
                    case "woman":
                        playerSex = Sex.Female;
                        break;
                    default:
                        sexResponse = "";
                        break;
                }
            }
            Console.WriteLine(string.Format(
                "\n"
                + "{0}, you are the {1} of an ancient storied noble house.  The blood of kings and queens -- and according to legend, the gods themselves -- runs in your veins.\n"
                + "Your noble line runs unbroken to the first of men and is filled with Lords and Ladies both great and terrible.\n"
                + "\n"
                + "What is the name of your house?",
                playerName,
                playerSex == Sex.Male ? "Lord and Patriarch" : "Lady and Matriarch"
            ));
            playerHouse = Console.ReadLine();

            InitializeWorld(world, rnd, player, playerName, playerHouse, playerSex);

            var playerLord = player.House.Lords.Last();
            if (playerLord.Father == null)
            {
                playerLord.Father = new Person(rnd);
            }

            Console.Write(
                "\nYou are " + playerLord.FullNameAndAge + "\n\n"
                );
            var playerHeirs = playerLord.GetCurrentHeirs();
            if (playerHeirs.Count() > 0)
            {
                var output = String.Format("You have {0} living heir{1}: ", playerHeirs.Count(), playerHeirs.Count > 1 ? "s" : "");
                foreach (var heir in playerHeirs)
                {
                    if (heir == playerHeirs.First())
                    {
                        output += "a ";
                    }
                    else if (heir == playerHeirs.Last())
                    {
                        output += ", and a ";
                    }
                    else
                    {
                        output += ", a ";
                    }
                    if (heir.Ancestors.IndexOf(playerLord) + 1 > 4)
                    {
                        output += "great ";
                    }
                    if (heir.Ancestors.IndexOf(playerLord) + 1 > 2)
                    {
                        output += "gand";
                    }
                    if (heir.Sex == Sex.Male)
                    {
                        output += "son";
                    }
                    else
                    {
                        output += "daughter";
                    }
                }
                output += string.Format(".\nBy tradition, you as {0} of the house, name your heirs.\n", playerLord.Sex == Sex.Male ? "Lord and Patriarch" : "Lady and Matriarch");
                Console.WriteLine(output);
                foreach (var heir in playerHeirs)
                {
                    var relation = "";
                    if (heir.Ancestors.IndexOf(playerLord) + 1 > 4)
                    {
                        relation += "great ";
                    }
                    if (heir.Ancestors.IndexOf(playerLord) + 1 > 2)
                    {
                        relation += "gand";
                    }
                    if (heir.Sex == Sex.Male)
                    {
                        relation += "son";
                    }
                    else
                    {
                        relation += "daughter";
                    }
                    Console.WriteLine(String.Format("What is your {0}'s name?", relation));
                    heir.Name = Console.ReadLine();

                }
                Console.WriteLine("\nYour heirs are:");
                foreach (var heir in playerHeirs)
                {
                    Console.WriteLine(heir.FullNameAndAge);
                }
                Console.WriteLine("Enter to continue..");
                Console.ReadLine();
            }          
            Console.WriteLine(string.Format(
            "\n"
            + "The great house of {0} has fallen on hard times.\n\n"
            + "The rich soil that has provided bounty for uncounted generations of your people has turned rocky and fruitless.\n\n"
            + "The surrounding land is racked with strife, banditry, and civil war. The sway that House {0} once held over lords and kings alike is a distant memory.\n\n"
            + "Nought remains of the once-great wealth of House {0} except for your family and the good men and women in your service -- and your renouned, sturdy long-ships.\n\n"
            + "Days ago, in a feverish state, lying in his death bed, your father, staring wide-eyed, speaking to no-one, had been raving madly for days-on of a land of plenty to the east.\n\n"
            + "As you knelt at the foot of his bed for his final hours, his eyes suddenly grew sharp and fixed on you with steel-blue intensity that instantly\n"
            + "transformed him from this pitiful frail wretch into the powerful man-god whose presence dominated your childhood heart with equal parts awe, love and fear.\n\n"
            + "And, for the last time, {1}, Lord and Patriarch of House {0}, filled the room with that oh-so-familiar baritone of command:\n"
            + "'{2}! GATHER OUR PEOPLE INTO OUR LONGSHIPS AND SAIL EAST TO SALVATION! IF NOT, ALL IS LOST AND HOUSE {3} WILL BE NO MORE!'\n\n"
            + "He then collapsed into a fugue and spoke naught another word."
            , playerLord.House.Name
            , playerLord.Father.Name
            , playerLord.Name.ToUpper()
            , playerLord.House.Name.ToUpper()
            ));
            Console.WriteLine("Enter to continue..");
            Console.ReadLine();
            

        }
        public static void Main(string[] args)
        {
            var rnd = new Random();
            var world = new World(rnd);
            var player = new Player();
            world.Player = player;
            if (Constants.PLAY_INTRO)
            {
                InitializeWorldWithIntro(world, rnd, player);
            } else
            {
                InitializeWorld(world, rnd, player);
            }

            while (world.Year < 500)
            {
                Console.WriteLine("Year: " + world.Year);
                Console.WriteLine(world.GetMapAsString());
                Console.WriteLine("Enter to continue. CTRL-C to quit.");
                var input = "hacky";
                while (input != "")
                {
                    input = Console.ReadLine();
                    var command = input.Split(' ');
                    if (command.Length > 0)
                    {

                        switch (command[0])
                        {
                            case "people":
                                {
                                    var peopleName = command[1];
                                    switch (peopleName.ToLower())
                                    {
                                        case "dane":
                                            Console.WriteLine(world.GetMapAsString(null, null, (int)People.Dane));
                                            break;
                                        case "saxon":
                                            Console.WriteLine(world.GetMapAsString(null, null, (int)People.Saxon));
                                            break;
                                    }
                                }
                                break;
                            case "lordship":
                                {
                                    int x;
                                    int y;
                                    Lordship lordship;
                                    if (command.Count() >= 3 && int.TryParse(command[1], out x) && int.TryParse(command[2], out y))
                                    {
                                        lordship = world.Lordships.FirstOrDefault(t => t.MapX == x && t.MapY == y);
                                    }
                                    else
                                    {
                                        var lordshipName = command[1];
                                        for (int i = 2; i < command.Length; i++)
                                        {
                                            lordshipName += " " + command[i];
                                        }
                                        lordship = world.Lordships.FirstOrDefault(t => t.Name.ToLower() == lordshipName.ToLower());
                                    }
                                    if (lordship != null)
                                    {
                                        Console.WriteLine(lordship.GetDetailsAsString());
                                    }
                                }
                                break;
                            case "households":
                                {
                                    var x = int.Parse(command[1]);
                                    var y = int.Parse(command[2]);
                                    var lordship = world.Lordships.FirstOrDefault(t => t.MapX == x && t.MapY == y);
                                    foreach (var household in lordship.Households)
                                    {
                                        Console.WriteLine(household.GetDetailsAsString());
                                    }
                                }
                                break;
                            case "house":
                                {
                                    var houseName = command[1];
                                    var houses = world.NobleHouses.Where(h => h.Name.ToLower() == houseName.ToLower());
                                    foreach (var house in houses)
                                    {
                                        Console.WriteLine(house.GetDetailsAsString());
                                    }
                                }
                                break;
                            case "world":
                                {
                                    Console.WriteLine(world.GetDetailsAsString());
                                }
                                break;
                            case "person":
                                {
                                    var name = command[1];
                                    var house = command[2];
                                    var people = world.Population.Where(p => p.Name.ToLower() == name.ToLower() && p.House.Name.ToLower() == house.ToLower());
                                    foreach (var person in people)
                                    {
                                        Console.WriteLine(person.GetDetailsAsString());
                                    }
                                }
                                break;
                            case "getHeirs":
                                {
                                    var houseName = command[1];
                                    var houses = world.NobleHouses.Where(h => h.Name.ToLower() == houseName.ToLower());
                                    foreach (var house in houses)
                                    {
                                        Console.WriteLine("Heirs of House " + houseName + ":");
                                        var heirs = house.Lords[0].GetCurrentHeirs();
                                        foreach (var heir in heirs)
                                        {
                                            Console.WriteLine("\t" + heir.FullNameAndAge);
                                        }

                                    }

                                }
                                break;
                            case "landlessNobles":
                                {
                                    var house = player.House;
                                    var landlessNobles = house.Members.Where(
                                        m => m.IsAlive
                                        && m.Household != null
                                        && m.Household.HeadofHousehold == m
                                        && m.Lordships.Count == 0
                                        );
                                    foreach (var noble in landlessNobles)
                                    {
                                        Console.WriteLine(noble.FullNameAndAge);
                                    }
                                }
                                break;
                            case "settle":
                                {
                                    int x;
                                    int y;
                                    Lordship sourceLordship;
                                    Lordship targetLordship;
                                    int numberOfSettlers;
                                    if (command.Count() == 5 && int.TryParse(command[2], out x) && int.TryParse(command[3], out y) && int.TryParse(command[4], out numberOfSettlers))
                                    {
                                        sourceLordship = world.Lordships.FirstOrDefault(l => l.Name.ToLower() == command[1].ToLower());
                                        targetLordship = world.Lordships.FirstOrDefault(t => t.MapX == x && t.MapY == y);
                                        if (sourceLordship!=null && targetLordship != null && targetLordship.Vacant)
                                        {
                                            var potentialSettlerHouseholds = sourceLordship.Households.Where(h => h.HeadofHousehold.Class == SocialClass.Peasant);
                                            var settlerLordsHousehold = player.House.GetPotentialSettlerLords().Select(h=>h.Household).FirstOrDefault();
                                            if (settlerLordsHousehold != null && numberOfSettlers <= potentialSettlerHouseholds.Count())
                                            {
                                                var settlerPeasantHouseholds = potentialSettlerHouseholds.Take(numberOfSettlers).ToList();
                                                sourceLordship.World.Player.SettleNewLordship(sourceLordship, targetLordship, settlerLordsHousehold, settlerPeasantHouseholds);
                                            }
                                        }
                                    }

                                }
                                break;
                            case "attack":
                                {
                                    //Lordship attackingLordship;
                                    //Lordship targetLordsphip;
                                    if (command.Length == 3)
                                    {
                                        var attackingLordship = world.Lordships.FirstOrDefault(ls => !ls.Vacant && ls.Name.ToLower() == command[1].ToLower());
                                        var targetLordship = world.Lordships.FirstOrDefault(ls => !ls.Vacant && ls.Name.ToLower() == command[2].ToLower());
                                        if (attackingLordship != null && targetLordship!=null && !targetLordship.Vacant)
                                        {
                                            var attackingLord = attackingLordship.Lords.Last();
                                            if (attackingLord != null)
                                            {
                                                var attackingArmy = attackingLordship.Households.SelectMany(h => h.Members.Where(m=>m.IsAlive&&m.Age>=Constants.AGE_OF_MAJORITY&&m.Age<=Constants.AGE_OF_RETIREMENT)).ToList();
                                                player.House.Attack(targetLordship, attackingLord, attackingArmy, rnd);
                                            }
                                        }
                                    }

                                }
                                break;
                        }
                    }
                }
                IncrementYear(world, rnd);
            }
            Console.ReadLine();
        }
    }
}
