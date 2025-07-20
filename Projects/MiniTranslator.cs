namespace MiniTranslator;

class Program
{
    struct Translation
    {
        public readonly string Original;
        public readonly string Translated;

        public Translation(string original, string translated)
        {
            this.Original = original;
            this.Translated = translated;
        }
    }
    abstract class Translator
    {
        protected Translation[] Translations = null!;
        public abstract void Translate(string from);
    }

    sealed class French: Translator
    {
        public French()
        {
            Translations = new Translation[]
            {
                new("apple", "Pomme"),
                new("banana", "Banane"),
                new("orange", "Orange"),
                new("mango", "Mangue"),
                new("pineapple", "Ananas"),
                new("grape", "Raisin"),
                new("strawberry", "Fraise"),
                new("cherry", "Cerise"),
                new("watermelon", "Pastèque"),
                new("peach", "Pêche")
            };
        }
        
        public override void Translate(string from)
        {
            from = from.ToLower().TrimStart();
            
            foreach (Translation word in Translations)
            {
                if (from == word.Original)
                {
                    Console.WriteLine(word.Translated);
                    return;
                }
            }
            Console.WriteLine("Unknown");
        }
    }

    sealed class Russian: Translator
    {
        public Russian()
        {
            Translations = new Translation[]
            {
                new("apple", "Яблоко"),
                new("banana", "Банан"),
                new("orange", "Апельсин"),
                new("mango", "Манго"),
                new("pineapple", "Ананас"),
                new("grape", "Виноград"),
                new("strawberry", "Клубника"),
                new("cherry", "Вишня"),
                new("watermelon", "Арбуз"),
                new("peach", "Персик")
            };
        }
        
        public override void Translate(string from)
        {
            from = from.ToLower().TrimStart();
            
            foreach (Translation word in Translations)
            {
                if (from == word.Original)
                {
                    Console.WriteLine(word.Translated);
                    return;
                }
            }
            Console.WriteLine("Unknown");
        }
    }

    sealed class Spanish: Translator
    {
        public Spanish()
        {
            Translations = new Translation[]
            {
                new("apple", "Manzana"),
                new("banana", "Banana"),
                new("orange", "Naranja"),
                new("mango", "Mango"),
                new("pineapple", "Piña"),
                new("grape", "Uva"),
                new("strawberry", "Fresa"),
                new("cherry", "Cereza"),
                new("watermelon", "Sandía"),
                new("peach", "Durazno")
            };
        }
        
        public override void Translate(string from)
        {
            from = from.ToLower().TrimStart();
            
            foreach (Translation word in Translations)
            {
                if (from == word.Original)
                {
                    Console.WriteLine(word.Translated);
                    return;
                }
            }
            Console.WriteLine("Unknown");
        }
    }
    
    static void Main()
    {
        Translator[] words = new Translator[3];
        words[0] = new Spanish();
        words[1] = new French();
        words[2] = new Russian();

        string? word;
        do
        {
            Console.Write("Enter the word to translate to Spanish, French, Russian: ");
            word = Console.ReadLine();
        } while (string.IsNullOrEmpty(word));
        
        foreach(Translator t in words){
            t.Translate(word);
        }
        
        
    }
}
