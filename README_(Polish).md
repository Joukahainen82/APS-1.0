# APS-1.0
Source code of APS, an application for processing data on vowels

---------------------------------------------
# FUNKCJE PROGRAMU APS
---------------------------------------------

Najważniejszym elementem programu APS była funkcja porównująca samogłoski badane z modelowymi. Zanim jednak doszło do właściwego porównania, konieczne było przetworzenie danych wejściowych, którymi były: 

- plik Readings.csv zawierający spis częstotliwości formantowych, spis segmentów z przypisanym tym segmentom symbolami fonetycznymi (transkrypcja A)  oraz lista symboli transkrypcji pomocniczych S, G i O); 

- plik Speakers.csv, w którym znajdowały się informacje na temat badanych; 

- plik Models.csv ze zbiorem modeli samogłosek opisanych względnymi częstotliwościami formantowymi. 

Fragmenty powyższych plików znajdują się poniżej. Wspomniane przetworzenie polegało na odczycie odpowiednich plików i przeniesienie zawartych w nich danych do list określonego typu. 

---------------------------------------------
## Pobranie danych z plików .csv

Pobranie danych polegało na wczytaniu informacji z plików .csv. Wykorzystano do tego celu funkcje poniższe funkcje: 

	public static List<Reading> GetReadings(string path)
	public static List<Speaker> GetSpeakers(string path)
	public static List<VowelModel> GetModels(string path)

Wszystkie powyższe metody korzystają z jednej uniwersalnej metody GetRecords(): 

	public static List<myClass> GetRecords<myClass>(string path, Type myClassMap = null, string delimiter = ";")

