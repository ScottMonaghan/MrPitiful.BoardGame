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
            "Recene,Wregan,Scur,Bealohydig,Paige,Gimm,Tamar,Nechtan,Sihtric,Bronson,Aldfrith,Ormod,Boniface,Gram,Earm,Irwyn,Ethelwulf,Alchfrith,Eamon,Earl,Gordie,Beowulf,Ord,Sherwin,Grimme,Aethelfrith,Jeffrey,Edward,Acennan,Tobrecan,Orvyn,Lin,Bryce,Felix,Snell,Courtland,Aethelbald,Earm,Rinc,Deman,Ethelbert,List,Agiefan,Cadwallon,Eldrid,Lynn,Shelley,Desmond,Geoff,Agilberht,Ancenned,Manton,Lyn,Beorn,Tracy,Agyfen,Offa,Egesa,Raedwald,Ine,Lynn,Scur,Edlin,Scead,Beadurinc,Putnam,Edgar,Baldlice,Abrecan,Arlice,Earle,Lyn,Bliss,Maccus,Edsel,Werian,Tracey,Germian,Caedwalla,Andsaca,Gordie,Broga,Treddian,Garrett,Cynric,Shelby,Beornwulf,Banan,Eldwin,Gareth,Alwin,Agyfen,Courtney,Stewart,Elmer,Kenway,Scrydan,Garberend,Banning,Sibley,Leof,Alwin,Raedwald,Pleoh,Eldwyn,Irwin,Shepard,Ruadson,Kim,Lufian,Wurt,Storm,Arlice,Ethelred,Pearce,Rinan,Eldwyn,Sherwin,Eadwyn,Beorn,Ethelbert,Beadurof,Sheply,Archard,Wallis,Fairfax,Sheply,Agiefan,Grimme,Selwin,Ahreddan,Eamon,Douglas,Govannon,Maccus,Wissian,Ethelbald,Geraint,Germian,Tedmund,Nodons,Seber,Cadman,Ord,Wright,Aethelbald,Ham,Woden,Shephard,Earle,Scowyrhta,Hererinc,Baldlice,Holt,Druce,Odi,Alden,Toland,Raedan,Lunden,Eadwyn,Edgar,Bordan,Aidan,Kent,Eddison,Brun,Athelstan,Bellinus,Feran,Isen,Wurt,Cynric,Wilbur,Verge,Bayen,Cyst,Camden,Theomund,Sheply,Andsaca,Earm,Andswarian,Ruadson,Atyhtan,Edwin,Aidan,Corey,Ealdian,Edred,Penda,Scand,Pleoh,Cerdic,Bowden,Kenway,Ceawlin,Roweson,Orlege,Caedwalla,Eldred,Seaver,Temman,Aldred,Ethelred,Brice,Stillman,Brecc,Shelby,Ealdian,Wright,Ine,Sceotend,Ruadson,Courtney,Birdoswald,Grendel,Hlaford,Penda,Tilian,Grendel,Anson,Hilderinc,Seaver,Ecgfrith,Courtland,Selwyn,Wann,Cynewulf,Algar,Ody,Bearn,Ethelwulf,Row,Leanian,Cnut,Anson,Devyn,Oswiu,Athelstan,Scand,Scowyrhta,Linn,Ware,Bronson,Drew,List,Benoic,Bronson,Sheldon,Seaver,Erian,Eldwin,Geoff,Wyman,Odel,Piers,Beornwulf,Devyn,Durwin,Wilbur,Audley,Selwyn,Aldred,Wallace,Cynegils,Faran,Denby,Larcwide,Ine,Acwellen,Albinus,Ceolfrith,Ealdian,Cyst,Tolan,Isen,Kent,Eadgard,Wregan,Bowden,Alden,Rinan,Stilwell,Cynegils,Aldfrith,Rinc,Maxwell,Andweard,Lange,Dalston,Rinan,Iden,Wulf,Agyfen,Awiergan,Courtland,Wyman,Aethelwulf,Tredan,Andswaru,Ro,Torhte,Birdoswald,Acey,Kenway,Durwin,Halwende,Awiergan,Tedman,Dreng,Tedman,Raedan,Atol,Awiergan,Arlys,Edwy,Erian,Anhaga,Geoff,Arlyss,Anson,Douglas,Godric,Werian,Boniface,Devyn,Penrith,Rawlins,Rodor,Woden,Aldwyn,Oswy,Tobrecan,Boden,Beowulf,Trace,Worthington,Arian,Rodor,Anfeald,Grindan,Alden,Scead,Gifre,Wright,Garrett,Wade,Govannon,Newton,Seber,Avery,Aethelbert,Alwalda,Caflice,Slecg,Aethelbald,Shelby,Grindan,Earm,Renweard,Raedwald,Cedd,Albinus,Astyrian,Paige,Stearc,Godric,Wissian,Rowe,Ahreddan,Gareth,Odel,Ellen,Beorn,Boniface,Betlic,Merton,Gildas,Deman,Trymian,Sihtric,Ahebban,Geoff,Gordie,Archibald,Douglas,Sheply,Iuwine,Stillman,Gordon,Aethelbald,Jeffrey,Archard,Wine,Shepard,Hlaford,Aldin,Oswald,Penrith,Agiefan,Leng,Orvin,Gildas,Adamnan,Slecg,Rheged,Lin,Byrtwold,Anfeald,Wallis,Holt,Attor,Steadman,Larcwide,Rodor,Kent,Halwende,Egesa,Gimm,Synn,Waelfwulf,Abeodan,Waelfwulf,Grahem,Page,Tedmund,Bordan,Arlys,Oxa,Firman,Ware,Barclay,Wyne,Arth,Edlin,Grimm,Mann,Drefan,Aldfrith,Desmond,Arlyss,Earh,Cyst,Sever,Kent,Rinc,Grindan,Wright,Norville,Bede,Bealohydig,Ablendan,Anhaga,Grindan,Finan,Seamere,Modig,Theomund,Benoic,Erian,Ord,Cnut,Wallis,Bowden,Alchfrith,Dalston,Norvel,Feran,Lufian,Temman,Erconberht,Odon,Kenway,Torhte,Gram,Anwealda,Sheply,Warian,Upton,Hengist,Birdoswald,Sherwyn,Wirt,Camden,Cynric,Ancenned,Eldwyn,Kim,Edmond,Andettan,Winchell,Dreng,Atelic,Grimbold,Lin,Torht,Bliss,Rodor,Agilberht,Snell,Andwyrdan,Ryce,Anna,Hlisa,Shephard,Andsaca,Fraomar,Scead,Grahem,Rowe,Firman,Kimball,Ruadson,Erian,Bar,Mann,Wilfrid,Tellan,Sar,Ahreddan,Eddison,Tolan,Fleming,Odell,Aart,Eadig,Kenric,Ormod,Fleming,Lange,Atelic,Beircheart,Wallis,Trymman,Nerian,Seaver,Winchell,Leng,Aglaeca,Wilbur,Fairfax,Stewart,Offa,Wilbur,Kent,Beadurof,Edlin,Edsel,Archard,Edric,Eldrid,Rinc,Temman,Gifre,Edgard,Acey,Slecg,Feran,Andwyrdan,Aglaeca,Nyle,Colby,Lidmann,Roweson,Aart,Aethelstan,Cynegils,Oswiu,Beadurof,Albinus,Boden,Sceadu,Orvin,Andswarian,Edmund,Lyn,Corey,Caedmon,Stewart,Roe,Sherwyn,Boden,Strang,Worthington,Denisc,Tedman,Isen,Kendrick,Sherard,Storm,Stefn,Tolan,Ruadson,Stedman,List,Nechtan,Lar,Offa,Norvel,Garberend,Arth,Gareth,Tobrytan,Caedmon,Garberend,Seaton,Selwin,Avery,Attor,Banan,Fairfax,Freeman,Lucan,Roweson,Ord,Camdene,Wylie,Eddison,Benoic,Earm,Garr,Finan,Freeman,Lang,Arlys,Bordan,Lar,Bealohydig,Stepan,Seward,Ace,Leng,Durwin,Broga,Toland,Bealohydig,Aethelfrith,Edson,Ethelred,Waelfwulf,Werian,Stewart,Aethelwulf,Alger,Ham,Tracy,Galan,Yrre,Garr,Erconberht,Tracy,Aethelred,Hrypa,Larcwide,Verge,Derian,Seward,Anfeald,Norvel,Ethelbert,Arlys,Andswarian,Byrtwold,Oxa,Ine,Brun,Snell,Iden,Bayen,Shelley,Earle,Stuart,Abrecan,Earm,Nerian,Rinan,Egbert,Linn,Cynewulf,Nyle,Ahreddan,Willan,Ham,Raedbora,Edwy,Cerdic,Aheawan,Archard,Aethelred,Orlege,Earm,Cerdic,Wilfrid,Rodor,Pierce,Pleoh,Edwin,Wissian,Rowson,Iuwine,Amaethon,Raedwald,Teon,Ordway,Byrtwold,Seaton,Teon,Halwende,Grahem,Broga,Tamar,Cadman,Slecg,Nerian,Beowulf,Upton,Teon,Acennan,Odell,Denby,Besyrwan,Edlin,Octha,Synn,Piers,Fyren,Lange,Scand,Row,Tolan,Aldwyn,Camdene,Eldwyn,Willan,Nyle,Awiergan,Gaderian,Kendryck,Cyneric,Wann,Cynegils,Bar,Archibald,Abrecan,Wulfgar,Nodons,Bede,Arth,Chad,Ody,Ethelbert,Elmer,Fugol,Baldlice,Ethelred,Eldwin,Manton,Edgard,Wellington,Ormod,Tedmund,Cynewulf,Gimm,Ody,Boden,Brun,Wright,Wann,Banan,Acennan,Birdoswald,Berkeley,Aethelhere,Grahem,Durwin,Raedan,Audley,Feran,Norton,Eadig,Hlaford,Putnam,Benwick,Chapman,Paige,Norton,Beadurinc,Tolan,Daegal,Bliss,Irwyn,Firman,Selwin,Aethelhere,Brogan,Alwalda,Perry,Aethelbert,Graeme,Trymian,Faran,Nyle,Bealohydig,Yrre,Chapman,Rypan,Anbidian,Hrypa,Maponus,Winter,Ham,Stefn,Ethelbald,Treddian,Perry,Birdoswald,Aethelbald,Nodons,Sever,Aethelbald,Nyle,Swift,Dalston,Teon,Toland,Synn,Tobrecan,Kent,Brogan,Cadman,Sherwyn,Ceawlin,Hrypa,Offa,Ormod,Sheply,Cyneric,Octha,Sever,Edwy,Gimm,Wulfgar,Byrtwold,Aglaeca,Geoffrey,Alwalda,Archard,Aethelfrith,Swithun,Germian,Boyden,Aidan,Bestandan,Aidan,Eldred,Bana,Swift,Daegal,Devyn,Bron,Birdoswald,Roe,Iuwine,Beadurof,Edgar,Fairfax,Bowdyn,Firman,Gildas,Wissian,Rodor,Kendryck,Eldwyn,Agyfen,Denby,Gar,Andwearde,Edsel,Ane,Aethelhere,Woden,Aethelbald,Octha,Brogan,Cyneric,Tredan,Tredan,Beorn,Acennan,Bowdyn,Oswald,Bana,Beornwulf,Courtnay,Wann,Andweard,Eorl,Tellan,Archibald,Trace,Tedman,Grimme,Grendel,Denby,Wilbur,Druce,Scead,Sherwin,Trace,Alger,Irwin,Courtland,Seward,Cedd,Heolstor,Earl,Andweard,Fleming,Grendel,Anfeald,Rice,Garberend,Farmon,Bawdewyn,Wallis,Grendel,Drefan,Druce,Awiergan,Baldlice,Aldwyn,Graham,Torht,Rinc,Elmer,Roweson,Halig,Aldin,Wyman,Wulfhere,Devon,Orvin,Norton,Woden,Mann,Edgar,Prasutagus,Avery,Seaver,Attor,Wissian,Andweard,Earle,Fairfax,Graeme,Raedwald,Cenwalh,Winchell,Andweard,Synn,Ator,Rheged,Wallace,Godric,Row,Geraint,Almund,Ann,Bertie,Woden,Norville,Aethelbald,Aldhelm,Rypan,Bealohydig,Anfeald,Bellinus,Shepard,Egbert,Alwin,Wissian,Edwy,Aethelhere,Nechtan,Norvel,Baecere,Lucan,Ine,Snell,Odon,Grimbold,Oswiu,Edwin,Acwel,Octa,Aglaeca,Snell,Camden,Eldred";
        public const string FEMALE_NAMES =
            "Viradecthis,Rheda,Whitney,Bodicea,Tate,Daryl,Ora,Silver,Hilda,Cyst,Engel,Nelda,Edith,Meghan,Bliss,Alodie,Etheswitha,Loretta,Eldrida,Edrys,Viradecthis,Moira,Ifield,Hamia,Chelsea,Beornia,Anlicnes,Juliana,Elga,Kendra,May,Garmangabis,Darel,Aethelflaed,Blythe,Eldrida,Bernia,Annis,Lyn,Daisy,Udele,Udele,Bliss,Megan,Eldrida,Darel,Anlicnes,Darlene,Arianrod,Moira,Dawn,Edrys,Eda,Odelia,Ellenweorc,Lora,Cwen,Darline,May,Nerthus,Sulis,Edlyn,Osberga,Elga,Elvina,Esma,Bisgu,Freya,Kendra,Tate,Aefentid,Estra,Don,Estra,Sibley,Kendra,Cartimandua,Silver,Ora,Diera,Mildred,Maida,Aethelthryth,Don,Rheda,Darelle,Mildred,Silver,Blythe,Bletsung,Odelia,Megan,Edrys,Cwen,Edris,Daisy,Brigantia,Engel,Lora,Wilona,Etheswitha,Wilona,Elvina,Diera,Juliana,Willa,Anlicnes,Aefentid,Andsware,Chelsea,Bernia,Eadgyth,Kendra,Alodie,Darline,Daryl,Orva,Andsware,Alodie,Don,Odelia,Diera,Mercia,Ashley,Claennis,Ellette,Cyst,Nelda,Cearo,Elswyth,Rowena,Cartimandua,Loretta,Elga,Freya,Alodie,Hilda,Sibley,Aethelflaed,Loretta,Catherine,Ifield,Ora,Dohtor,Aefre,Bletsung,Ellenweorc,Wilda,Aethelflaed,Maida,Anlicnes,Alodie,Elswyth,Linette,Silver,Kendra,Bliss,Ashley,Ifield,Maida,Juliana,Cearo,Harimilla,Bysen,Loretta,Freya,Edrys,Annis,Linette,Bearrocscir,Edmunda,Mae,Darlene,Mercia,Elene,Bodicea,Daisy,Ellette,Estra,Elga,Darel,Bliss,Darelle,Edrys,Ellette,Etheswitha,Garmangabis,Maida,Daedbot,May,Wilona,Elva,Edlyn,Brigantia,Brimlad,Sibley,Maida,Easter,Lyn,Ellenweorc,Megan,Mildred,Meghan,Anlicnes,Darelene,Ifield,Elvina,Bodicea,Odelia,Chelsea,Harimilla,Lyn,Bysen,Easter,Annis,Loretta,Wilona,Edlyn,Darel,Garmangabis,Viradecthis,Darel,Whitney,Etheswitha,Bodicea,Bernia,Cwen,Lyn,Maida,Aefre,Kendra,Don,Willa,Eacnung,Darelle,Eda,Cartimandua,Aethelthryth,Kendra,Coventina,Silver,Odelia,Sibley,Erlina,Dohtor,Hilda,Hamia,Moira,Estra,Hilda,Arianrod,Bletsung,Darline,Daryl,Lora,Edrys,Kendra,Kendra,Ashley,Easter,Coventina,Udele,Aefre,Eda,Harimilla,Daisy,Dawn,Darel,Mae,Aefentid,Cyst,Orva,Darel,Claennis,Alodie,Elene,Mercia,Coventina,Darel,Ar,Silver,Sibley,Elene,Mae,Megan,Cwen,Devona,Aefentid,Daryl,Estra,Loretta,Coventina,Don,Osberga,Odelia,Linette,Blythe,Edmunda,Daisy,Claennis,Bliss,May,Elvina,Arianrod,Sunniva,Whitney,Tate,Cyst,Mae,Esma,Bletsung,Nerthus,Megan,Silver,Ellette,Lora,Devona,Nerthus,Edris,Edmunda,Edith,Cyst,Coventina,Sulis,Aedre,Chelsea,Ashley,Daedbot,Elga,Hamia,Mercia,Edlyn,Audrey,Wilona,Ar,Aedre,Elene,Bletsung,Aethelthryth,Cyst,Estra,Ardith,Osberga,Orva,Don,Elvina,Cwen,Ar,Lora,Elga,Mildred,Mae,Bysen,Viradecthis,Engel,Odelia,Easter,Claennis,Aethelthryth,Elva,Edrys,Silver,Beornia,Blythe,Easter,Alodia,Bletsung,Loretta,Nerthus,Elvina,Esma,Udele,Elvina,Osberga,Rheda,Hamia,Lyn,Megan,Kendra,Cyst,Brigantia,Edlyn,Clover,Dawn,Orva,Cyst,Darelene,Claennis,Elva,Eadgyth,Lyn,Edmunda,Catherine,Coventina,Claennis,Bearrocscir,Aefentid,Mercia,Sibley,Beornia,Edmunda,Bliss,Lyn,Mercia,Harimilla,Aedre,Odelia,Cartimandua,Daryl,Rowena,Edith,Mildred,Shelley,Elene,Claennis,Eadgyth,Kendra,Claennis,Sunniva,Bisgu,Erlina,Hamia,Edith,Eadgyth,Ellette,Erlina,Cwen,Chelsea,Moira,Elswyth,Darelle,Orva,Aedre,Lora,Daisy,Elene,Edris,Rheda,Udele,Bernia,Mae,Estra,Bearrocscir,Cearo,Elswyth,Rowena,Edlyn,Elene,Erlina,Kendra,Eda,Sunniva,Megan,Claennis,Cartimandua,Eacnung,Edmunda,Engel,Chelsea,Bernia,Daisy,Bearrocscir,Sibley,Estra,Aefre,Wilda,Don,Arianrod,Elga,Eldrida,Nelda,Megan,Brigantia,Tate,Rheda,Chelsea,Whitney,Ifield,Elga,Nerthus,Meghan,Erlina,Harimilla,Elga,Beornia,Estra,Beornia,Viradecthis,Easter,Mae,Darlene,Alodie,Bearrocscir,Osberga,Eostre,Viradecthis,Silver,Eldrida,Darelene,Bletsung,Clover,Edith,Ardith,Don,Eostre,Darline,Aefentid,Eostre,Eostre,Kendra,Elvina,Orva,Maida,Mildred,Ashley,Eldrida,Eldrida,Edmunda,Meghan,Ifield,Cearo,Devona,Elvina,Ellenweorc,Estra,Audrey,Eacnung,Garmangabis,Esma,Ashley,Ardith,Brimlad,Aedre,Eadgyth,Wilda,Brigantia,Lyn,May,Ar,Chelsea,Claennis,Darelene,Whitney,Edith,Daisy,Eacnung,Sulis,Eadgyth,Bodicea,Shelley,Aethelflaed,Aefentid,Tate,Loretta,Sulis,Mercia,Edmunda,Darlene,Elene,Eda,Brigantia,Udele,Diera,Sunniva,Aedre,Claennis,Dawn,Bisgu,Bliss,Andsware,Esma,Audrey,Engel,Hamia,Brimlad,Cartimandua,Daryl,May,Osberga,Loretta,Alodia,Udele,Don,Garmangabis,Maida,Orva,May,Ora,Don,Acca,Viradecthis,Wilona,Bearrocscir,Wilona,Eacnung,Ifield,Garmangabis,Viradecthis,Wilona,Darelene,Eostre,Hilda,Lyn,Darelene,Darelle,Rheda,Osberga,Ellette,Tate,Aedre,Elvina,Bisgu,Blythe,Don,Viradecthis,Moira,Easter,Bletsung,Freya,Odelia,Willa,Ora,Linette,Brigantia,Aethelthryth,Daedbot,Alodia,Harimilla,Dohtor,Darel,Brimlad,Daisy,Alodie,Elva,Osberga,Edrys,Eda,Acca,Alodia,Sunniva,Eostre,Ashley,Engel,Arianrod,Elvina,Aefentid,Cwen,Annis,Devona,Nerthus,Juliana,Esma,Anlicnes,Aefre,Catherine,Lora,Bliss,Freya,Silver,Coventina,Aefre,Alodie,Daryl,Clover,Elvina,Aethelthryth,Andsware,Estra,Alodia,Sunniva,Hilda,Shelley,Darelle,Daryl,Elvina,Elva,Ellenweorc,Garmangabis,Bletsung,Audrey,Garmangabis,Ellenweorc,Bletsung,Sulis,Mae,Hilda,Moira,Ellenweorc,Bearrocscir,Andsware,Dawn,Mercia,Freya,Arianrod,Darlene,Darel,Acca,Eacnung,Rowena,Bernia,Brigantia,Elswyth,Willa,Darlene,Aefentid,Edith,Ardith,Claennis,Freya,Edmunda,Erlina,Coventina,Daisy,Darelene,Dohtor,Freya,Ellette,Aethelflaed,Mildred,Acca,Cearo,Lyn,Esma,Linette,Dawn,Dohtor,Bernia,Sulis,Darlene,Bernia,Shelley,Ar,Ar,Edlyn,Hilda,Garmangabis,Edith,Rowena,Alodia,Loretta,Bletsung,Mercia,Estra,Elswyth,Maida,Elene,Aefentid,Beornia,Diera,Arianrod,Bodicea,Dawn,Udele,Shelley,Diera,Engel,Aedre,Alodia,Ifield,Eda,Elvina,Megan,Garmangabis,May,Engel,Elvina,Linette,Cyst,Sibley,Wilda,Eacnung,Clover,Aedre,Wilona,Ellenweorc,Elvina,Lyn,Aedre,Easter,Nerthus,Esma,Beornia,Audrey,Elene,Edmunda,Viradecthis,Elga,Odelia,Meghan,Edith,Juliana,Aethelthryth,Clover,Sibley,Alodia,Aethelflaed,Odelia,Whitney,Aethelflaed,Bearrocscir,Blythe,Viradecthis,Clover,Mae,Ardith,Clover,Bernia,Viradecthis,Meghan,Rheda,Dawn,Maida,Catherine,Andsware,Nerthus,Eda,Whitney,Eacnung,Esma,Aefre,Anlicnes,Wilona,Andsware,Annis,Bletsung,Linette,Eadignes,Erlina,Bysen,Megan,Aedre,Udele,Daedbot,Bearrocscir,Edrys,Viradecthis,Shelley,Whitney,Rheda,Chelsea,Loretta,Orva,Ellenweorc,Daryl,Darlene,Chelsea,Ar,Chelsea,Elga,Ashley,Ellette,Dawn,Willa,Nelda,Catherine,Alodia,Juliana,Loretta,Erlina,Ar,Chelsea,Esma,Aefre,Wilona,Claennis,Diera,Bisgu,Elva,Osberga,Rowena,Don,Edmunda,Elvina,Ar,Silver,Nelda,Daryl,Mildred,Cearo,Bearrocscir,Cwen,Willa,Cartimandua,Rheda,Bernia,Aefentid,Elva,Tate,Edlyn,Edlyn,Lora,Viradecthis,Bysen,Bisgu,Bearrocscir,Lyn,Engel,Daryl,Orva,Mildred,Ifield,Brimlad,Harimilla,Andsware,Mae,Viradecthis,Darelene,Acca,Rowena,Loretta,Juliana,Darel,Sunniva,Tate,Willa,Lora,Darel,Osberga,Etheswitha,Lora,Sulis,Elga,Clover,Aethelthryth,Dawn,Bearrocscir,Mercia,Bodicea,Ora,Eostre,Alodie,Chelsea,Acca,Willa,Whitney,Ellette,Willa,Elga,Freya,Bisgu,Freya,Arianrod,Wilda,Elvina,Bysen,Brimlad,Megan,Andsware,Ashley,Aethelflaed,Ora,Cyst,Eostre,Nelda,Chelsea,Linette,Arianrod,Audrey,Hilda,Bernia,Eda,Acca,Odelia,Edith,Meghan,Bernia,Coventina,Bisgu,Darlene,Edrys,Chelsea,Eadgyth,Sulis,Bernia,Anlicnes,Acca,Meghan,Edrys,Beornia,Dohtor,Anlicnes,Cyst,Esma,Daisy,Daedbot,Tate,Sulis,Elva,Dawn,Diera,Eda,Elvina,Moira,Megan,Garmangabis,Cearo,Ardith,Chelsea,Cwen,Linette";
        public const double NOBLE_COST = 10;
        public const double NOBLE_INCOME = 0;
        public const double SOLDIER_RATIO = 0.1;
        public const double MIN_TAX_RATE = 0.1;
        public const int MAX_YEILD_HIGH = 10000;
        public const int MAX_YEILD_LOW = 5000;
        public const string VILLAGE_NAMES = "Doddingtree,Winstree,Pershore,Uggescombe,Merton,Kerswell,Bountisborough,Patton,Bowcombe,Gartree,Hormer,Wotton,Spelhoe,Chilford,Arringford,Bibury,Amesbury,Blackwell,Calcewath,Ainsty,Cleyley,Land of Count Alan,Boldre,Redbridge,Navisford,Leintwardine,Acklam,Langbaurgh,Wittery,Agbrigg,Osgodcross,Walsham,Freebridge,[South] Greenhoe,Loningborough,Warmundestrou,Ailwood,Babergh,Condover,Bagstone,Baschurch,Cuttlestone,Grimboldestou,Pirehill,Horethorne,Rushcliffe,Bloxham,Hodnet,Dolesfield,Burghshire,Craven,Ixhill,Mow,Larkfield,Navisland,Wallington,Candleshoe,Skyrack,Beltisloe,Eastry,Salmonsbury,Staincross,Hamestan,Celfledetorn,North Petherton,Foxley,Lewknor,Strafforth,Witheridge,Langport,Bere[Regis],Offlow,Street,Amounderness,Sneculfcros,Elsdon,Tremlowe,Upton,Allerton,[West] Derby,Barkston,Corringham,Threo,Cannington,Dic,Lawress,Merset,Stotfold,Claydon,Lothingland,Leominster,Reweset,Wrockwardine,Alnodestreu,Earsham,Edwinstree,Thame,Blackheath,South Erpingham,Stradel,Rotherfield,Wandelmestrei,Lodding,Carhampton,Leightonstone,North Erpingham,Selkley,Holderness[Middle Hundred],Tring,Plomesgate,Clavering,St Albans,Danish,Alderbury,Hinckford,Reading,Frustfield,Tewkesbury,Wilford,Dunley,Ongar,Bircholt,Lexden,Cosford,Boxgrove,Eyhorne,Fishborough,Culvestan,Ruloe,Bishop's,Aldrington,Bulford,Hartcliffe,Huxloe,Nakedthorn,Gallow,Sandford,Blachethorna,Williton,Scarsdale,Kirton,Whitstone,Manley,Blachelaue,Berkeley,Appletree,Bledisloe,Silverton,South Molton,Somerton,Pocklington,Bempstone,Morley,Litchurch,Goscote,Exestan,Goderthorn,Mansbridge,Winnibriggs,Barcombe,Studfold,Diptford,Chillington,Hartland,Broadwater,Fernecumbe,Carlford,Blything,Wonford,Henstead,Rushton,Axminster,Tendring,Fawley,Tunendune,Middlewich,Hamston,Coleshill,Colnes,Oswaldslow,Huntspill,Totmonslow,Nobottle,Epworth,Neatham,Stretford,Swanborough,Cerne, Totcombe and Modbury,Stratton,Came,Seisdon,Fremington,Meonstoke,Lydney,Connerton,Newark,Bampton,Langley,Pathlow,Bradford,Louthesk,Bromsash,Normancross,Black Torrington,Thurgarton,Uttlesford,Tornelaus,Easwrithe,Headington,Burnham,Maneshou,Gersdones,Andover,Redbornstoke,Thedwastre,Hertford,Glastonbury,Holderness[South Hundred],Risberg,Hessle,Welford,Broxtowe,Steyning,Bumbelowe,Dunworth,Rillaton,Flaxwell,Hoddington,Willybrook,Portsdown,Wraggoe,Forehoe,Walecros,Halberton,North Tawton,Blackbourne,Sutton,Marcham,Bucklow,Bewsbury,Milverton,Elmbridge,Odsey,Yarlestre,Wantage,Kirtlington,Torbar,Hunesberi,Clifton,Shirwell,Polebrook,Guthlaxton,Holderness[North Hundred],Rowditch,Faversham,Tybesta,Wetherley,Rothwell,Binsted,Shipton,Bolingbroke,Braunton,Pimperne,Axton,Loose,Alleriga,Kingsbury West,Bosmere,Foxearle,Teignbridge,Hildslow,Shropham,West Flegg,Wymersley,Guilsborough,Haverstoe,Hamfordshoe,Hill,Gravesend,Horncastle,Cliston,Exminster,Winterstoke,Whitley,Freshwell,Overton,Archenfield,Wibrihtesherne,Ashendon,Wye,Blackburn,Longbridge,Spelthorne,Wayland,Abdick,Rochford,Stone,Lifton,Cheveley,Cicementone,Stoke,Cranborne,Stoneleigh,Radlow,Copthorne,Whorwellsdown,Pucklechurch,Heytesbury,Cricklade,Tibblestone,Salford,Alstoe[South],Kilmersdon,Eggardon,Bassetlaw,Aveland,Depwade,Bingham,Hartismere,Manshead,Howden,Towcester,Ati's Cross,Hezetre,Cottesloe,Wacrescumbe,Aylesbury,Yardley,Warden,Wootton,Greston,Blewbury,Alboldstow,Biggleswade,Moulsoe,Ash,Aswardhurn,Puddletown,Whitchurch[Canonicorum],Taverham,Graffoe,Hunthow,Yarborough,Cave,Brentry,Fawton,Chafford,Plegelgete,Longtree,Lythe,Kintbury,Shirley,Somborne,Hemyock,Axmouth,Budleigh,Bradley,Plympton,Tunstead,Thornhill,Chelmsford,Binfield,Dudstone,Crondall,Staploe,Risbridge,Taunton,Wimundestreu,Cirencester,Thatcham,Brothercross,Driffield,Holt,Brixton,Thunderlow,Falmer,Radfield,Banbury,Guiltcross,Witley,Ness,Alwardsley,Barcheston,Gainfield,Downton,Barford,Cadworth,Barham,Framland,Charldon,Ruston,Becontree,Rotherbridge,Rinlau,Maidstone,Lothing,[North] Greenhoe,Willaston,Dunmow,South Petherton,Barrington,Thingoe,Witchley,Wangford,Barstable,Greytree,Odiham,Dinedor,Clackclose,Rowley,Flitton,Lackford,Swineshead,Barton,Docking,Edgegate,Slotisford,Basingstoke,Mitford,Staple,Bath,Branchbury,Hailesaltede,Conditre,Eynesford,Holford,Beaminster,Felborough,Cornilo,Willingdon,Bromley,Shrivenham,Oswaldbeck,Frome,Shamwell,Totnore,Fordingbridge,Buckelowe,Kinwardstone,Burghbeach,Rowbury,Colyton,Wichestanestou,Laundich,Bridge,Clent,Heane,Rolvenden,Keynsham,Hitchin,Wyndham,Loveden,Benson,Twyford,Bentley,Broughton,Welton,Witham,Marton,Easebourne,Roborough,Streat,Winfrith[Newburgh],Duddeston,Eastbourne,Kingsbridge,Parham,Bexhill,Helmestrei,Dorchester,Westbury,Chippenham,Chuteley,Bury,Langoe,Stanbridge,Newchurch,Walshcroft,Cullifordtree,Singleton,Burton,Droxford,Wittering,Scard,Beynhurst,Ossulstone,Stepleset,Tintinhull,Flexborough,Warminster,Bisley,Ringwood,Overs,Hasler,Worth,Combsditch,Thurstable,Corby,Andersfield,Whitstable,Tandridge,Risborough,Collingtree,Blofield,Scipa,Hurstingstone,Aslacoe,Stowting,Lambourn,Winnianton,Rialton,Tiverton,Stodden,Effingham,Boothby,Rochester,Bosham,Staine,Toseland,Boughton,Botloe,Longstowe,Deerhurst,Pevensey,Papworth,Higham,Humbleyard,Desborough,Startley,Sherborne,Morleystone,Mere,Seckley,Fexhole,East Grinstead,Ashley,Well,Hallikeld,Holdshott,Westerham,Wincanton,Braughing,Bray,Aloesbridge,Diss,Bruton,Welesmere,Rapsgate,Cutestornes,Cresslow,Cawdon,Mawsley,Brightford,Cheltenham,Thriplow,Fleamdyke,Bosbarrow,Knowlton,Calne,Orlingbury,Avronhelle,Titchfield,Happing,Grimshoe,Reigate,Buckland[Newton],Bucklebury,Edivestone,Henhurst,Romney Marsh,Woking,Weighton,Wyfold,Wolmersty,Stowmarket,Godley,Castlery,Edlogan,Is Coed,East Flegg,Calbourne,Cambridge,Chewton,Wellow,Mainsborough,Bermondspit,Cogdean,[Bishops] Cannings,Canterbury,Willey,Ninfield,Brunsell,Eagle,Stowford,Chalton,Charborough,Kingsbury Episcopi,Calehill,Greenwich,Chart,Chatham,Ely 1,Langtree,Tollerford,Hilton,Kingston,Chester,Chesterton,Rowborough,Chew,Stockbridge,Buddlesgate,Falemere,Waltham,Houndsborough,Elstub,Chislet,Dumpford,Portbury,Waddesdon,Buttinghill,Kingsclere,Evingar,Ripplesmere,York,Yetminster,Kiftsgate,[Sturminster] Newton,Colchester,Highworth,Elthorne,Brightwells Barrow,Hurstbourne,Thorngrove,Godalming,Ghidenetroi,Sixpenny,Baldslow,Toreshou,Alstoe[North],Ludborough,Micheldever,Litlelee,Crediton,Crewkerne,Badbury,Wolfhay,Elloe,North Curry,Welsh District,Warter,Damerham,Wormelow,Eddredestane,Ely 2,Mursley,Whittlesford,Summerdene,Lene,Ramsbury,West Grinstead,Edmonton,Blagrove,Preston,Harlow,Goldspur,Weneslawe,Fareham,Farnham,Gillingham,Wingham,Folkestone,Fordwich,Poynings,Downhamford,Bunsty,Northstowe,Smethdon,Tollingtrough,Guestling,Littlefeld,Martinsley,Hounslow,Samford,Holmestrow,Gore,Hartfield,Dill,Shoyswell,Henfield,Cutsthorn,Langebrige,Hoo,Framfield,Pyrton,Ifield,WOR,Suffolk,Ipswich,Babinrerode,Letberge,Leyland,Wells,Ewias,Wyvern,Reculver,Maldon,Malling,Thanet,Martock,Melksham,Shrewsbury,East Meon,Milton,Castle,Silverden,Newton,Norwich,Ham,Codsheath,Ottery St Mary,Pagham,Oxney,Pawton,Petham,Stursete,Sandwich,Somerley,Teynham,Crickland,Sellack,Sturry,Thetford,Tidenham,Lowy of Tonbridge,Wechylstone,Hawkesborough,Warrington,Wonderditch,Wrotham,Hemreswel";
        public const int MINIMUM_VILLAGE_SIZE = 25;
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
    public enum HouseholdClass
    {
        Noble = 0,
        Peasant = 1
    }
    public class House
    {
        public House()
        {
            Lords = new List<Person>();
            Members = new List<Person>();
        }
        public String Name { get; set; }
        public List<Person> Lords { get; set; }
        public List<Person> Members { get; set; }
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
        public void IncrementYear() { }
    }
    public class Household
    {
        public Household()
        {
            Members = new List<Person>();
            Village = null;
            HouseholdClass = HouseholdClass.Peasant;
        }
        //The members of the family
        //public Person HouseFounder { get; set; }
        public Person HeadofHousehold { get; set; }
        public List<Person> Members { get; set; }
        //Where the family currently lives
        public Village Village {get; set;}
        public HouseholdClass HouseholdClass { get; set; }
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
                if (Village != null) { 
                    Village.Households.Remove(this);
                    Village = null;
                }
            } else if (oldMember == HeadofHousehold)
            {
                //make eldest head of household
                HeadofHousehold = Members.OrderBy(x => x.Age).Last();
            }
        }
        public static Household CreateMarriageHousehold(Person headOfHousehold, Person spouse)
        {
            Household marriageHousehold;
            var headsOldHousehold = headOfHousehold.Household;
            var spousesOldHousehold = spouse.Household; 
            //if headOfHousehold is already head then their house is the marriageHousehold
            if (headsOldHousehold.HeadofHousehold == headOfHousehold)
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
                    marriageHousehold.Village = headsOldHousehold.Village;
                }
            }
            marriageHousehold.AddMember(headOfHousehold);
            marriageHousehold.AddMember(spouse);
            headOfHousehold.House.AddMember(spouse);
            if (marriageHousehold.Village != null) { 
                marriageHousehold.Village.AddHousehold(marriageHousehold);
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
            return marriageHousehold;
        }
        public void IncrementYear()
        {

        }
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
            Year = 0;
            if (Age >= 18 && Age < 50)
            {
                Profession = Profession.Peasant;
            }
            else
            {
                Profession = Profession.Dependant;
            }
            Lordships = new List<Village>();
            //HouseFounder = this;
        }
        public Person(
            Random rnd
            , Household household
            , int birthYear
            , Village birthPlace
            , Person father
            , Person mother
            //,Person houseFounder
            , Profession profession
            , Person spouse
            , int year
            ) : this(rnd)
        {
            Household = household;
            BirthYear = birthYear;
            BirthPlace = birthPlace;
            Father = father;
            Mother = mother;
            //HouseFounder = houseFounder;
            Profession = profession;
            Spouse = spouse;
            Year = year;
        }
        public Guid Id { get; set; }
        public House House {get;set;}
        public int Year { get; set; }
        public Household Household { get; set; }
        public int BirthYear { get; set; }
        public Village BirthPlace { get; set; }
        public string Name { get; set; }
        public string FullNameAndAge
        {
            get
            {
                string fullNameAndAge = "";
                fullNameAndAge += this.Name;
                if (this.Lordships.Count > 0)
                {
                    fullNameAndAge += ", Lord of " + Lordships[0].Name;
                    if (Lordships.Count > 1)
                    {
                        for (int i = 1; i < Lordships.Count(); i++)
                        {
                            if(i == Lordships.Count - 1)
                            {
                                fullNameAndAge += ", and ";
                            } else
                            {
                                fullNameAndAge += ", ";
                            }
                            fullNameAndAge += Lordships[i].Name;
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
                    fullNameAndAge += this.Father.Name + " and " + this.Mother.Name;
                }
                fullNameAndAge += ", of House " + this.House.Name;
                if (Household != null && Household.Village != null)
                {
                    fullNameAndAge += ", residing in " + Household.Village.Name;
                }
                fullNameAndAge += ", aged " + this.Age + " years";
                return fullNameAndAge;
            }
        }
        //public Person HouseFounder { get; set; }
        public Profession Profession { get; set; }
        public List<Person> Children { get; set; }
        public Person Newborn { get; set; }
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
        public Village Fealty { get; set; }
        public List<Village> Lordships { get; set; }
        public void IncrementYear()
        {
            if (IsAlive)
            {
                Year++;
                //Death Check
                if (_rnd.Next(1, 100) < Age && _rnd.Next(1, 100) < Age && _rnd.Next(1, 100) < Age && _rnd.Next(1, 100) < Age)
                {
                    IsAlive = false;
                    Household.RemoveMember(this);
                }
                else
                {
                    Age++;
                    //Childbirth Check
                    Newborn = null;
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
                        Newborn = new Person(_rnd
                            , childsMother.Household
                            , childsMother.BirthYear + childsMother.Age
                            , childsMother.Household.Village
                            , childsFather
                            , childsMother
                            , Profession.Dependant
                            , null
                            , Year
                            );
                        if (childsMother.Profession == Profession.Noble)
                        {
                            Newborn.Profession = Profession.Noble;
                        }
                        Children.Add(Newborn);
                        Spouse.Children.Add(Newborn);
                        Household.AddMember(Newborn);
                        House.AddMember(Newborn);
                        if (Newborn.Mother.Lordships.Count()> 0 || Newborn.Father.Lordships.Count() > 0)
                        {
                            Console.WriteLine(Newborn.Name + " WAS BORN to " +  Newborn.Mother.FullNameAndAge + " and " + Newborn.Father.FullNameAndAge + " in " + Year);
                        }
                    }
                }
            }
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
        public static Person GetNextHeir(Person predesessor, List<Person> successionList = null, Person currentLord = null)
        {
            Person nextHeir = null;
            if (successionList == null)
            {
                successionList = new List<Person>();
            }
            if (currentLord == null)
            {
                currentLord = new Person(new Random());
            }
            if (predesessor.Children.Count() > 0)
            {
                var orderedChildren = predesessor.Children.OrderBy(x => x.Age).ToList();
                nextHeir = orderedChildren.LastOrDefault(x => x.IsAlive && !successionList.Contains(x) && x != currentLord);
                {
                    var childIndex = 0;
                    while (nextHeir == null && childIndex < predesessor.Children.Count())
                    {
                        nextHeir = GetNextHeir(orderedChildren[childIndex], successionList, currentLord);
                        childIndex++;
                    }
                }
            }
            return nextHeir;
        }
        public static void CreateMarriages(List<Person> unmarriedPeople, Random rnd, bool echo = false)
        {
            var unmarriedMenInPrime = unmarriedPeople.Where(x => x.Sex == Sex.Male).OrderBy(x => x.Age).ToList();
            var unmarriedWomenInPrime = unmarriedPeople.Where(x => x.Sex == Sex.Female).OrderBy(x => x.Age).ToList();
            while (unmarriedMenInPrime.Count() > 0 && unmarriedWomenInPrime.Count() > 0)
            {
                var groom = unmarriedMenInPrime[0];
                //nobles can only marry nobles
                var isNoble = groom.Household.HouseholdClass == HouseholdClass.Noble;
                //don't marry your brother, father, or grandfather
                var bride = unmarriedWomenInPrime.FirstOrDefault(x =>
                        (
                            x.Father == null ||
                            (
                                //don't marry your father
                                groom != x.Father
                                && (
                                    //don't marry your brother
                                    groom.Father == null || (
                                        x.Father != groom.Father
                                        && (
                                           //don't marry your grandfather
                                           x.Father.Father == null || (
                                                groom != x.Father.Father
                                            )
                                        )
                                    )
                                )
                            )
                        )
                    //don't marry your half brother
                    && (
                        x.Mother == null || (
                            x.Mother != groom.Mother
                            && (
                                //don't marry your maternal grandfather
                                x.Mother.Father == null || groom != x.Mother.Father
                            )
                        )
                    )
                    //don't marry outside your class
                    && isNoble == (x.Household.HouseholdClass == HouseholdClass.Noble)
                    //you must marry outside your house
                    && x.House != groom.House
                    );
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

                    if (spouse.Lordships.Count() > 0 || groom.Lordships.Count() > 0)
                    {
                        Console.WriteLine(spouse.FullNameAndAge + " MARRIED " + headOfHousehold.FullNameAndAge + " in " + headOfHousehold.Year + ".");
                    }
                    Household.CreateMarriageHousehold(headOfHousehold, spouse);
                }
                unmarriedMenInPrime.Remove(groom);
                unmarriedWomenInPrime.Remove(bride);

            }
        }
    }
    public class Village
    {
        private Random _rnd;
        private int _maxYeild;
        public Village(Random rnd)
        {
            _rnd = rnd;
            Households = new List<Household>();
            Lords = new List<Person>();
            Wealth = 0;
            Year = 0;
            Surplus = 0;
            DynasticStartYear = 1;
            _maxYeild = _rnd.Next(Constants.MAX_YEILD_LOW, Constants.MAX_YEILD_HIGH);
            Villages = new List<Village>();
            Vacant = true;
        }
        public bool Vacant { get; set; }
        public List<Village> Villages { get; set; }
        public int FoundingYear { get; set; }
        public String Name { get; set; }
        public int Year { get; set; }
        public int DynasticStartYear { get; set; }
        public List<Household> Households { get; set; }
        public double Income { get; set; }
        public double Yeild { get; set; }
        public double Cost { get; set; }
        public double Surplus { get; set; }
        public double Wealth { get; set; }
        public void IncrementYear()
        {
            //lets fix this economy!
            //1. Increment year for each villager
            Year++;
            if (Households.Count() > 0)
            {
                var villagers = new List<Person>();
                Households.ForEach(x => villagers.AddRange(x.Members));
                foreach (var villager in villagers)
                {
                    if (villager.Year < Year)
                    {
                        villager.IncrementYear();
                    }              
                }
                //4. Marry villagers! 
                var villagersInPrime = villagers.Where(x => x.IsAlive && x.Age >= 18 && x.Age < 50  && x.Household.HouseholdClass == HouseholdClass.Peasant).ToList();
                Person.CreateMarriages(villagersInPrime,_rnd);
                //5. Check for succession of Lord
                var incumbentLord = Lords.Last();
                if (!incumbentLord.IsAlive && !Vacant)
                {
                    //The lord is Dead!  Long live the lord!
                    //Console.WriteLine(incumbentLord.FullNameAndAge + ", died in year " + Year);
                    //create new lord (only inherit to oldest living child, otherwise it is up for grabs)
                    Console.WriteLine(incumbentLord.FullNameAndAge + " DIED in " + Year);

                    Person heir = null;
                    var orderOfSuccession = GetOrderOfSuccession(1);
                    if (orderOfSuccession.Count > 0)
                    {
                        heir = orderOfSuccession[0];
                    }
                    if (heir != null)
                    {
                        AddLord(heir);
                        Console.WriteLine(heir.FullNameAndAge + " INHERITED the Lordship of " + Name + " in " + Year);
                    }
                    else
                    {
                        Vacant = true;
                        Console.WriteLine("The Lordship of " + Name + " is vacant.");
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
                Income = Math.Round(Yeild * Constants.MIN_TAX_RATE,2);
                //10. Calculate surplus/deficit
                Surplus = Yeild - Cost - Income;
                //11. Add surplus to income if positive
                if (Surplus > 0) { Income += Surplus; }
                //12. Add Income to treasury
                Wealth += Income;
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
              
                //14. Colonize!
                var nobleHouseholds = Households.Where(x => x.HouseholdClass == HouseholdClass.Noble && !x.Members.Contains(Lords.Last())).ToList();
                var peasantHouseholds = Households.Where(x => x.HouseholdClass == HouseholdClass.Peasant).ToList();
                var unclaimedLands = Villages.Where(x => x.Vacant).ToList();
                while (unclaimedLands.Count() > 0 && peasantHouseholds.Count() >= 2*Constants.MINIMUM_VILLAGE_SIZE && nobleHouseholds.Count() >= 1)
                {
                    var newVillage = unclaimedLands[_rnd.Next(0, unclaimedLands.Count())];
                    newVillage.FoundingYear = Year;
                    unclaimedLands.Remove(newVillage);
                    var lordsHouseHold = nobleHouseholds[_rnd.Next(0, nobleHouseholds.Count())];
                    var settlers = new List<Household>();
                    nobleHouseholds.Remove(lordsHouseHold);
                    newVillage.Lords.Add(lordsHouseHold.HeadofHousehold);

                    for (int i = 0; i < Constants.MINIMUM_VILLAGE_SIZE; i++)
                    {
                        var peasantSettler = peasantHouseholds[_rnd.Next(0, peasantHouseholds.Count())];
                        peasantHouseholds.Remove(peasantSettler);
                        settlers.Add(peasantSettler);
                    }
                    PopulateVillage(newVillage, this, lordsHouseHold, settlers);
                }
               
            }
        }
        public void AddHousehold(Household newHousehold)
        {
            if (!Households.Contains(newHousehold)){ 
                if (newHousehold.Village != null)
                {
                    newHousehold.Village.Households.Remove(newHousehold);
                    newHousehold.Village = null;
                }
                Households.Add(newHousehold);
                newHousehold.Village = this;
            }
        }
        public void Removehousehold(Household oldHousehold)
        {
            if (Households.Contains(oldHousehold))
            {
                oldHousehold.Village = null;
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
        public List<Person> Lords { get; set; }
        public List<Person> GetOrderOfSuccession(int depth)
        {
            var successionList = new List<Person>();
            var lordIndex = Lords.Count - 1;
            while (successionList.Count() < depth && lordIndex >=0)
            {
                var nextHeir = Person.GetNextHeir(Lords[lordIndex], successionList, Lords.Last());
                if (nextHeir != null)
                {
                    successionList.Add(nextHeir);
                } else
                {
                    lordIndex--;
                }
            }
            return successionList;
        }
        public static void PopulateVillage (Village newVillage, Village fealty, Household lordsHouseHold, List<Household> peasantHouseholds)
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
            Console.WriteLine(newLord.FullNameAndAge + " FOUNDED " + newVillage.Name + " in " + newVillage.Year);
            newVillage.Vacant = false;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var rnd = new Random();
            var villageNames = Constants.VILLAGE_NAMES.Split(',');
            var Villages = new List<Village>();
            //create villages
            foreach (var villageName in villageNames)
            {
                Villages.Add(new Village(rnd) { Name = villageName, Villages = Villages });
            }
            Village firstVillage = new Village(rnd);
            for (int k = 0; k < 20; k++) {
                var vacantVillages = Villages.Where(x => x.Vacant).ToList();
                firstVillage = vacantVillages[rnd.Next(0, vacantVillages.Count)];
                //create settlers
                var firstSettlers = new List<Household>();
                for (int i = 0; i < 100; i++)
                {
                    var husband = new Person(rnd)
                    {
                        Age = rnd.Next(18, 36),
                        Sex = Sex.Male,
                        Profession = Profession.Peasant
                    };
                    husband.House = new House() { Name = husband.Name };
                    var wife = new Person(rnd)
                    {
                        Age = husband.Age,
                        Sex = Sex.Female,
                        Profession = Profession.Peasant
                    };
                    for (int j = 18 - 5; j < (wife.Age - 18) && j <= 18; j++)
                    {
                        var kid = new Person(rnd)
                        {
                            Age = j,
                            Mother = wife,
                            Father = husband,
                            Profession = Profession.Dependant
                        };
                        wife.Children.Add(kid);
                        husband.Children.Add(kid);
                        husband.House.AddMember(kid);
                    }
                    var settlerHousehold = Household.CreateMarriageHousehold(husband, wife);
                    settlerHousehold.HouseholdClass = HouseholdClass.Peasant;
                    firstSettlers.Add(settlerHousehold);
                }
                
                var lord = new Person(rnd)
                {
                    Age = rnd.Next(18, 36),
                    Sex = Sex.Male,
                    Profession = Profession.Noble
                };
                var lady = new Person(rnd)
                {
                    Age = lord.Age,
                    Sex = Sex.Female,
                    Profession = Profession.Noble
                };
                lord.House = new House() { Name = lord.Name };
                for (int j = 18 - 5; j < (lady.Age - 18) && j <= 18; j++)
                {
                    var kid = new Person(rnd)
                    {
                        Age = j,
                        Mother = lady,
                        Father = lord,
                        Profession = Profession.Noble
                    };
                    lady.Children.Add(kid);
                    lord.Children.Add(kid);
                    lord.House.AddMember(kid);
                }
                var lordsHousehold = Household.CreateMarriageHousehold(lord, lady);
                lordsHousehold.HouseholdClass = HouseholdClass.Noble;
                Village.PopulateVillage(firstVillage, firstVillage, lordsHousehold, firstSettlers);

            }
            while (firstVillage.Year < 500 && firstVillage.Households.Count() > 0)
            {
                //marry nobles
                var eligibleNobles = new List<Person>();

                var villagesToIncrement = new List<Village>();
                villagesToIncrement.AddRange(Villages);
                while (villagesToIncrement.Count() > 0)
                {
                    var villageToIncrement = villagesToIncrement[rnd.Next(0, villagesToIncrement.Count())];
                    villageToIncrement.IncrementYear();
                    villagesToIncrement.Remove(villageToIncrement);
                    if (villageToIncrement.Households.Count() > 0)
                    {
                        villageToIncrement.Households
                            .Where(household => household.HouseholdClass == HouseholdClass.Noble).ToList()
                            .ForEach(nobleHousehold => eligibleNobles.AddRange(
                                nobleHousehold.Members.Where(
                                    member =>
                                    member.Age >= 18
                                    && member.Age < 50
                                    && (member.Spouse == null || !member.Spouse.IsAlive)
                                    )
                                )
                            );
                    }
                }
                
                foreach (var village in Villages) { 
                   /*
                    if (village.Households.Count() > 0 && village.Year % 1 == 0 ) {                   
                        Console.WriteLine("YEAR " + village.Year);
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Village: " + village.Name);
                        Console.WriteLine("Founding Year: " + village.FoundingYear);
                        var incumentlord = village.Lords.Last();
                        Console.WriteLine("Lord: " + incumentlord.FullNameAndAge);
                        Console.WriteLine("Order of Succession:");
                        var orderOfSuccession = village.GetOrderOfSuccession(2);
                        for (int i = 0; i < orderOfSuccession.Count(); i++)
                        {
                            Console.WriteLine((i + 1) + ": " + orderOfSuccession[i].FullNameAndAge);
                        }
                        var villagers = new List<Person>();
                        village.Households.ForEach(x => villagers.AddRange(x.Members));
                        Console.WriteLine("Noble Households:" + village.Households.Count(x=>x.HouseholdClass==HouseholdClass.Noble));
                        Console.WriteLine("Peasant Households:" + village.Households.Count(x=>x.HouseholdClass==HouseholdClass.Peasant));
                        Console.WriteLine("Population:" + villagers.Count());
                        Console.WriteLine("Seniors >= 50:" + villagers.Count(x => x.IsAlive && x.Age > 50));
                        Console.WriteLine("Children < 18: " + villagers.Count(x => x.IsAlive && x.Age < 18));
                        Console.WriteLine("Nobles: " + villagers.Count(x => x.Household.HouseholdClass == HouseholdClass.Noble && x.IsAlive));
                        Console.WriteLine("Peasants: " + villagers.Count(x => x.Household.HouseholdClass == HouseholdClass.Peasant && x.IsAlive));
                        Console.WriteLine("Yeild: " + village.Yeild);
                        Console.WriteLine("Cost: " + village.Cost);
                        Console.WriteLine("Surplus: " + village.Surplus);
                        Console.WriteLine("Income: " + village.Income);
                        Console.WriteLine("Wealth: " + village.Wealth);
                        Console.WriteLine("------------------------");
                    }
                    */
                }
                //marry villagers 
                Person.CreateMarriages(eligibleNobles, rnd);
                if (Villages[0].Year % 1 == 0)
                {
                    Console.WriteLine("Year: " + Villages[0].Year);
                    Console.WriteLine("Villages: " + Villages.Count(x => x.Households.Count() > 0));
                    Console.WriteLine("Total Population: " + Villages.Sum(x => x.Households.Sum(y => y.Members.Count())));
                    Console.WriteLine("Total Noble Households: " + Villages.Sum(x => x.Households.Count(y => y.HouseholdClass == HouseholdClass.Noble)));
                    Console.WriteLine("Total Peasant Households: " + Villages.Sum(x => x.Households.Count(y => y.HouseholdClass == HouseholdClass.Peasant)));
                    var housePower = Villages.Where(v => !v.Vacant).GroupBy(v => v.Lords.Last().House);
                    foreach (var houseGrouping in housePower)
                    {
                        Console.WriteLine("House " + houseGrouping.Key.Name);
                        Console.WriteLine("\tLordships:" + houseGrouping.Count());
                        Console.WriteLine("\tWealth:" + houseGrouping.Sum(x => x.Wealth));
                    }
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Enter to continue. CTRL-C to quit.");
                    Console.ReadLine();
                }
            }
            Console.ReadLine();
        }
    }
}
