using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using CSharp_Khodakivska_01.Annotations;
using CSharp_Khodakivska_01.Models;
using CSharp_Khodakivska_01.Tools;

namespace CSharp_Khodakivska_01.ViewModels
{
    internal class BirthdayViewModel: INotifyPropertyChanged
    {
        #region Fields

        private readonly User _user;
        private RelayCommand<object> _analyzeDateCommand;
        #endregion

        #region Properties

        public DateTime Date
        {
            get => _user.BirthDate;
            set
            {
                _user.BirthDate = value;
                OnPropertyChanged();
            }
        }
        public string Age
        {
            get => $"Your age: {_user.Age} ";
            set
            {
                _user.Age = value;
                OnPropertyChanged();
            }
        }
        public string WesternZodiac
        {
            get => $"Western Zodiac sign: {_user.WesternZodiac}";
            set
            {
                _user.WesternZodiac = value;
                OnPropertyChanged();
            }
        }
        public string ChineseZodiac
        {
            get => $"Chinese Zodiac sign: {_user.ChineseZodiac}";
            set
            {
                _user.ChineseZodiac = value;
                OnPropertyChanged();
            }
        }

        public string ZodiacPersonality
        {
            get => $"Your personality: {_user.ZodiacPersonality}";
            set
            {
                _user.ZodiacPersonality = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand<object> AnalyzeDateCommand
        {
            get
            {
                return _analyzeDateCommand ??= new RelayCommand<object>(AnalyzeBirthDate);
            }
        }

        #endregion

        internal BirthdayViewModel()
        {
            _user = new User();
            Date = DateTime.Today;
        }
        private async void AnalyzeBirthDate(object o)
        {
           await Task.Run(() =>
            {
                try
                {
                    Age=CountAge();
                    ChineseZodiac=FindChineseZodiac();
                    WesternZodiac=FindWesternZodiac();
                    ZodiacPersonality=FindZodiacPersonality();
                    CheckIfBirthday();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            });
        }
        private string CountAge()
        {
           DateTime today = DateTime.Today;
           int years = today.Year - Date.Year;
           if ((today.Month < Date.Month) ||
               (today.Month == Date.Month && today.Day < Date.Day)) years--;
           if (years < 0) throw new ArgumentException("Sorry, you should be born to use my app");
           if (years > 135) throw new ArgumentException("Sorry, you're too old to use my app");
           return years.ToString();
        }
        private string FindChineseZodiac()
        {
            return (Date.Year % 12) switch
            {
                0 => "Monkey",
                1 => "Rooster",
                2 => "Dog",
                3 => "Pig",
                4 => "Rat",
                5 => "Ox",
                6 => "Tiger",
                7 => "Rabbit",
                8 => "Dragon",
                9 => "Snake",
                10 => "Horse",
                _ => "IDK"
            };
        }

        private string FindZodiacPersonality()
        {
            int day = Date.Day;
            string aries = "The first sign of the zodiac, Aries loves to be number one. Naturally, this dynamic fire sign is no stranger to competition. Bold and ambitious, Aries dives headfirst into even the most challenging situations—and they'll make sure they always come out on top!";
            string taurus = "What sign is more likely to take a six-hour bath, followed by a luxurious Swedish massage and decadent dessert spread? Why Taurus, of course! Taurus is an earth sign represented by the bull. Like their celestial spirit animal, Taureans enjoy relaxing in serene, bucolic environments surrounded by soft sounds, soothing aromas, and succulent flavors.";
            string gemini = "Have you ever been so busy that you wished you could clone yourself just to get everything done? That's the Gemini experience in a nutshell. Spontaneous, playful, and adorably erratic, Gemini is driven by its insatiable curiosity. Appropriately symbolized by the celestial twins, this air sign was interested in so many pursuits that it had to double itself. You know, NBD! ";
            string cancer = "Represented by the crab, Cancer seamlessly weaves between the sea and shore representing Cancer’s ability to exist in both emotional and material realms. Cancers are highly intuitive and their psychic abilities manifest in tangible spaces. But—just like the hard-shelled crustaceans—this water sign is willing to do whatever it takes to protect itself emotionally. In order to get to know this sign, you're going to need to establish trust!";
            string leo = "Roll out the red carpet because Leo has arrived. Passionate, loyal, and infamously dramatic, Leo is represented by the lion and these spirited fire signs are the kings and queens of the celestial jungle. They're delighted to embrace their royal status: Vivacious, theatrical, and fiery, Leos love to bask in the spotlight and celebrate… well, themselves.";
            string virgo = "You know the expression, \"if you want something done, give it to a busy person?\" Well, that definitely is the Virgo anthem. Virgos are logical, practical, and systematic in their approach to life. Virgo is an earth sign historically represented by the goddess of wheat and agriculture, an association that speaks to Virgo's deep-rooted presence in the material world. This earth sign is a perfectionist at heart and isn’t afraid to improve skills through diligent and consistent practice.";
            string libra = "Balance, harmony, and justice define Libra energy. As a cardinal air sign, Libra is represented by the scales (interestingly, the only inanimate object of the zodiac), an association that reflects Libra's fixation on establishing equilibrium. Libra is obsessed with symmetry and strives to create equilibrium in all areas of life — especially when it comes to matters of the heart.";
            string scorpio = "Elusive and mysterious, Scorpio is one of the most misunderstood signs of the zodiac. Scorpio is a water sign that uses emotional energy as fuel, cultivating powerful wisdom through both the physical and unseen realms. In fact, Scorpio derives its extraordinary courage from its psychic abilities, which is what makes this sign one of the most complicated, dynamic signs of the zodiac.";
            string sagittarius = "Oh, the places Sagittarius goes! But… actually. This fire sign knows no bounds. Represented by the archer, Sagittarians are always on a quest for knowledge. The last fire sign of the zodiac, Sagittarius launches its many pursuits like blazing arrows, chasing after geographical, intellectual, and spiritual adventures.";
            string capricorn = "What is the most valuable resource? For Capricorn, the answer is clear: Time. Capricorn is climbing the mountain straight to the top and knows that patience, perseverance, and dedication is the only way to scale. The last earth sign of the zodiac, Capricorn, is represented by the sea-goat, a mythological creature with the body of a goat and the tail of a fish. Accordingly, Capricorns are skilled at navigating both the material and emotional realms. ";
            string aquarius = "Despite the \"aqua\" in its name, Aquarius is actually the last air sign of the zodiac. Innovative, progressive, and shamelessly revolutionary, Aquarius is represented by the water bearer, the mystical healer who bestows water, or life, upon the land. Accordingly, Aquarius is the most humanitarian astrological sign. At the end of the day, Aquarius is dedicated to making the world a better place.";
            string pisces = "If you looked up the word \"psychic\" in the dictionary, there would definitely be a picture of Pisces next to it. Pisces is the most intuitive, sensitive, and empathetic sign of the entire zodiac — and that’s because it’s the last of the last. As the final sign, Pisces has absorbed every lesson — the joys and the pain, the hopes and the fears — learned by all of the other signs. It's symbolized by two fish swimming in opposite directions, representing the constant division of Pisces' attention between fantasy and reality.";
            return Date.Month switch
            {
                1 => (day < 20 ? capricorn : aquarius),
                2 => (day < 19 ? aquarius : pisces),
                3 => (day < 21 ? pisces : aries),
                4 => (day < 20 ? aries : taurus),
                5 => (day < 21 ? taurus : gemini),
                6 => (day < 21 ? gemini : cancer),
                7 => (day < 23 ? cancer : leo),
                8 => (day < 23 ? leo : virgo),
                9 => (day < 23 ? virgo : libra),
                10 => (day < 23 ? libra : scorpio),
                11 => (day < 22 ? scorpio : sagittarius),
                _ => (day < 22 ? sagittarius : capricorn)
            };
        }
        private string FindWesternZodiac()
        {
            int day = Date.Day;
            return Date.Month switch
            {
                1 => (day < 20 ? "Capricorn" : "Aquarius"),
                2 => (day < 19 ? "Aquarius" : "Pisces"),
                3 => (day < 21 ? "Pisces" : "Aries"),
                4 => (day < 20 ? "Aries" : "Taurus"),
                5 => (day < 21 ? "Taurus" : "Gemini"),
                6 => (day < 21 ? "Gemini" : "Cancer"),
                7 => (day < 23 ? "Cancer" : "Leo"),
                8 => (day < 23 ? "Leo" : "Virgo"),
                9 => (day < 23 ? "Virgo" : "Libra"),
                10 => (day < 23 ? "Libra" : "Scorpio"),
                11 => (day < 22 ? "Scorpio" : "Sagittarius"),
                _ => (day < 22 ? "Sagittarius" : "Capricorn")
            };
        }
        private void CheckIfBirthday()
        {
            if (DateTime.Today.Month == Date.Month && DateTime.Today.Day == Date.Day) MessageBox.Show("Wishing your birthday\nIs a super - special one,\nFilled with surprises,\nHappiness and fun!");
        }

        #region INotifyPropertyImplementation
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