W powyższej funkcji zastosowano metody zewnętrznej biblioteki CsvHelper (https://joshclose.github.io/CsvHelper/). 

---------------------------------------------
## Analiza transkrypcji pomocnicznych A, S, G i O 

Analiza transkrypcji polegała na przypisaniu każdemu segmentowi ciągu fonów zawierających cechy artykulacyjne zgodne z symbolami fonetycznymi zawartymi w transkrypcji A. 
To zadanie, łącznie z dodaniem informacji o badanych, wykonywała pojedyncza metoda ProcessReadings(): 

	public static void ProcessReadings(List<Reading> readings, List<Speaker> speakers)

Funkcja nie zwraca wartości, ale przetwarza dane w kolekcji readings przy użyciu metod FindAndCorrectPhones, AddInfoOnSpeakers i AddInfoOnReadings: 

	private static List<Phone> FindAndCorrectPhones(string text, Library library)
	private static void AddInfoOnReadings(Reading r)
	private static void AddInfoOnSpeakers(Reading reading, List<Speaker> speakers)

Metoda FindAndCorrectPhones pobiera jako swoje parametry transkrypcję (ciąg znaków graficznych – text) oraz odpowiedni zbiór symboli z dopasowanymi cechami fonetycznymi (argument library typu Library). W metodzie tworzona jest nowa lista fonów; następuje posortowanie biblioteki przy użyciu metody GetSortedLibrary, a następnie odbywa się przypisywanie cech fonetycznych (metoda FindPhones6). Na końcu przypisywane są cechy fonetyczne wskazywane przez znaki diakrytyczne, a nierozpoznane symbole zamienia się na fony pozbawione cech artykulacyjnych. 

W metodzie AddInfoOnSpeakers znajduje się osobna metoda AddSpeaker użyta czterokrotnie (w odniesieniu do każdej transkrypcji pomocniczej). 

Oto nagłówki wspomnianych wyżej metod: 

	public static Dictionary<string, Phone> GetSortedLibrary(Library library)
	public static List<Phone> FindPhones6(string text, Dictionary<string, Phone> sortedLibrary)
	public static List<Phone> CorrectDiacritics5(List<Phone> phones)
	public static List<Phone> CorrectUnknownPhones2(List<Phone> phones)
	private static void AddSpeaker(List<Phone> phones, Speaker speaker, SpeakerType speakerType)

W metodzie CorrectDiacritics5 znajduje się osobna metoda dodająca symbole diakrytyczne: 

	private static Symbol AddSymbol(Phone phone, Phone diacritic, int diacriticImpact)

---------------------------------------------
## Analiza kontekstu 

Przypisanie każdemu fonowi oznaczeń kontekstów polega na sprawdzeniu, czy znajduje się on w danym kontekście. Temu służą następujące metody: 

	PhoneString.TagContext(Readings, PhoneString.V_neutral, ContextType.V_neutral);
	PhoneString.TagContext(Readings, PhoneString.Ṽ_, ContextType.Ṽ_);
	PhoneString.TagContext(Readings, PhoneString.Ṽ_S, ContextType.Ṽ_S);            
	PhoneString.TagContext(Readings, PhoneString.Ṽ_T, ContextType.Ṽ_T);            
	PhoneString.TagContext2(Readings, PhoneString.V_ł, new List<PhoneString.Comparer>() { PhoneString.rz_V, PhoneString.cz_V }, ContextType.V_ł);
	PhoneString.TagContext2(Readings, PhoneString.V_l, new List<PhoneString.Comparer>() { PhoneString.rz_V, PhoneString.cz_V }, ContextType.V_l);
	PhoneString.TagContext2(Readings, PhoneString.V_rz, new List<PhoneString.Comparer>() { PhoneString.rz_V, PhoneString.cz_V }, ContextType.V_rz);
	PhoneString.TagContext2(Readings, PhoneString.V_r, new List<PhoneString.Comparer>() { PhoneString.rz_V, PhoneString.cz_V }, ContextType.V_r);
	PhoneString.TagContext2(Readings, PhoneString.V_j, new List<PhoneString.Comparer>() { PhoneString.rz_V, PhoneString.cz_V }, ContextType.V_j);
	PhoneString.TagContext2(Readings, PhoneString.cz_V, new List<PhoneString.Comparer>  { PhoneString.V_ł, PhoneString.V_l, PhoneString.V_r, PhoneString.V_rz, PhoneString.ć_V_N, PhoneString.V_N, PhoneString.V_j  }, ContextType.cz_V);
	PhoneString.TagContext2(Readings, PhoneString.rz_V, new List<PhoneString.Comparer>  { PhoneString.V_ł, PhoneString.V_l, PhoneString.V_r, PhoneString.V_rz, PhoneString.ć_V_N, PhoneString.V_N, PhoneString.V_j  }, ContextType.rz_V);
	PhoneString.TagContext(Readings, PhoneString.ć_V_N, ContextType.ć_V_N);
	PhoneString.TagContext2(Readings, PhoneString.V_N,  new List<PhoneString.Comparer>() { 	PhoneString.rz_V, PhoneString.cz_V }, ContextType.V_N);

Przypisywanie kontekstu wymagało wykorzystania 2 metod (TagContext i TagContext2), ponieważ pewne typy konteksty wymagały sprawdzenia nie tylko tego, czy określone fony występują w sąsiedztwie analizowanego fonu, ale także, czy odpowiednie fony się w tym sąsiedztwie nie znajdują. Dystrybucję wykluczającą przypisanie danego typu kontekstu zawierała metoda TagContext2: 

	public static void TagContext(List<Reading> readings, Comparer method, ContextType contextType)
	public static void TagContext2

Powyższe metody sprawdzają obecność danych kontekstów przy użyciu osobnej funkcji przekazywanej jako parametr method. Po stwierdzeniu, że dany fon znajduje się w określonym kontekście, następowało przypisanie oznaczenia kontekstu metodą ApplyContexts: 

	private static void ApplyContexts(Reading reading, ContextType contextType)

A oto spis metod sprawdzających obecność danego kontekstu: 

	//Kontekst neutralny
	public static bool V_neutral(Reading reading, List<Reading> readings)

	// Samogłoska nosowa (transkrypcja S) w wygłosie.
	public static bool Ṽ_(Reading reading, List<Reading> readings)

	//Samogłoska nosowa przed spółgłoską szczelinową 
	public static bool Ṽ_S(Reading reading, List<Reading> readings)

	//Spółgłoska zwarta po samogłosce nosowej 
	public static bool Ṽ_T(Reading reading, List<Reading> readings)

	//Spółgłoska [ł] po samogłosce ustnej
	public static bool V_ł(Reading reading, List<Reading> readings)

	//Spółgłoska płynna po samogłosce ustnej 
	public static bool V_l(Reading reading, List<Reading> readings)

	//Spółgłoska ustna przed rz 
	public static bool V_rz(Reading reading, List<Reading> readings)

	//Samogłoska ustna przed [r]
	public static bool V_r(Reading reading, List<Reading> readings)

	//Samogłoska ustna przed [j]
	public static bool V_j(Reading reading, List<Reading> readings)

	//Samogłoska ustna po spółgłoskach szumiących za wyjątkiem rz
	public static bool cz_V(Reading reading, List<Reading> readings)

	//Spółgłoska ustna po rz
	public static bool rz_V(Reading reading, List<Reading> readings)

	//Samogłoska ustna po spółgłosce miękkiej, a przed nosową
	public static bool ć_V_N(Reading reading, List<Reading> readings)

	//Samogłoska ustna przed spółgłoską nosową
	public static bool V_N(Reading reading, List<Reading> readings)

Ponieważ niektóre z powyższych metod wykorzystują inne metody sprawdzające typ kontekstu, przed ich wykonaniem listę fonów uzupełniano o ich dystrybucje (zbiór otoczeń do 3. fonu w pre- i postpozycji; liczba 3 wynika stąd, iż w transkrypcjach pomocniczych osobno notowane były zakończenia wyrazów oraz pauzy; oba elementy występowały czasem łącznie, tak wiec kolejny/poprzedni fon  posiadający cechy artykulacyjne mógł się znaleźć na maksymalnie 3 pozycji względem bieżącego fonu) metodą GetBothContexts. Nie powodowało to zdublowania danych, ale zapewniało poprawne rozpoznanie kontekstu. Oto nagłówek metody GetBothContexts: 

	public static void GetBothContexts

Powyższa metoda wykorzystuje osobne funkcje zwracające lewe i prawe otoczenie każdego fonu. Odnalezienie 3 sąsiadujących fonów w pre- i postpozycji każdego fonu nie jest prostym zadaniem, gdy mamy do czynienia z dwupoziomową listą (listą w innej liście): lista pierwszego poziomu (zewnętrza) to lista odczytów (typ Readings – odczytami stały się wszystkie segmenty wydzielone podczas analizy spektrogramu), a druga lista, a w zasadzie zbiór list, to listy fonów przypisanych każdemu odczytowi. Z tego też powodu opracowano osobne metody zwracające lewe i prawe otoczenie foniczne każdego fonu: 

	public static Phone[] GetLeftContext(List<Reading> readings, Reading reading, Phone phone, Transcriptions transcription)
	public static Phone[] GetRightContext(List<Reading> readings, Reading reading, Phone phone, Transcriptions transcription)

---------------------------------------------
## Rozpoznanie kontynuantów

Każdy fon samogłoskowy otrzymał odpowiednie oznaczenie zależnie od tego, z kontynuacją jakiej samogłoski staropolskiej mamy do czynienia. Przypisania dokonywano na podstawie transkrypcji pomocniczej S; do tego celu użyto metody TagContinuants o następującej definicji: 

	public static void TagContinuants(ref List<Reading> readings)

Powyższa metoda najpierw tworzy słownik  zawierający oznaczenia samogłosek staropolskich oraz cechy artykulacyjne tych samogłosek zebrane w fony. W drugiej części metody następuje przejrzenie wszystkich odczytów, a przy każdym odczycie – przejrzenie wszystkich pozycji utworzonego słownika. Jeśli tylko odczyt posiada wartość częstotliwości formantowej (a to zdarzało się tylko wówczas, gdy odczyt zawierał segment przeznaczony do analizy), następowało właściwe przypisanie samogłoski staropolskiej. W tym celu wykorzystano metodę ContainsOnlyVowel, która sprawdzała, czy w odczycie znajduje się wyłącznie jedna samogłoska (ewentualnie uzupełniona fonem odsyłającym do pauzy lub granicy międzywyrazowej). Obecność samogłoski weryfikowano na podstawie transkrypcji pomocniczych A i S. Dodatkowo funkcja Contains testowała obecność cech fonetycznych samogłoski staropolskiej (pobranych ze wspomnianego wcześniej słownika). 

Oto nagłówe metody ContainsOnlyVowel (funkcja Contains stanowi już element języka C#): 

	public static bool ContainsOnlyVowel(Reading reading, Transcriptions transcription)

---------------------------------------------
## Obliczenia częstotliwości względnych

Następnym krokiem były obliczenia względnych częstotliwości formantowych, wykonywane przy użyciu metody CountRelativeFrequencies: 

	public static void CountRelativeFrequencies(List<Reading> readings)

Funkcja ta przegląda wszystkie odczyty (typ Readings). Przy każdym odczycie sprawdzane są 4 warunki: dostępność częstotliwości bezwzględnych (wystarczy, że f_1 jest większe od zera), dostępność częstotliwości skrajnych (f_min i f_max), obecność fonu wymówionego przez informatora (właściwość SpeakerType ma wartość Informator), i wreszcie obecność samogłoski lub półsamogłoski (metody sprawdzające obecność wyłącznie samogłoski lub półsamogłoski w transkrypcji A zwracają prawdę). Nagłówek metody ContainsOnlyVowel był już podany wcześniej; poniżej przedstawiamy nagłówek metody ContainsOnlySemivowel: 

	public static bool ContainsOnlySemivowel(Reading reading, Transcriptions transcription)

Zanim częstotliwości względne zostały przetworzone na bezwzględne, wykonywano sprawdzenie, czy wartości częstotliwości względnych mieszczą się w typowych wartościach. Zdarzają się bowiem w programie Praat (tego programu użyto do pomiarów częstotliwości formantowych) błędne odczyty częstotliwości, zwykle w przypadku znacznego zbliżenia 2 formantowych. W takiej sytuacji dwa formanty znajdujące się blisko siebie (mające podobne częstotliwości) są traktowane przez algorytm zaimplementowany w programie Praat jako jeden formant, a za kolejny formant (np. 2.) uznaje się formant w rzeczywistości o 1 wyższy (np. 3.), który przyjmuje zupełnie inne wartości. Tego typu błędy mogły powodować niewłaściwe rozszerzanie rozstępu częstotliwości (różnicy f_max-f_min), fałszując rozpoznania samogłosek (częstszym przypisywaniem modeli samogłosek wysokich i tylnych). Oto nagłówek metody CheckF: 

        public static bool CheckF(double F,  int no)

Typowe wartości częstotliwości formantowych zapisano we właściwości typicalFrequencies o następującej definicji: 

        private static readonly Frequency[] typicalFrequencies = new[] {
            new Frequency(100, 400, 1400, 3000), 
            new Frequency(1000, 2800, 4000, 5000)
        };

Za typowe przedziały bezgwzględnych częstotliwości formantowych uznano następujące wartości: 

| Formant: | F1 | F2 | F3 | F4 |
| -------- | -- | -- | -- | -- |
| Minimum: | 100 Hz | 400 Hz | 1400 Hz | 3000 Hz |
| Maksimum: | 1000 Hz | 28000 Hz | 4000 Hz | 5000 Hz |

Samo obliczenie częstotliwości względnej wykonywane było w operatorze ternarnym (trójwartościowym), o następującej postaci ogólnej: A ?B∶C. Element A zawiera wartość logiczną (w naszym przypadku to metoda CheckF); jeśli tą wartością jest prawda, wówczas cały operator zwraca wartość B, w przeciwnym razie – wartość C. Tą ostatnią wartością była w omawianej funkcji stała NaN (z ang. not a number) wskazujaca, że uzyskany wynik nie jest liczbą. 

---------------------------------------------
## Przypisanie modeli samogłoskowych

Przypisanie modeli poprzedzone było pobraniem danych samogłosek modelowych z pliku Models.csv. Użyto do tego celu metody GetModels: 

	public static List<VowelModel> GetModels(string path)

Metoda wykorzystuje opisaną wcześniej metodę GetRecords pobierającą dane z pliku o podanej ścieżce dostępu (argument path). Dodatkowo wykorzystywany jest model typu danych (argument typeof(VowelModelMap)) pozwalający przenieść dane z pliku do odpowiednich właściwości typu Model. 

Za przypisanie modeli każdej samogłosce (spełniającej określone warunki ) odpowiadała metoda AppendModels: 

	public static void AppendModels(List<Reading> Readings, List<VowelModel> models, bool use4thFormant)

Powyższa metoda przyjmuje jako swoje argumenty listę odczytów (Readings), listę modeli (models) oraz warunek określający zastosowanie 4. formantu (use4thFormant). W samej metodzie natomiast następowało przejrzenie wszystkich odczytów i odnajdowanie modelu dla każdego odczytu. Za to z kolei odpowiadała metoda FindModel: 

	public static VowelModel FindModel(Reading reading, List<VowelModel> models, bool use4thFormant)

W metodzie FindModel następuje przejrzenie wszystkich modeli podanych jako argument models. Dla każdego modeli oblicza się odległość (zmienna distance) tego modelu od samogłoski w odczycie. Następnie, po utworzeniu listy odległości, ustala się najmniejszą odległość (zmienna minDistance) i zwraca model znajdujący się w tej samej pozycji, co ta minimalna odległość (lista odległości odpowiada liście modeli, gdyż utworzona została podczas przeglądania listy modeli). Model ten przypisywany jest właściwości VowelModel znajdującej się w każdym odczycie. 

---------------------------------------------
## Wyświetlenie wyników 

Ostatnim elementem było wyświetlenie uzyskanych wyników oraz list przykładów. Pierwsze zadanie wykonywane było przez metodę ShowData: 

	public static void ShowData(List<Reading> Readings, List<VowelModel> Models, bool use4thFormant = false)

W powyższej metodzie została wielokrotnie użyta funkcja PresentData, która wyświetlała w układzie tabelarycznym wyniki rozpoznawania samogłosek spełniających określone warunki. Argumentami wejściowymi tej metody były: lista odczytów, lista modeli, wartość logiczna wskazujące użycie 4. formantu oraz funkcja wykonujące odpowiednie obliczenia. 

Z uwagi na fakt, że poszczególne wyniki należało przedstawiać w nieco inny sposób, opracowano kilka wariantów funkcji PresentData. Oto nagłówek jednego z nich:

	public static void PresentData(
		ApsFunction function, 
		int examples, 
		List<Reading> readings, 
		List<VowelModel> models, 
		bool use4thFormant)

Funkcja przetwarzająca dane wprowadzana jest parametrem function, liczba przykładów – examples, lista odczytów – readings, lista modeli – models, warunek uwzględnienia 4. formantu – use4thFormant. Wewnątrz modeli następowało przetworzenie danych przy użyciu przekazanej funkcji function, a następnie wyświetlenie danych ze zmiennej res w formie tabeli. 

Oto przykłady 2 metod przetwarzających dane, przekazywanych do metody PresentData: 

- VowelsInNeutranContext – rozpoznania samogłosek w kontekstach neutralnych bez uwzględnienia cech demograficznych badanych: 

	public static List<VowelRecognition> VowelsInNeutralContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)

- VowelsInṼ_Context – kontynuanty samogłosek ustnych w wygłosie bez uwzględnienia cech demograficznych: 

	public static List<VowelRecognition> VowelsInṼ_Context(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)

Powyższe 2 metody różnią się jedynie wartością zmiennej condition, określającej warunek uwzględnienia rozpoznań w obliczeniach. Oto spis pozostałych metod przetwarzających dane do wyświetlenia wraz z użytymi w nich wartościami zmiennej condition: 

- VowelsInṼ_SContext – kontynuanty samogłosek nosowych przed spółgłoskami szczelinowymi: 

	public static List<VowelRecognition> VowelsInṼ_SContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.Ṽ_S);

