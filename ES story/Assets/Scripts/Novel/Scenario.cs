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
	void Start () {
		Stars = "stars";
		Boathouse_night = "ext_boathouse_night";
		House_of_mt_night = "ext_house_of_mt_night_without_light";
		Square_night = "ext_square_night";
		House_of_mt_night_in2 = "int_house_of_mt_night2";
		Club_screen = "d5_clubs_robot";

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

	IEnumerator TheScene()
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
	}

	// Update is called once per frame
	void Update () {
		if (!EndOf) {
			StartCoroutine(TheScene());
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

	IEnumerator WaitNext()
	{
		while ((!GameManaging.CanDoNext)) {
			yield return null;
		}
	}
}
