using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Models;

namespace GameOfHouses.MechanicsExperiments
{
    public class Constants {
        public const double CHILDBEARING_CHANCE_IN_PRIME = 0.6;
        public const double DEPENDENT_COST = 1;
        public const double DEPENDENT_INCOME = 0;
        public const double PEASANT_COST = 1;
        public const double PEASANT_INCOME = 10;
        public const string MALE_NAMES =
            "Abelar,Addam,Addison,Adrack,Adrian,Aegon,Aegor,Aemon,Aemond,Aenar,Aenys,Aerion,Aeron,Aerys,Aethan,Aethelmure,Aggar,Aladale,Alan,Alaric,Albar,Albett,Alebelly,Alekyne,Alesander,Alesandor,Alester,Alf,Alfred,Alfyn,Alios,Allaquo,Allar,Allard,Alleras,Alliser,Alvyn,Alyn,Alys,Ambrose,Amory,Andahar,Andar,Anders,Andrew,Andrey,Andrik,Andros,Androw,Anguy,Antario,Archibald,Ardrian,Areo,Argilac,Arlan,Armen,Armond,Arneld,Arnell,Arnolf,Aron,Arrec,Arron,Arryk,Arson,Arstan,Arthor,Arthur,Artos,Artys,Arwood,Arys,Aurane,Axell,Ayrmidon,Azor Ahai,Bael,Baelon,Baelor,Balaq,Ballabar,Balman,Balon,Bannen,Baqq,Barre,Barristan,Barth,Bartimos,Bartimus,Bass,Bayard,Bean,Beans,Beck,Bedwyck,Belaquo,Beldecar,Belicho,Belis,Belwas,Ben,Benedar,Benedict,Benerro,Benethon,Benfred,Benfrey,Benjen,Benjicot,Bennarion,Bennet,Beqqo,Beren,Beric,Bernarr,Beron,Bertram,Bhakaz,Bharbo,Big Boil,Bill,Billy,Biter,Black Fist,Blane,Bloodbeard,Bluetooth,Bodger,Bokkoko,Bonifer,Books,Borcas,Boremund,Boros,Borroq,Borros,Bors,Bowen,Bradamar,Brandon,Brendel,Brenett,Briar,Brogg,Bronn,Brus,Brusco,Bryan,Bryce,Bryen,Brynden,Bryndon,Bump,Burton,Butterbumps,Butts,Byam,Byan,Byron,Cadwyl,Cadwyle,Cadwyn,Caggo,Caleotte,Calon,Calor,Camarron,Canty,Carrot,Casper,Caspor,Casso,Cayn,Cedric,Cedrik,Cellador,Cetherys,Chains,Chayle,Chett,Chezdhar,Chiggen,Chiswyck,Clarence,Clarent,Clayton,Clement,Cleon,Cleos,Cletus,Cley,Clifford,Clydas,Cohollo,Colemon,Colen,Colin,Collio,Colloquo,Colmar,Conn,Conwy,Coratt,Corliss,Corlys,Cortnay,Cossomo,Cotter,Courtenay,Craghas,Cragorn,Craster,Crawn,Cregan,Creighton,Cressen,Creylen,Criston,Cromm,Cugen,Cuger,Cutjack,Daario,Dacks,Daegon,Daemon,Daeron,Dafyn,Dagmer,Dagon,Dagos,Dake,Dalbridge,Dale,Dalton,Damion,Damon,Dan,Dannel,Danny,Danos,Danwell,Dareon,Darla,Daryn,Daven,Davos,Del,Delp,Denestan,Dennet,Dennett,Dennis,Denyo,Denys,Denzo,Dermot,Desmond,Devan,Devyn,Deziel,Dick,Dickon,Dirk,Dobber,Dolf,Domeric,Donal,Donel,Doniphos,Donnel,Donnis,Donnor,Dontos,Doran,Dorden,Dormund,Dorren,Doss,Drennan,Drogo,Dryn,Dudley,Dunaver,Duncan,Dunsen,Dunstan,Duram,Duran,Durran,Dykk,Dywen,Earl,Easy,Ebben,Ebrose,Eddard,Edderion,Eddison,Edgerran,Edmund,Edmure,Edmyn,Edric,Edrick,Edwyd,Edwyle,Edwyn,Eggen,Eggon,Egon,Eladon Goldenhair,Elbert,Eldiss,Eldon,Eldred,Ellendor,Ellery,Elmar,Elron,Elwood,Elyas,Elys,Emmett,Emmon,Emmond,Emrick,Endehar,Endrew,Enger,Eon,Erik,Erreck,Erreg,Erren,Errok,Erryk,Ethan,Euron,Eustace,Eyron,Ezzelyno,Faezhar,Farlen,Ferrego,Fingers,Flement,Florian,Fogo,Forley,Fornio,Forrest,Fralegg,Franklyn,Frenken,Frynne,Fulk,Gage,Galbart,Galendro,Galladon,Galyeon,Gared,Garibald,Garigus,Garin,Garlan,Garrett,Garrison,Garse,Garth,Gascoyne,Gavin,Gawen,Gelmar,Gendel,Gendry,Gerald,Gerardys,Geremy,Gergen,Gerion,Germund,Gerold,Gerren,Gerrick,Gerris,Gerrold,Gevin,Ghael,Ghazdor,Gilbert,Gillam,Gilwood,Gladden,Glendon,Goady,Godric,Godry,Godwyn,Goghor,Gorghan,Gormon,Gormond,Gorne,Gorold,Gorys,Gorzhak,Gowen,Gran,Grance,Grazdan,Grazdar,Grazdhan,Grazhar,Greenguts,Gregor,Grenn,Grey Worm,Greydon,Grigg,Grimtongue,Groleo,Grubbs,Grunt,Gueren,Gulian,Guncer,Gunthor,Gurn,Guthor,Guyard,Gwayne,Gylbert,Gyldayn,Gyleno,Gyles,Gylo,Gyloro,Gynir,Haereg,Hagen,Haggo,Haggon,Hake,Hal,Halder,Haldon,Halleck,Hallis,Hallyne,Halmon,Halys,Hamish,Hammer,Harbert,Hareth,Harghaz,Harl,Harlan,Harle,Harlen,Harlon,Harmen,Harmond,Harmund,Harmune,Harrag,Harras,Harren,Harrion,Harrold,Harry,Harsley,Harwin,Harwood,Harwyn,Harys,Hayhead,Hazrak,Heke,Helliweg,Helman,Hendry,Henk,Henly,Herbert,Hero,Heward,Hibald,Hildy,Hilmar,Hizdahr,Hoarfrost,Hobb,Hobber,Hobert,Hod,Hoke,Holger,Hop-Bean,Hop-Robin,Horas,Horonno,Horton,Hosman,Hosteen,Hoster,Hot Pie,Hother,Hotho,Howd,Howland,Hubard,Hugh,Hugo,Hugor,Hullen,Humfrey,Hunnimore,Husband,Hyle,Iggo,Igon,Illifer,Illyrio,Ilyn,Imry,Ironbelly,Ithoke,Izembaro,Jacaerys,Jace,Jacelyn,Jack,Jack-Be-Lucky,Jacks,Jaehaerys,Jafer,Jaggot,Jaime,Jalabhar,Jammos,Janos,Jaqen,Jared,Jaremy,Jarl,Jarman,Jason,Jasper,Jate,Jax,Jeffory,Jeor,Jeren,Jhaqo,Jhogo,Jodge,Joffrey,John,Jojen,Jokin,Jommo,Jommy,Jon,Jonnel,Jonos,Jonothor,Jorah,Joramun,Jorquen,Jory,Joseran,Joseth,Josmyn,Joss,Josua,Joth,Jothos,Jurne,Justin,Jyck,Kaeth,Karl,Karlon,Karyl,Kasporio,Kedge,Kedry,Kegs,Kem,Kemmett,Kenned,Kennet,Kennos,Kerwin,Ketter,Kevan,Khorane,Khrazz,Kirth,Koss,Kraznys,Kromm,Kurleket,Kurz,Kyle,Kyleg,Kym,Laenor,Lambert,Lancel,Lann,Larence,Lark,Larraq,Larys,Laswell,Leathers,Lem,Lenn,Lennocks,Lenwood,Lenyl,Leo,Leobald,Leslyn,Lester,Lew,Lewyn,Lewys,Leyton,Lharys,Lister,Lomas,Lommy,Lomys,Longleaf,Longwater,Loras,Loren,Lorent,Loreth,Lorimas,Lorimer,Lormelle,Lorren,Lothar,Lotho,Lothor,Loyal Spear,Lucamore,Lucan,Lucantine,Lucas,Luceon,Lucerys,Lucias,Lucifer,Lucimore,Lucion,Luco,Lucos,Luke,Lum,Lump,Luthor,Luton,Luwin,Lyle,Lyman,Lymond,Lyn,Lync,Lyonel,Lysono,Mace,Mad Axe,Maegor,Maekar,Maelor,Maelys,Maezon,Mag,Maggo,Mago,Malaquo,Malcolm,Malegorn,Mallador,Malleon,Malliard,Mallor,Malo,Malwyn,Mance,Mandon,Manfred,Manfrey,Manfryd,Manly,Marghaz,Maric,Marillion,Mark,Marlon,Maron,Marq,Marselen,Marston,Martyn,Marwyn,Maslyn,Matarys,Mathis,Mathos,Matt,Matthar,Matthos,Mawney,Maynard,Mazdhan,Mebble,Medger,Medrick,Medwick,Meizo,Mekko,Meldred,Mellos,Melwys,Meribald,Merion,Mern,Mero,Merrel,Merrell,Merrett,Merriman,Merrit,Methyso,Michael,Mikken,Mohor,Mollander,Mollono,Mollos,Monford,Monterys,Moon Boy,Moqorro,Mord,Moredo,Moreo,Morgan,Morgarth,Morghaz,Morgil,Morgo,Moribald,Moro,Moroggo,Morosh,Morrec,Morros,Mors,Morton,Moryn,Mossador,Motho,Mudge,Mullin,Mully,Munciter,Munken,Murch,Murenmure,Murmison,Mushroom,Mycah,Mychel,Myles,Myrio,Myrmello,Nage,Nagga,Naggle,Nail,Narbert,Narbo,Ned,Nestor,Noho,Norbert,Norjen,Normund,Norne,Norren,Notch,Nurse,Nute,Nyessos,Oberyn,Ogo,Ollidor,Ollo,Olymer,Olyvar,Omer,Ondrew,Oppo,Orbelo,Orbert,Ordello,Orell,Orivel,Orland,Ormond,Ormund,Oro,Orson,Orton,Orwyle,Orys,Osbert,Osfryd,Osgood,Osmund,Osmynd,Osney,Osric,Oss,Ossifer,Ossy,Oswell,Oswyn,Othell,Otho,Othor,Otter,Otto,Ottyn,Owen,Oznak,Paezhar,Parmen,Parquello,Patchface,Pate,Patrek,Paul,Paxter,Pearse,Pello,Perestan,Perkin,Perros,Perwyn,Peter,Petyr,Philip,Plummer,Podrick,Pollitor,Pono,Porther,Portifer,Poul,Poxy Tym,Praed,Prendahl,Preston,Puckens,Puddingfoot,Pyat,Pycelle,Pyg,Pykewood,Pylos,Pynto,Pypar,Pytho,Qalen,Qarl,Qarlton,Qarro,Qavo,Qhored,Qhorin,Qos,Qotho,Quaro,Quellon,Quence,Quenn,Quent,Quenten,Quentin,Quenton,Quentyn,Quhuru,Quill,Quincy,Quort,Qyburn,Qyle,Racallio,Rafford,Ragnor,Ragwyle,Rakharo,Ralf,Ralph,Ramsay,Randyll,Rast,Rattleshirt,Rawney,Raymar,Raymond,Raymun,Raymund,Raynald,Raynard,Redwyn,Regenard,Renfred,Renly,Rennifer,Rey,Reysen,Reznak,Rhaegar,Rhaegel,Rhodry,Rhogoro,Ricasso,Richard,Rickard,Rickon,Rigney,Robar,Robb,Robert,Robett,Robin,Robyn,Roderick,Rodrik,Rodwell,Roger,Roggo,Roggon,Roland,Rolder,Rolfe,Rollam,Rolland,Rolley,Rolly,Rolph,Rommo,Romny,Ronald,Ronel,Ronnel,Ronnet,Rook,Roone,Roose,Rorge,Roro,Rory,Roryn,Rossart,Royce,Rudge,Rufus,Rugen,Runceford,Runcel,Runciter,Rupert,Rus,Russ,Russell,Rusty,Ryam,Rycherd,Ryger,Ryk,Ryles,Ryman,Rymolf,Rymund,Ryn,Ryon,Saathos,Salladhor,Sallor,Salloreon,Samwell,Sandor,Sargon,Satin,Sawane,Sawwood,Scar,Scarb,Sebastion,Sebaston,Sedgekins,Selmond,Selwyn,Serwyn,Shadd,Shadrich,Shagga,Shagwell,Sharako,Sherrit,Shortear,Sigfry,Sigfryd,Sigorn,Sigrin,Silveraxe,Simon,Skahaz,Skinner,Skittrick,Skyte,Snatch,Softfoot,Soren,Spare Boot,Squint,Stafford,Stalwart,Stannis,Steelskin,Steffar,Steffarion,Steffon,Stevron,Stiv,Stone Thumbs,Stonehand,Stonesnake,Stygg,Styr,Sumner,Sybassion,Sylas,Symeon,Symon,Symond,Syrio,Tagganaro,Tal,Talbert,Tallad,Tanton,Tarber,Tarle,Temmo,Ternesio,Terrance,Terrence,Terro,Thaddeus,The Tickler,Theo,Theobald,Theodan,Theodore,Theomar,Theomore,Theon,Therry,Thomax,Thoren,Thormor,Thoros,Three Toes,Tim,Timeon,Timett,Timon,Timoth,Tion,Titus,Tobbot,Tobho,Todder,Todric,Toefinger,Togg,Tom,Tomard,Tommen,TomToo,Torbert,Toregg,Torghen,Torgon,Torman,Tormo,Tormund,Torrek,Torren,Torrhen,Torwold,Torwynd,Tothmure,Trebor,Tregar,Tremond,Tristan,Tristifer,Tristimun,Triston,Trombo,Trystane,Tuffleberry,Tumberjon,Tumco,Turnip,Turquin,Ty,Tybero,Tybolt,Tycho,Tygett,Tyland,Tyler,Tymor,Tyrek,Tyrion,Tytos,Tywin,Uhlan,Ulf,Uller,Ulmer,Ulwyck,Umar,Umfred,Unwin,Urek,Urho,Urragon,Urras,Urrathon,Urreg,Urrigon,Urron,Urswyck,Urzen,Uthero,Utherydes,Uthor,Utt,Vaellyn,Vaemond,Valarr,Vardis,Vargo,Varly,Varys,Vayon,Vickon,Victarion,Victor,Viserys,Vogarro,Vortimer,Vylarr,Vyman,Walder,Waldon,Walgrave,Wallace,Wallen,Walton,Waltyr,Walys,Warren,Warrick,Wat,Wate,Watkyn,Watt,Watty,Waymar,Wayn,Webber,Weese,Wendamyr,Wendel,Wendello,Werlag,Wex,Whalen,Wick,Wilbert,Will,Willam,Willamen,Willas,Willem,William,Willis,Willit,Woth,Wulfe,Wun,Wyl,Wylis,Wyman,Wynton,Xaro,Xhondo,Yandry,Yezzan,Ygon,Yohn,Yoren,Yorkel,Yorko,Yormwell,Yurkhaz,Zachery,Zharaq,Zollo";
        //"Recene,Wregan,Scur,Bealohydig,Paige,Gimm,Tamar,Nechtan,Sihtric,Bronson,Aldfrith,Ormod,Boniface,Gram,Earm,Irwyn,Ethelwulf,Alchfrith,Eamon,Earl,Gordie,Beowulf,Ord,Sherwin,Grimme,Aethelfrith,Jeffrey,Edward,Acennan,Tobrecan,Orvyn,Lin,Bryce,Felix,Snell,Courtland,Aethelbald,Earm,Rinc,Deman,Ethelbert,List,Agiefan,Cadwallon,Eldrid,Lynn,Shelley,Desmond,Geoff,Agilberht,Ancenned,Manton,Lyn,Beorn,Tracy,Agyfen,Offa,Egesa,Raedwald,Ine,Lynn,Scur,Edlin,Scead,Beadurinc,Putnam,Edgar,Baldlice,Abrecan,Arlice,Earle,Lyn,Bliss,Maccus,Edsel,Werian,Tracey,Germian,Caedwalla,Andsaca,Gordie,Broga,Treddian,Garrett,Cynric,Shelby,Beornwulf,Banan,Eldwin,Gareth,Alwin,Agyfen,Courtney,Stewart,Elmer,Kenway,Scrydan,Garberend,Banning,Sibley,Leof,Alwin,Raedwald,Pleoh,Eldwyn,Irwin,Shepard,Ruadson,Kim,Lufian,Wurt,Storm,Arlice,Ethelred,Pearce,Rinan,Eldwyn,Sherwin,Eadwyn,Beorn,Ethelbert,Beadurof,Sheply,Archard,Wallis,Fairfax,Sheply,Agiefan,Grimme,Selwin,Ahreddan,Eamon,Douglas,Govannon,Maccus,Wissian,Ethelbald,Geraint,Germian,Tedmund,Nodons,Seber,Cadman,Ord,Wright,Aethelbald,Ham,Woden,Shephard,Earle,Scowyrhta,Hererinc,Baldlice,Holt,Druce,Odi,Alden,Toland,Raedan,Lunden,Eadwyn,Edgar,Bordan,Aidan,Kent,Eddison,Brun,Athelstan,Bellinus,Feran,Isen,Wurt,Cynric,Wilbur,Verge,Bayen,Cyst,Camden,Theomund,Sheply,Andsaca,Earm,Andswarian,Ruadson,Atyhtan,Edwin,Aidan,Corey,Ealdian,Edred,Penda,Scand,Pleoh,Cerdic,Bowden,Kenway,Ceawlin,Roweson,Orlege,Caedwalla,Eldred,Seaver,Temman,Aldred,Ethelred,Brice,Stillman,Brecc,Shelby,Ealdian,Wright,Ine,Sceotend,Ruadson,Courtney,Birdoswald,Grendel,Hlaford,Penda,Tilian,Grendel,Anson,Hilderinc,Seaver,Ecgfrith,Courtland,Selwyn,Wann,Cynewulf,Algar,Ody,Bearn,Ethelwulf,Row,Leanian,Cnut,Anson,Devyn,Oswiu,Athelstan,Scand,Scowyrhta,Linn,Ware,Bronson,Drew,List,Benoic,Bronson,Sheldon,Seaver,Erian,Eldwin,Geoff,Wyman,Odel,Piers,Beornwulf,Devyn,Durwin,Wilbur,Audley,Selwyn,Aldred,Wallace,Cynegils,Faran,Denby,Larcwide,Ine,Acwellen,Albinus,Ceolfrith,Ealdian,Cyst,Tolan,Isen,Kent,Eadgard,Wregan,Bowden,Alden,Rinan,Stilwell,Cynegils,Aldfrith,Rinc,Maxwell,Andweard,Lange,Dalston,Rinan,Iden,Wulf,Agyfen,Awiergan,Courtland,Wyman,Aethelwulf,Tredan,Andswaru,Ro,Torhte,Birdoswald,Acey,Kenway,Durwin,Halwende,Awiergan,Tedman,Dreng,Tedman,Raedan,Atol,Awiergan,Arlys,Edwy,Erian,Anhaga,Geoff,Arlyss,Anson,Douglas,Godric,Werian,Boniface,Devyn,Penrith,Rawlins,Rodor,Woden,Aldwyn,Oswy,Tobrecan,Boden,Beowulf,Trace,Worthington,Arian,Rodor,Anfeald,Grindan,Alden,Scead,Gifre,Wright,Garrett,Wade,Govannon,Newton,Seber,Avery,Aethelbert,Alwalda,Caflice,Slecg,Aethelbald,Shelby,Grindan,Earm,Renweard,Raedwald,Cedd,Albinus,Astyrian,Paige,Stearc,Godric,Wissian,Rowe,Ahreddan,Gareth,Odel,Ellen,Beorn,Boniface,Betlic,Merton,Gildas,Deman,Trymian,Sihtric,Ahebban,Geoff,Gordie,Archibald,Douglas,Sheply,Iuwine,Stillman,Gordon,Aethelbald,Jeffrey,Archard,Wine,Shepard,Hlaford,Aldin,Oswald,Penrith,Agiefan,Leng,Orvin,Gildas,Adamnan,Slecg,Rheged,Lin,Byrtwold,Anfeald,Wallis,Holt,Attor,Steadman,Larcwide,Rodor,Kent,Halwende,Egesa,Gimm,Synn,Waelfwulf,Abeodan,Waelfwulf,Grahem,Page,Tedmund,Bordan,Arlys,Oxa,Firman,Ware,Barclay,Wyne,Arth,Edlin,Grimm,Mann,Drefan,Aldfrith,Desmond,Arlyss,Earh,Cyst,Sever,Kent,Rinc,Grindan,Wright,Norville,Bede,Bealohydig,Ablendan,Anhaga,Grindan,Finan,Seamere,Modig,Theomund,Benoic,Erian,Ord,Cnut,Wallis,Bowden,Alchfrith,Dalston,Norvel,Feran,Lufian,Temman,Erconberht,Odon,Kenway,Torhte,Gram,Anwealda,Sheply,Warian,Upton,Hengist,Birdoswald,Sherwyn,Wirt,Camden,Cynric,Ancenned,Eldwyn,Kim,Edmond,Andettan,Winchell,Dreng,Atelic,Grimbold,Lin,Torht,Bliss,Rodor,Agilberht,Snell,Andwyrdan,Ryce,Anna,Hlisa,Shephard,Andsaca,Fraomar,Scead,Grahem,Rowe,Firman,Kimball,Ruadson,Erian,Bar,Mann,Wilfrid,Tellan,Sar,Ahreddan,Eddison,Tolan,Fleming,Odell,Aart,Eadig,Kenric,Ormod,Fleming,Lange,Atelic,Beircheart,Wallis,Trymman,Nerian,Seaver,Winchell,Leng,Aglaeca,Wilbur,Fairfax,Stewart,Offa,Wilbur,Kent,Beadurof,Edlin,Edsel,Archard,Edric,Eldrid,Rinc,Temman,Gifre,Edgard,Acey,Slecg,Feran,Andwyrdan,Aglaeca,Nyle,Colby,Lidmann,Roweson,Aart,Aethelstan,Cynegils,Oswiu,Beadurof,Albinus,Boden,Sceadu,Orvin,Andswarian,Edmund,Lyn,Corey,Caedmon,Stewart,Roe,Sherwyn,Boden,Strang,Worthington,Denisc,Tedman,Isen,Kendrick,Sherard,Storm,Stefn,Tolan,Ruadson,Stedman,List,Nechtan,Lar,Offa,Norvel,Garberend,Arth,Gareth,Tobrytan,Caedmon,Garberend,Seaton,Selwin,Avery,Attor,Banan,Fairfax,Freeman,Lucan,Roweson,Ord,Camdene,Wylie,Eddison,Benoic,Earm,Garr,Finan,Freeman,Lang,Arlys,Bordan,Lar,Bealohydig,Stepan,Seward,Ace,Leng,Durwin,Broga,Toland,Bealohydig,Aethelfrith,Edson,Ethelred,Waelfwulf,Werian,Stewart,Aethelwulf,Alger,Ham,Tracy,Galan,Yrre,Garr,Erconberht,Tracy,Aethelred,Hrypa,Larcwide,Verge,Derian,Seward,Anfeald,Norvel,Ethelbert,Arlys,Andswarian,Byrtwold,Oxa,Ine,Brun,Snell,Iden,Bayen,Shelley,Earle,Stuart,Abrecan,Earm,Nerian,Rinan,Egbert,Linn,Cynewulf,Nyle,Ahreddan,Willan,Ham,Raedbora,Edwy,Cerdic,Aheawan,Archard,Aethelred,Orlege,Earm,Cerdic,Wilfrid,Rodor,Pierce,Pleoh,Edwin,Wissian,Rowson,Iuwine,Amaethon,Raedwald,Teon,Ordway,Byrtwold,Seaton,Teon,Halwende,Grahem,Broga,Tamar,Cadman,Slecg,Nerian,Beowulf,Upton,Teon,Acennan,Odell,Denby,Besyrwan,Edlin,Octha,Synn,Piers,Fyren,Lange,Scand,Row,Tolan,Aldwyn,Camdene,Eldwyn,Willan,Nyle,Awiergan,Gaderian,Kendryck,Cyneric,Wann,Cynegils,Bar,Archibald,Abrecan,Wulfgar,Nodons,Bede,Arth,Chad,Ody,Ethelbert,Elmer,Fugol,Baldlice,Ethelred,Eldwin,Manton,Edgard,Wellington,Ormod,Tedmund,Cynewulf,Gimm,Ody,Boden,Brun,Wright,Wann,Banan,Acennan,Birdoswald,Berkeley,Aethelhere,Grahem,Durwin,Raedan,Audley,Feran,Norton,Eadig,Hlaford,Putnam,Benwick,Chapman,Paige,Norton,Beadurinc,Tolan,Daegal,Bliss,Irwyn,Firman,Selwin,Aethelhere,Brogan,Alwalda,Perry,Aethelbert,Graeme,Trymian,Faran,Nyle,Bealohydig,Yrre,Chapman,Rypan,Anbidian,Hrypa,Maponus,Winter,Ham,Stefn,Ethelbald,Treddian,Perry,Birdoswald,Aethelbald,Nodons,Sever,Aethelbald,Nyle,Swift,Dalston,Teon,Toland,Synn,Tobrecan,Kent,Brogan,Cadman,Sherwyn,Ceawlin,Hrypa,Offa,Ormod,Sheply,Cyneric,Octha,Sever,Edwy,Gimm,Wulfgar,Byrtwold,Aglaeca,Geoffrey,Alwalda,Archard,Aethelfrith,Swithun,Germian,Boyden,Aidan,Bestandan,Aidan,Eldred,Bana,Swift,Daegal,Devyn,Bron,Birdoswald,Roe,Iuwine,Beadurof,Edgar,Fairfax,Bowdyn,Firman,Gildas,Wissian,Rodor,Kendryck,Eldwyn,Agyfen,Denby,Gar,Andwearde,Edsel,Ane,Aethelhere,Woden,Aethelbald,Octha,Brogan,Cyneric,Tredan,Tredan,Beorn,Acennan,Bowdyn,Oswald,Bana,Beornwulf,Courtnay,Wann,Andweard,Eorl,Tellan,Archibald,Trace,Tedman,Grimme,Grendel,Denby,Wilbur,Druce,Scead,Sherwin,Trace,Alger,Irwin,Courtland,Seward,Cedd,Heolstor,Earl,Andweard,Fleming,Grendel,Anfeald,Rice,Garberend,Farmon,Bawdewyn,Wallis,Grendel,Drefan,Druce,Awiergan,Baldlice,Aldwyn,Graham,Torht,Rinc,Elmer,Roweson,Halig,Aldin,Wyman,Wulfhere,Devon,Orvin,Norton,Woden,Mann,Edgar,Prasutagus,Avery,Seaver,Attor,Wissian,Andweard,Earle,Fairfax,Graeme,Raedwald,Cenwalh,Winchell,Andweard,Synn,Ator,Rheged,Wallace,Godric,Row,Geraint,Almund,Ann,Bertie,Woden,Norville,Aethelbald,Aldhelm,Rypan,Bealohydig,Anfeald,Bellinus,Shepard,Egbert,Alwin,Wissian,Edwy,Aethelhere,Nechtan,Norvel,Baecere,Lucan,Ine,Snell,Odon,Grimbold,Oswiu,Edwin,Acwel,Octa,Aglaeca,Snell,Camden,Eldred";
        public const string FEMALE_NAMES =
            "Aemma,Aglantine,Alannys,Alayaya,Alerie,Alia,Alicent,Alla,Allyria,Alyce,Alynne,Alys,Alysane,Alysanne,Alyse,Alyssa,Alyx,Amabel,Amarei,Amerei,Annara,Anya,Arianne,Arwyn,Arya,Asha,Ashara,Assadora,Baela,Bandy,Barba,Barbara,Barbrey,Barra,Barsena,Becca,Belandra,Bella,Bellegere,Bellena,Bellonara,Beony,Berena,Bess,Bessa,Beth,Bethany,Betharios,Brea,Brella,Brienne,Carellen,Carolei,Cass,Cassana,Catelyn,Cerenna,Cersei,Chataya,Chella,Corenna,Cynthea,Cyrenna,Dacey,Daella,Daena,Daenerys,Daeryssa,Dalla,Dancy,Danelle,Darlessa,Deana,Delena,Della,Delonne,Desmera,Dilly,Donella,Donyse,Dorcas,Dorea,Doreah,Dorna,Dyah,Eddara,Eglantine,Eleanor,Elenei,Elenya,Elia,Elinor,Ellaria,Ellyn,Elyana,Elyn,Emberlei,Emma,Erena,Ermesande,Eroeh,Esgred,Ezzara,Falia,Falyse,Ferny,Frenya,Galazza,Gella,Genna,Gilly,Gretchel,Grisel,Grisella,Gwin,Gwynesse,Gwyneth,Gysella,Hali,Harma,Harra,Hazzea,Helaena,Helly,Helya,Holly,Hostella,Irri,Jaehaera,Janei,Janna,Janyce,Jayde,Jayne,Jennelyn,Jenny,Jeyne,Jezhene,Jhiqui,Joanna,Jocelyn,Johanna,Jonelle,Jonquil,Jorelle,Joy,Joyeuse,Jyana,Jyanna,Jynessa,Jyzene,Kella,Kezmya,Kojja Mo,Korra,Kyra,Lacey,Laena,Lanna,Larra,Layna,Leaf,Leana,Lemore,Leona,Leonella,Leonette,Leslyn,Lia,Lollys,Loreza,Lyanna,Lyessa,Lynesse,Lyra,Lysa,Lythene,Maddy,Maege,Maegelle,Maerie,Maggy,Marei,Margaery,Margot,Marianne,Maris,Marissa,Mariya,Marsella,Mary,Marya,Masha,Matrice,Meera,Megga,Meggett,Meha,Mela,Melara,Melesa,Melessa,Meliana,Melicent,Melisandre,Melissa,Mellara,Mellario,Mellei,Melly,Meralyn,Meredyth,Merianne,Meris,Mezzara,Mina,Minisa,Mirri,Missandei,Moelle,Mordane,Morna,Morra,Morya,Munda,Mya,Mylenda,Myranda,Myrcella,Myria,Myriah,Myrielle,Myrtle,Mysaria,Naerys,Nan,Nella,Nettles,Nissa Nissa,Nolla,Nymella,Nymeria,Nysterica,Obara,Obella,Olene,Olenna,Osha,Palla,Penny,Perra,Perriane,Pia,Qezza,Quaithe,Ravella,Rhaella,Rhaena,Rhaenyra,Rhaenys,Rhea,Robin,Roelle,Rosamund,Rosey,Roslin,Rowan,Rowena,Ryella,Rylene,Rylona,S'vrone,Saera,Sallei,Sansa,Sarella,Sarra,Sarya,Scolera,Selyse,Senelle,Serala,Serra,Shae,Sharna,Shella,Shiera,Shierle,Shireen,Shirei,Shyra,Sloey,Snowylocks,Squirrel,Su,Sybell,Sybelle,Sylva,Sylwa,Taena,Talea,Talla,Tanda,Tanselle,Tansy,Thistle,Three-Tooth,Trianna,Tya,Tyana,Tyene,Tysane,Tyta,Umma,Unella,Val,Victaria,Visenya,Walda,Weasel,Wenda,Willow,Wylla,Wynafrei,Wynafryd,Ygritte,Yna,Ynys,Ysilla,Zahrina,Zei,Zhoe,Zia";
        //"Viradecthis,Rheda,Whitney,Bodicea,Tate,Daryl,Ora,Silver,Hilda,Cyst,Engel,Nelda,Edith,Meghan,Bliss,Alodie,Etheswitha,Loretta,Eldrida,Edrys,Viradecthis,Moira,Ifield,Hamia,Chelsea,Beornia,Anlicnes,Juliana,Elga,Kendra,May,Garmangabis,Darel,Aethelflaed,Blythe,Eldrida,Bernia,Annis,Lyn,Daisy,Udele,Udele,Bliss,Megan,Eldrida,Darel,Anlicnes,Darlene,Arianrod,Moira,Dawn,Edrys,Eda,Odelia,Ellenweorc,Lora,Cwen,Darline,May,Nerthus,Sulis,Edlyn,Osberga,Elga,Elvina,Esma,Bisgu,Freya,Kendra,Tate,Aefentid,Estra,Don,Estra,Sibley,Kendra,Cartimandua,Silver,Ora,Diera,Mildred,Maida,Aethelthryth,Don,Rheda,Darelle,Mildred,Silver,Blythe,Bletsung,Odelia,Megan,Edrys,Cwen,Edris,Daisy,Brigantia,Engel,Lora,Wilona,Etheswitha,Wilona,Elvina,Diera,Juliana,Willa,Anlicnes,Aefentid,Andsware,Chelsea,Bernia,Eadgyth,Kendra,Alodie,Darline,Daryl,Orva,Andsware,Alodie,Don,Odelia,Diera,Mercia,Ashley,Claennis,Ellette,Cyst,Nelda,Cearo,Elswyth,Rowena,Cartimandua,Loretta,Elga,Freya,Alodie,Hilda,Sibley,Aethelflaed,Loretta,Catherine,Ifield,Ora,Dohtor,Aefre,Bletsung,Ellenweorc,Wilda,Aethelflaed,Maida,Anlicnes,Alodie,Elswyth,Linette,Silver,Kendra,Bliss,Ashley,Ifield,Maida,Juliana,Cearo,Harimilla,Bysen,Loretta,Freya,Edrys,Annis,Linette,Bearrocscir,Edmunda,Mae,Darlene,Mercia,Elene,Bodicea,Daisy,Ellette,Estra,Elga,Darel,Bliss,Darelle,Edrys,Ellette,Etheswitha,Garmangabis,Maida,Daedbot,May,Wilona,Elva,Edlyn,Brigantia,Brimlad,Sibley,Maida,Easter,Lyn,Ellenweorc,Megan,Mildred,Meghan,Anlicnes,Darelene,Ifield,Elvina,Bodicea,Odelia,Chelsea,Harimilla,Lyn,Bysen,Easter,Annis,Loretta,Wilona,Edlyn,Darel,Garmangabis,Viradecthis,Darel,Whitney,Etheswitha,Bodicea,Bernia,Cwen,Lyn,Maida,Aefre,Kendra,Don,Willa,Eacnung,Darelle,Eda,Cartimandua,Aethelthryth,Kendra,Coventina,Silver,Odelia,Sibley,Erlina,Dohtor,Hilda,Hamia,Moira,Estra,Hilda,Arianrod,Bletsung,Darline,Daryl,Lora,Edrys,Kendra,Kendra,Ashley,Easter,Coventina,Udele,Aefre,Eda,Harimilla,Daisy,Dawn,Darel,Mae,Aefentid,Cyst,Orva,Darel,Claennis,Alodie,Elene,Mercia,Coventina,Darel,Ar,Silver,Sibley,Elene,Mae,Megan,Cwen,Devona,Aefentid,Daryl,Estra,Loretta,Coventina,Don,Osberga,Odelia,Linette,Blythe,Edmunda,Daisy,Claennis,Bliss,May,Elvina,Arianrod,Sunniva,Whitney,Tate,Cyst,Mae,Esma,Bletsung,Nerthus,Megan,Silver,Ellette,Lora,Devona,Nerthus,Edris,Edmunda,Edith,Cyst,Coventina,Sulis,Aedre,Chelsea,Ashley,Daedbot,Elga,Hamia,Mercia,Edlyn,Audrey,Wilona,Ar,Aedre,Elene,Bletsung,Aethelthryth,Cyst,Estra,Ardith,Osberga,Orva,Don,Elvina,Cwen,Ar,Lora,Elga,Mildred,Mae,Bysen,Viradecthis,Engel,Odelia,Easter,Claennis,Aethelthryth,Elva,Edrys,Silver,Beornia,Blythe,Easter,Alodia,Bletsung,Loretta,Nerthus,Elvina,Esma,Udele,Elvina,Osberga,Rheda,Hamia,Lyn,Megan,Kendra,Cyst,Brigantia,Edlyn,Clover,Dawn,Orva,Cyst,Darelene,Claennis,Elva,Eadgyth,Lyn,Edmunda,Catherine,Coventina,Claennis,Bearrocscir,Aefentid,Mercia,Sibley,Beornia,Edmunda,Bliss,Lyn,Mercia,Harimilla,Aedre,Odelia,Cartimandua,Daryl,Rowena,Edith,Mildred,Shelley,Elene,Claennis,Eadgyth,Kendra,Claennis,Sunniva,Bisgu,Erlina,Hamia,Edith,Eadgyth,Ellette,Erlina,Cwen,Chelsea,Moira,Elswyth,Darelle,Orva,Aedre,Lora,Daisy,Elene,Edris,Rheda,Udele,Bernia,Mae,Estra,Bearrocscir,Cearo,Elswyth,Rowena,Edlyn,Elene,Erlina,Kendra,Eda,Sunniva,Megan,Claennis,Cartimandua,Eacnung,Edmunda,Engel,Chelsea,Bernia,Daisy,Bearrocscir,Sibley,Estra,Aefre,Wilda,Don,Arianrod,Elga,Eldrida,Nelda,Megan,Brigantia,Tate,Rheda,Chelsea,Whitney,Ifield,Elga,Nerthus,Meghan,Erlina,Harimilla,Elga,Beornia,Estra,Beornia,Viradecthis,Easter,Mae,Darlene,Alodie,Bearrocscir,Osberga,Eostre,Viradecthis,Silver,Eldrida,Darelene,Bletsung,Clover,Edith,Ardith,Don,Eostre,Darline,Aefentid,Eostre,Eostre,Kendra,Elvina,Orva,Maida,Mildred,Ashley,Eldrida,Eldrida,Edmunda,Meghan,Ifield,Cearo,Devona,Elvina,Ellenweorc,Estra,Audrey,Eacnung,Garmangabis,Esma,Ashley,Ardith,Brimlad,Aedre,Eadgyth,Wilda,Brigantia,Lyn,May,Ar,Chelsea,Claennis,Darelene,Whitney,Edith,Daisy,Eacnung,Sulis,Eadgyth,Bodicea,Shelley,Aethelflaed,Aefentid,Tate,Loretta,Sulis,Mercia,Edmunda,Darlene,Elene,Eda,Brigantia,Udele,Diera,Sunniva,Aedre,Claennis,Dawn,Bisgu,Bliss,Andsware,Esma,Audrey,Engel,Hamia,Brimlad,Cartimandua,Daryl,May,Osberga,Loretta,Alodia,Udele,Don,Garmangabis,Maida,Orva,May,Ora,Don,Acca,Viradecthis,Wilona,Bearrocscir,Wilona,Eacnung,Ifield,Garmangabis,Viradecthis,Wilona,Darelene,Eostre,Hilda,Lyn,Darelene,Darelle,Rheda,Osberga,Ellette,Tate,Aedre,Elvina,Bisgu,Blythe,Don,Viradecthis,Moira,Easter,Bletsung,Freya,Odelia,Willa,Ora,Linette,Brigantia,Aethelthryth,Daedbot,Alodia,Harimilla,Dohtor,Darel,Brimlad,Daisy,Alodie,Elva,Osberga,Edrys,Eda,Acca,Alodia,Sunniva,Eostre,Ashley,Engel,Arianrod,Elvina,Aefentid,Cwen,Annis,Devona,Nerthus,Juliana,Esma,Anlicnes,Aefre,Catherine,Lora,Bliss,Freya,Silver,Coventina,Aefre,Alodie,Daryl,Clover,Elvina,Aethelthryth,Andsware,Estra,Alodia,Sunniva,Hilda,Shelley,Darelle,Daryl,Elvina,Elva,Ellenweorc,Garmangabis,Bletsung,Audrey,Garmangabis,Ellenweorc,Bletsung,Sulis,Mae,Hilda,Moira,Ellenweorc,Bearrocscir,Andsware,Dawn,Mercia,Freya,Arianrod,Darlene,Darel,Acca,Eacnung,Rowena,Bernia,Brigantia,Elswyth,Willa,Darlene,Aefentid,Edith,Ardith,Claennis,Freya,Edmunda,Erlina,Coventina,Daisy,Darelene,Dohtor,Freya,Ellette,Aethelflaed,Mildred,Acca,Cearo,Lyn,Esma,Linette,Dawn,Dohtor,Bernia,Sulis,Darlene,Bernia,Shelley,Ar,Ar,Edlyn,Hilda,Garmangabis,Edith,Rowena,Alodia,Loretta,Bletsung,Mercia,Estra,Elswyth,Maida,Elene,Aefentid,Beornia,Diera,Arianrod,Bodicea,Dawn,Udele,Shelley,Diera,Engel,Aedre,Alodia,Ifield,Eda,Elvina,Megan,Garmangabis,May,Engel,Elvina,Linette,Cyst,Sibley,Wilda,Eacnung,Clover,Aedre,Wilona,Ellenweorc,Elvina,Lyn,Aedre,Easter,Nerthus,Esma,Beornia,Audrey,Elene,Edmunda,Viradecthis,Elga,Odelia,Meghan,Edith,Juliana,Aethelthryth,Clover,Sibley,Alodia,Aethelflaed,Odelia,Whitney,Aethelflaed,Bearrocscir,Blythe,Viradecthis,Clover,Mae,Ardith,Clover,Bernia,Viradecthis,Meghan,Rheda,Dawn,Maida,Catherine,Andsware,Nerthus,Eda,Whitney,Eacnung,Esma,Aefre,Anlicnes,Wilona,Andsware,Annis,Bletsung,Linette,Eadignes,Erlina,Bysen,Megan,Aedre,Udele,Daedbot,Bearrocscir,Edrys,Viradecthis,Shelley,Whitney,Rheda,Chelsea,Loretta,Orva,Ellenweorc,Daryl,Darlene,Chelsea,Ar,Chelsea,Elga,Ashley,Ellette,Dawn,Willa,Nelda,Catherine,Alodia,Juliana,Loretta,Erlina,Ar,Chelsea,Esma,Aefre,Wilona,Claennis,Diera,Bisgu,Elva,Osberga,Rowena,Don,Edmunda,Elvina,Ar,Silver,Nelda,Daryl,Mildred,Cearo,Bearrocscir,Cwen,Willa,Cartimandua,Rheda,Bernia,Aefentid,Elva,Tate,Edlyn,Edlyn,Lora,Viradecthis,Bysen,Bisgu,Bearrocscir,Lyn,Engel,Daryl,Orva,Mildred,Ifield,Brimlad,Harimilla,Andsware,Mae,Viradecthis,Darelene,Acca,Rowena,Loretta,Juliana,Darel,Sunniva,Tate,Willa,Lora,Darel,Osberga,Etheswitha,Lora,Sulis,Elga,Clover,Aethelthryth,Dawn,Bearrocscir,Mercia,Bodicea,Ora,Eostre,Alodie,Chelsea,Acca,Willa,Whitney,Ellette,Willa,Elga,Freya,Bisgu,Freya,Arianrod,Wilda,Elvina,Bysen,Brimlad,Megan,Andsware,Ashley,Aethelflaed,Ora,Cyst,Eostre,Nelda,Chelsea,Linette,Arianrod,Audrey,Hilda,Bernia,Eda,Acca,Odelia,Edith,Meghan,Bernia,Coventina,Bisgu,Darlene,Edrys,Chelsea,Eadgyth,Sulis,Bernia,Anlicnes,Acca,Meghan,Edrys,Beornia,Dohtor,Anlicnes,Cyst,Esma,Daisy,Daedbot,Tate,Sulis,Elva,Dawn,Diera,Eda,Elvina,Moira,Megan,Garmangabis,Cearo,Ardith,Chelsea,Cwen,Linette";
        public const string SURNAMES =
            "Allyrion,Ambrose,Antaryon,Arryn,Ashford,Baelish,Banefort,Bar Emmon,Baratheon,Barleycorn,Beesbury,Belgrave,Belmore,Bentley,Bettley,Bigglestone,Blackbar,Blackberry,Blackfyre,Blackmont,Blacktyde,Blackwood,Blount,Bolling,Bolton,Bone,Borrell,Botley,Bracken,Branch,Brax,Broom,Broome,Browntooth,Brune,Buckler,Buckwell,Bulwer,Burley,Bushy,Butterwell,Byrch,Byrne,Bywater,Cafferen,Cargyll,Caron,Cassel,Caswell,Celtigar,Cerwyn,Chambers,Charlton,Chelsted,Chester,Chyttering,Clegane,Clifton,Cobb,Codd,Coldwater,Cole,Condon,Connington,Corbray,Corne,Correy,Costayne,Cox,Crabb,Crakehall,Crane,Cuy,D'han,Dalt,Darke,Darklyn,Darry,Dayne,Dedding,Deddings,Deem,Deremond,Dimittis,Dondarrion,Dothare,Drahar,Drinkwater,Drumm,Duckfield,Durrandon,Dustin,Edoryen,Egen,Emeros,Errol,Estermont,Estren,Farman,Farring,Farrow,Farwynd,Fell,Flatnose,Flint,Florent,Flowers,Follard,Foote,Footly,Forel,Fossoway,Fowler,Foxglove,Freeborn,Fregar,Frey,Galarre,Gardener,Gargalen,Gaunt,Gimpknee,Glover,Godsgrief,Goodbrook,Goodbrother,Goode,Gower,Graceford,Grafton,Grandison,Greenfield,Greenhill,Grell,Grey,Greyiron,Greyjoy,Greysteel,Grimm,H'ghar,Haigh,Harclay,Hardy,Hardyng,Harlaw,Harte,Hasty,Hayford,Heddle,Hetherspoon,Hewett,Hightower,Hill,Hoare,Hoat,Hogg,Hollard,Holt,Hornwood,Horpe,Hotah,Humble,Hungerford,Hunt,Hunter,Inchfield,Ironfoot,Ironmaker,Istarion,Jast,Jayn,Jordayne,Joth,Karstark,Kenning,Kettleblack,Kingsblood,Ladybright,Lannister,Lansdale,Lanster,Largent,Leek,Lefford,Lho,Liddle,Locke,Lohar,Long,Longaxe,Longbough,Longstrider,Longthorpe,Longwaters,Lonmouth,Lorch,Lornel,Lothston,Lychester,Lydden,Lynderly,Maar,Maegyr,Mahr,Malanon,Mallarawan,Mallery,Mallister,Manderly,Mandrake,Manwoody,Mar Tun Doh Weg,Marbrand,Marsh,Martell,Massey,Maz Duur,Meadows,Merlyn,Merrell,Merryweather,Mertyns,Mo,mo Eraz,mo Kandaq,mo Nakloz,mo Reznak,mo Ullhor,Mogat,Mollen,Moore,Mooton,Mopatis,Moreland,Mormont,Morrigen,Mott,Mudd,Mullendore,Musgood,Myrakis,Myre,na Ghezn,Naharis,Nayland,Nestoris,Nogarys,Norcross,Norrey,Noye,Oakheart,Of Dorne,Of Sisterton,Oldfather,Orkwood,Ormollen,Otherys,Paege,Paenymion,Payne,Peake,Pease,Peasebury,Peckledon,Pemford,Penny,Penrose,Perryn,Piper,Plumm,Poole,Potter,Pox,Pree,Prestayn,Prester,Pyke,Qar Deeth,Qhaedar,Qorgyle,Quaynis,Quickaxe,Quince,Rambton,Rankenfell,Rayder,Redback,Redbeard,Redfort,Redwyne,Reed,Reyne,Rhee,Rhegan,Rhysling,Rivers,Rodden,Roote,Rosby,Rowan,Roxton,Royce,Rustbeard,Ruttiger,Ryger,Rykker,Ryndoon,Ryswell,Saan,Saltcliffe,Sand,Santagar,Sarsfield,Sathmantes,Sawyer,Scales,Sealskinner,Seastar,Seaworth,Selmy,Serrett,Serry,Sharp,Shepherd,Shett,Shield,Shieldbreaker,Short,Slate,Slynt,Smallwood,Snow,Sparr,Spicer,Stackspear,Staedmon,Staegone,Stark,Staunton,Stilwood,Stokeworth,Stone,Stonehouse,Stonetree,Storm,Stormdrunk,Stout,Straw,Strickland,Stripeback,Strong,Suggs,Sunderland,Sunderly,Sunglass,Swann,Sweet,Swyft,Tallhart,Tangletongue,Tanner,Tarbeck,Targaryen,Tarly,Tarth,Tawney,Templeton,Tendyris,Terys,Thorne,Tidewood,Toland,Tollett,Toraq,Torrent,Toyne,Tully,Tumitis,Turnberry,Tyrell,Uhoris,Uller,Umber,Vaelaros,Vaith,Vance,Varner,Velaryon,Vhassar,Vikary,Volentin,Volmark,Votar,Votyris,Vypren,Vyrwel,Wagstaff,Wanderer,Waters,Waxley,Wayn,Waynwood,Weaver,Weg Wun Dar Wun,Wells,Westerling,Wheaton,Whent,Whitewater,Whittlestick,Willum,Wode,Woods,Woodwright,Wull,Wylde,Wynch,Wythers,Xho,Xhoan Daxos,Yarwyck,Yew,Yos Dob,Yronwood,zo Ahlaq,zo Eraz,zo Faez,zo Galare,zo Loraq,zo Myraq,zo Pahl,zo Qaggaz,zo Rhaezn,zo Yunzak,zo Zherzyn";
        public const double NOBLE_COST = 5;
        public const double NOBLE_INCOME = 0;
        public const double SOLDIER_RATIO = 0.1;
        public const double MIN_TAX_RATE = 0.1;
        public const int MAX_YEILD_HIGH = 10000;
        public const int MAX_YEILD_LOW = 5000;
        public const string TOWN_NAMES = "Doddingtree,Winstree,Pershore,Uggescombe,Merton,Kerswell,Bountisborough,Patton,Bowcombe,Gartree,Hormer,Wotton,Spelhoe,Chilford,Arringford,Bibury,Amesbury,Blackwell,Calcewath,Ainsty,Cleyley,Land of Count Alan,Boldre,Redbridge,Navisford,Leintwardine,Acklam,Langbaurgh,Wittery,Agbrigg,Osgodcross,Walsham,Freebridge,[South] Greenhoe,Loningborough,Warmundestrou,Ailwood,Babergh,Condover,Bagstone,Baschurch,Cuttlestone,Grimboldestou,Pirehill,Horethorne,Rushcliffe,Bloxham,Hodnet,Dolesfield,Burghshire,Craven,Ixhill,Mow,Larkfield,Navisland,Wallington,Candleshoe,Skyrack,Beltisloe,Eastry,Salmonsbury,Staincross,Hamestan,Celfledetorn,North Petherton,Foxley,Lewknor,Strafforth,Witheridge,Langport,Bere[Regis],Offlow,Street,Amounderness,Sneculfcros,Elsdon,Tremlowe,Upton,Allerton,[West] Derby,Barkston,Corringham,Threo,Cannington,Dic,Lawress,Merset,Stotfold,Claydon,Lothingland,Leominster,Reweset,Wrockwardine,Alnodestreu,Earsham,Edwinstree,Thame,Blackheath,South Erpingham,Stradel,Rotherfield,Wandelmestrei,Lodding,Carhampton,Leightonstone,North Erpingham,Selkley,Holderness[Middle Hundred],Tring,Plomesgate,Clavering,St Albans,Danish,Alderbury,Hinckford,Reading,Frustfield,Tewkesbury,Wilford,Dunley,Ongar,Bircholt,Lexden,Cosford,Boxgrove,Eyhorne,Fishborough,Culvestan,Ruloe,Bishop's,Aldrington,Bulford,Hartcliffe,Huxloe,Nakedthorn,Gallow,Sandford,Blachethorna,Williton,Scarsdale,Kirton,Whitstone,Manley,Blachelaue,Berkeley,Appletree,Bledisloe,Silverton,South Molton,Somerton,Pocklington,Bempstone,Morley,Litchurch,Goscote,Exestan,Goderthorn,Mansbridge,Winnibriggs,Barcombe,Studfold,Diptford,Chillington,Hartland,Broadwater,Fernecumbe,Carlford,Blything,Wonford,Henstead,Rushton,Axminster,Tendring,Fawley,Tunendune,Middlewich,Hamston,Coleshill,Colnes,Oswaldslow,Huntspill,Totmonslow,Nobottle,Epworth,Neatham,Stretford,Swanborough,Cerne, Totcombe and Modbury,Stratton,Came,Seisdon,Fremington,Meonstoke,Lydney,Connerton,Newark,Bampton,Langley,Pathlow,Bradford,Louthesk,Bromsash,Normancross,Black Torrington,Thurgarton,Uttlesford,Tornelaus,Easwrithe,Headington,Burnham,Maneshou,Gersdones,Andover,Redbornstoke,Thedwastre,Hertford,Glastonbury,Holderness[South Hundred],Risberg,Hessle,Welford,Broxtowe,Steyning,Bumbelowe,Dunworth,Rillaton,Flaxwell,Hoddington,Willybrook,Portsdown,Wraggoe,Forehoe,Walecros,Halberton,North Tawton,Blackbourne,Sutton,Marcham,Bucklow,Bewsbury,Milverton,Elmbridge,Odsey,Yarlestre,Wantage,Kirtlington,Torbar,Hunesberi,Clifton,Shirwell,Polebrook,Guthlaxton,Holderness[North Hundred],Rowditch,Faversham,Tybesta,Wetherley,Rothwell,Binsted,Shipton,Bolingbroke,Braunton,Pimperne,Axton,Loose,Alleriga,Kingsbury West,Bosmere,Foxearle,Teignbridge,Hildslow,Shropham,West Flegg,Wymersley,Guilsborough,Haverstoe,Hamfordshoe,Hill,Gravesend,Horncastle,Cliston,Exminster,Winterstoke,Whitley,Freshwell,Overton,Archenfield,Wibrihtesherne,Ashendon,Wye,Blackburn,Longbridge,Spelthorne,Wayland,Abdick,Rochford,Stone,Lifton,Cheveley,Cicementone,Stoke,Cranborne,Stoneleigh,Radlow,Copthorne,Whorwellsdown,Pucklechurch,Heytesbury,Cricklade,Tibblestone,Salford,Alstoe[South],Kilmersdon,Eggardon,Bassetlaw,Aveland,Depwade,Bingham,Hartismere,Manshead,Howden,Towcester,Ati's Cross,Hezetre,Cottesloe,Wacrescumbe,Aylesbury,Yardley,Warden,Wootton,Greston,Blewbury,Alboldstow,Biggleswade,Moulsoe,Ash,Aswardhurn,Puddletown,Whitchurch[Canonicorum],Taverham,Graffoe,Hunthow,Yarborough,Cave,Brentry,Fawton,Chafford,Plegelgete,Longtree,Lythe,Kintbury,Shirley,Somborne,Hemyock,Axmouth,Budleigh,Bradley,Plympton,Tunstead,Thornhill,Chelmsford,Binfield,Dudstone,Crondall,Staploe,Risbridge,Taunton,Wimundestreu,Cirencester,Thatcham,Brothercross,Driffield,Holt,Brixton,Thunderlow,Falmer,Radfield,Banbury,Guiltcross,Witley,Ness,Alwardsley,Barcheston,Gainfield,Downton,Barford,Cadworth,Barham,Framland,Charldon,Ruston,Becontree,Rotherbridge,Rinlau,Maidstone,Lothing,[North] Greenhoe,Willaston,Dunmow,South Petherton,Barrington,Thingoe,Witchley,Wangford,Barstable,Greytree,Odiham,Dinedor,Clackclose,Rowley,Flitton,Lackford,Swineshead,Barton,Docking,Edgegate,Slotisford,Basingstoke,Mitford,Staple,Bath,Branchbury,Hailesaltede,Conditre,Eynesford,Holford,Beaminster,Felborough,Cornilo,Willingdon,Bromley,Shrivenham,Oswaldbeck,Frome,Shamwell,Totnore,Fordingbridge,Buckelowe,Kinwardstone,Burghbeach,Rowbury,Colyton,Wichestanestou,Laundich,Bridge,Clent,Heane,Rolvenden,Keynsham,Hitchin,Wyndham,Loveden,Benson,Twyford,Bentley,Broughton,Welton,Witham,Marton,Easebourne,Roborough,Streat,Winfrith[Newburgh],Duddeston,Eastbourne,Kingsbridge,Parham,Bexhill,Helmestrei,Dorchester,Westbury,Chippenham,Chuteley,Bury,Langoe,Stanbridge,Newchurch,Walshcroft,Cullifordtree,Singleton,Burton,Droxford,Wittering,Scard,Beynhurst,Ossulstone,Stepleset,Tintinhull,Flexborough,Warminster,Bisley,Ringwood,Overs,Hasler,Worth,Combsditch,Thurstable,Corby,Andersfield,Whitstable,Tandridge,Risborough,Collingtree,Blofield,Scipa,Hurstingstone,Aslacoe,Stowting,Lambourn,Winnianton,Rialton,Tiverton,Stodden,Effingham,Boothby,Rochester,Bosham,Staine,Toseland,Boughton,Botloe,Longstowe,Deerhurst,Pevensey,Papworth,Higham,Humbleyard,Desborough,Startley,Sherborne,Morleystone,Mere,Seckley,Fexhole,East Grinstead,Ashley,Well,Hallikeld,Holdshott,Westerham,Wincanton,Braughing,Bray,Aloesbridge,Diss,Bruton,Welesmere,Rapsgate,Cutestornes,Cresslow,Cawdon,Mawsley,Brightford,Cheltenham,Thriplow,Fleamdyke,Bosbarrow,Knowlton,Calne,Orlingbury,Avronhelle,Titchfield,Happing,Grimshoe,Reigate,Buckland[Newton],Bucklebury,Edivestone,Henhurst,Romney Marsh,Woking,Weighton,Wyfold,Wolmersty,Stowmarket,Godley,Castlery,Edlogan,Is Coed,East Flegg,Calbourne,Cambridge,Chewton,Wellow,Mainsborough,Bermondspit,Cogdean,[Bishops] Cannings,Canterbury,Willey,Ninfield,Brunsell,Eagle,Stowford,Chalton,Charborough,Kingsbury Episcopi,Calehill,Greenwich,Chart,Chatham,Ely 1,Langtree,Tollerford,Hilton,Kingston,Chester,Chesterton,Rowborough,Chew,Stockbridge,Buddlesgate,Falemere,Waltham,Houndsborough,Elstub,Chislet,Dumpford,Portbury,Waddesdon,Buttinghill,Kingsclere,Evingar,Ripplesmere,York,Yetminster,Kiftsgate,[Sturminster] Newton,Colchester,Highworth,Elthorne,Brightwells Barrow,Hurstbourne,Thorngrove,Godalming,Ghidenetroi,Sixpenny,Baldslow,Toreshou,Alstoe[North],Ludborough,Micheldever,Litlelee,Crediton,Crewkerne,Badbury,Wolfhay,Elloe,North Curry,Welsh District,Warter,Damerham,Wormelow,Eddredestane,Ely 2,Mursley,Whittlesford,Summerdene,Lene,Ramsbury,West Grinstead,Edmonton,Blagrove,Preston,Harlow,Goldspur,Weneslawe,Fareham,Farnham,Gillingham,Wingham,Folkestone,Fordwich,Poynings,Downhamford,Bunsty,Northstowe,Smethdon,Tollingtrough,Guestling,Littlefeld,Martinsley,Hounslow,Samford,Holmestrow,Gore,Hartfield,Dill,Shoyswell,Henfield,Cutsthorn,Langebrige,Hoo,Framfield,Pyrton,Ifield,WOR,Suffolk,Ipswich,Babinrerode,Letberge,Leyland,Wells,Ewias,Wyvern,Reculver,Maldon,Malling,Thanet,Martock,Melksham,Shrewsbury,East Meon,Milton,Castle,Silverden,Newton,Norwich,Ham,Codsheath,Ottery St Mary,Pagham,Oxney,Pawton,Petham,Stursete,Sandwich,Somerley,Teynham,Crickland,Sellack,Sturry,Thetford,Tidenham,Lowy of Tonbridge,Wechylstone,Hawkesborough,Warrington,Wonderditch,Wrotham,Hemreswel";
        public const int MINIMUM_VILLAGE_SIZE = 50;
        public const int MAP_WIDTH = 39;
        public const int MAP_HEIGHT = 19;
        public const int GENERATIONS_WITHOUT_SHARED_ANCESTOR = 3;
        public const int AGE_OF_MAJORITY = 18;
        public const int MAX_BETROTHAL_AGE_DIFFERENCE = 10;
        public const double CHANCE_OF_RECRUITING_FOREIGN_HOUSE = 1;
        public const int NUMBER_OF_CHILDREN_FOR_NEW_LORD = 10;
        public const int YEARS_TO_ITERATE_NEW_HOUSES = 30;
        public const int MAX_RECRUITMENTS = 3;
        public const int NUMBER_OF_INDESPENSIBLE_HEIRS = 3;
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
        Noble = 2
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
            Towns = new List<Town>();
            Population = new List<Person>();
            NobleHouses = new List<House>();
            Bethrothals = new List<Bethrothal>();
            _rnd = rnd;
        }
        public int Year { get; set; }
        public List<Town> Towns { get; set; }
        public List<Person> Population { get; set; }
        public List<House> NobleHouses { get; set; }
        public void AddTown(Town town)
        {
            if (!Towns.Contains(town))
            {
                if (town.World != null)
                {
                    town.World.RemoveTown(town);
                }
                Towns.Add(town);
                town.World = this;
            }
        }
        public void RemoveTown(Town town)
        {
            if (Towns.Contains(town))
            {
                Towns.Remove(town);
                town.World = null;
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
            //if (!People.Contains(person))
            //{
                if (person.World != null)
                {
                    person.World.RemovePerson(person);
                }
                Population.Add(person);
                person.World = this;
            //}
        }
        public void RemovePerson(Person person)
        {
            //if (Population.Contains(person))
            //{
                Population.Remove(person);
                person.World = null;
            //}
        }
        public void IncrementYear()
        {
            Year++;
            Population.ForEach(person => person.IncrementYear());
            NobleHouses.ForEach(house => house.IncrementYear());
            Towns.ForEach(town => town.IncrementYear());
        }
        public string GetMapAsString()
        {
            //output map
            var map = "  |01|02|03|04|05|06|07|08|09|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|31|32|33|34|35|36|37|38|39|\n";
            for (var y = 1; y <= Constants.MAP_HEIGHT; y++)
            {
                map += y.ToString("00");
                for (var x = 1; x <= Constants.MAP_WIDTH; x++)
                {
                    map += "| ";
                    var village = Towns.First(v => v.MapX == x && v.MapY == y);
                    if (village.Vacant)
                    {
                        map += " ";
                    }
                    else
                    {
                        map += village.Lords.Last().House.Symbol;
                    }

                    /*if (!village.Vacant && village.Lords.Last().House.Name == "Stark" && world.Year % 1 == 0)
                    {
                        Console.WriteLine("YEAR " + world.Year);
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Village: " + village.Name);
                        Console.WriteLine("Founding Year: " + village.FoundingYear);
                        var incumentlord = village.Lords.Last();
                        Console.WriteLine("Lord: " + incumentlord.FullNameAndAge);
                        Console.WriteLine("Order of Succession:");
                        var orderOfSuccession = village.GetOrderOfSuccession(10);
                        for (int i = 0; i < orderOfSuccession.Count(); i++)
                        {
                            Console.WriteLine((i + 1) + ": " + orderOfSuccession[i].FullNameAndAge);
                        }
                        var villagers = new List<Person>();
                        village.Households.ForEach(v => villagers.AddRange(v.Members));
                        Console.WriteLine("Noble Households:" + village.Households.Count(v => v.HouseholdClass == SocialClass.Noble));
                        Console.WriteLine("Peasant Households:" + village.Households.Count(v => v.HouseholdClass == SocialClass.Peasant));
                        Console.WriteLine("Population:" + villagers.Count());
                        Console.WriteLine("Seniors >= 50:" + villagers.Count(v => v.IsAlive && v.Age > 50));
                        Console.WriteLine("Children < 18: " + villagers.Count(v => v.IsAlive && v.Age < 18));
                        Console.WriteLine("Nobles: " + villagers.Count(v => v.Household.HouseholdClass == SocialClass.Noble && v.IsAlive));
                        Console.WriteLine("Peasants: " + villagers.Count(v => v.Household.HouseholdClass == SocialClass.Peasant && v.IsAlive));
                        Console.WriteLine("Yeild: " + village.Yeild);
                        Console.WriteLine("Cost: " + village.Cost);
                        Console.WriteLine("Surplus: " + village.Surplus);
                        Console.WriteLine("Income: " + village.Income);
                        Console.WriteLine("Wealth: " + village.Wealth);
                        Console.WriteLine("------------------------");

                    }*/
                }
                map += "|\n";
            }
            return map;
        }
        public string GetDetailsAsString()
        {
            var retString = "";
            var world = this;
            retString += ("Dane Noble Houses: " + world.NobleHouses.Count(x => !x.Vacant && x.Lords.Last().People == People.Dane) + "\n");
            retString += ("Saxon Noble Houses: " + world.NobleHouses.Count(x => !x.Vacant && x.Lords.Last().People == People.Saxon) + "\n");
            retString += ("Towns: " + world.Towns.Count(x => x.Households.Count() > 0)) +"\n";
            retString += ("Total Population: " + world.Population.Count(x=>x.IsAlive)) + "\n";
            retString += ("Total Saxon Population: " + world.Population.Count(x => x.IsAlive && x.People ==People.Saxon)) + "\n";
            retString += ("Total Dane Population: " + world.Population.Count(x => x.IsAlive && x.People == People.Dane)) + "\n";
            retString += ("Total Noble Households: " + world.Towns.Sum(x => x.Households.Count(y => y.HouseholdClass == SocialClass.Noble))) + "\n";
            retString += ("Total Peasant Households: " + world.Towns.Sum(x => x.Households.Count(y => y.HouseholdClass == SocialClass.Peasant))) + "\n";
            /*
            var housePower = world.Towns.Where(v => !v.Vacant).GroupBy(v => v.Lords.Last().House);
            foreach (var houseGrouping in housePower)
            {
                retString += ("House " + houseGrouping.Key.Symbol + "-" + houseGrouping.Key.Name) + "\n";
                retString += ("\tLordships:" + houseGrouping.Count()) + "\n";
                retString += ("\tWealth:" + houseGrouping.Sum(x => x.Wealth)) + "\n";
            }*/
            retString += ("------------------------") + "\n";
            return retString;
        }
        public List<Bethrothal> Bethrothals
        {
            get;set;
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
            
            if (echo && headOfHouseoldToBe.House.Name == "Stark")
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
            AvailableUnmarriedMembers = new List<Person>();
            Vassles = new List<House>();
            AssessedIncome = new List<AssessedIncome>();
            Recruitments = 0;
        }
        public int Recruitments { get; set; }
        public Town Seat { get; set; }
        public House Allegience { get; set; }
        public List<House> Vassles { get; set; }
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
            if (Members.Contains(oldMember)) {
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
        public void IncrementYear() {
            var incumbentLord = Lords.Last();
            CollectTaxes();
            if (!incumbentLord.IsAlive)
            {
                //The lord is Dead!  Long live the lord!

                if (incumbentLord.House.Name == "Stark")
                {
                    Console.WriteLine(incumbentLord.FullNameAndAge + " DIED in " + World.Year);
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
                    if (heir.House.Name == "Stark" || incumbentLord.House.Name == "Stark")
                    {
                        Console.WriteLine(heir.FullNameAndAge + " INHERITED the Lordship of House " + Name + " in " + World.Year);
                        if (heir.House != incumbentLord.House)
                        {
                            Console.WriteLine("LOSS OF HOUSE! Control of House " + Name + " passed to " + heir.House.Name + " in " + World.Year);
                        }
                    }
                }
                else
                {
                    Vacant = true;
                    if (incumbentLord.House.Name == "Stark")
                    {
                        Console.WriteLine("The Lordship of House " + Name + " is vacant.");
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
            if(newLord.Household!=null && newLord != newLord.Household.HeadofHousehold)
            {
                var newHousehold = new Household()
                {
                    HeadofHousehold = newLord
                };
                newHousehold.AddMember(newLord);
                if (newLord.Spouse!=null && newLord.Spouse.IsAlive)
                {
                    newHousehold.AddMember(newLord.Spouse);
                    var spousesMinorChildren = newLord.Spouse.Children.Where(x => x.Age < Constants.AGE_OF_MAJORITY);
                    foreach(var child in spousesMinorChildren)
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
            if (newLord.Household.Town == null || newLord.Household.Town != Seat)
            {
                Seat.AddHousehold(newLord.Household);
            }
            Lords.Add(newLord);
        }
        public List<House> GetAllSubVassles()
        {
            var subVassles = new List<House>();
            foreach (var vassle in Vassles)
            {
                subVassles.Add(vassle);
                subVassles.AddRange(vassle.GetAllSubVassles());
            }
            return subVassles;
        }
        public string GetDetailsAsString()
        {
            var retString = "";
            retString += ("YEAR " + World.Year + '\n');
            retString += ("------------------------\n");
            retString += ("House: " + Name + '\n');
            var incumentlord = Lords.Last();
            retString += ("Lord: " + incumentlord.FullNameAndAge + '\n');
            retString += ("Wealth: " + Wealth.ToString("0.00") + '\n');
            var lastYear = World.Year - 1;
            var lastYearsIncome = AssessedIncome.FirstOrDefault(x => x.Year == lastYear);
            if (lastYearsIncome != null)
            {
                retString += lastYear + " Income: " + lastYearsIncome.Income.ToString("0.00") + "\n"; 
            }
            retString += ("Order of Succession:" + '\n');
            var orderOfSuccession = GetOrderOfSuccession(10);
            for (int i = 0; i < orderOfSuccession.Count(); i++)
            {
                retString += ((i + 1) + ": " + orderOfSuccession[i].FullNameAndAge + '\n');
            }
            retString += "Vassles:\n";
            var nobleVassles = Vassles.Where(v => v.Lords.Count > 0 && v.Lords.Last().Class == SocialClass.Noble);
            foreach (var vassle in nobleVassles)
            {
                retString += "\t" + vassle.Name + "(" + vassle.GetAllSubVassles().Count() + " sub-vassles)\n";
            }
            return retString;
        }
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
        public List<Person> GetIndespensibleMembers()
        {
            var allLivingHeirs = Lords[0].GetHeirs().Where(x => x.IsAlive && x.House==this).ToList();
            var indespensibleLivingHeirs = new List<Person>();
            foreach (var livingHeir in allLivingHeirs)
            {
                var positionInMothersLivingChildren = 1;
                var positionInFathersLivingChildern = 1;
                if (livingHeir.Father != null)
                {
                    positionInFathersLivingChildern = livingHeir.Father.Children.Where(child => child.IsAlive).ToList().IndexOf(livingHeir) + 1;
                }
                if (livingHeir.Mother != null)
                {
                    positionInMothersLivingChildren = livingHeir.Mother.Children.Where(child => child.IsAlive).ToList().IndexOf(livingHeir) + 1;
                }
                if(positionInFathersLivingChildern <= Constants.NUMBER_OF_INDESPENSIBLE_HEIRS || positionInMothersLivingChildren <= Constants.NUMBER_OF_INDESPENSIBLE_HEIRS)
                {
                    indespensibleLivingHeirs.Add(livingHeir);
                }
            }
            return indespensibleLivingHeirs;
        }
        public List<Person> GetDispensibleMembers()
        {
            return Members.Except(GetIndespensibleMembers()).ToList();
        }
        public double Wealth { get; set; }
        public List<Town> GetTowns()
        {
            return World.Towns.Where(town => !town.Vacant && town.Lords.Last().House == this).ToList();
        }
        public void CollectTaxes()
        {
            //set tax year for tax collection
            var previousTaxYear = World.Year - 1;
            double houseIncome = 0; 

            //first collect assessed taxes from previous year from each town under house control
            var houseTowns = GetTowns();
            foreach(var houseTown in houseTowns)
            {
                var assessedTownIncome = houseTown.AssessedIncome.FirstOrDefault(income => income.Year == previousTaxYear);
                if (assessedTownIncome != null)
                {
                    //move ALL income from town wealth to house coffers (the house lord controls all wealth for the house)
                    houseTown.Wealth -= assessedTownIncome.Income;
                    houseIncome += assessedTownIncome.Income;
                }
            }
            //next collect assessed taxes from all vassle houses
            foreach(var vassle in Vassles)
            {
                var assessedVassleIncome = vassle.AssessedIncome.FirstOrDefault(income => income.Year == previousTaxYear);
                if (assessedVassleIncome !=null)
                {
                    //tax vassle income at tax rate
                    var tax = assessedVassleIncome.Income * Constants.MIN_TAX_RATE;
                    vassle.Wealth -= tax;
                    houseIncome += tax;
                }
            }
            //add income to wealth
            Wealth += houseIncome;
            //add assessment for taxes
            AssessedIncome.Add(new AssessedIncome() { Year = World.Year, Income = houseIncome });
        } 
        public List<AssessedIncome> AssessedIncome { get; set; }
    }
    public class Household
    {
        public Household()
        {
            Members = new List<Person>();
            Town = null;
            HouseholdClass = SocialClass.Peasant;
        }
        //The members of the family
        //public Person HouseFounder { get; set; }
        public Person HeadofHousehold { get; set; }
        public List<Person> Members { get; set; }
        //Where the family currently lives
        public Town Town {get; set;}
        public SocialClass HouseholdClass { get; set; }
        public void AddMember(Person newMember)
        {
            if (!Members.Contains(newMember)) { 
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
                if (Town != null) { 
                    Town.Households.Remove(this);
                    Town = null;
                }
            } else if (oldMember == HeadofHousehold)
            {
                //make eldest head of household
                HeadofHousehold = Members.OrderBy(x => x.Age).Last();
            }
        }
        public string GetDetailsAsString()
        {
            var retStr = "";
            retStr += "Class:" + HouseholdClass + "\n"
            + "Town: " + Town.Name + "\n"
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
                if (headOfHousehold.House.Name == "Stark") {
                    Console.WriteLine("MARRIAGE: " + headOfHousehold.FullNameAndAge + " MARRIED " + spouse.FullNameAndAge + " in " + headOfHousehold.World.Year);
                }
            } 
            //if headOfHousehold is already head then their house is the marriageHousehold
            if (headsOldHousehold!=null && headsOldHousehold.HeadofHousehold == headOfHousehold)
            {
                marriageHousehold = headOfHousehold.Household;
            } else
            {
                marriageHousehold = new Household()
                {
                    HeadofHousehold = headOfHousehold
                };
                if (headsOldHousehold != null) {
                    marriageHousehold.HouseholdClass = headsOldHousehold.HouseholdClass;
                    marriageHousehold.Town = headsOldHousehold.Town;
                }
            }
            marriageHousehold.AddMember(headOfHousehold);
            marriageHousehold.AddMember(spouse);
            headOfHousehold.House.AddMember(spouse);
            if (marriageHousehold.Town != null) { 
                marriageHousehold.Town.AddHousehold(marriageHousehold);
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
            TownLordships = new List<Town>();
            HouseLordships = new List<House>();
            Ancestors = new List<Person>();
        }
        public Guid Id { get; set; }
        public People People { get; set; }
        public World World { get; set; }
        public SocialClass Class { get; set; }
        public List<Person> Ancestors { get; set; }
        public House House {get;set;}
        //public int Year { get; set; }
        public Household Household { get; set; }
        public int BirthYear { get; set; }
        public Town BirthPlace { get; set; }
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
                if (this.TownLordships.Count > 0)
                {
                    if (Sex == Sex.Male)
                    {
                        fullNameAndAge += ", Lord of " + TownLordships[0].Name;
                    } else
                    {
                        fullNameAndAge += ", Lady of " + TownLordships[0].Name;
                    }
                    if (TownLordships.Count > 1)
                    {
                        for (int i = 1; i < TownLordships.Count(); i++)
                        {
                            if(i == TownLordships.Count - 1)
                            {
                                fullNameAndAge += ", and ";
                            } else
                            {
                                fullNameAndAge += ", ";
                            }
                            fullNameAndAge += TownLordships[i].Name;
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
                if (Household != null && Household.Town != null)
                {
                    fullNameAndAge += ", residing in " + Household.Town.Name;
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
                }
                // +/- 50%
                return Math.Round(income + (income * (_rnd.NextDouble() * 0.5) * _rnd.Next(-1, 2)),2);
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
                }
                return cost;
            }
        }
        public List<Town> TownLordships { get; set; }
        public List<House> HouseLordships { get; set; }
        public void IncrementYear()
        {
            if (IsAlive)
            {
                //Death Check
                if (_rnd.Next(1, 100) < Age && _rnd.Next(1, 100) < Age && _rnd.Next(1, 100) < Age && _rnd.Next(1, 100) < Age)
                {
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
                            BirthPlace = childsMother.Household.Town,
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
                        if ((newborn.Mother.TownLordships.Count()> 0 || newborn.Father.TownLordships.Count() > 0) && House.Name=="Stark")
                        {
                            Console.WriteLine("BIRTH: " + newborn.Name + " WAS BORN to " +  newborn.Mother.FullNameAndAge + " and " + newborn.Father.FullNameAndAge + " in " + World.Year);
                        }
                    }
                }
            }
        }
        public bool IsEligibleForMarriage()
        {
            return (
                IsAlive
                && (Spouse ==null || !Spouse.IsAlive)
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
                ancestors.AddRange(Father.GetAncestors(maxGenerations-1).Where(x =>!ancestors.Contains(x)));
            }
            if (maxGenerations > 0 && Mother != null)
            {
                ancestors.Add(Father);
                ancestors.AddRange(Mother.GetAncestors(maxGenerations-1).Where(x => !ancestors.Contains(x)));
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
            string retString= "";

            retString += "Name: " + FullNameAndAge + "\n";
            retString += "People: " + People + "\n";
            retString += "Class: " + Class + "\n";
            if (Spouse != null && Spouse.IsAlive)
            {
                retString += "Spouse: " + Spouse.FullNameAndAge + "\n";
            }
            if (Bethrothal != null) {
                retString += "Betrothal:\n"
                + "\tBetrothal Year:" + Bethrothal.Year + "\n"
                + "\tHead of Household to Be:" + Bethrothal.HeadOfHouseholdToBe.FullNameAndAge + "\n"
                + "\tSpouce to Be: " + Bethrothal.SpouseToBe.FullNameAndAge + "\n";
            }
            if (Children.Count() > 0)
            {
                retString += "Children:\n";
                foreach (var child in Children.OrderByDescending(c=>c.Age))
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
    public class Town
    {
        private Random _rnd;
        private int _maxYeild;
        public Town(Random rnd)
        {
            _rnd = rnd;
            Households = new List<Household>();
            Lords = new List<Person>();
            Wealth = 0;
            Surplus = 0;
            _maxYeild = _rnd.Next(Constants.MAX_YEILD_LOW, Constants.MAX_YEILD_HIGH);
            AssessedIncome = new List<AssessedIncome>();
            Vacant = true;
        }
        public World World { get; set; }
        public bool Vacant { get; set; }
        public int MapX { get; set; }
        public int MapY { get; set; }
        //public List<Town> Villages { get; set; }
        public int FoundingYear { get; set; }
        public String Name { get; set; }
        public List<Household> Households { get; set; }
        public List<AssessedIncome> AssessedIncome { get; set; }
        //public double Income { get; set; }
        public double Yeild { get; set; }
        public double Cost { get; set; }
        public double Surplus { get; set; }
        public double Wealth { get; set; }
        public void IncrementYear()
        {
            //lets fix this economy!
            
            if (Households.Count() > 0)
            {
                var villagers = new List<Person>();
                Households.ForEach(x => villagers.AddRange(x.Members));

                //4. Marry villagers! 
                var villagersInPrime = villagers.Where(x => x.IsAlive && x.Age >= 18 && x.Age < 50  && x.Household.HouseholdClass == SocialClass.Peasant).ToList();
                Person.CreateMarriages(villagersInPrime,_rnd);
                //5. Check for succession of Lord
                var incumbentLord = Lords.Last();
                if (!incumbentLord.IsAlive && !Vacant)
                {
                    //The lord is Dead!  Long live the lord!

                    if (incumbentLord.House.Name == "Stark")
                    {
                        Console.WriteLine("DEATH: " + incumbentLord.FullNameAndAge + " DIED in " + World.Year);
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
                        if (heir.House.Name == "Stark" || incumbentLord.House.Name == "Stark")
                        {
                            Console.WriteLine("INHERITANCE: " + heir.FullNameAndAge + " INHERITED the Lordship of " + Name + " in " + World.Year);
                            if (heir.House != incumbentLord.House)
                            {
                                Console.WriteLine("CHANGE OF HOUSE! " + Name + " passed from House " + incumbentLord.House.Name + " to " + heir.House.Name + " in " + World.Year);
                            }
                        }
                    }
                    else
                    {
                        Vacant = true;
                        if (incumbentLord.House.Name == "Stark")
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
                var thisYearsMaxYeild = Math.Round(_maxYeild + (_maxYeild * (_rnd.NextDouble() * 0.2) * _rnd.Next(-1, 2)),2);
                if (thisYearsMaxYeild < Yeild)
                {
                    Yeild = thisYearsMaxYeild;
                }
                //9. Add tax to income
                var income = Math.Round(Yeild * Constants.MIN_TAX_RATE,2);
                //10. Calculate surplus/deficit
                Surplus = Yeild - Cost - income;
                //11. Add surplus to income if positive
                if (Surplus > 0) { income += Surplus; }
                //12. Add Income to treasury
                Wealth += income;
                //Add income to assessedIncome (for tax to house)
                AssessedIncome.Add(new AssessedIncome() { Year = World.Year, Income = income });
                //13. If there is a deficit then villagers die :(
                if (Surplus < 0)
                {
                    var deficit = Surplus * -1;
                    if (Wealth < 0)
                    {
                        deficit += Wealth * -1;
                    }
                    while (deficit > 0)
                    {
                        if (villagers.Count() > 0) { 
                            //kill a random villager
                            var deadOne = villagers[_rnd.Next(0, villagers.Count())];
                            deadOne.IsAlive = false;
                            if (deadOne.Household != null)
                            {
                                deadOne.Household.RemoveMember(deadOne);
                            }
                            deficit -=
                                deadOne.Cost;
                        }
                    }
                }
                //Clear out any empty households
                Households.RemoveAll(x => x.Members.Count() == 0);
            }
        }
        public void AddHousehold(Household newHousehold)
        {
            if (!Households.Contains(newHousehold)){ 
                if (newHousehold.Town != null)
                {
                    newHousehold.Town.Households.Remove(newHousehold);
                    newHousehold.Town = null;
                }
                Households.Add(newHousehold);
                newHousehold.Town = this;
            }
        }
        public void Removehousehold(Household oldHousehold)
        {
            if (Households.Contains(oldHousehold))
            {
                oldHousehold.Town = null;
                Households.Remove(oldHousehold);
            }
        }
        public void AddLord(Person newLord)
        {
            if (!newLord.TownLordships.Contains(this))
            {
                newLord.TownLordships.Add(this);
            }
            Lords.Add(newLord);
        }
        public List<Town> GetAdjacentTowns()
        {
            return World.Towns.Where(v => v!=this && (Math.Abs(v.MapX - MapX) == 1 || v.MapX == MapX) && (Math.Abs(v.MapY - MapY) == 1 || v.MapY == MapY)).ToList();
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
            return successionList.Where(x=>x.IsAlive).Take(depth).ToList();
        }
        public string GetDetailsAsString()
        {
            var retString = "";
            retString+=("YEAR " + World.Year + '\n');
            retString+=("------------------------\n");
            retString+=("Town: " + Name + '\n');
            retString+=("Founding Year: " + FoundingYear + '\n');
            var incumentlord = Lords.Last();
            retString+=("Lord: " + incumentlord.FullNameAndAge + '\n');
            retString+=("Order of Succession:" + '\n');
            var orderOfSuccession = GetOrderOfSuccession(10);
            for (int i = 0; i < orderOfSuccession.Count(); i++)
            {
                retString+=((i + 1) + ": " + orderOfSuccession[i].FullNameAndAge + '\n');
            }
            var villagers = new List<Person>();
            Households.ForEach(v => villagers.AddRange(v.Members));
            retString+=("Noble Households:" + Households.Count(v => v.HouseholdClass == SocialClass.Noble) + '\n');
            retString+=("Peasant Households:" + Households.Count(v => v.HouseholdClass == SocialClass.Peasant) + '\n');
            retString+=("Population:" + villagers.Count() + '\n');
            retString+=("Seniors >= 50:" + villagers.Count(v => v.IsAlive && v.Age > 50) + '\n');
            retString+=("Children < 18: " + villagers.Count(v => v.IsAlive && v.Age < 18) + '\n');
            retString+=("Nobles: " + villagers.Count(v => v.Household.HouseholdClass == SocialClass.Noble && v.IsAlive) + '\n');
            retString+=("Peasants: " + villagers.Count(v => v.Household.HouseholdClass == SocialClass.Peasant && v.IsAlive) + '\n');
            retString+=("Yeild: " + Yeild + '\n');
            retString+=("Cost: " + Cost + '\n');
            retString+=("Surplus: " + Surplus + '\n');
            retString+=("Income: " + AssessedIncome.Last().Income.ToString("0.00") + '\n');
            retString+=("Wealth: " + Wealth + '\n');
            retString+=("------------------------" + '\n');
            return retString;
        }
        public static void PopulateTown (Town newVillage, Household lordsHouseHold, List<Household> peasantHouseholds)
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
            if (newLord.House.Name == "Stark")
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
        public static void HouseMoves(House house, Random rnd)
        {

            //colonize
            //determine potential settler households
            //find heads of households that don't hold a lordship and don't have any heirs from other houses

            var houseAndSubVassles = new List<House>();
            houseAndSubVassles.Add(house);
            houseAndSubVassles.AddRange(house.GetAllSubVassles());
            var houseTowns = house.World.Towns.Where(town => !town.Vacant && houseAndSubVassles.Contains(town.Lords.Last().House)).ToList();
            var potentialSettlerLords = house.Members.Where(x =>
                x.TownLordships.Count() == 0
                && x.Household != null
                && x.Household.HeadofHousehold == x
                && x.GetHeirs().Count(heir=>heir.House != house) == 0
                ).ToList();
            List<Town> unclaimedLands;
            if (potentialSettlerLords.Count() > 0)
            {
                //get potential settler peasants
                //get towns the house controls
                var potentialSettlerPeasantHouseholds = new List<Household>();
                unclaimedLands = GetUnclaimedLands(house);
                foreach (var houseTown in houseTowns)
                {
                    var peasantHouseholds = houseTown.Households.Where(x => x.HeadofHousehold.Class == SocialClass.Peasant).ToList();
                    while (peasantHouseholds.Count() > Constants.MINIMUM_VILLAGE_SIZE)
                    {
                        var potentialSettlerPeasantHousehold = peasantHouseholds.First();
                        potentialSettlerPeasantHouseholds.Add(potentialSettlerPeasantHousehold);
                        peasantHouseholds.Remove(potentialSettlerPeasantHousehold);
                    }
                }
                while (potentialSettlerLords.Count() > 0 && potentialSettlerPeasantHouseholds.Count() >= Constants.MINIMUM_VILLAGE_SIZE && unclaimedLands.Count > 0)
                {
                    var settlerTown = unclaimedLands[rnd.Next(0, unclaimedLands.Count())];
                    settlerTown.FoundingYear = house.World.Year;
                    unclaimedLands.Remove(settlerTown);
                    var settlerLord = potentialSettlerLords[rnd.Next(0, potentialSettlerLords.Count())];
                    potentialSettlerLords.Remove(settlerLord);
                    settlerTown.AddLord(settlerLord);
                    var settlerPeasantHouseholds = new List<Household>();
                    for (int i = 0; i < Constants.MINIMUM_VILLAGE_SIZE; i++)
                    {
                        var settlerPeasantHousehold = potentialSettlerPeasantHouseholds[rnd.Next(0, potentialSettlerPeasantHouseholds.Count())];
                        potentialSettlerPeasantHouseholds.Remove(settlerPeasantHousehold);
                        settlerPeasantHouseholds.Add(settlerPeasantHousehold);
                    }
                    Town.PopulateTown(settlerTown, settlerLord.Household, settlerPeasantHouseholds);
                }
            }

            //perform marriages
            //find good matches for 1st & 2nd children
            /* var eligibleLordsAndLikelyHeirs = new List<Person>();
            
            //first add house lord
            if (house.Lords.Last().IsEligableForBetrothal())
            {
                eligibleLordsAndLikelyHeirs.Add(house.Lords.Last());
            }
            //now add top 4 house heirs          
            var topHouseHeirs = house.GetOrderOfSuccession(4).Where(x => x.IsEligableForBetrothal() && x.House == house);
            //if any of the top heirs are betrothed out of the house, then cancel betrothal
            var topHouseHeirsAndTheirHeirs = new List<Person>();
            topHouseHeirsAndTheirHeirs.AddRange(topHouseHeirs);
            foreach (var heir in topHouseHeirs)
            {
                topHouseHeirsAndTheirHeirs.AddRange(heir.GetHeirs().Where(h => h.IsEligableForBetrothal() && !topHouseHeirsAndTheirHeirs.Contains(h)));
                if (heir.Bethrothal!=null && heir.Bethrothal.SpouseToBe == heir)
                {
                    Console.WriteLine("CANCELLED BETROTHAL of " + heir.Bethrothal.HeadOfHouseholdToBe.FullNameAndAge + " and " + heir.Bethrothal.SpouseToBe.FullNameAndAge + "\n");
                    heir.World.CancelBetrothal(heir.Bethrothal);
                }

            }
            eligibleLordsAndLikelyHeirs.AddRange(topHouseHeirs);
            */
            var indespensibleEligibleMembers = house.GetIndespensibleMembers().Where(x => x.IsEligableForBetrothal()).ToList();
            //advertise everyone else on the marriage market
            //var eligibleUnlikelyHeirs = house.Members.Where(x => x.IsEligableForBetrothal() && !eligibleLordsAndLikelyHeirs.Contains(x));
            //house.AvailableUnmarriedMembers = eligibleUnlikelyHeirs.ToList();
            //clean up list removing ineligable members
            //house.AvailableUnmarriedMembers.RemoveAll(x => !x.IsEligableForBetrothal());

            var potentialMatches = new List<Person>();
            foreach (var otherHouse in house.World.NobleHouses)
            {
                potentialMatches.AddRange(otherHouse.GetDispensibleMembers().Where(x=>x.IsEligableForBetrothal()));
            }
            //potentialMatches = potentialMatches.OrderByDescending(x => x.Age).ToList();
            var matchcount = 0;
            var unmatchedLordsAndHeirs = new List<Person>();
            while (indespensibleEligibleMembers.Count() > 0 && potentialMatches.Count() > 0)
            {
                var eligableLordOrHeir = indespensibleEligibleMembers.First();
                var matches = potentialMatches.Where(x => x.IsCompatibleForBetrothal(eligableLordOrHeir)).ToList();

                if (matches.Count() >0)
                {
                    //find match closest in age
                    matches = matches.OrderBy(m => Math.Abs(m.Age - eligableLordOrHeir.Age)).ToList();
                    var match = matches.First();
                    house.World.CreateBethrothal(eligableLordOrHeir, match, house.World.Year, true);
                    potentialMatches.Remove(match);
                    matchcount++;
                } else
                {
                    unmatchedLordsAndHeirs.Add(eligableLordOrHeir);
                }
                indespensibleEligibleMembers.Remove(eligableLordOrHeir);
            }
            
            if (unmatchedLordsAndHeirs.Count(x=>x.Age>5 && x.Age<25 && x.GetHeirs().Count == 0) > 0 && matchcount == 0)
            {
                //no heirs!  Try to invite a new house from the homeland!
                if (rnd.NextDouble() <= Constants.CHANCE_OF_RECRUITING_FOREIGN_HOUSE && house.Recruitments<Constants.MAX_RECRUITMENTS)
                {
                    unclaimedLands = GetUnclaimedLands(house);
                    if (unclaimedLands.Count() > 0)
                    {
                        var eldest = unmatchedLordsAndHeirs.Max(h => h.Age) + 5;
                        var newLand = unclaimedLands[rnd.Next(0, unclaimedLands.Count())];
                        var surnames = Constants.SURNAMES.Split(',');
                        var newHouseName = surnames[rnd.Next(0,surnames.Count())];
                        var newHouse = CreateNewHouse(newHouseName, (char)rnd.Next(33,126), house.Lords.Last().People, newLand, rnd, house,eldest);
                        var recruitingLord = house.Lords.Last();
                        var recruitedLord = newHouse.Lords.Last();
                        if (recruitingLord.House.Name == "Stark")
                        {
                            Console.WriteLine("RECRUITMENT: " + recruitingLord.FullNameAndAge + " RECRUITED " + recruitedLord.FullNameAndAge + " from the " + recruitingLord.People + " homeland.");
                        }
                        house.Recruitments++;
                    }
                }
            }

        }
        public static List<Town> GetUnclaimedLands(House house)
        {
            var unclaimedLands = new List<Town>();
            var houseAndSubVassles = new List<House>();
            houseAndSubVassles.Add(house);
            houseAndSubVassles.AddRange(house.GetAllSubVassles());
            var houseTowns = house.World.Towns.Where(town => !town.Vacant && houseAndSubVassles.Contains(town.Lords.Last().House)).ToList();
            foreach (var houseTown in houseTowns)
            {
                unclaimedLands.AddRange(houseTown.GetAdjacentTowns().Where(x => x.Vacant && !unclaimedLands.Contains(x)));
            }
            return unclaimedLands;
        }
        public static House CreateNewHouse(string name, char symbol, People people, Town town, Random rnd, House allegience = null, int eldest = 18)
        {
            var oldWorld = new World(rnd) { Year = town.World.Year - Constants.YEARS_TO_ITERATE_NEW_HOUSES };//town.World;
            var newWorld = town.World;
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
                for (int j = 18 - 5; j < (wife.Age - 17) && j <= 17; j++)
                {
                    var kid = new Person(rnd)
                    {
                        Age = j,
                        Mother = wife,
                        Father = husband,
                        Profession = Profession.Dependant,
                        Class = SocialClass.Peasant,
                        People = people,
                        BirthYear = oldWorld.Year - j
                    };
                    kid.Ancestors.Add(husband);
                    kid.Ancestors.Add(wife);
                    wife.Children.Add(kid);
                    husband.Children.Add(kid);
                    husband.House.AddMember(kid);
                    oldWorld.AddPerson(kid);
                }
                var settlerHousehold = Household.CreateMarriageHousehold(husband, wife);
                settlerHousehold.HouseholdClass = SocialClass.Peasant;
                firstSettlers.Add(settlerHousehold);
            }

            var lord = new Person(rnd)
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
            lord.House = new House() { Name = name, Symbol = symbol, Seat = town};
            lord.House.AddLord(lord);
            oldWorld.AddHouse(lord.House);
            var lordsHousehold = Household.CreateMarriageHousehold(lord, lady);
            lordsHousehold.HouseholdClass = SocialClass.Noble;
            for (var i = 0; i < Constants.YEARS_TO_ITERATE_NEW_HOUSES; i++)
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
                    } else
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
            if (allegience != null)
            {
                allegience.AddVassle(lord.House);
            }
            newWorld.AddHouse(lord.House);
            while (oldWorld.Population.Count() > 0)
            {
                newWorld.AddPerson(oldWorld.Population[0]);
            }
            Town.PopulateTown(town, lordsHousehold, firstSettlers);
            return lord.House;
        }
        public static void PerformNobleMarriages(World world)
        {
            var bethrothalsToCheck = new List<Bethrothal>();
            bethrothalsToCheck.AddRange(world.Bethrothals);
            while (bethrothalsToCheck.Count() > 0)
            {
                var betrothalToCheck = bethrothalsToCheck[0];
                if(betrothalToCheck.HeadOfHouseholdToBe.Age >= Constants.AGE_OF_MAJORITY && betrothalToCheck.SpouseToBe.Age >= Constants.AGE_OF_MAJORITY)
                {
                    Household.CreateMarriageHousehold(betrothalToCheck.HeadOfHouseholdToBe, betrothalToCheck.SpouseToBe, true);
                    world.CancelBetrothal(betrothalToCheck);
                }
                bethrothalsToCheck.Remove(betrothalToCheck);
            }
        }
        public static void InitializeWorld(World world, Random rnd)
        {
            var townNames = Constants.TOWN_NAMES.Split(',').ToList();
            for (var y = 1; y <= Constants.MAP_HEIGHT; y++)
            {
                for (var x = 1; x <= Constants.MAP_WIDTH; x++)
                {
                    var villageName = townNames[0];
                    world.AddTown(new Town(rnd) { Name = villageName, MapX = x, MapY = y });
                    townNames.Remove(villageName);
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
            var easternTowns = world.Towns.Where(x => x.Vacant && x.MapX == 1).ToList();
            var westernTowns = world.Towns.Where(x => x.Vacant && x.MapX == Constants.MAP_WIDTH).ToList();

            //create first dane house
            var daneTown = westernTowns[rnd.Next(0, westernTowns.Count())];
            daneTown.Name = "Winterfell";
            CreateNewHouse("Stark", '*', People.Dane, daneTown, rnd);
            //create first saxon house
            var saxonTown = easternTowns[rnd.Next(0, easternTowns.Count())];
            saxonTown.Name = "Casterly Rock";
            CreateNewHouse("Lannister", '$', People.Saxon, saxonTown, rnd);
            //for (int k = 0; k < houseNames.Count(); k++)
            //{
            //    var vacantVillages = world.Towns.Where(x => x.Vacant && (x.MapY == 1 || x.MapY == Constants.MAP_HEIGHT)).ToList();
            //    var firstVillage = vacantVillages[rnd.Next(0, vacantVillages.Count)];
            //    firstVillage.Name = houseSeats[k];
            //    CreateNewHouse(houseNames[k], houseSymbols[k], People.Saxon, firstVillage, rnd);
            //}
        }
        public static void Main(string[] args)
        {
            var rnd = new Random();
            var world = new World(rnd);
            InitializeWorld(world, rnd);
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
                            case "town":
                                {
                                    int x;
                                    int y;
                                    Town town;
                                    if (int.TryParse(command[1], out x) && int.TryParse(command[2], out y))
                                    {
                                        town = world.Towns.FirstOrDefault(t => t.MapX == x && t.MapY == y);
                                    } else
                                    {
                                        var townName = command[1];
                                        for (int i = 2; i < command.Length; i++)
                                        {
                                            townName += " " + command[i];
                                        }
                                        town = world.Towns.FirstOrDefault(t => t.Name.ToLower() == townName.ToLower());
                                    }
                                    Console.WriteLine(town.GetDetailsAsString());
                                }
                                break;
                            case "households":
                                {
                                    var x = int.Parse(command[1]);
                                    var y = int.Parse(command[2]);
                                    var town = world.Towns.FirstOrDefault(t => t.MapX == x && t.MapY == y);
                                    foreach(var household in town.Households)
                                    {
                                        Console.WriteLine(household.GetDetailsAsString());
                                    }
                                }
                                break;
                            case "house":
                                {
                                    var houseName = command[1];
                                    var house = world.NobleHouses.FirstOrDefault(h => h.Name.ToLower() == houseName.ToLower());
                                    if (house != null)
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
                        }
                    }
                }
                IncrementYear(world, rnd);
            }
            Console.ReadLine();
        }
    }
}