- VowelsInṼ_TContext – kontynuanty dawnych nosówek przed zwartymi: 

	public static List<VowelRecognition> VowelsInṼ_TContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.Ṽ_T);

- VowelsInV_łContext – kontynuanty samogłosek ustnych przed spółgłoską ł: 

	public static List<VowelRecognition> VowelsInV_łContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_ł);

- VowelsInV_lContext – kontynuanty samogłosek ustnych przed spółgłoską l: 

	public static List<VowelRecognition> VowelsInV_lContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_l);

- VowelsInV_rzContext – kontynuanty samogłosek ustnych przed dawnym r’ (obecnie [ʃ ʒ] zapisywane dwuznakiem <rz>): 

	public static List<VowelRecognition> VowelsInV_rzContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_rz);

- VowelsInV_rContext – kontynuanty samogłosek ustnych przed r: 

	public static List<VowelRecognition> VowelsInV_rContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_r);

- VowelsInV_jContext – kontynuanty samogłosek ustnych przed j: 

	public static List<VowelRecognition> VowelsInV_jContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_j);

- VowelsIncz_VContext – kontynuanty samogłosek ustnych po spółgłoskach stwardniałych (dawnych č́, ǯ́, š́, ž́, obecnie [t͡ʃ d͡ʒ ʃ ʒ], zapisywanych jako <cz dż sz ż>): 

	public static List<VowelRecognition> VowelsIncz_VContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.cz_V);

- VowelsInrz_VContext – kontynuanty samogłosek ustnych po dawnym r’, obecnie [ʒ ʃ] zapisywane dwuznakiem <rz>: 

	public static List<VowelRecognition> VowelsInrz_VContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.rz_V);

- VowelsInć_V_NContext – kontynuanty samogłosek ustnych po spółgłoskach miękkich i przed spółgłoskami nosowymi: 

	public static List<VowelRecognition> VowelsInć_V_NContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.ć_V_N);

- VowelInV_NContext – kontynuanty samogłosek ustnych przed spółgłoskami nosowymi: 

	public static List<VowelRecognition> VowelsInV_NContext(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_N);

- VowelsNeutralBeginning – kontynuanty samogłosek ustnych w kontekstach neutralnych; próbki z początku wypowiedzi badanych: 

	public static List<VowelRecognition> VowelsNeutralBeginning(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, ExcerptNo.beginning);

- VowelsNeutralEnd – kontynuanty samogłosek ustnych w kontekstach neutralnych; próbki z końca wypowiedzi badanych: 

	public static List<VowelRecognition> VowelsNeutralEnd(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, ExcerptNo.end);

