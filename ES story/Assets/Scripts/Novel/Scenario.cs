using UnityEngine;
using System.Collections;

public class Scenario : MonoBehaviour {

	private bool EndOf = false;
	//Backgrounds
	private string Stars;
	private string Boathouse_night;
	private string House_of_mt_night;
	private string Square_night;
	private string House_of_mt_night_in2;
	private string Club_screen;
	private string Bathhouse;
	private string DiningHall;
	private string House_of_mt;
	private string House_of_mt_sunset;
	private string Houses;
	private string Path2;
	private string Polyana;
	private string Polyana_sunset;
	private string Square;
	private string Washstand;
	private string DiningHall_in;
	private string DiningHall_in_people;
	private string DiningHall_in_sunset;
	private string House_of_mt_in;
	private string DiningHall_way_sunset;
	private string House_of_mt_night_in;

	//Actors
	Actor Alice;
	Actor Electronic;
	Actor Miku;
	Actor Olga;
	Actor Zhenya;
	Actor Shurik;
	Actor Slavya;
	Actor Helen;
	Actor Uliana;

	//Audiostreams
	AudioStream Environment;
	AudioStream Music;
	AudioStream Effects;

	static public int CurrentLevel = 0;
	void Start () {
		Stars = "stars";
		Boathouse_night = "ext_boathouse_night";
		House_of_mt_night = "ext_house_of_mt_night_without_light";
		Square_night = "ext_square_night";
		House_of_mt_night_in2 = "int_house_of_mt_night2";
		Club_screen = "d5_clubs_robot";
		Bathhouse = "ext_bathhouse_night";
		DiningHall = "ext_dining_hall_near_day";
		House_of_mt = "ext_house_of_mt_day";
		House_of_mt_sunset = "ext_house_of_mt_sunset";
		Houses = "ext_houses_day";
		Path2 = "ext_path2_day";
		Polyana = "ext_polyana_day";
		Polyana_sunset = "ext_polyana_sunset";
		Square = "ext_square_day";
		Washstand = "ext_washstand_day";
		DiningHall_in = "int_dining_hall_day";
		DiningHall_in_people = "int_dining_hall_people_day";
		DiningHall_in_sunset = "int_dining_hall_sunset";
		House_of_mt_in = "int_house_of_mt_day";
		DiningHall_way_sunset = "ext_dining_hall_away_sunset";
		House_of_mt_night_in = "int_house_of_mt_night";

		Alice = new Actor ("Алиса","dv");
		Electronic = new Actor ("Электроник","el");
		Miku = new Actor ("Мику","mi");
		Olga = new Actor ("Ольга Дмитриевна","mt");
		Zhenya = new Actor ("Женя","mz");
		Shurik = new Actor ("Шурик","sh");
		Slavya = new Actor ("Славя","sl");
		Helen = new Actor ("Лена","un");
		Uliana = new Actor ("Ульяна","us");

		Environment = new AudioStream ("Sounds/Environment/",true);
		Music = new AudioStream ("Sounds/Music/",true);
		Effects = new AudioStream ("Sounds/Effects/",false);
	}