- VowelsNeutralAgeYoung – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani w młodym wieku: 

	public static List<VowelRecognition> VowelsNeutralAgeYoung(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, Age.young);

- VowelsNeutralAgeMiddle – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani w średnim wieku:

	public static List<VowelRecognition> VowelsNeutralAgeMiddle(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, Age.middleAged);

- VowelsNeutralAgeOld – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani w starszym wieku:

	public static List<VowelRecognition> VowelsNeutralAgeOld(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, Age.old);

- VowelsNeutralEducationPrimary – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani o wykształceniu podstawowym:

	public static List<VowelRecognition> VowelsNeutralEducationPrimary(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, null, Education.primary);

- VowelsNeutralEducationMiddle – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani o wykształceniu gimnazjalnym:

	public static List<VowelRecognition> VowelsNeutralEducationMiddle(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, null, Education.middle);

- VowelsNeutralEducationSecondary – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani o wykształceniu średnim:

	public static List<VowelRecognition> VowelsNeutralEducationSecondary(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, null, Education.secondary);

- VowelsNeutralEducationVocational – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani o wykształceniu zawodowym:

	public static List<VowelRecognition> VowelsNeutralEducationVocational(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, null, Education.vocational);

- VowelsNeutralEducationHigher – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani o wykształceniu wyższym:

	public static List<VowelRecognition> VowelsNeutralEducationHigher(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, null, Education.higher);

- VowelsNeutralPlaceVillage – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani mieszkający na wsi:

	public static List<VowelRecognition> VowelsNeutralPlaceVillage(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, null, null, PlaceType.village);

- VowelsNeutralPlaceVillage – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani mieszkający w małym mieście:

	public static List<VowelRecognition> VowelsNeutralPlaceTown(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, null, null, PlaceType.town);

- VowelsNeutralPlaceCity – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani mieszkający w dużym mieście:

	public static List<VowelRecognition> VowelsNeutralPlaceCity(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, null, null, PlaceType.city);

- VowelsNeutralDwellingTimePartOfLive – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani mieszkający w swojej miejscowości część życia:

	public static List<VowelRecognition> VowelsNeutralDwellingTimePartOfLive(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, null, null, null, DwellingTime.partOfLife);

- VowelsNeutralDwellingTimeWholeLife – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani mieszkający w swojej miejscowości całe życie:

	public static List<VowelRecognition> VowelsNeutralDwellingTimeWholeLife(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, null, null, null, DwellingTime.wholeLife);

- VowelsNeutralParentsOriginBoth – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani, których oboje rodziców pochodziło z tej samej miejscowości, co badani:

	public static List<VowelRecognition> VowelsNeutralParentsOriginBoth(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, null, null, null, null, ParentsOrigin.bothFromTheSamePlace);

- VowelsNeutralParentsOriginMother – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani, których matki pochodziły z tej samej miejscowości, co badani:

	public static List<VowelRecognition> VowelsNeutralParentsOriginMother(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, null, null, null, null, ParentsOrigin.motherFromTheSamePlace);

- VowelsNeutralParentsOriginDifferent – kontynuanty samogłosek ustnych w kontekstach neutralnych; badani, których oboje rodziców pochodziło z innej miejscowości niż badani:

	public static List<VowelRecognition> VowelsNeutralParentsOriginDifferent(List<Reading> readings, List<VowelModel> vowelModels, bool use4thFormant)
	var condition = new Condition(i, ContextType.V_neutral, null, null, null, null, null, ParentsOrigin.bothFromDifferentPlaceOrOnlyFatherFromTheSame);

---------------------------------------------
## Konteksty Vj 

W przypadku kontekstów typu +j zastosowano podział rozpoznań zależnie kategorii gramatycznej oraz od pozycji w struktrurze morfologicznej formy. Z tego powodu konieczne było zastosowanie nieco innej metody, która przyjmowała jako argument dodatkowy element, nazwany skrótowo „kategorią morfologiczną”. Oto nagłówek nadrzędnej metody ShowDataV_jMC:  

	public static void ShowDataV_jMC(List<Reading> Readings, List<VowelModel> Models, bool use4thFormant = false)

W metodzie ShowDataV_jMC wykorzystano zmodyfikowaną wersję metody PresentData (z dopiskiem 2), przyjmującej dodatkowy argument MorphCategory („kategoria morfologiczna”):
 
	public static void PresentData2
		(ApsFunction2 function, 
		int examples, 
		List<Reading> readings, 
		List<VowelModel> models, 
		MorphCategory morphCategory, 
		bool use4thFormant)

Od metody PresentData różni się jedynie dodatkowym argumentem przekazywanym do funkcji function. 

---------------------------------------------
## Tworzenie list rozpoznań

W wywołaniach funkcji PresentData i PresentData2 wykorzystano podobne metody zwracające w wyniku listę rozpoznań (modeli samogłosek wraz z liczbą wystąpień, przepisaną samogłoską staropolską i listą przykładów). W przypadku PresentData były to opisane wyżej metody (VowelsInNeutralContext, VowelsInṼ_Context itd.); w metodzie PresentData2 z kolei  jako argument function wykorzystano metodę V_j, wszystkie te metody miały identyczną budowę, którą zilustrowano niżej na przykładzie funkcji V_j: 

	public static List<VowelRecognition> V_j
		(List<Reading> readings, 
		List<VowelModel> vowelModels, 
		MorphCategory morphCategory, 
		bool use4thFormant)

Rozpoznanie (dopasowanie do modeli) polegało na przejrzeniu wszystkich modeli samogłoskowych (w pętli foreach), a następnie przypisaniu wartości następujących zmiennych: 

- continuants – liczba kontynuantów danej samogłoski staropolskiej bez uwzględnienia kontekstu (niezależnie od kontekstu, w jakiej występuje); do obliczeń używana jest metoda ConditionalCount; 

- condition – zbiór warunków, jakie musi spełnić odczyt (zmienna typu Reading, pojedynczy segment wydzielony podczas analizy spektrogramu), by został uwzględniony w rozpoznawaniu samogłoski; 

- counter – jak continuants, ale z uwzględnieniem kontekstu (a więc jest to liczba kontynuantów danej samogłoski staropolskiej w określonym kontekście); 

- examples – zbiór przykładów zawierających realizacje danej samogłoski staropolskiej w określonym kontekście; 

- recognition – model samogłoski przypisany danemu odczytowi; 

- vowelCode – kod modelu samogłoski zawartego w zmiennej recognition; 

- ipaSymbol – symbol przypisanego modelu. 

Istotne w dopasowaniu modelu samogłoski do badanego odczytu są metody ConditionalCount, ConditionalMedian, GetExamples i FindModel. Pierwsza liczy odczyty spełniające podany zestaw warunków: 

	public static int ConditionalCount(List<Reading> readings, Condition conditions)

W powyższej metodzie wykorzystano metodę ConditionChecker, która sprawdza, czy dany odczyt spełnia podane warunki: 

	public static bool ConditionChecker(Reading reading, Condition condition)

Metoda ta sprawdza jednoczesne spełnienie aż 10 warunków: 

- czy odczyt zawiera głoskę wymówioną przez badanego; 

- czy odczyt zawiera kontynuant danej samogłoski staropolskiej; 

- czy odczytowi przypisano analizowany kontekst; 

- czy odczyt pochodzi z właściwej części wypowiedzi (początku lub końca); 

- czy odczyt należy do mówcy w określonym wieku; 

- czy odczyt należy do mówcy o określonym wykształceniu; 

- czy odczyt należy do mówcy mieszkającego w określonym typie miejscowości; 

- czy odczyt należy do mówcy o określonym czasie zamieszkania w swojej miejscowości; 

- czy pochodzenie rodziców mówcy, który wypowiedział głoskę znajdującą się w odczycie, jest zgodne z podanym warunkiem; 

- czy przypisana odczytowi „kategoria gramatyczna” (właściwość MorphCategory) jest zgodna z podaną w warunku. 

Metoda ConditionalMedian oblicza medianę warunkową częstotliwości formantowych, tzn. medianę tych częstotliwości formantowych, które znajdują się w odczytach spełniających podane warunki: 

	public static Frequency ConditionalMedian(List<Reading> readings, Condition conditions)

Powyższa metoda przegląda wszystkie odczyty przekazane do niej przez argument readings, sprawdzając, czy spełniają podane warunki (argument conditions). Do tego celu wykorzystywana jest metoda ConditionChecker. Odczyty spełniające wskazane warunki trafiają do tymczasowej listy odczytów list. W następnej kolejności do zmiennej lokalnej res przypisuje się obliczone mediany bezwzględnych częstotliwości formantowych. Do obliczeń wykorzystuje się metodę Median: 

	public static bool ConditionChecker(Reading reading, Condition condition)
	public static double Median(List<double> list)

Metoda ConditionChecker sprawdza aż 10 warunków; są nimi: przypisanie odczytu mówcy, zgodność kontynuantu (czy odczyt zawiera samogłoskę kontynuującą daną samogłoskę staropolską), zgodność kontekstu, odpowiedniość miejsca w nagraniu (czy odczyt pochodzi z początku lub końca wypowiedzi), odpowiedniość wieku, wykształcenia, pochodzenia i czasu zamieszkania badanego w danej miejscowości, zgodność pochodzenia rodziców badanego, i wreszcie odpowiedniość „kategorii morfologicznej”. Wszystkie 10 warunków musi być spełnionych, by funkcja zwróciła prawdę. 

Z kolei metoda Median analizuje 3 sytuacje: liczba posegregowanych odczytów (w zmiennej list) jest równa zero (wówczas zwracana jest wartość NaN – wartość nie będąca liczbą), jest parzysta (wówczas zwracana jest średnia arytmetyczna wartości o indeksach n-1 oraz n) lub jest nieparzysta (wówczas zwracany jest element o indeksie n, gdzie n to całkowitoliczbowy iloraz liczby elementów w argumencie list i dwójki). 

Metoda GetExamples zwraca listę adresów (nr odczytu, nr próbki, nr odczytu) odczytów spełniających łącznie warunki pozwalające uwzględnić je w obliczeniach, jest to więc jednocześnie lista adresów przykładowych form: 

	public static List<string> GetExamples(List<Reading> readings, Condition conditions)

I wreszcie najważniejsza metoda – FindModel – odnajdująca najbardziej podobny model samogłoski: 

	public static VowelModel FindModel(Reading reading, List<VowelModel> models, bool use4thFormant)

Działanie metody FindModel jest następujące: przy użyciu metody CountDistance tworzona jest lista odległości (zmienna distances) między każdym modelem a odczytem (argument reading; dokładniej chodzi o samogłoskę w odczycie), następnie obliczana jest minimalna odległość (minDistance), ustalana jest pozycja tej minimalnej odległości (position) i wreszcie zwracany jest model o indeksie równym pozycji minimalnej odległości. Użyta funkcja CountDistance ma następujący nagłówek: 

	public static double CountDistance(Reading reading, VowelModel model, bool use4thFormant)

W powyższej metodzie uwzględniono wagi – zmienne d1, d2, d3, d4. W wykonanych obliczeniach były to odwrotności średnich wariancji odpowiednich bezwzględnych częstotliwości formantowych zmierzonych w wymówieniach kilku fonetyków brytyjskich (Rybka, 2014, 2015a). Oto definicja tychże wag w postaci tablicy wartości rzeczywistych wykorzystanych w kodzie programu APS (w kolejności od odwrotności wariancji częstotliwości pierwszego formantu): 

	private static readonly double[] weights = new[]{
		125.2055928,
		176.824207,
		34.38832733,
		22.50366091        
	};

Zastosowanie wag pozwoliło zróżnicować wpływ poszczególnych częstotliwości formantowych na określenie odległości między samogłoskami modelowymi, a tym samym na przypisanie najbliższego modelu. Jak widać, największe wagi pojawiły się w przypadku formantu drugiego i pierwszego (powyżej 100) – te wartości miały zatem decydujący wpływ na przypisanie modelu. Mniejsze znaczenie miały wagi odnoszące się do częstotliwości formantu trzeciego i czwartego. 

---------------------------------------------
Listy przykładów