	IEnumerator Day0()
	{
		Environment.Play ("water");
		Music.Play ("Confession");
		PushText ("Звёзды..."); yield return StartCoroutine (WaitNext ());
		PushText ("Интересно, сколько же, в конце концов, звёзд мерцают на нашем небосклоне, волей или неволей заставляя людей погружаться в собственные мысли или просто глупо глазеть наверх? "); yield return StartCoroutine (WaitNext ());
		PushText ("Каждый, кто самостоятельно пытался узнать ответ на этот вопрос, неизбежно терпел неудачу, и это каждый знает. "); yield return StartCoroutine (WaitNext ());
		PushText ("Так почему же…"); yield return StartCoroutine (WaitNext ());
		PushText ("Семьдесят два...","Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("И вроде бы просто огромные газовые шары, а иногда кажутся живыми…"); yield return StartCoroutine (WaitNext ());
		PushText ("Семьдесят три...","Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("Может, я просто схожу с ума, но они даже вроде иногда подмигивают мне, словно зовут уютно расположиться среди них"); yield return StartCoroutine (WaitNext ());
		PushText ("Семьдесят четыре...", "Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("Я, может, и сам бы рад, но вот только…"); yield return StartCoroutine (WaitNext ());
		PushText ("И чем это мы тут занимаемся?","Алиса"); yield return StartCoroutine (WaitNext ());
		Music.Stop();
		ChangeBackground (Boathouse_night); yield return StartCoroutine (WaitNext ());
		Alice.SetSprite (Actor.Side.Right,"4smile");
		PushText ("Да в общем-то, ничем я постыдным не занимался, но всё же счёл это за вероломное вторжение в своё личное пространство."); yield return StartCoroutine (WaitNext ());
		PushText ("Двачевская. Почему бы тебе не скрыться из виду и не сдохнуть?", "Семён"); yield return StartCoroutine (WaitNext ());
		Alice.ChangePosition (Actor.Side.Center);
		Alice.ChangeSprite ("1surprise");
		PushText ("Хм. Не слишком ли это грубо даже для тебя?", "Алиса"); yield return StartCoroutine (WaitNext ());
		PushText ("По-твоему, я всем своим видом показываю, что горю желанием общаться с тобой в данный момент?","Семён"); yield return StartCoroutine (WaitNext ());
		Alice.ChangeSprite ("4normal");
		PushText ("Ну-ну, язви дальше. Я же пришла сказать, что Ольга Дмитриевна давно уж тебя обыскалась. Предупредить хотела. А ты тут…","Алиса"); yield return StartCoroutine (WaitNext ());
		PushText ("Хм. И правда, что-то перегнул."); yield return StartCoroutine (WaitNext ());
		PushText ("Ладно, прости.","Семён"); yield return StartCoroutine (WaitNext ());
		Alice.ChangeSprite ("2grin");
		PushText ("Да чего уж там. С кем не бывает. ","Алиса"); yield return StartCoroutine (WaitNext ());
		Alice.ChangeSprite ("4normal");
		PushText ("Кстати, говорят, завтра новый пионер приезжает.","Алиса"); yield return StartCoroutine (WaitNext ());
		PushText ("Интересная ситуация. Так пионер или пионерка?","Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("Будто мне есть до этого дело."); yield return StartCoroutine (WaitNext ());
		Alice.ChangeSprite ("4laugh");
		PushText ("Ха! Так вот что тебя интересует в первую очередь! Не знаю уж, не спрашивала. А что, уже надеешься на что-то?","Алиса"); yield return StartCoroutine (WaitNext ());
		PushText ("Нет уж, ты моя единственная любовь до гроба.","Семён"); yield return StartCoroutine (WaitNext ());
		Alice.ChangeSprite ("1shocked");
		PushText ("...","Алиса"); yield return StartCoroutine (WaitNext ());
		Alice.ChangeSprite ("5angry");
		PushText ("Ха-ха-ха, как смешно. Ладно, я к себе. Увидимся.","Алиса"); yield return StartCoroutine (WaitNext ());
		PushText ("Ага, до завтра.","Семён"); yield return StartCoroutine (WaitNext ());
		Alice.Delete (Actor.Side.Left);
		PushText ("Утомляет это девица, но иногда с ней весело."); yield return StartCoroutine (WaitNext ());
		PushText ("Чтоб не наживать себе ещё больше проблем, я побрёл к своему домику."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (Square_night); yield return StartCoroutine (WaitNext ());
		Music.Play ("Silhouette In Sunset");
		Environment.ChangeSound ("grasshopers");
		PushText ("И снова в голове начали возникать увлекательные (идиотские, точнее, мысли)."); yield return StartCoroutine (WaitNext ());
		PushText ("Интересно, если бы я прямо в этот момент писал книгу о себе, то что именно писал?"); yield return StartCoroutine (WaitNext ());
		PushText ("Привет, меня зовут Семён! Я живу в городе Пхе, закончил школу Кхе, теперь же родители отправили меня против моей же воли в какой-то сраный лагерь."); yield return StartCoroutine (WaitNext ());
		PushText ("Учился я так себе, и был тем ещё остолопом. Может, умей я прилагать усилия, я мог бы стать отличником. Поступил бы институт, стал бы профессором, исследователем, светлом науки!"); yield return StartCoroutine (WaitNext ());
		PushText ("И место мне тогда в кружке кибернетиков!","Семён"); yield return StartCoroutine (WaitNext ());
		ChangeBackground (Club_screen); yield return StartCoroutine (WaitNext ());
		ChangeBackground (Square_night); yield return StartCoroutine (WaitNext ());
		PushText ("Ахахахахаха… ни в коем разе."); yield return StartCoroutine (WaitNext ());
		PushText ("«Совёнок» этот, пожалуй, не так плох, как показался мне в начале. Здесь неплохо кормят, да и…"); yield return StartCoroutine (WaitNext ());
		PushText ("Э-ээ…"); yield return StartCoroutine (WaitNext ());
		PushText ("Да здесь вообще ничего хорошего нет!"); yield return StartCoroutine (WaitNext ());
		PushText ("Вожатая эта – «подай» да «принеси», помощница её туда же – «подмети» да «приберись»."); yield return StartCoroutine (WaitNext ());
		PushText ("Хотя, последняя достаточно милая, и даже иногда есть, о чём поговорить."); yield return StartCoroutine (WaitNext ());
		PushText ("Дети бегают вокруг да около со своими дурацкими приколами. Ха-ха-ха, жук в тарелке, как смешно!"); yield return StartCoroutine (WaitNext ());
		PushText ("И к этому ещё ежедневное промывание мозгов об общественной работе, коллективизме, готовности помочь товарищу и так далее."); yield return StartCoroutine (WaitNext ());
		PushText ("Будто, без всего этого Союз развалится через пару лет."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (House_of_mt_night); yield return StartCoroutine (WaitNext ());
		PushText ("Что ж, оставлю свою воображаемую автобиографию на потом, а сейчас нужно немножко повоевать с вожатой за право на жизнь."); yield return StartCoroutine (WaitNext ());
		PushText ("Я аккуратно вошёл в домик и…"); yield return StartCoroutine (WaitNext ());
		ChangeBackground (House_of_mt_night_in2); yield return StartCoroutine (WaitNext ());
		Environment.Stop ();
		Effects.Play ("door");
		PushText ("Спит.","Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("Так вот она и нашла пропавшего пионера. Всем пример, ничего не скажешь…"); yield return StartCoroutine (WaitNext ());
		PushText ("Не мешкая, я разделся и залез в кровать. "); yield return StartCoroutine (WaitNext ());
		PushText ("Вопреки своим собственным традициям, я заснул почти сразу."); yield return StartCoroutine (WaitNext ());
		PushText ("Завтра, наверно, будет такой же день, как и остальные."); yield return StartCoroutine (WaitNext ());
		PushText ("Или нет?"); yield return StartCoroutine (WaitNext ());
		Music.Stop ();
		Effects.Stop ();
		ShowDay ("ДЕНЬ 1", House_of_mt_in); yield return StartCoroutine (WaitNext ());
		CurrentLevel++;
		EndOf = false;
	}

	IEnumerator Day1()
	{ 
		Music.Play ("My Daily Life");
		ChangeBackground (House_of_mt_in); yield return StartCoroutine (WaitNext ());
		PushText ("Будильник, как и положено, прозвенел в 7 утра."); yield return StartCoroutine (WaitNext ());
		PushText ("Я неспешно поднялся, оделся, взял свой пакетик и вышел за дверь."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (House_of_mt); yield return StartCoroutine (WaitNext ());
		Environment.Play ("birds");
		Effects.Play ("door");
		PushText ("В голове был небольшой беспорядок, но холодная вода быстро всё исправит."); yield return StartCoroutine (WaitNext ());
		PushText ("Уже который день я беспрекословно просыпался в столь раннее для себя время."); yield return StartCoroutine (WaitNext ());
		PushText ("Первые дни здесь я отчаянно пытался отоспаться по утрам, но Ольга Дмитриевна была беспощадна, использовала самые подлые уловки, и мне таки приходилось вставать."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (Houses); yield return StartCoroutine (WaitNext ());
		PushText ("Потом я сам заставлял себя подниматься, чтобы лишний раз не получать по шее."); yield return StartCoroutine (WaitNext ());
		PushText ("Затем же я немного попривык, и, ложась часов в 11 вечера, просыпался вовремя без лишних усилий."); yield return StartCoroutine (WaitNext ());
		PushText ("На самом деле, это оказалось не так уж и плохо. День так кажется намного длинней, и можно сделать больше всяких интересных вещей."); yield return StartCoroutine (WaitNext ());
		PushText ("Только в этом местечке этих вещей не особо много."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (Washstand); yield return StartCoroutine (WaitNext ());
		PushText ("И вот я уже размазываю по лицу свежую порцию ледяной воды и потихоньку прихожу в себя."); yield return StartCoroutine (WaitNext ());
		PushText ("Энергично чищу зубы, затем ополаскиваю руки, лицо, мочу себе голову (жара же) и закрываю кран."); yield return StartCoroutine (WaitNext ());
		PushText ("Отлично! Не опоздаю на линейку хоть."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (Houses); yield return StartCoroutine (WaitNext ());
		Electronic.SetSprite (Actor.Side.Center, "1normal", Actor.Side.Right);
		PushText ("По дороге я встречаю Электроника."); yield return StartCoroutine (WaitNext ());
		PushText ("Слава Советам!","Семён"); yield return StartCoroutine (WaitNext ());
		Electronic.ChangeSprite ("2surprise");
		PushText ("Ленину сл… эй, тебе не кажется, что это звучит как-то…","Электроник"); yield return StartCoroutine (WaitNext ());
		PushText ("Ладно, забудь. Доброе утро.","Семён"); yield return StartCoroutine (WaitNext ());
		Electronic.ChangeSprite ("1normal");
		PushText ("Доброе.","Электроник"); yield return StartCoroutine (WaitNext ());
		Electronic.Delete (Actor.Side.Left);
		PushText ("Как-то он не особо проснулся, вроде. Или просто настроение не очень."); yield return StartCoroutine (WaitNext ());
		PushText ("Иногда я встречаю его идущим из библиотеки с точно таким же лицом."); yield return StartCoroutine (WaitNext ());
		PushText ("Слишком грустные, драматичные книги, наверно, читает."); yield return StartCoroutine (WaitNext ());
		PushText ("Хм. Может он и сейчас оттуда же?"); yield return StartCoroutine (WaitNext ());
		PushText ("Тогда он, получается, всю ночь читал…"); yield return StartCoroutine (WaitNext ());
		PushText ("Надо будет тоже туда наведаться, раз там настолько невероятные истории."); yield return StartCoroutine (WaitNext ());
		PushText ("Бедняга… как же он будет робота делать в таком состоянии?"); yield return StartCoroutine (WaitNext ());
		PushText ("Я больно ударил себя по лицу."); yield return StartCoroutine (WaitNext ());
		PushText ("Да что вообще за отстойные мысли у меня в голове появляются? Кому вообще нужен этот Электроник?"); yield return StartCoroutine (WaitNext ());
		PushText ("Сказал бы мне. Я бы с удовольствием помогла.","Алиса"); yield return StartCoroutine (WaitNext ());
		Alice.SetSprite (Actor.Side.Left, "2grin");
		PushText ("Ну да, её хлебом не корми, дай избить кого-нибудь."); yield return StartCoroutine (WaitNext ());
		Alice.ChangeSprite ("4laugh");
		PushText ("И так, пока мы шли до площади, она пыталась меня подкалывать, но у неё как-то не очень получалось."); yield return StartCoroutine (WaitNext ());
		PushText ("Мне даже становилось забавно."); yield return StartCoroutine (WaitNext ());
		Alice.Delete ();
		ChangeBackground (Square); yield return StartCoroutine (WaitNext ());
		PushText ("Мы вышли на площадь. Пионеры уже начали строиться, и мы решили к ним примкнуть."); yield return StartCoroutine (WaitNext ());
		Music.Stop ();
		PushText ("Линейка началась."); yield return StartCoroutine (WaitNext ());
		PushText ("…"); yield return StartCoroutine (WaitNext ());
		PushText ("Генда… О чём же он думает?"); yield return StartCoroutine (WaitNext ());
		PushText ("В какие тайны он посвящён? Какими способностями он обладает?"); yield return StartCoroutine (WaitNext ());
		PushText ("Мудрость веков заключена в его каменном теле."); yield return StartCoroutine (WaitNext ());
		PushText ("Взял бы он меня к себе в ученики?"); yield return StartCoroutine (WaitNext ());
		PushText ("Я столькому мог бы у него научиться."); yield return StartCoroutine (WaitNext ());
		PushText ("Да я бы превзошёл его! Стал бы самым могущественным колдуном и пошёл бы вершить правосу…"); yield return StartCoroutine (WaitNext ());
		Olga.SetSprite (Actor.Side.Center, "1normal");
		PushText ("Линейка окончена, всем спасибо!","Ольга Дмитриевна"); yield return StartCoroutine (WaitNext ());
		Olga.Delete ();
		Music.Play ("Feeling Good");
		PushText ("Наконец-то! Что ж, теперь же можно с чистой совестью идти завтракать."); yield return StartCoroutine (WaitNext ());
		PushText ("Только вот подожду, пока толпа разойдётся."); yield return StartCoroutine (WaitNext ());
		PushText ("Я решил прилечь на скамейку и уставился в небо."); yield return StartCoroutine (WaitNext ());
		PushText ("Снова привет, мой мнимый читатель!"); yield return StartCoroutine (WaitNext ());
		PushText ("Сегодня вроде как экватор смены, а здесь всё так же скучно."); yield return StartCoroutine (WaitNext ());
		PushText ("И ведь дальше-то ничего не изменится! Ещё семь дней строгого режима, проведённых в попытках скрыться от вожатой."); yield return StartCoroutine (WaitNext ());
		PushText ("Только вот сегодня, если верить Алисе, какой-то пионер должен приехать."); yield return StartCoroutine (WaitNext ());
		PushText ("Или пионерка. А что? От чего-то типа «лагерного» романа я бы не отказался."); yield return StartCoroutine (WaitNext ());
		PushText ("Хаха! Да кого я обманываю, я никому никогда особо-то не нравился."); yield return StartCoroutine (WaitNext ());
		PushText ("Впрочем, если это парень, то, пожалуй, с ним можно подружиться."); yield return StartCoroutine (WaitNext ());
		PushText ("Надеюсь, это не ещё один Шурик. Если нет, то с ним можно будет найти общий язык."); yield return StartCoroutine (WaitNext ());
		PushText ("Ладно, достаточно, пора идти есть."); yield return StartCoroutine (WaitNext ());
		PushText ("Я встал и направился в столовую."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (DiningHall_in); yield return StartCoroutine (WaitNext ());
		Environment.ChangeSound ("posuda");
		Music.Stop ();
		PushText ("Видимо, я слишком уж много прождал."); yield return StartCoroutine (WaitNext ());
		PushText ("В столовой настолько тихо, что там не оказалось ни одного знакомого."); yield return StartCoroutine (WaitNext ());
		Helen.SetSprite (Actor.Side.Left,"1normal");
		PushText ("Только на выходе я повстречал девочку с синими волосами."); yield return StartCoroutine (WaitNext ());
		PushText ("Я с ней не знаком, даже не знаю, как зовут, но часто видел её."); yield return StartCoroutine (WaitNext ());
		Helen.Delete (Actor.Side.Right);
		PushText ("Она быстрыми шагами прошла мимо меня и направилась по своим делам."); yield return StartCoroutine (WaitNext ());
		PushText ("Просидев в одиночестве минут десять, я вышел из столовой с наполненным желудком."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (DiningHall); yield return StartCoroutine (WaitNext ());
		Environment.ChangeSound ("birds");
		PushText ("Хм. Чем бы заняться?"); yield return StartCoroutine (WaitNext ());
		PushText ("Пройдусь по лесу. Понаслаждаюсь природой, красиво здесь всё же."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (Path2); yield return StartCoroutine (WaitNext ());
		Music.Play ("Waltz of Doubts");
		PushText ("…"); yield return StartCoroutine (WaitNext ());
		PushText ("Тени от листьев весело игрались на моей перепачканной рубашке."); yield return StartCoroutine (WaitNext ());
		PushText ("Надо будет постираться или попросить новую."); yield return StartCoroutine (WaitNext ());
		PushText ("Я отыскал уютненькое местечко под деревом, где не так сильно печёт."); yield return StartCoroutine (WaitNext ());
		PushText ("Здешний пейзаж расслабляет и заставляет задуматься о некоторых вещах."); yield return StartCoroutine (WaitNext ());
		PushText ("Иногда мне кажется, что этот лагерь – особое место для меня."); yield return StartCoroutine (WaitNext ());
		PushText ("Я постепенно забываю, что со мной было до него. И это не из-за плохой памяти, а из-за того, что прошлое уже не имеет большого значения."); yield return StartCoroutine (WaitNext ());
		PushText ("Ведь меня ждёт новая жизнь, мне нужно будет вести себя по-другому, посещать другие места, заводить новых друзей, и многих своих старых знакомых я буду видеть очень редко."); yield return StartCoroutine (WaitNext ());
		PushText ("Но и до этого ещё как-то далеко. Именно поэтому мне кажется, что это какой-то промежуточный мирок, и пусть в нём не особо весело, но зато он почти что полностью состоит из некой беззаботности."); yield return StartCoroutine (WaitNext ());
		PushText ("Ничего подобного у меня уже не будет. Нужно будет стараться, что-то постоянно решать, пытаться как-то жить."); yield return StartCoroutine (WaitNext ());
		Music.Stop ();
		PushText ("Мои рассуждения прервал девчачий голос, наполненный странным возбуждением."); yield return StartCoroutine (WaitNext ());
		Music.Play ("Gentle Predator");
		PushText ("Ну же!","Пионерка"); yield return StartCoroutine (WaitNext ());
		PushText ("Такс, что там у нас…"); yield return StartCoroutine (WaitNext ());
		PushText ("Чуть ниже…","Пионерка"); yield return StartCoroutine (WaitNext ());
		PushText ("Стойте, там же не…"); yield return StartCoroutine (WaitNext ());
		PushText ("Аккуратнее…","Пионерка"); yield return StartCoroutine (WaitNext ());
		PushText ("Эээээээ… Вообще-то это неприемлемо для порядочной пионерки!"); yield return StartCoroutine (WaitNext ());
		PushText ("Хотя это достаточно интересное зрелище, я бы глянул. Я встал и пошёл в ту сторону."); yield return StartCoroutine (WaitNext ());
		Music.Stop ();
		PushText ("Но следующая фраза развеяла мои надежды."); yield return StartCoroutine (WaitNext ());
		PushText ("Спасибо тебе! Их тут так много, и они постоянно лезут, а я их так боюсь!","Пионерка"); yield return StartCoroutine (WaitNext ());
		PushText ("Да не за что! Как странно, мне они не кажутся противными.","Славя"); yield return StartCoroutine (WaitNext ());
		PushText ("Ай, ладно, пойду хоть поздороваюсь, раз там Славя."); yield return StartCoroutine (WaitNext ());
		Slavya.SetSprite (Actor.Side.Right, "1normal");
		Helen.SetSprite (Actor.Side.Left, "2surprise");
		PushText ("Всем привет!","Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("Рядом со Славей оказалась та синеволосая девочка."); yield return StartCoroutine (WaitNext ());
		Helen.ChangeSprite ("1shy");
		Helen.Delete (Actor.Side.Right);
		PushText ("Она мигом покраснела и убежала."); yield return StartCoroutine (WaitNext ());
		PushText ("Видимо, её отношения с местными насекомыми должны были остаться секретом."); yield return StartCoroutine (WaitNext ());
		Slavya.ChangeSprite ("3surprise");
		Music.Play ("Get To Know Me Better");
		PushText ("Привет, Семён! Как ты тут оказался?","Славя"); yield return StartCoroutine (WaitNext ());
		PushText ("Да так, прогуливался, любовался природой. Да и ты, наверно, тоже здесь поэтому.","Семён"); yield return StartCoroutine (WaitNext ());
		Slavya.ChangeSprite ("2happy");
		PushText ("Конечно! Тут ведь здорово!","Славя"); yield return StartCoroutine (WaitNext ());
		PushText ("Согласен. А разве у тебя нет никакой работы?","Семён"); yield return StartCoroutine (WaitNext ());
		Slavya.ChangeSprite ("3sad");
		PushText ("Была свободная минутка. А сейчас мне уже пора. Дела не ждут!","Славя"); yield return StartCoroutine (WaitNext ());
		PushText ("Понятно. А я здесь ещё посижу.","Семён"); yield return StartCoroutine (WaitNext ());
		Slavya.ChangeSprite ("1smile");
		PushText ("Не надоело отлынивать?","Славя"); yield return StartCoroutine (WaitNext ());
		PushText ("Неа.","Семён"); yield return StartCoroutine (WaitNext ());
		Slavya.ChangeSprite ("2smile2");
		PushText ("Ладушки. Увидимся.","Славя"); yield return StartCoroutine (WaitNext ());
		Slavya.Delete (Actor.Side.Left);
		Music.Stop ();
		PushText ("Так я просидел ещё полчаса с мыслями ни о чём и затем пошёл в столовую на обед."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (DiningHall_in_people); yield return StartCoroutine (WaitNext ());
		Environment.ChangeSound ("dining");
		PushText ("На этот раз столовая переполнена, и только рядом с Алисой и Ульянкой были свободные места."); yield return StartCoroutine (WaitNext ());
		Alice.SetSprite (Actor.Side.Left, "4normal");
		Uliana.SetSprite (Actor.Side.Right, "1normal");
		PushText ("Бонжур, мадмуазель.","Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("Сказал я Ульянке."); yield return StartCoroutine (WaitNext ());
		Uliana.ChangeSprite ("1laugh2");
		PushText ("Её, похоже, это развеселило."); yield return StartCoroutine (WaitNext ());
		PushText ("Привет! Как настроение?","Ульяна"); yield return StartCoroutine (WaitNext ());
		PushText ("Как обычно, нейтральное. А ты, я смотрю, вся светишься от счастья.","Семён"); yield return StartCoroutine (WaitNext ());
		Uliana.ChangeSprite ("1grin");
		PushText ("Конечно! Ведь сегодня новенький приезжает! На ужине ему жука какого-нибудь подложу в тарелку!","Ульяна"); yield return StartCoroutine (WaitNext ());
		PushText ("Кто бы сомневался…","Семён"); yield return StartCoroutine (WaitNext ());
		Uliana.ChangeSprite ("2dontlike");
		PushText ("Говоришь так, будто это не смешно","Ульяна"); yield return StartCoroutine (WaitNext ());
		PushText ("Ну как тебе сказать…"); yield return StartCoroutine (WaitNext ());
		PushText ("Ладно, когда я ем, я глух и нем! Смотри, даже Алиса следует этому правилу!","Семён"); yield return StartCoroutine (WaitNext ());
		Uliana.ChangeSprite ("2upset");
		PushText ("Угу","Ульяна"); yield return StartCoroutine (WaitNext ());
		PushText ("Бон аппети.","Семён"); yield return StartCoroutine (WaitNext ());
		Uliana.ChangeSprite ("1smile");
		Alice.Delete (Actor.Side.Left);
		Uliana.Delete (Actor.Side.Right);
		PushText ("Мы неспешно разделались с едой и разошлись кто куда."); yield return StartCoroutine (WaitNext ());
		PushText ("Я решил пока неспешно прогуляться до домика."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (House_of_mt); yield return StartCoroutine (WaitNext ());
		Environment.ChangeSound ("birds");
		Music.Play ("Silhouette In Sunset");
		PushText ("…"); yield return StartCoroutine (WaitNext ());
		PushText ("Уже издалека я увидел мужскую фигуру и рядом с ней стоящую Славю."); yield return StartCoroutine (WaitNext ());
		PushText ("Как раз пойду познакомлюсь."); yield return StartCoroutine (WaitNext ());
		PushText ("Подойдя чуть ближе, я услышал из домика…"); yield return StartCoroutine (WaitNext ());
		PushText ("И прекрати издеваться над Леной!","Ольга Дмитриевна"); yield return StartCoroutine (WaitNext ());
		PushText ("И тут лицо новобранца изобразило какой-то неописуемый страх."); yield return StartCoroutine (WaitNext ());
		PushText ("Чего он испугался-то?"); yield return StartCoroutine (WaitNext ());
		Uliana.SetSprite (Actor.Side.Center, "1grin", Actor.Side.Right);
		Uliana.Delete (Actor.Side.Left);
		Helen.SetSprite (Actor.Side.Right, "1normal");
		PushText ("Из домика выбежала Ульянка, а вслед за ней вышла девочка с синими волосами."); yield return StartCoroutine (WaitNext ());
		PushText ("Не обижайся ты на неё, Лен, она не со зла.","Славя"); yield return StartCoroutine (WaitNext ());
		PushText ("На этом моменте новичок громко выдохнул."); yield return StartCoroutine (WaitNext ());
		Helen.ChangeSprite ("1shy");
		Helen.Delete (Actor.Side.Left);
		PushText ("Покраснев, Лена (так вот как её зовут) быстро пошла в сторону площади, а незнакомец со Славей зашли в домик."); yield return StartCoroutine (WaitNext ());
		PushText ("Я решил подождать на шезлонге."); yield return StartCoroutine (WaitNext ());
		PushText ("Некоторое время я вслушивался в какие-то бессмысленные вопросы по типу «А когда следующий автобус?» и всё такое."); yield return StartCoroutine (WaitNext ());
		PushText ("Затем же мою голову опять начали наполнять посторонние мысли."); yield return StartCoroutine (WaitNext ());
		PushText ("Чего же он так испугался?"); yield return StartCoroutine (WaitNext ());
		PushText ("Имя что ли перепутал?"); yield return StartCoroutine (WaitNext ());
		PushText ("Гена? Бред какой-то."); yield return StartCoroutine (WaitNext ());
		PushText ("Рена? Ха-ха, да такого имени вообще нет!"); yield return StartCoroutine (WaitNext ());
		Music.Stop ();
		Environment.ChangeSound ("cicadas");
		PushText ("Мм? Мне показалось, или кузнечики стали стрекотать как-то громче?"); yield return StartCoroutine (WaitNext ());
		PushText ("Думаю, показалось."); yield return StartCoroutine (WaitNext ());
		Olga.SetSprite (Actor.Side.Center, "1smile");
		Slavya.SetSprite (Actor.Side.Right, "1normal");
		Olga.Delete (Actor.Side.Left);
		Slavya.Delete (Actor.Side.Left);
		Environment.ChangeSound ("birds");
		PushText ("Тем временем, из домика поочередно вышли Ольга Дмитриевна и Славя и направились куда-то по делам."); yield return StartCoroutine (WaitNext ());
		PushText ("Как хорошо, что меня не заметили, а то бы я сейчас пошёл куда-нибудь скамейки красить."); yield return StartCoroutine (WaitNext ());
		PushText ("Затем вышел новый пионер."); yield return StartCoroutine (WaitNext ());
		PushText ("Я встал, чтобы поздороваться."); yield return StartCoroutine (WaitNext ());
		PushText ("Что-то мне в нём показалось странным…"); yield return StartCoroutine (WaitNext ());
		PushText ("А, точно!"); yield return StartCoroutine (WaitNext ());
		PushText ("Тебе в пальто не жарко?","Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("Жарко.","Пионер"); yield return StartCoroutine (WaitNext ());
		PushText ("Эм. Ясно.","Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("Клоун."); yield return StartCoroutine (WaitNext ());
		PushText ("Тебя как звать?","Пионер"); yield return StartCoroutine (WaitNext ());
		PushText ("Меня Семён. А тебя?","Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("Санёк.","Пионер"); yield return StartCoroutine (WaitNext ());
		PushText ("Всё-таки ещё один Шурик. Я чуть не засмеялся."); yield return StartCoroutine (WaitNext ());
		PushText ("Очень приятно.","Санёк"); yield return StartCoroutine (WaitNext ());
		PushText ("Он протянул мне руку."); yield return StartCoroutine (WaitNext ());
		GameManaging.BloodMode = true;
		Music.Play ("Scarytale");
		Environment.Stop ();
		PushText ("ч … е … г … о … ?"); yield return StartCoroutine (WaitNext ());
		PushText ("Время остановилось. Морозный ветер начал обдувать меня, а непонятно откуда взявшиеся ледяные колья начали пронзать моё тело."); yield return StartCoroutine (WaitNext ());
		PushText ("Я начал ощущать близкое присутствие смерти."); yield return StartCoroutine (WaitNext ());
		PushText ("Каждый кусочек моего тела, каждая клеточка, каждая аминокислота начали умолять меня не брать эту руку."); yield return StartCoroutine (WaitNext ());
		PushText ("Не бери её!"); yield return StartCoroutine (WaitNext ());
		PushText ("Это бессмысленно."); yield return StartCoroutine (WaitNext ());
		PushText ("Ты сгинешь!"); yield return StartCoroutine (WaitNext ());
		PushText ("Но ведь он выглядит самым безобидным человеком на планете."); yield return StartCoroutine (WaitNext ());
		PushText ("Не вздумай делать этого!"); yield return StartCoroutine (WaitNext ());
		PushText ("Что вообще такое со мной происходит???"); yield return StartCoroutine (WaitNext ());
		PushText ("Не бери её, не бери её, не бери её, пожалуйста, не бери её, подумай о себе, не бери её, не бери её"); yield return StartCoroutine (WaitNext ());
		PushText ("Небериеёнебериеёнебериеёнебериеёнеберинеберинеберинеберинеберинеберинебери"); yield return StartCoroutine (WaitNext ());
		PushText ("Я собрал остатки разума и отошёл от него."); yield return StartCoroutine (WaitNext ());
		GameManaging.BloodMode = false;
		Music.Stop ();
		Environment.Play ("birds");
		PushText ("Эмм… взаимно!","Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("Что это было???"); yield return StartCoroutine (WaitNext ());
		PushText ("Если это какая-то болезнь, то это первое и какое-то странное её проявление."); yield return StartCoroutine (WaitNext ());
		PushText ("Извини за странный вопрос, а какой сейчас год?","Санёк"); yield return StartCoroutine (WaitNext ());
		PushText ("Мм? Хех! 1917ый! Ну знаешь там, и Ленин такой молодой, и всё остальное…","Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("Он выглядел несколько недоумённо."); yield return StartCoroutine (WaitNext ());
		PushText ("Ладно, бывай.","Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("Мне стоит о многом подумать, так что мне нужно побыть в одиночестве."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (Polyana); yield return StartCoroutine (WaitNext ());
		Music.Play ("Drown");
		Environment.Stop ();
		PushText ("…"); yield return StartCoroutine (WaitNext ());
		PushText ("Какого чёрта?"); yield return StartCoroutine (WaitNext ());
		PushText ("Что это за человек сюда приехал? Кто он такой? Чего он от меня хочет?"); yield return StartCoroutine (WaitNext ());
		PushText ("Он не выглядит каким-то особенным."); yield return StartCoroutine (WaitNext ());
		PushText ("И как такое вообще могло происходить?"); yield return StartCoroutine (WaitNext ());
		PushText ("Разве только это у меня в голове…"); yield return StartCoroutine (WaitNext ());
		PushText ("Тогда и Санёк не виноват ни в чём."); yield return StartCoroutine (WaitNext ());
		PushText ("Дерьмо, я не хочу в лечебницу!"); yield return StartCoroutine (WaitNext ());
		PushText ("Остаётся только один выход. Надеяться, что этого больше не произойдёт, а если произойдёт, то пытаться контролировать себя."); yield return StartCoroutine (WaitNext ());
		PushText ("Решено! Всё будет так же, как и раньше. Только нужно быть чуть внимательнее."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (Polyana_sunset); yield return StartCoroutine (WaitNext ());
		Music.Stop ();
		Environment.Play ("grasshopers");
		PushText ("Кажется, я немножко опоздал на ужин."); yield return StartCoroutine (WaitNext ());
		PushText ("Опять придётся есть одному, как утром."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (DiningHall_way_sunset); yield return StartCoroutine (WaitNext ());
		Alice.SetSprite (Actor.Side.Center, "4smile");
		Music.Play ("Silhouette In Sunset");
		PushText ("Возле столовки я встретил Алису."); yield return StartCoroutine (WaitNext ());
		PushText ("Месьё, не хотите поделиться частью своего ужина с прелестной дамой?","Алиса"); yield return StartCoroutine (WaitNext ());
		PushText ("Она что, не наелась?"); yield return StartCoroutine (WaitNext ());
		PushText ("Да и вообще, слишком уж я голоден, чтоб разбрасываться своими ужином направо и налево."); yield return StartCoroutine (WaitNext ());
		PushText ("А как же фигура, все дела?","Семён"); yield return StartCoroutine (WaitNext ());
		Alice.ChangeSprite ("3sad");
		PushText ("???"); yield return StartCoroutine (WaitNext ());
		Alice.Delete (Actor.Side.Left);
		PushText ("Похоже, она обиделась."); yield return StartCoroutine (WaitNext ());
		PushText ("Надо бы следить за языком."); yield return StartCoroutine (WaitNext ());
		PushText ("И поесть надо бы. Хочу есть."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (DiningHall_in_sunset); yield return StartCoroutine (WaitNext ());
		Environment.ChangeSound ("posuda");
		PushText ("…"); yield return StartCoroutine (WaitNext ());
		ChangeBackground (DiningHall_way_sunset); yield return StartCoroutine (WaitNext ());
		Environment.ChangeSound ("grasshopers");
		PushText ("Картошка с котлеткой неплохо зашли."); yield return StartCoroutine (WaitNext ());
		PushText ("Пока есть время (будто у меня его обычно нет), нужно сходить помыться."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (House_of_mt_sunset); yield return StartCoroutine (WaitNext ());
		PushText ("Я зашёл в домик за запасным комплектом одежды."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (Bathhouse); yield return StartCoroutine (WaitNext ());
		PushText ("И направился в баню."); yield return StartCoroutine (WaitNext ());
		PushText ("Там я хорошенько отстирал свою форму и отмылся сам."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (Square_night); yield return StartCoroutine (WaitNext ());
		PushText ("Чистый, опрятный и довольный я направился домой."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (House_of_mt_night); yield return StartCoroutine (WaitNext ());
		PushText ("Одежду я оставил сушиться снаружи."); yield return StartCoroutine (WaitNext ());
		ChangeBackground (House_of_mt_night_in); yield return StartCoroutine (WaitNext ());
		Environment.Stop ();
		Effects.ChangeSound ("door");
		PushText ("Спокойной ночи, Ольга Дмитриевна.","Семён"); yield return StartCoroutine (WaitNext ());
		Olga.SetSprite (Actor.Side.Center, "1smile");
		PushText ("Спокойной ночи, Семён.","Ольга Дмитриевна"); yield return StartCoroutine (WaitNext ());
		Olga.Delete ();
		ChangeBackground (House_of_mt_night_in2); yield return StartCoroutine (WaitNext ());
		PushText ("Сон пришёл очень быстро."); yield return StartCoroutine (WaitNext ());
		ShowDay ("ДЕНЬ 2", House_of_mt_in); yield return StartCoroutine (WaitNext ());
		CurrentLevel++;
		EndOf = false;
	}

	// Update is called once per frame
	void Update () {
		if (!EndOf) {
			switch (CurrentLevel)
			{
				case 0:
					StartCoroutine(Day0());
					break;
				case 1:
					StartCoroutine(Day1());
					break;
			}
			EndOf = true;
		}
	}

	void PushText(string text)
	{
		text = text.Insert (0, "\t");
		GameManaging.stText.AddString (text, "");
		StartCoroutine (GameManaging.PushText (text));
	}
	
	void PushText(string text, string author)
	{
		text = text.Insert (0, "\t");
		GameManaging.stText.AddString (text, author);
		StartCoroutine (GameManaging.PushText (text,author));
	}

	void ChangeBackground(string path)
	{
		StartCoroutine (GameManaging.ChangeBackground (path));
	}

	void ShowDay(string whattoshow, string initialBackground)
	{
		StartCoroutine (GameManaging.ShowDay (whattoshow, initialBackground));
	}

	IEnumerator WaitNext()
	{
		while ((!GameManaging.CanDoNext)) {
			yield return null;
		}
	}
}