Osobnej metody użyto do wyświetlenia przykładów na podstawie adresów (nr odczytu, nr nagrania i nr fragmentu). Oto przykładowy fragment kodu zawierający adresy form i metodę wyświetlającą przykłady: 

	string[][] adresy = {
		new[] {"1/1/14", "1/1/120", "1/1/212", "1/1/223", "1/1/329"}, 
		new[] {"1/1/19", "1/1/136", "1/1/192", "1/1/198", "1/1/285"}, 
		new[] {"1/1/16", "1/1/93", "1/1/110", "1/1/130", "1/1/140"}, 
		new[] {"1/1/337", "1/1/444", "1/1/455", "2/2/69", "2/2/80"}, 
		new[] {"1/1/35", "1/1/44", "1/1/60", "1/1/72", "1/1/105"}, 
		new[] {"1/1/49", "1/1/51", "1/1/81", "1/1/216", "1/1/219"}, 
		new[] {"1/1/8", "1/1/23", "1/1/26", "1/1/38", "1/1/55"}, 
		new[] {"1/2/454", "1/2/471", "1/2/480", "4/2/437", "10/1/350"}, 
		new[] {"1/1/33", "1/1/42", "1/1/79", "1/1/178", "1/1/368"}, 

	foreach (var i in adresy)
	{
		foreach (var j in i)
		{
			ApsManager.ApsManager.GetExamples3(j, Readings, 10);
		}
	}

Jak widzimy, jest to wariant przedstawionej wyżej metody GetExamples, tym razem jednak nie mamy do czynienia ze zwróceniem wartości, ale wyświetleniem ich na ekranie komputera: 

	public static void GetExamples3(string location, List<Reading> readings, int span = 5)

---------------------------------------------
Nasycenie gwaryzmami i różnice artykulacyjne

Informacje dotyczące nasycenia wypowiedzi gwaryzmami oraz różnic artykulacyjnych między realizacjami zwracane były przez jeszcze inne metody – PresentDataOnSaturation (nasycenie gwaryzmami), PresentDataOnSaturationComparison (jak poprzednio, ale z podziałem na początek i koniec wypowiedzi), PresentDataOnDifferences (różnice artykulacyjne) oraz PresentDataOnDifferencesComparison (jak wcześniej, lecz z podziałem na próbki z początku i z końca nagrania). Przed każdym wywołaniem tych funkcji definiowano argumenty tych funkcji, zawierające niezbędne wartości. Oto przykład dla danych dotyczących wykształcenia: 

	var variantNames = new[] { "początek", "koniec" };
	var variants = new[] { new Condition(null, null, ExcerptNo.beginning), new Condition(null, null, ExcerptNo.end) };

	var age_c = new[] 
	{
		new Condition(null, ContextType.V_neutral, null, Age.young), 
		new Condition(null, ContextType.V_neutral, null, Age.middleAged), 
		new Condition(null, ContextType.V_neutral, null, Age.old)
	};

	var age_n = new[] { "osoby młode", "osoby w średnim wieku", "osoby starsze" };

	var age = "Nasycenie gwaryzmami wypowiedzi osób w danym wieku.";

	ApsInterface.PresentDataOnSaturation(Readings, age_c, age_n, age);

	age = "Nasycenie gwaryzmami NA POCZĄTKU wypowiedzi osób w danym wieku."; 
                                    
	ApsInterface.PresentDataOnSaturationComparison(Readings, age_c, variants, age_n, variantNames, age); 

	age = "Różnice artykulacyjne między wypowiedziami osób w danym wieku.";

	ApsInterface.PresentDataOnDifferences(Readings, age_c, Models, age_n, age, use4thformant, showData, numberOfExamples);

	age = "Różnice artykulacyjne między wypowiedziami osób w danym wieku i POCZĄTKIEM a KOŃCEM nagrania.";

	ApsInterface.PresentDataOnDifferencesComparison(Readings, age_c, variants, Models, age_n, variantNames, age, use4thformant, showData, numberOfExamples); 

W podanych wyżej metodach wykorzystywane były 3 główne metody: N – metoda zwracająca liczbe gwaryzmów fonetycznych, W – metoda zwracajaca liczbe wyrazów ortograficznych oraz R – metoda zwracająca liczbę różnic artykulacyjnych między rozpoznaniami (listami zmiennych typu VowelRecognition): 

	public static int N(List<Reading> readings, Condition condition)
	public static int W(List<Reading> readings, Condition condition)
	public static int R(List<Reading> readings, Condition conditionA, Condition conditionB, bool use4thFormant = false)
	private static int R(List<VowelRecognition> recognitionA, List<VowelRecognition> recognitionB)

We wszystkich powyższych funkcjach następuje przejrzenie wszystkich odczytów (zmienna readings); wyjątkiem jest jedynie funkcja R, w której przeglądany jest zbiór samogłosek staropolskich (zmienna oldPolishVowels). W metodzie N sprawdzane są wszystkie fony transkrypcji G, S oraz O. Każdy przypadek różnicy między tymi transkrypcjami powoduje zwiększenie licznika cech gwarowych o 1 (zmienna res). Z kolei metoda W oblicza wystąpienia symbolu granicy wyrazu: <#> (funkcja Count zwracajaca wynik dodawany do zmiennej res). I wreszcie funkcja R tworzy 2 listy rozpoznań (zmienne resA i resB) w taki sam sposób, jak omówione wyżej metody (np. VowelsInNeutralContext, V_j) i oblicza różnicę artykulacyjną przy użyciu dodatkowej metody R. Ta ostatnia funkcja przegląda wszystkie rozpoznania i oblicza wartość bezwzględną (funkcja Abs) między odpowiednimi etykietami kodu samogłosek: przedniością (właściwość Frontness), wysokością (Height) i zaokrągleniem (Roundness). 

---------------------------------------------
TYPY DANYCH W PROGRAMIE APS

Omawiając w poprzedniej części poszczególne metody programu APS, wielokrotnie wspominaliśmy o pewnych typach danych, np. Reading, VowelRecognition i in. Opracowanie programu komputerowego wymagało bowiem napisania nie tylko funkcji wykonujących określone operacje na danych, ale także zdefiniowania typów zmiennych przechowujących te dane. Przedstawienie ich w tej części jest o tyle ważne, iż nie tylko ułatwi zrozumienie funkcji programu APS, ale jest także interesujące jako propozycja modelowania zjawisk fonetycznych w programie komputerowym napisanym przy użyciu tzw. obiektowego języka programowania. Nie będziemy jednak opisywać absolutnie wszystkich klas danych, jakie wykorzystaniu we wspomnianym programie, lecz jedynie najważniejsze, wspomniane wcześniej podczas opisywania metod programu APS. 

Zanim jednak przejdziemy do opisu najistotniejszych typów danych, należy kilka słów poświecić umówieniu budowy klasy w języku C#. Pierwszym elementem klasy są zazwyczaj właściwości (ang. properties), będące właściwymi kontenerami przechowującymi dane. Drugim składnikiem klas są tzw. konstruktory – funkcje o takiej samej nazwie co klasa, używane do wykonywania operacji podczas tworzenia obiektu tejże klasy (nadawania początkowych wartości, tworzenia list itp.). Ponieważ jest to element czysto techniczny, niezbędny do poprawnego działania programu, pominiemy go w dalszych częściach. Ostatnią częścią definicji klas są metody operujące na obiektach danego typu. Najważniejsze funkcje opisano w poprzeczniej części, dlatego również i ten element zostanie opuszczony – poprzestaniemy jedynie na wyliczeniu właściwości każdego typu. 

---------------------------------------------
Odczyt (klasa Reading) 

Podstawowy typ danych przechowujący informacje pobrane z programu Praat: 

	public class Reading

Każdy odczyt posiadał następujące właściwości: 

- RecordingNo – numer nagrania; 

- ExcerptNo – numer próbki (1 – początek, 2 – koniec); 

- LineNo – numer odczytu; 

- SpeakerType – rodzaj mówcy (informator/parlator lub eksplorator); 

- Segment, TranscriptionS, TranscriptionG, TranscriptionO – transkrypcje pomocnicze, odpowiednio: A, S, G, O; 

- Notes – notatki do każdego odczytu; 

- F1_Hz, F2_Hz, F3_Hz, F4_Hz – bezwzględne częstotliwości formantowe; 

- f_1_min, f_2_min, f_3_min, f_4_min – minimalne bezwzględne częstotliwości formantowe; 

- f_1_max, f_2_max, f_3_max, f_4_max – maksymalne bezwzględne częstotliwości formantowe; 

- rel_F1, rel_F2, rel_F3, rel_F4 – względne częstotliwości formantowe; 

- PhoneStringA, PhoneStringS, PhoneStringG, PhoneStringO – listy fonów poszczególnych transkrypcji pomocniczych (zbiorów cech artykulacyjnych ustalonych na podstawie symboli fonetycznych); 

- Speaker – informacje nt. mówcy; 

- OldPolishVowel – samogłoska staropolska, którą kontynuuje samogłoska w danym odczycie; 

- ContextType – lista kontekstów, w jakich znajduje się samogłoska w danym odczycie; 

- VowelModel – model samogłoski przypisany samogłosce w danym odczycie; 

- MorphCategory – „kategoria morfologiczna” (część mowy, położenie w strukturze gramatycznej wyrazu; tutaj założono następujące możliwe wartości: n – rzeczownik, v – czasownik, v_Vje – samogłoska w czasownikowym zakończeniu typu samogłoska + -je, np. rysuje, a – przymiotniki i przysłówki, a_naj – przedrostek naj- przymiotników i przysłówków, a_ejsz – przyrostek -ejsz- przymiotników i przysłówków, p – zaimki, inne – pozostałe formy). 

Metoda Contains sprawdza, czy dany fon (argument phone) znajduje się w danej transkrypcji (argument transcription). 

---------------------------------------------
Mówca (klasa Speaker)

Obiekty klasy Speaker zawierały dane na temat informatorów: 

	public class Speaker

Właściwości klasy Speaker były następujące: 

- RecordingNo – numer nagrania; 

- Surname, Name – nazwisko i imię badanego; 

- SpeakerNo – numer badanego; 

- Education – wykształcenie (tu 4 możliwe wartości: noInformation – brak informacji, primary – podstawowe, middle – gimnazjalne, vocational – zawodowe, secondary – średnie, higher – wyższe); 

- Age – wiek (tu 4 możliwe wartości: noInformation – brak informacji, young – młody wiek, middleAged – średni wiek, old – starszy wiek); 

- Place – miejscowość, z której pochodził badany; 

- Population – liczba ludności danej miejscowości; 

- PlaceType – typ miejsca zamieszkania (tu również 4 możliwe wartości: noInformation – brak informacji, village – wieś, town – małe miasto, city – duże miasto);

- County – powiat, w jakim znajduje się miejscowość, z jakiej pochodził badany; 

- DwellingTime – czas zamieszkania w danej miejscowości (tu 3 możliwe wartości: noInformation, wholeLife – całe życie, partOfLife – część życia); 

- ParentSOrigin – pochodzenie rodziców badanego (tu 4 możliwe wartości: noInformation, bothFromTheSamePlace – oboje z tej samej miejscowości, motherFromTheSamePlace – matka z tej samej miejscowości, bothFromDifferentPlaceOrOnlyFatherFromTheSame – oboje z różnej miejscowości lub tylko ojciec z tej samej miejscowości); 

- AdditionalInfo – dodatkowe informacje nt. badanego; 

- Explorer – imię i nazwisko osoby, która wykonała nagranie; 

- FileName – nazwa pliku z wypowiedzią badanego; 

- FileSize – rozmiar pliku z nagraniem; 

- Length – długość nagrania; 

- RecordYear – rok wykonania nagrania; 

- RecordYearCertain – informacja, czy rok wykonania jest informacją pewną (tu 2 wartości: true ‘prawda’ lub false ‘fałsz’). 

- Fon (klasa Phone) 

Obiekty klasy Phone i typów pochodnych (derywowanych od klasy Phone) stosowane były do modelowania fonów (głosek, segmentów) podanych w transkrypcjach pomocniczych. Jest więc bardzo istotna grupa typów, gdyż od ich budowy zależy poprawność przetwarzania danych na temat wymowy (rozpoznawanie kontekstu, ustalanie różnic fonetycznych itp.): 

	public class Phone

	public class Vowel : Phone

	public class Consonant : Phone

	public class Juncture : Phone

	public class Pause : Phone

	public class UnknownPhone : Phone

Bazowa klasa Phone posiada następujące właściwości: 

- Reading – odczyt, z którego pochodzi dany fon; 

- PhoneNo – numer fonu; 

- SpearekType – typ mówcy (możliwe wartości: Parlator, Informator, Eksplorator); 

- Speaker – informacje dotyczące mówcy; 

- Symbol – symbol fonetyczny (dokładnie zbiór symboli w 4 różnych systemach tranksrypcji: międzynarodowym, slawistycznym, X-Sampa i uproszczonym – quasi-ortograficznym); 

- Phonation – typ fonacji (możliwe wartości: breathy – zaszumiona, voiceless – bezdźwięczna, voiced – dźwięczna, creaky – zgrzytliwa); 

- Nasality – nosowość (wartości: oral – ustny, nasal – nosowy);

- Length – długość (wartości: extraShort – przykrótkość, @short – krótkość, @long – długość, extraLong – podwójna długość); 

- Roundness – zaokrąglenie (wartości: unrounded - niezaokrąglona, openRounded – otwarte zaokrąglenie, rounded – zaokrąglenie (bez uwzględnienia typu), closeRounded – przymknięte zaokrąglenie); 

- MannerOfArticulation – sposób artykulacji (wartości: stop – zwarta, releaseVoiced – wybuch dźwięczny (plozja dźwięczna), releaseVoiceless (wybuch bezdźwięczny (plozja bezdźwięczna), releaseVowel – plozja samogłoskowa (przejście spółgłoski w samogłoskę w fazie zestępu), releaseFricativeVoiced – plozja szczelinowa dźwięczna, releaseFricativeVoiceless – plozja szczelinowa bezdźwięczna, affricate – afrykata, fricative – spółgłoska szczelinowa (trąca), fricativeTrill – wibrant szczelinowy (spółgłoska szczelinowo¬ drżąca), flap (spółgłoska uderzeniowa), trill – spółgłoska drżąca,  lateral – spółgłoska boczna, semivowel – półsamogłoska, vowel – samogłoska); 

- Retroflex – retrofleksja (wartości: rhotic – z retrofleksją, nonRhotic – bez retrofleksji); 

- DiacriticImpact – liczba symboli fonetycznych modyfikowanych przez diakryt, któremu odpowiada fon posiadający tę właściwość (możliwe wartości to liczby całkowite dodatnie i ujemne, np. -1 wskazuje na modyfikowanie poprzedniego symbolu, 1 – kolejnego symbolu, 0 – fon posiadający tę właściwość odpowiada symbolowi literowemu). 

Na bazie klasy Phone utworzono klasę Vowel stosowaną w odniesieniu do symboli samogłosek w transkrypcjach pomocniczych. Oprócz właściwości klasy Phone, typ Vowel posiadał następujące dodatkowe właściwości: 

- Frequency – zestaw bezwzględnych częstotliwości formantowych zawarty w obiekcie typu Frequency (ten typ zawierał 4 właściwości odpowiadające poszczególnym formantom); 

- AvgFrequency – zestaw względnych częstotliwości formantowych, również typu Frequency (zob. wyżej); 

- Frontness – stopień uprzednienia samogłoski (możliwe wartości: front – przedniość, nearFront – przedniość cofnięta, centralFronted – środkowość uprzedniona, central – środkowość, centralBacked – środkowość cofnięta, nearBack – tylność uprzedniona, back – tylność); 

- Height – wysokość samogłoski (możliwe wartości: close – przymkniętość, nearClose – przymkniętość obniżona, closeMid – średniość podwyższona, mid – średniość, openMid – średniość obniżona, nearOpen – otwartość podwyższona, open – otwartość); 

- Stress – obecność akcentu (możliwe wartości: unstressed – nieakcentowana, stressed – akcentowana); 

Cechy artykulacyjne spółgłosek były kodowane w typie Consonant o następujących właściwościach dodatkowych: 

- PlaceOfArticulation – miejsce artykulacji (możliwe wartości: bilabial – dwuwargowy, labiodental – wargowo¬ zębowy, dental – zębowy, alveolar – dziąsłowy, postalveolar – zadziąsłowy, alveopalatal – dziąsłowo-palatalny, retroflexive – retrofleksyjny, palatal – palatalny, velar – welarny, uvular – języczkowy, faryngeal – gardłowy, epiglottal – nagłośniowy, glottal – krtaniowy); 

- Palatalization – obecność palatalizacji (możliwe wartości: unpalatalized – niepalatalizowany, palatalized – palatalizowany). 

Granice między wyrazami zamieniano na obiekty typu Juncture; nie posiadał on osobnych właściwości. Podobnie pozbawiony specyficznych właściwości był typ Pause odpowiadający symbolom pauz w transkrypcjach pomocniczych. Nierozpoznanym symbolom, jeśli tylko tworzyły całość (wewnątrz tej grupy nie znajdował się symbol, któremu można było przypisać obiekt typu Phone, Vowel, Consonant, Pause lub Juncture), przypisywano pojedyncze obiekty typu UnknownPhone (‘nierozpoznany fon’). W tym ostatnim przechowywano wejściowe symbole fonetyczne (będące podstawą przypisywania obiektu typu Phone) we właściwości PreviouslyRecognizedPhone. 

---------------------------------------------
Modele samogłosek (klasa VowelModel)

Dane dotyczące modeli samogłoskowych (względne częstotliwości formantowe) przenoszone były z pliku zewnętrznego do listy obiektów typu VowelModel: 

	public class VowelModel

Zestaw właściwości tej klasy ograniczony był do kodu samogłoski (właściwość Code), symbolu (Symbol) oraz częstotliwości formantowych (f1, f2, f3, f4). 

---------------------------------------------
Warunek rozpoznania (klasa Condition) 

Warunki, jakie miał spełniać odczyt (a dokładniej zawarty w nim fon samogłoskowy), zawarte było w obiekcie klasy Condition: 

	public class Condition

W zmiennej typu Conditon można było zawrzeć informacje dotyczące: 

- samogłoski staropolskiej, której kontynuantem była samogłoska w bieżącym odczycie (właściwość OldPolishVowels, przyjmująca wartości: allVowels – wszystkie samogłoski, i, y, e, e_long – długie e, a, a_long – długie a, o, o_long – długie o, u, ę, ą); 

- numeru próbki (czy odczyt pochodził z początku, czy z końca nagrania – zmienna ExcerptNo; możliwe wartości: bothExcerpts – oba fragmenty, beginning – początek, end – koniec); 

- wieku badanego (Age; wartości jak w typie Speaker); 

- wykształcenia badanego (Education; zob. typ Speaker); 

- miejsca zamieszkania badanego (PlaceTypel; zob. typ Speaker);

- czasu zamieszkania badanego w danej miejscowości (Dwellingtime; zob. typ Speaker);

- pochodzenia rodziców (ParentOrigin; zob. typ Speaker);
„kategorii morfologicznej” (MorphCategory; zob. typ Speaker). 

---------------------------------------------
Rozpoznanie samogłoski (klasa VowelRecognition) i kod modelu samogłoski (klasa VowelCode) 

Jak powiedziano wyżej (w części dotyczącej metod programu APS przypisywania modeli samogłoskowych), rozpoznanie samogłoski polegało na przypisaniu jej modelu samogłoski. W rzeczywistości tworzony był wówczas obiekt klasy VowelRecognition zawierający dodatkowe informacje oprócz modelu samogłoski:

	public class VowelRecognition

Oto właściwości typu VowelRecognition: 

- Counter – licznik samogłosek kontynuujących określoną samogłoskę staropolską (liczba rozpoznanych samogłosek); 

- VowelCode – kod modelu (osobny typ VowelCode, zob. niżej); 

- Examples – lista adresów (nr nagrania, nr próbki, nr odczytu) zawierających przykłady (wystąpienia kontynuantów danej samogłoski staropolskiej); 

- OldPolishVowel – samogłoska staropolska kontynuowana przez samogłoski, którym przypisano model samogłoskowy; 

- ConditionalMedian – lista warunkowych median względnych częstotliwości formantowych (zawartych w osobnym typie Frequency); 

- IpaSymbol – symbol fonetyczny alfabetu międzynarodowego. 

Definicja kodu samogłoski była bardzo prosta: 

	public class VowelCode
	{
		public int Height { get; set; }
		public int Frontness { get; set; }
		public int Roundness { get; set; }
	}

– są to całkowitoliczbowe wartości podpisane Height (wysokość), Frontness (przedniość) i Roundness (zaokrąglenie). 

---------------------------------------------
Kontekst samogłoskowy (typ wyliczeniowy ContextType) 

Konteksty, w jakich mogły się pojawiać kontynuanty staropolskich samogłosek, nie wymagał tworzenia nowej klasy wraz z właściwościami – wystarczający był prosty typ wyliczeniowy zawierający jedynie skrótowe oznaczenia każdego kontekstu: 

	public enum ContextType

Przewidziano następujące typy kontekstu: 

- unspecified – nieokreślony; 

- V_neutral – neutralny (nieasymilujący);

- Ṽ_ – w wygłosie (kontynuant samogłoski nosowej); 

- Ṽ_S – przed spółgłoską trącą (dawne nosówki); 

- Ṽ_T – przed spółgloską zwartą (dawne nosówki); 

- V_ł – przed spółgloską ł (dawne samogłoski ustne); 

- V_l – przed l (jw.); 

- V_rz – przed dawną spółgłoską r’ (obecnie š, ž zapisywane dwuznakiem <rz>; dawne samogłoski ustne); 

- V_r – przed r (dawne samogłoski ustnej); 

- V_j – przed j (jw.); 

- cz_V – spógłoska ustna po spółgłosce stwardniałej (obecnym č, ǯ, š, ž, zapisywanym <cz dż sz ż>); 

- rz_V – samogłoska ustna po dawnym r’ (obecnie š lub ž zapisywane dwuznakiem <rz>); 

- ć_V_N – samogłoska ustna po spółgłosce miękkiej, a przed nosową; 

- V_N – samogłoska ustna przed spółgłoską nosową. 

---------------------------------------------
PLIK Z GŁÓWNYM KODEM PROGRAMU APS 

Cały kod źródłowy programu APS nie znajduje się w jednym pliku, ale jest podzielony na kilkadziesiąt niewielkich plików tekstowych posegregowanych w określone katalogi. Takie rozwiązanie znacznie ułatwiło wprowadzanie zmian i poprawek, a także rozszerzanie funkcjonalności programu. Jednakże jeden z tych plików zawiera główną metodę (zw. Main), w której znajdują się metody wykonywane w kolejności, w jakiej są zapisane. W tej metodzie zapisywano wywołania metod przetwarzających dane i wyświetlających uzyskane wyniki. W tej części przedstawimy fragment kodu zawartego we wspomnianej metodzie – ułatwi to zrozumienie tekstu wyświetlanego w oknie programu APS podczas jego działania (zob. kolejną część), a także powiąże wszystkie przedstawione dotychczas informacje na temat budowy i sposobu działania omawianego programu. Pomocne w czytaniu metody Main będą komentarze (zaczynające się od podwójnych ukośników //) informujące o czynnościach wykonywanych przez program. 

	static void Main(string[] args)

---------------------------------------------
PLIKI Z DANYMI ŹRÓDŁOWYMI WYKORZYSTANE DO ANALIZ W PROGRAMIE APS

Wszystkie poniższe pliki są w formacie CSV (z ang. comma separates values), są to zatem wartości oddzielane określonymi znakami interpunkcyjnymi (zwykle są to przecinki, jednak w tym przypadku zastosowano średniki). Pierwsza linijka takiego pliku zawiera nazwy poszczególnych wartości zapisanych w kolejnych linijkach. 

Pliki utworzono w programie Microsoft Excel, eksportując dane do pliku we wspomnianym formacie. Nazwy kolumn arkusza kalkulacyjnego, w którym zebrano dane do eksportowania, znalazły się w pierwszej linijce wyjściowego pliku. 

Z uwagi na duże rozmiary wszystkich plików (zwłaszcza pliku Readings.csv – ponad 17 tysięcy linijek tekstu), poniżej zamieszczamy tylko nagłówki kolumn w każdym z nich. 


Plik Readings.csv 

  RecordingNo;ExcerptNo;LineNo;Person;Segment;TranscriptionS;TranscriptionG;TranscriptionO;Notes;[F1_Hz];[F2_Hz];[F3_Hz];


Plik Speakers.csv 

  Recording;Surname;Name;SpeakerNo;Education;Age;Place;Population;PlaceType;County;DwellingTime;ParentsOrigin;AdditionalInfo;Explorer;FileName;FileSize;Length;RecordYear


Plik Models.csv 

  Code;Symbol;f1;f2;f3;f4

